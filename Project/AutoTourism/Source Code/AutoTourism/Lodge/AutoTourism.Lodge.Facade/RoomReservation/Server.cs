using System;
using System.Collections.Generic;

using BinAff.Core;

using LodgeCrys = Crystal.Lodge.Component;
using ArtfCrys = Crystal.Navigator.Component.Artifact;
using CustCrys = Crystal.Customer.Component;
using RoomRsvCrys = Crystal.Lodge.Component.Room.Reservation;
using RoomRsvArtf = Crystal.Lodge.Component.Room.Reservation.Navigator.Artifact;

using LodgeConfigFac = AutoTourism.Lodge.Configuration.Facade;
using RuleFac = AutoTourism.Configuration.Rule.Facade;
using CustAuto = AutoTourism.Component.Customer;

namespace AutoTourism.Lodge.Facade.RoomReservation
{

    public class Server : Vanilla.Form.Facade.Document.Server
    {        

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            FormDto formDto = this.FormDto as FormDto;
            formDto.AllRoomList = this.ReadAllRoom().Value;
            formDto.configurationRuleDto = this.ReadConfigurationRule().Value;
            formDto.CategoryList = new LodgeConfigFac.Room.Server(null).ReadAllCategory().Value;
            formDto.TypeList = new LodgeConfigFac.Room.Server(null).ReadAllType().Value;

            if (formDto.Dto != null && formDto.Dto.Id > 0)
            {
                (formDto.Dto as Facade.RoomReservation.Dto).Customer = this.GetCustomerDtoForReservation(formDto.Dto.Id);
            }
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            LodgeCrys.Room.Reservation.Data reservation = data as LodgeCrys.Room.Reservation.Data;
            return new Dto
            {
                Id = data.Id,
                NoOfDays = reservation.NoOfDays,
                //NoOfPersons = reservation.NoOfPersons,
                NoOfRooms = reservation.NoOfRooms,
                BookingFrom = reservation.ActivityDate,
                //Advance = reservation.Advance,                
                BookingStatusId = reservation.Status == null ? 0 : reservation.Status.Id,
                RoomList = reservation.ProductList == null ? null : GetRoomDtoList(reservation.ProductList),
                RoomCategory = reservation.RoomCategory == null ? null : new Table { Id = reservation.RoomCategory.Id },
                RoomType = reservation.RoomType == null ? null : new Table { Id = reservation.RoomType.Id },
                //IsAC = reservation.IsAC,
                ACPreference = reservation.ACPreference,
                BookingDate = reservation.Date,
                isCheckedIn = reservation.IsCheckedIn,
                NoOfMale = reservation.NoOfMale,
                NoOfFemale = reservation.NoOfFemale,
                NoOfChild = reservation.NoOfChild,
                NoOfInfant = reservation.NoOfInfant,
                Remark = reservation.Remark,
                ReservationNo = reservation.ReservationNo
            };
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto reservation = dto as Dto;
            return new LodgeCrys.Room.Reservation.Data
            {
                Id = dto.Id,
                NoOfDays = reservation.NoOfDays,
                //NoOfPersons = reservation.NoOfPersons,
                NoOfRooms = reservation.NoOfRooms,
                //Advance = reservation.Advance,
                ActivityDate = reservation.BookingFrom,
                Date = DateTime.Now,
                ProductList = reservation.RoomList == null ? null : GetRoomDataList(reservation.RoomList),
                Status = new Crystal.Customer.Component.Action.Status.Data
                {
                    //Id = System.Convert.ToInt64(RoomStatus.Open)
                    Id = reservation.BookingStatusId
                },
                Description = String.Empty,//description will be added later if required
                RoomCategory = reservation.RoomCategory == null ? null : new LodgeCrys.Room.Category.Data { Id = reservation.RoomCategory.Id },
                RoomType = reservation.RoomType == null ? null : new LodgeCrys.Room.Type.Data { Id = reservation.RoomType.Id },
                ACPreference = reservation.ACPreference,
                NoOfMale = reservation.NoOfMale,
                NoOfFemale = reservation.NoOfFemale,
                NoOfChild = reservation.NoOfChild,
                NoOfInfant = reservation.NoOfInfant,
                Remark = reservation.Remark
            };
        }

        public override void Add()
        {
            this.Save();
        }

        public override void Change()
        {
            this.Save();
        }

        protected override ArtfCrys.Server GetArtifactServer(BinAff.Core.Data artifactData)
        {
            return new RoomRsvArtf.Server(artifactData as RoomRsvArtf.Data);
        }

        protected override ICrud GetComponentServer()
        {
            return new RoomRsvCrys.Server(this.Convert((this.FormDto as FormDto).Dto) as RoomRsvCrys.Data);
        }

        protected override String GetComponentDataType()
        {
            return "Crystal.Lodge.Component.Room.Reservation.Navigator.Artifact.Data, Crystal.Lodge.Component";
        }

        protected override ArtfCrys.Data GetArtifactData(Int64 artifactId)
        {
            return new RoomRsvArtf.Data { Id = artifactId };
        }

        protected override BinAff.Core.Observer.IRegistrar GetRegisterer()
        {
            return new Crystal.Lodge.Observer.RoomReservation();
        }

        protected override String GetAttachmentComponentCode()
        {
            return "PAMT";
        }

        public override Vanilla.Utility.Facade.Module.Definition.Dto GetAncestorComponentCode()
        {
            return (BinAff.Facade.Cache.Server.Current.Cache["Main"] as Vanilla.Utility.Facade.Cache.Dto).ComponentDefinitionList.FindLast((
                    (p) => { return p.Code == new AutoTourism.Customer.Facade.Server(null).GetComponentCode(); }));
        }

        #region Public

        public Int32 GetTotalNoRooms()
        {
            Int32 totalRooms = 0;
            Boolean blnAdd = true;

            FormDto formDto = this.FormDto as FormDto;
            Dto dto = formDto.Dto as Dto;

            List<LodgeConfigFac.Room.Dto> allRoomList = formDto.FilteredRoomList;

            if (allRoomList != null && allRoomList.Count > 0)
            {
                foreach (LodgeConfigFac.Room.Dto roomDto in allRoomList)
                {
                    blnAdd = true;

                    if (dto.RoomCategory != null && dto.RoomCategory.Id > 0 && dto.RoomCategory.Id != roomDto.Category.Id)
                        blnAdd = false;

                    if (blnAdd && dto.RoomType != null && dto.RoomType.Id > 0 && dto.RoomType.Id != roomDto.Type.Id)
                        blnAdd = false;

                    if (blnAdd && dto.ACPreference > 0)
                    {
                        Boolean isAC = dto.ACPreference == 1 ? true : false;
                        if (isAC != roomDto.IsAirconditioned)
                            blnAdd = false;
                    }

                    if (blnAdd)
                        totalRooms += 1;
                }
            }

            return totalRooms;
        }

        //Returning the Reservation FormDto , since this function will be called from CheckIn
        public FormDto PopulateRoomWithCriteria()
        {
            FormDto formDto = this.FormDto as FormDto;
            Dto dto = formDto.Dto as Dto;

            if (formDto.FilteredRoomList == null)
                return null;

            formDto.RoomList = new List<LodgeConfigFac.Room.Dto>();

            if (dto.NoOfDays > 0)
            {
                Boolean blnAdd = true;
                List<LodgeConfigFac.Room.Dto> selRoomList = new List<LodgeConfigFac.Room.Dto>();

                foreach (LodgeConfigFac.Room.Dto roomDto in formDto.FilteredRoomList)
                {
                    blnAdd = true;

                    if (dto.RoomCategory != null && dto.RoomCategory.Id > 0 && dto.RoomCategory.Id != roomDto.Category.Id)
                        blnAdd = false;

                    if (blnAdd && dto.RoomType != null && dto.RoomType.Id > 0 && dto.RoomType.Id != roomDto.Type.Id)
                        blnAdd = false;

                    if (blnAdd && dto.ACPreference > 0)
                    {
                        Boolean isAC = dto.ACPreference == 1 ? true : false;
                        if (isAC != roomDto.IsAirconditioned)
                            blnAdd = false;
                    }

                    if (blnAdd)
                        formDto.RoomList.Add(roomDto);
                }
            }

            if (formDto.SelectedRoomList != null && formDto.SelectedRoomList.Count > 0)
                this.ResetRoomList();

            //populate no of rooms booked
            List<LodgeConfigFac.Room.Dto> AvailableRoomList = this.AvailableRoomList();
            formDto.AvailableRoomCount = AvailableRoomList == null ? 0 : AvailableRoomList.Count;

            return formDto;
        }

        //Returning the Reservation FormDto , since this function will be called from CheckIn
        public FormDto AddRoomToAllRoomList(LodgeConfigFac.Room.Dto room)
        {
            FormDto formDto = this.FormDto as FormDto;
            formDto.SelectedRoomList.Remove(room);

            if (formDto.RoomList == null)
                formDto.RoomList = new List<LodgeConfigFac.Room.Dto>();

            formDto.RoomList.Add(room);

            if (formDto.RoomList != null && formDto.RoomList.Count > 1)
                formDto.RoomList = this.SortRoomListByRoomNo(formDto.RoomList);

            return formDto;
        }

        public void RemoveRoomFromAllRoomList(LodgeConfigFac.Room.Dto room)
        {
            FormDto formDto = this.FormDto as FormDto;
            formDto.RoomList.Remove(room);

            if (formDto.SelectedRoomList == null)
                formDto.SelectedRoomList = new List<LodgeConfigFac.Room.Dto>();

            formDto.SelectedRoomList.Add(room);

            if (formDto.SelectedRoomList != null && formDto.SelectedRoomList.Count > 1)
                formDto.SelectedRoomList = this.SortRoomListByRoomNo(formDto.SelectedRoomList);
        }

        //This function will also be called from CheckIn
        public List<LodgeConfigFac.Room.Dto> SortRoomListByRoomNo(List<LodgeConfigFac.Room.Dto> roomList)
        {
            String[] arrRoomNo = new String[roomList.Count];
            List<LodgeConfigFac.Room.Dto> sortedRoomList = new List<LodgeConfigFac.Room.Dto>();

            for (int i = 0; i < roomList.Count; i++)
                arrRoomNo[i] = roomList[i].Number;

            Array.Sort(arrRoomNo);

            for (int i = 0; i < arrRoomNo.Length; i++)
            {
                foreach (LodgeConfigFac.Room.Dto room in roomList)
                {
                    if (room.Number == arrRoomNo[i])
                    {
                        if (!IsRoomExist(room, sortedRoomList))
                        {
                            sortedRoomList.Add(room);
                            break;
                        }
                    }
                }
            }

            return sortedRoomList;
        }

        //Returning the Reservation FormDto , since this function will be called from CheckIn
        //Resetting FilteredRoomList , during DateChange And No of days change ;         
        public FormDto RemoveAllBookedRoom()
        {
            FormDto formDto = this.FormDto as FormDto;
            Dto dto = formDto.Dto as Dto;

            if (formDto.FilteredRoomList == null)
                formDto.FilteredRoomList = formDto.AllRoomList;

            CustCrys.Action.IAction reservation = new RoomRsvCrys.Server(null);
            ReturnObject<List<CustCrys.Action.Data>> ret = reservation.Search(new CustCrys.Action.Status.Data { Id = System.Convert.ToInt64(RoomStatus.Open) }, dto.BookingFrom, dto.BookingFrom.AddDays(dto.NoOfDays));

            List<LodgeConfigFac.Room.Dto> bookedRoomList = new List<LodgeConfigFac.Room.Dto>();

            if (ret.Value != null)
            {
                foreach (CustCrys.Action.Data reservationData in ret.Value)
                {
                    if (dto.Id != reservationData.Id)
                    {
                        if (reservationData.ProductList != null && reservationData.ProductList.Count > 0)
                        {
                            foreach (LodgeCrys.Room.Data roomData in reservationData.ProductList)
                            {
                                if (roomData.Id > 0)
                                    bookedRoomList.Add(new LodgeConfigFac.Room.Dto { Id = roomData.Id });
                            }
                        }
                    }
                }
            }

            //populate room list            
            if (bookedRoomList != null && bookedRoomList.Count > 0)
            {
                formDto.FilteredRoomList = new List<LodgeConfigFac.Room.Dto>();
                Boolean blnInclude = true;

                for (int i = 0; i < formDto.AllRoomList.Count; i++)
                {
                    blnInclude = true;

                    foreach (LodgeConfigFac.Room.Dto roomDto in bookedRoomList)
                    {
                        if (formDto.AllRoomList[i].Id == roomDto.Id)
                        {
                            blnInclude = false;
                            break;
                        }
                    }

                    if (blnInclude)
                        formDto.FilteredRoomList.Add(formDto.AllRoomList[i]);
                }
            }

            //populate no of rooms booked
            List<LodgeConfigFac.Room.Dto> AvailableRoomList = this.AvailableRoomList();
            formDto.AvailableRoomCount = AvailableRoomList == null ? 0 : AvailableRoomList.Count;

            return formDto;
        }

        public ReturnObject<Boolean> ChangeReservationStatus()
        {
            ReturnObject<Boolean> ret = new ReturnObject<bool>();
            Dto reservationDto = (this.FormDto as FormDto).Dto as Dto;

            if (this.componentServer == null) this.componentServer = this.GetComponentServer();

            LodgeCrys.Room.Reservation.Data reservationData = (this.componentServer as LodgeCrys.Room.Reservation.Server).Data as LodgeCrys.Room.Reservation.Data;
            reservationData.Status = new CustCrys.Action.Status.Data
            {
                Id = ((this.FormDto as FormDto).Dto as Dto).BookingStatusId
            };

            using (System.Transactions.TransactionScope T = new System.Transactions.TransactionScope())
            {
                ret = (this.componentServer as CustCrys.Action.IAction).UpdateStatus();
                if (ret.Value)
                {
                    ret = (this.componentServer as ArtfCrys.Observer.ISubject).NotifyObserverForUpdate();

                    if (ret.Value)
                    {
                        this.UpdateAuditInformation();
                        T.Complete();
                    }
                }

            }
            return ret;
        }

        public Customer.Facade.Dto GetCustomerDtoForReservation(Int64 reservationId)
        {
            CustAuto.ICustomer autoCustomer = new CustAuto.Server(null);
            return ConvertToCustomerDto(autoCustomer.GetCustomerForReservation(reservationId));
        }

        public Customer.Facade.Dto ConvertToCustomerDto(Crystal.Customer.Component.Data customerData)
        {
            if (customerData == null)
                return null;

            BinAff.Facade.Library.Dto dto = new AutoTourism.Customer.Facade.Server(null).Convert(customerData);
            return dto as Customer.Facade.Dto;
        }

        public List<CustCrys.ContactNumber.Data> ConvertToContactNumberData(List<Table> contactNumberList)
        {
            List<CustCrys.ContactNumber.Data> lstContactNumber = new List<CustCrys.ContactNumber.Data>();
            if (contactNumberList != null && contactNumberList.Count > 0)
            {
                foreach (Table table in contactNumberList)
                {
                    lstContactNumber.Add(new CustCrys.ContactNumber.Data
                    {
                        Id = table.Id,
                        ContactNumber = table.Name
                    });
                }
            }

            return lstContactNumber;
        }

        public List<Data> GetRoomDataList(List<LodgeConfigFac.Room.Dto> RoomList)
        {
            List<Data> RoomDataList = new List<Data>();
            foreach (LodgeConfigFac.Room.Dto dto in RoomList)
            {
                RoomDataList.Add(new LodgeCrys.Room.Data
                {
                    Id = dto.Id,
                    Number = dto.Number,
                });
            }
            return RoomDataList;
        }

        public List<LodgeConfigFac.Room.Dto> GetRoomDtoList(List<Data> RoomList)
        {
            List<LodgeConfigFac.Room.Dto> RoomDtoList = new List<LodgeConfigFac.Room.Dto>();
            foreach (LodgeCrys.Room.Data data in RoomList)
            {
                RoomDtoList.Add(new LodgeConfigFac.Room.Dto
                {
                    Id = data.Id,
                    Number = data.Number,
                    Name = data.Name
                });
            }
            return RoomDtoList;
        }

        public void SaveArtifactForReservation(Vanilla.Utility.Facade.Artifact.Dto artifactDto)
        {
            Vanilla.Utility.Facade.Module.Dto reservationModuleDto = new Vanilla.Utility.Facade.Module.Server(null).GetModule("LRSV", (this.FormDto as FormDto).ModuleFormDto.FormModuleList);
            String fileName = new Vanilla.Utility.Facade.Artifact.Server(null).GetArtifactName(reservationModuleDto.Artifact, Vanilla.Utility.Facade.Artifact.Type.Document, "Form");
            artifactDto.FileName = fileName;

            if (reservationModuleDto != null)
            {
                reservationModuleDto.Artifact.Children.Add(artifactDto);
            }

            (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact = new Vanilla.Utility.Facade.Artifact.FormDto
            {
                Dto = artifactDto
            };

            (this.FormDto as FormDto).ModuleFormDto.Dto = reservationModuleDto;
            Vanilla.Utility.Facade.Module.Server moduleFacade = new Vanilla.Utility.Facade.Module.Server((this.FormDto as FormDto).ModuleFormDto);
            moduleFacade.Add();
        }

        public List<LodgeConfigFac.Room.Dto> FilterRoomList(List<LodgeConfigFac.Room.Dto> roomList, Int64 categoryId, Int64 typeId, Int32 acPreference)
        {
            List<LodgeConfigFac.Room.Dto> lstRoom = new List<LodgeConfigFac.Room.Dto>();

            foreach (LodgeConfigFac.Room.Dto room in roomList)
            {
                if (this.ValidateRoomWithCategoryTypeAndACPreference(room, categoryId, typeId, acPreference))
                {
                    lstRoom.Add(room);
                }
            }

            return lstRoom;
        }

        public Int32 GetReservedRoomList(DateTime startDate, DateTime endDate, Int64 reservationId)
        {
            int retVal = 0;
            Crystal.Customer.Component.Action.IAction reservation = new Crystal.Lodge.Component.Room.Reservation.Server(null);
            ReturnObject<List<Crystal.Customer.Component.Action.Data>> ret = reservation.Search(new Crystal.Customer.Component.Action.Status.Data { Id = System.Convert.ToInt64(RoomStatus.Open) }, startDate, endDate);

            if (ret.Value != null && ret.Value.Count > 0)
            {
                List<Crystal.Customer.Component.Action.Data> actionList = this.RemoveDuplicateReservation(ret.Value);
                foreach (LodgeCrys.Room.Reservation.Data reservationData in actionList)
                {
                    if (reservationData.Id != reservationId)
                        retVal += reservationData.NoOfRooms;
                }
            }

            return retVal;
        }

        public Int32 GetReservedRoomList(DateTime startDate, DateTime endDate, Int64 reservationId, Int64 categoryId, Int64 typeId, Int32 acPreference)
        {
            int retVal = 0;
            Crystal.Customer.Component.Action.IAction reservation = new Crystal.Lodge.Component.Room.Reservation.Server(null);
            ReturnObject<List<Crystal.Customer.Component.Action.Data>> ret = reservation.Search(new Crystal.Customer.Component.Action.Status.Data { Id = System.Convert.ToInt64(RoomStatus.Open) }, startDate, endDate);

            if (ret.Value != null && ret.Value.Count > 0)
            {
                List<Crystal.Customer.Component.Action.Data> actionList = this.RemoveDuplicateReservation(ret.Value);
                foreach (LodgeCrys.Room.Reservation.Data reservationData in actionList)
                {
                    if (reservationData.Id != reservationId && ValidateRoomWithCategoryTypeAndACPreference(reservationData, categoryId, typeId, acPreference))
                        retVal += reservationData.NoOfRooms;
                }
            }

            return retVal;
        }

        public Dto CloneReservaion(Dto reservationDto)
        {
            return new Dto
                    {
                        Id = reservationDto.Id,
                        isCheckedIn = reservationDto.isCheckedIn,
                        ReservationNo = reservationDto.ReservationNo,
                        BookingFrom = reservationDto.BookingFrom,
                        NoOfDays = reservationDto.NoOfDays,
                        NoOfRooms = reservationDto.NoOfRooms,
                        BookingStatusId = reservationDto.BookingStatusId,
                        RoomCategory = reservationDto.RoomCategory == null ? null : new Table
                        {
                            Id = reservationDto.RoomCategory.Id,
                            Name = reservationDto.RoomCategory.Name
                        },
                        RoomType = reservationDto.RoomType == null ? null : new Table
                        {
                            Id = reservationDto.RoomType.Id,
                            Name = reservationDto.RoomType.Name
                        },
                        ACPreference = reservationDto.ACPreference,
                        NoOfMale = reservationDto.NoOfMale,
                        NoOfFemale = reservationDto.NoOfFemale,
                        NoOfChild = reservationDto.NoOfChild,
                        NoOfInfant = reservationDto.NoOfInfant,
                        Remark = reservationDto.Remark,
                        RoomList = reservationDto.RoomList == null ? null : this.CloneRoomList(reservationDto.RoomList),
                        Customer = reservationDto.Customer
                    };
        }

        #endregion

        #region Private

        private List<LodgeConfigFac.Room.Dto> RemoveRoomFromList(List<LodgeConfigFac.Room.Dto> roomList, LodgeConfigFac.Room.Dto room)
        {
            List<LodgeConfigFac.Room.Dto> filteredRoomList = new List<LodgeConfigFac.Room.Dto>();

            for (int i = 0; i < roomList.Count; i++)
            {
                if (room.Id != roomList[i].Id)
                    filteredRoomList.Add(roomList[i]);
            }

            return filteredRoomList;
        }

        private List<LodgeConfigFac.Room.Dto> AvailableRoomList()
        {
            FormDto formDto = this.FormDto as FormDto;
            Dto dto = formDto.Dto as Dto;

            CustCrys.Action.IAction objReservation = new RoomRsvCrys.Server(null);
            ReturnObject<List<CustCrys.Action.Data>> ret = objReservation.Search(new CustCrys.Action.Status.Data { Id = System.Convert.ToInt64(RoomStatus.Open) }, dto.BookingFrom, dto.BookingFrom.AddDays(dto.NoOfDays));
            List<CustCrys.Action.Data> allReservation = ret.Value as List<CustCrys.Action.Data>;
            List<LodgeConfigFac.Room.Dto> allRoomList = formDto.AllRoomList;

            List<LodgeConfigFac.Room.Dto> AvailableRoom = new List<LodgeConfigFac.Room.Dto>();
            List<LodgeConfigFac.Room.Dto> AllBookedRoom = new List<LodgeConfigFac.Room.Dto>();

            int counter = 0;
            List<CustCrys.Action.Data> threeFilter = new List<CustCrys.Action.Data>();
            List<CustCrys.Action.Data> twoFilter = new List<CustCrys.Action.Data>();
            List<CustCrys.Action.Data> oneFilter = new List<CustCrys.Action.Data>();
            List<CustCrys.Action.Data> noFilter = new List<CustCrys.Action.Data>();

            if (allReservation != null && allReservation.Count > 0)
            {
                foreach (CustCrys.Action.Data reservationData in allReservation)
                {
                    RoomRsvCrys.Data reservation = reservationData as RoomRsvCrys.Data;
                    counter = 0;
                    if (dto.Id != reservation.Id)
                    {
                        if (reservation.RoomCategory != null && reservation.RoomCategory.Id > 0)
                            counter++;
                        if (reservation.RoomType != null && reservation.RoomType.Id > 0)
                            counter++;
                        if (reservation.ACPreference > 0)
                            counter++;

                        if (counter == 0)
                            noFilter.Add(reservation);
                        else if (counter == 1)
                            oneFilter.Add(reservation);
                        else if (counter == 2)
                            twoFilter.Add(reservation);
                        else if (counter == 3)
                            threeFilter.Add(reservation);
                    }
                }
            }

            if (threeFilter != null && threeFilter.Count > 0)
                this.UpdateRoomFromReservation(allRoomList, threeFilter, AllBookedRoom);

            if (twoFilter != null && twoFilter.Count > 0)
                this.UpdateRoomFromReservation(allRoomList, twoFilter, AllBookedRoom);

            if (oneFilter != null && oneFilter.Count > 0)
                this.UpdateRoomFromReservation(allRoomList, oneFilter, AllBookedRoom);

            if (noFilter != null && noFilter.Count > 0)
                this.UpdateRoomFromReservation(allRoomList, noFilter, AllBookedRoom);

            //--- of no rooms are booked 
            if (AllBookedRoom == null || AllBookedRoom.Count == 0)
                AvailableRoom = allRoomList;
            else
                AvailableRoom = ReadAllAvailableRoom(allRoomList, AllBookedRoom);

            return AvailableRoom;
        }

        private void UpdateRoomFromReservation(List<LodgeConfigFac.Room.Dto> AllRoom, List<CustCrys.Action.Data> reservationFilter, List<LodgeConfigFac.Room.Dto> AllBookedRoom)
        {
            Int32 NoOfRoom = 0;
            Int64 CatId = 0;
            Int64 TypeId = 0;
            Int32 ACPreference = 0;

            foreach (CustCrys.Action.Data reservationData in reservationFilter)
            {
                RoomRsvCrys.Data reservation = reservationData as RoomRsvCrys.Data;
                CatId = reservation.RoomCategory == null ? 0 : reservation.RoomCategory.Id;
                TypeId = reservation.RoomType == null ? 0 : reservation.RoomType.Id;
                ACPreference = reservation.ACPreference;

                NoOfRoom = reservation.NoOfRooms;

                if (reservationData.ProductList != null && reservationData.ProductList.Count > 0)
                {
                    NoOfRoom = reservation.NoOfRooms - GetProductCount(reservationData.ProductList);
                    foreach (LodgeCrys.Room.Data roomData in reservationData.ProductList)
                    {
                        if (roomData.Id > 0)
                            AllBookedRoom.Add(new LodgeConfigFac.Room.Dto { Id = roomData.Id });
                    }
                }

                if (NoOfRoom > 0)
                {
                    for (int i = 0; i < NoOfRoom; i++)
                    {
                        foreach (LodgeConfigFac.Room.Dto room in AllRoom)
                        {
                            if (CatId > 0 && room.Category.Id != CatId)
                                continue;
                            if (TypeId > 0 && room.Type.Id != TypeId)
                                continue;
                            if (ACPreference > 0)
                            {
                                Boolean isAC = ACPreference == 1 ? true : false;
                                if (isAC != room.IsAirconditioned)
                                    continue;
                            }

                            if (IsRoomExist(room, AllBookedRoom))
                                continue;

                            AllBookedRoom.Add(new LodgeConfigFac.Room.Dto { Id = room.Id });
                            break;
                        }


                    }
                }
            }
        }

        private Boolean IsRoomExist(LodgeConfigFac.Room.Dto room, List<LodgeConfigFac.Room.Dto> roomList)
        {
            Boolean blnValue = false;
            if (roomList == null || roomList.Count == 0)
                blnValue = false;
            else
            {
                foreach (LodgeConfigFac.Room.Dto dto in roomList)
                {
                    if (room.Id == dto.Id)
                    {
                        blnValue = true;
                        break;
                    }
                }
            }

            return blnValue;
        }

        private List<LodgeConfigFac.Room.Dto> ReadAllAvailableRoom(List<LodgeConfigFac.Room.Dto> allRoomList, List<LodgeConfigFac.Room.Dto> AllBookedRoom)
        {
            FormDto formDto = this.FormDto as FormDto;
            Dto dto = formDto.Dto as Dto;
            Boolean blnAdd = true;
            List<LodgeConfigFac.Room.Dto> AvailableRoomList = new List<LodgeConfigFac.Room.Dto>();
            List<LodgeConfigFac.Room.Dto> UnOccupiedRoomList = new List<LodgeConfigFac.Room.Dto>();
            if (allRoomList != null && allRoomList.Count > 0 && allRoomList.Count > AllBookedRoom.Count)
            {
                foreach (LodgeConfigFac.Room.Dto room in allRoomList)
                {
                    if (!IsRoomExist(room, AllBookedRoom))
                        UnOccupiedRoomList.Add(room);
                }
            }

            if (UnOccupiedRoomList != null && UnOccupiedRoomList.Count > 0)
            {
                foreach (LodgeConfigFac.Room.Dto room in UnOccupiedRoomList)
                {
                    blnAdd = true;

                    if (dto.RoomCategory != null && dto.RoomCategory.Id > 0 && dto.RoomCategory.Id != room.Category.Id)
                        blnAdd = false;
                    if (blnAdd && dto.RoomType != null && dto.RoomType.Id > 0 && dto.RoomType.Id != room.Type.Id)
                        blnAdd = false;
                    if (blnAdd && dto.ACPreference > 0)
                    {
                        Boolean isAC = dto.ACPreference == 1 ? true : false;
                        if (isAC != room.IsAirconditioned)
                            blnAdd = false;
                    }

                    if (blnAdd)
                        AvailableRoomList.Add(new LodgeConfigFac.Room.Dto { Id = room.Id });

                }
            }

            return AvailableRoomList;
        }

        private Int32 GetProductCount(List<BinAff.Core.Data> productList)
        {
            Int32 productCount = 0;
            foreach (BinAff.Core.Data data in productList)
            {
                if (data.Id > 0)
                    productCount++;
            }
            return productCount;
        }

        private List<Crystal.Customer.Component.Action.Data> RemoveDuplicateReservation(List<Crystal.Customer.Component.Action.Data> actionList)
        {
            List<Crystal.Customer.Component.Action.Data> lstAction = new List<CustCrys.Action.Data>();
            Boolean isExists;
            foreach (Crystal.Customer.Component.Action.Data roomData in actionList)
            {
                if (lstAction.Count == 0)
                {
                    lstAction.Add(roomData);
                }
                else
                {
                    isExists = false;
                    foreach (Crystal.Customer.Component.Action.Data uniqueRoomData in lstAction)
                    {
                        if (uniqueRoomData.Id == roomData.Id)
                        {
                            isExists = true;
                            break;
                        }
                    }
                    if (!isExists) lstAction.Add(roomData);
                }
            }

            return lstAction;
        }

        private Boolean ValidateRoomWithCategoryTypeAndACPreference(LodgeConfigFac.Room.Dto room, Int64 categoryId, Int64 typeId, Int32 acPreference)
        {
            if (room.Id == 0) return false;
            if (categoryId > 0 && categoryId != room.Category.Id) return false;
            if (typeId > 0 && typeId != room.Type.Id) return false;

            if (acPreference > 0)
            {
                Boolean isAC = acPreference == 1 ? true : false;
                if (isAC != room.IsAirconditioned) return false;
            }

            return true;
        }

        private Boolean ValidateRoomWithCategoryTypeAndACPreference(LodgeCrys.Room.Data room, Int64 categoryId, Int64 typeId, Int32 acPreference)
        {
            if (room.Id == 0) return false;
            if (categoryId > 0 && categoryId != room.Category.Id) return false;
            if (typeId > 0 && typeId != room.Type.Id) return false;

            if (acPreference > 0)
            {
                Boolean isAC = acPreference == 1 ? true : false;
                if (isAC != room.IsAirConditioned) return false;
            }

            return true;
        }

        private Boolean ValidateRoomWithCategoryTypeAndACPreference(LodgeCrys.Room.Reservation.Data reservationData, Int64 categoryId, Int64 typeId, Int32 acPreference)
        {
            Int64 catId = reservationData.RoomCategory == null ? 0 : reservationData.RoomCategory.Id;
            Int64 typId = reservationData.RoomType == null ? 0 : reservationData.RoomType.Id;

            Boolean retVal = true;
            if (categoryId != 0) retVal = catId == categoryId;
            if (retVal && typeId != 0) retVal = typId == typeId;
            if (retVal && acPreference != 0) retVal = reservationData.ACPreference == acPreference;

            return retVal;
        }

        private List<Table> CloneContactNumber(List<Table> contactNumberList)
        {
            List<Table> lstContactNumber = new List<Table>();
            foreach (Table contactNo in contactNumberList)
            {
                lstContactNumber.Add(new Table
                {
                    Id = contactNo.Id,
                    Name = contactNo.Name
                });
            }
            return lstContactNumber;
        }

        private List<LodgeConfigFac.Room.Dto> CloneRoomList(List<LodgeConfigFac.Room.Dto> roomList)
        {
            List<LodgeConfigFac.Room.Dto> lstRoom = new List<LodgeConfigFac.Room.Dto>();

            foreach (LodgeConfigFac.Room.Dto room in roomList)
                lstRoom.Add(new LodgeConfigFac.Room.Dto
                {
                    Id = room.Id,
                    Action = room.Action,
                    //artifactPath = room.artifactPath,
                    Building = room.Building,
                    Category = room.Category,
                    Description = room.Description,
                    //fileName = room.fileName,
                    Floor = room.Floor,
                    ImageList = room.ImageList,
                    IsAirconditioned = room.IsAirconditioned,
                    Name = room.Name,
                    Number = room.Number,
                    StatusId = room.StatusId,
                    //trvForm = room.trvForm,
                    Type = room.Type
                });

            return lstRoom;
        }

        private Int64 ReadIdForArtifact(Int64 artifactId)
        {
            return new RoomRsvCrys.Server(null).ReadIdForArtifact(artifactId);
        }

        private Int32 GetTotalNoBookedRooms(Dto dto)
        {
            Int32 totalReservedRooms = 0;
            RoomRsvCrys.Data roomReservationData;
            CustCrys.Action.IAction reservation = new Crystal.Lodge.Component.Room.Reservation.Server(null);
            ReturnObject<List<CustCrys.Action.Data>> ret = reservation.Search(new Crystal.Customer.Component.Action.Status.Data { Id = System.Convert.ToInt64(RoomStatus.Open) }, dto.BookingFrom, dto.BookingFrom.AddDays(dto.NoOfDays));

            Boolean blnAdd = true;
            if (ret.Value != null)
            {
                foreach (CustCrys.Action.Data reservationData in ret.Value)
                {
                    blnAdd = true;
                    roomReservationData = reservationData as RoomRsvCrys.Data;
                    if (dto.Id != reservationData.Id) // if update , ignore the current reservation
                    {
                        if (dto.RoomCategory.Id > 0 && dto.RoomCategory.Id != roomReservationData.RoomCategory.Id)
                            blnAdd = false;

                        if (blnAdd && dto.RoomType.Id > 0 && dto.RoomType.Id != roomReservationData.RoomType.Id)
                            blnAdd = false;

                        if (blnAdd && dto.ACPreference > 0 && dto.ACPreference != roomReservationData.ACPreference)
                            blnAdd = false;

                        if (blnAdd)
                            totalReservedRooms += roomReservationData.NoOfRooms;
                    }
                }
            }

            return totalReservedRooms;
        }

        private ReturnObject<RuleFac.ConfigurationRuleDto> ReadConfigurationRule()
        {
            return new RuleFac.RuleServer().ReadConfigurationRule();
        }

        private ReturnObject<List<LodgeConfigFac.Room.Dto>> ReadAllRoom()
        {
            return new LodgeConfigFac.Room.Server(null).ReadAllRoom();
        }

        private void Save()
        {
            Boolean isNew = (this.FormDto as FormDto).Dto.Id == 0;
            using (System.Transactions.TransactionScope T = new System.Transactions.TransactionScope())
            {
                CustAuto.Server custServer = new CustAuto.Server(this.ConvertCustomer());
                ReturnObject<Boolean> ret = (custServer as ICrud).Save();
                CustAuto.Data customer = (custServer as BinAff.Core.Crud).Data as CustAuto.Data;
                if (customer.RoomReserver.Active != null)
                {
                    (this.FormDto as FormDto).Dto.Id = customer.RoomReserver.Active.Id;
                }

                //Call observer...
                //This is work around because for this form artifact is different than component server.
                //Here customer component has to call bu need to update room reservation artifact
                if (this.componentServer == null) this.componentServer = this.GetComponentServer();
                if (isNew)
                {
                    (this.componentServer as BinAff.Core.Crud).Data.Id = (this.FormDto as FormDto).Dto.Id;
                    (this.componentServer as ArtfCrys.Observer.ISubject).NotifyObserverForCreate();
                }
                else
                {
                    (this.componentServer as ArtfCrys.Observer.ISubject).NotifyObserverForUpdate();
                }
                this.UpdateAuditInformation();

                this.DisplayMessageList = ret.GetMessage((this.IsError = ret.HasError()) ? Message.Type.Error : Message.Type.Information);
                T.Complete();
            }
        }

        private CustAuto.Data ConvertCustomer()
        {
            Dto dto = (this.FormDto as FormDto).Dto as Dto;
            AutoTourism.Component.Customer.Data autoCustomer = new Component.Customer.Data()
            {
                Id = dto.Customer.Id,
                FirstName = dto.Customer.FirstName,
                MiddleName = dto.Customer.MiddleName,
                LastName = dto.Customer.LastName,
                Address = dto.Customer.Address,
                City = dto.Customer.City,
                Pin = dto.Customer.Pin,
                Email = dto.Customer.Email,
                IdentityProof = dto.Customer.IdentityProofName == null ? String.Empty : dto.Customer.IdentityProofName,
                Country = dto.Customer.Country == null ? null : new Crystal.Configuration.Component.Country.Data
                {
                    Id = dto.Customer.Country.Id,
                    Name = dto.Customer.Country.Name
                },
                State = dto.Customer.State == null ? null : new Crystal.Configuration.Component.State.Data
                {
                    Id = dto.Customer.State.Id,
                    Name = dto.Customer.State.Name
                },
                ContactNumberList = this.ConvertToContactNumberData(dto.Customer.ContactNumberList),
                //Initial = new Crystal.Configuration.Component.Initial.Data
                //{
                //    Id = reservationDto.Customer.Initial.Id,
                //    Name = reservationDto.Customer.Initial.Name
                //},
                IdentityProofType = dto.Customer.IdentityProofType == null ? null : new Crystal.Configuration.Component.IdentityProofType.Data
                {
                    Id = dto.Customer.IdentityProofType.Id,
                    Name = dto.Customer.IdentityProofType.Name
                },
                RoomReserver = new LodgeCrys.Room.Reserver.Data()
            };

            autoCustomer.RoomReserver.Active = this.Convert(dto) as CustCrys.Action.Data;
            autoCustomer.RoomReserver.Active.ProductList = dto.RoomList == null ? null : this.GetRoomDataList(dto.RoomList);

            return autoCustomer;
        }

        private void ResetRoomList()
        {
            FormDto formDto = this.FormDto as FormDto;
            Dto dto = formDto.Dto as Dto;

            //Reset SelectedRoomList And AllRoomList           
            Boolean blnExists = false;
            List<LodgeConfigFac.Room.Dto> removeSelectedRoomList = new List<LodgeConfigFac.Room.Dto>();

            for (int selectedList = 0; selectedList < formDto.SelectedRoomList.Count; selectedList++)
            {
                LodgeConfigFac.Room.Dto room = formDto.SelectedRoomList[selectedList];

                blnExists = false;
                for (int allList = 0; allList < formDto.RoomList.Count; allList++)
                {
                    if (room.Id == formDto.RoomList[allList].Id)
                    {
                        blnExists = true;
                        break;
                    }
                }

                if (blnExists)
                    formDto.RoomList = this.RemoveRoomFromList(formDto.RoomList, room);
                else
                    removeSelectedRoomList.Add(room);
            }


            if (removeSelectedRoomList != null && removeSelectedRoomList.Count > 0)
            {
                for (int i = 0; i < removeSelectedRoomList.Count; i++)
                    formDto.SelectedRoomList.Remove(removeSelectedRoomList[i]);
            }
        }

        private ReturnObject<List<Dto>> GetCustomerBooking(Int64 customerId)
        {
            List<Dto> bookingList = new List<Dto>();

            //Crystal.Lodge.Reservation.IReservation reservation = new Server(new Crystal.Lodge.Reservation.Data
            //{
            //    Customer = new Crystal.CustomerManagement.Data()
            //    {
            //        Id = customerId,
            //    },
            //});

            //ReturnObject<List<BinAff.Core.Data>> reservationDataList = reservation.GetBooking();

            //    foreach (BinAff.Core.Data data in reservationDataList.Value)
            //    {
            //        bookingList.Add(new Dto()
            //        {
            //            Id = data.Id,
            //            BookingDate = ((Crystal.Lodge.Reservation.Data)data).BookingDate,
            //            BookingFrom = ((Crystal.Lodge.Reservation.Data)data).BookingFrom,
            //            NoOfDays = ((Crystal.Lodge.Reservation.Data)data).NoOfDays,
            //            NoOfPersons = ((Crystal.Lodge.Reservation.Data)data).NoOfPersons,
            //            NoOfRooms = ((Crystal.Lodge.Reservation.Data)data).NoOfRooms,
            //            Advance = ((Crystal.Lodge.Reservation.Data)data).Advance,
            //            BookingStatusId = ((Crystal.Lodge.Reservation.Data)data).BookingStatusId,
            //            RoomList = GetRoomDtoList(((Crystal.Lodge.Reservation.Data)data).RoomList),
            //        });
            //    }

            return new ReturnObject<List<Dto>>()
            {
                Value = bookingList,
            };

        }

        #endregion

        //-- RoomStaus ID is mapped with database table RoomReservationStatus
        public enum RoomStatus
        {
            Open = 10001,
            Cancel = 10003
        }

    }

}
