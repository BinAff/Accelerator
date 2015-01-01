using System;
using System.Collections.Generic;

using BinAff.Core;

using LodgeCrys = Crystal.Lodge.Component;
using ArtfCrys = Crystal.Navigator.Component.Artifact;
using CustCrys = Crystal.Customer.Component;
using RoomRsvCrys = Crystal.Lodge.Component.Room.Reservation;
using RoomRsvArtf = Crystal.Lodge.Component.Room.Reservation.Navigator.Artifact;

using ModDefFac = Vanilla.Utility.Facade.Module.Definition;
using FrmFac = Vanilla.Form.Facade.Document;

using RoomFac = AutoTourism.Lodge.Configuration.Facade.Room;
using RuleFac = AutoTourism.Configuration.Rule.Facade;
using CustAuto = AutoTourism.Component.Customer;
using CustFac = AutoTourism.Customer.Facade;

namespace AutoTourism.Lodge.Facade.RoomReservation
{

    public class Server : FrmFac.Server
    {

        public Server(FormDto formDto)
            : base(formDto)
        {

        }

        public override void LoadForm()
        {
            AutoTourism.Utility.Facade.Cache.Dto cache = BinAff.Facade.Cache.Server.Current.Cache["AutoTourism"] as AutoTourism.Utility.Facade.Cache.Dto;
            FormDto formDto = this.FormDto as FormDto;
            formDto.ConfigurationRule = new RuleFac.RuleServer().ReadConfigurationRule().Value;
            formDto.AllRoomList = cache.RoomList;
            formDto.CategoryList = cache.RoomCategoryList;
            formDto.TypeList = cache.RoomTypeList;

            if (formDto.Dto != null && formDto.Dto.Id > 0)
            {
                (formDto.Dto as Facade.RoomReservation.Dto).Customer = this.GetCustomer(formDto.Dto.Id);
            }
        }

        public override BinAff.Facade.Library.Dto Convert(BinAff.Core.Data data)
        {
            RoomRsvCrys.Data reservation = data as RoomRsvCrys.Data;
            Dto dto = new Dto
            {
                Id = data.Id,
                IsBackDateEntry = reservation.IsBackDateEntry,
                NoOfDays = reservation.NoOfDays,
                NoOfRooms = reservation.NoOfRooms,
                BookingFrom = reservation.ActivityDate,
                ACPreference = reservation.ACPreference,
                BookingDate = reservation.Date,
                IsCheckedIn = reservation.IsCheckedIn,
                NoOfMale = reservation.NoOfMale,
                NoOfFemale = reservation.NoOfFemale,
                NoOfChild = reservation.NoOfChild,
                NoOfInfant = reservation.NoOfInfant,
                Remark = reservation.Remark,
                ReservationNo = reservation.ReservationNo,

                Customer = this.GetCustomer(data.Id),
            };

            if (reservation.Status != null) dto.BookingStatus = (Status)reservation.Status.Id;
            dto.RoomList = reservation.ProductList == null ? null : new RoomFac.Server(null).ConvertAll<Data, RoomFac.Dto>(reservation.ProductList);
            if (reservation.RoomCategory != null) dto.RoomCategory = reservation.RoomCategory == null ? null : new Table { Id = reservation.RoomCategory.Id };
            if(reservation.RoomType != null) dto.RoomType = reservation.RoomType == null ? null : new Table { Id = reservation.RoomType.Id };
            
            return dto;
        }

        public override BinAff.Core.Data Convert(BinAff.Facade.Library.Dto dto)
        {
            Dto reservation = dto as Dto;
            return new RoomRsvCrys.Data
            {
                Id = dto.Id,
                NoOfDays = reservation.NoOfDays,
                IsBackDateEntry = reservation.IsBackDateEntry,
                NoOfRooms = reservation.NoOfRooms,
                ActivityDate = reservation.BookingFrom,
                Date = DateTime.Now,
                ProductList = reservation.RoomList == null ? null : GetRoomDataList(reservation.RoomList),
                Status = new Crystal.Customer.Component.Action.Status.Data
                {
                    Id = (Int64)reservation.BookingStatus
                },
                RoomCategory = reservation.RoomCategory == null ? null : new LodgeCrys.Room.Category.Data
                {
                    Id = reservation.RoomCategory.Id,
                    Name = reservation.RoomCategory.Name,
                },
                RoomType = reservation.RoomType == null ? null : new LodgeCrys.Room.Type.Data
                {
                    Id = reservation.RoomType.Id,
                    Name = reservation.RoomType.Name,
                },
                ACPreference = reservation.ACPreference,
                NoOfMale = reservation.NoOfMale,
                NoOfFemale = reservation.NoOfFemale,
                NoOfChild = reservation.NoOfChild,
                NoOfInfant = reservation.NoOfInfant,
                Remark = reservation.Remark,
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

        public override string GetComponentCode()
        {
            return "LRSV";
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

        public override ModDefFac.Dto GetAncestorComponentCode()
        {
            return (BinAff.Facade.Cache.Server.Current.Cache["Main"] as Vanilla.Utility.Facade.Cache.Dto).ComponentDefinitionList.FindLast((
                    (p) => { return p.Code == new CustFac.Server(null).GetComponentCode(); }));
        }

        #region Public

        /// <summary>
        /// Get total numbers of rooms in the lodge
        /// </summary>
        /// <returns></returns>
        public Int32 GetTotalNoRooms()
        {
            Int32 totalRooms = 0;
            Boolean blnAdd = true;

            FormDto formDto = this.FormDto as FormDto;
            Dto dto = formDto.Dto as Dto;

            List<RoomFac.Dto> allRoomList = formDto.FilteredRoomList;

            if (allRoomList != null && allRoomList.Count > 0)
            {
                foreach (RoomFac.Dto roomDto in allRoomList)
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
                        totalRooms++;
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

            formDto.RoomList = new List<RoomFac.Dto>();

            if (dto.NoOfDays > 0)
            {
                Boolean blnAdd = true;
                List<RoomFac.Dto> selRoomList = new List<RoomFac.Dto>();

                foreach (RoomFac.Dto roomDto in formDto.FilteredRoomList)
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
            List<RoomFac.Dto> AvailableRoomList = this.AvailableRoomList();
            formDto.AvailableRoomCount = AvailableRoomList == null ? 0 : AvailableRoomList.Count;

            return formDto;
        }

        //Returning the Reservation FormDto , since this function will be called from CheckIn
        public FormDto AddRoomToAllRoomList(RoomFac.Dto room)
        {
            FormDto formDto = this.FormDto as FormDto;
            formDto.SelectedRoomList.Remove(room);

            if (formDto.RoomList == null)
                formDto.RoomList = new List<RoomFac.Dto>();

            formDto.RoomList.Add(room);

            if (formDto.RoomList != null && formDto.RoomList.Count > 1)
                formDto.RoomList = this.SortRoomListByRoomNo(formDto.RoomList);

            return formDto;
        }

        public void RemoveRoomFromAllRoomList(RoomFac.Dto room)
        {
            FormDto formDto = this.FormDto as FormDto;
            formDto.RoomList.Remove(room);

            if (formDto.SelectedRoomList == null)
                formDto.SelectedRoomList = new List<RoomFac.Dto>();

            formDto.SelectedRoomList.Add(room);

            if (formDto.SelectedRoomList != null && formDto.SelectedRoomList.Count > 1)
                formDto.SelectedRoomList = this.SortRoomListByRoomNo(formDto.SelectedRoomList);
        }

        //This function will also be called from CheckIn
        public List<RoomFac.Dto> SortRoomListByRoomNo(List<RoomFac.Dto> roomList)
        {
            String[] arrRoomNo = new String[roomList.Count];
            List<RoomFac.Dto> sortedRoomList = new List<RoomFac.Dto>();

            for (int i = 0; i < roomList.Count; i++)
                arrRoomNo[i] = roomList[i].Number;

            Array.Sort(arrRoomNo);

            for (int i = 0; i < arrRoomNo.Length; i++)
            {
                foreach (RoomFac.Dto room in roomList)
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
            ReturnObject<List<CustCrys.Action.Data>> ret = reservation.Search(new CustCrys.Action.Status.Data { Id = System.Convert.ToInt64(Status.Open) }, dto.BookingFrom, dto.BookingFrom.AddDays(dto.NoOfDays));

            List<RoomFac.Dto> bookedRoomList = new List<RoomFac.Dto>();

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
                                    bookedRoomList.Add(new RoomFac.Dto { Id = roomData.Id });
                            }
                        }
                    }
                }
            }

            //populate room list            
            if (bookedRoomList != null && bookedRoomList.Count > 0)
            {
                formDto.FilteredRoomList = new List<RoomFac.Dto>();
                Boolean blnInclude = true;

                for (int i = 0; i < formDto.AllRoomList.Count; i++)
                {
                    blnInclude = true;

                    foreach (RoomFac.Dto roomDto in bookedRoomList)
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
            List<RoomFac.Dto> AvailableRoomList = this.AvailableRoomList();
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
                Id = (Int64)((this.FormDto as FormDto).Dto as Dto).BookingStatus
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

        public CustFac.Dto GetCustomer(Int64 reservationId)
        {
            CustAuto.ICustomer server = new CustAuto.Server(null);
            CustCrys.Data data = server.GetCustomerForReservation(reservationId);
            return data == null ? null : new CustFac.Server(null).Convert(data) as CustFac.Dto;
        }

        private List<Data> GetRoomDataList(List<RoomFac.Dto> RoomList)
        {
            List<Data> RoomDataList = new List<Data>();
            foreach (RoomFac.Dto dto in RoomList)
            {
                RoomDataList.Add(new LodgeCrys.Room.Data
                {
                    Id = dto.Id,
                    Number = dto.Number,
                });
            }
            return RoomDataList;
        }

        //private List<RoomFac.Dto> GetRoomDtoList(List<Data> RoomList)
        //{
        //    List<RoomFac.Dto> RoomDtoList = new List<RoomFac.Dto>();
        //    foreach (LodgeCrys.Room.Data data in RoomList)
        //    {
        //        RoomDtoList.Add(new RoomFac.Dto
        //        {
        //            Id = data.Id,
        //            Number = data.Number,
        //            Name = data.Name
        //        });
        //    }
        //    return RoomDtoList;
        //}

        //public void SaveArtifactForReservation(Vanilla.Utility.Facade.Artifact.Dto artifactDto)
        //{
        //    Vanilla.Utility.Facade.Module.Dto reservationModuleDto = new Vanilla.Utility.Facade.Module.Server(null).GetModule("LRSV", (this.FormDto as FormDto).ModuleFormDto.FormModuleList);
        //    String fileName = new Vanilla.Utility.Facade.Artifact.Server(null).GetArtifactName(reservationModuleDto.Artifact, Vanilla.Utility.Facade.Artifact.Type.Document, "Form");
        //    artifactDto.FileName = fileName;

        //    if (reservationModuleDto != null)
        //    {
        //        reservationModuleDto.Artifact.Children.Add(artifactDto);
        //    }

        //    (this.FormDto as FormDto).ModuleFormDto.CurrentArtifact = new Vanilla.Utility.Facade.Artifact.FormDto
        //    {
        //        Dto = artifactDto
        //    };

        //    (this.FormDto as FormDto).ModuleFormDto.Dto = reservationModuleDto;
        //    Vanilla.Utility.Facade.Module.Server moduleFacade = new Vanilla.Utility.Facade.Module.Server((this.FormDto as FormDto).ModuleFormDto);
        //    moduleFacade.Add();
        //}

        public List<RoomFac.Dto> FilterRoomList(List<RoomFac.Dto> roomList, Int64 categoryId, Int64 typeId, Int32 acPreference)
        {
            List<RoomFac.Dto> lstRoom = new List<RoomFac.Dto>();

            foreach (RoomFac.Dto room in roomList)
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
            ReturnObject<List<Crystal.Customer.Component.Action.Data>> ret = reservation.Search(new Crystal.Customer.Component.Action.Status.Data { Id = System.Convert.ToInt64(Status.Open) }, startDate, endDate);

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
            ReturnObject<List<Crystal.Customer.Component.Action.Data>> ret = reservation.Search(new Crystal.Customer.Component.Action.Status.Data { Id = System.Convert.ToInt64(Status.Open) }, startDate, endDate);

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

        //public Dto CloneDto(Dto dto)
        //{
        //    Dto ret = new Dto
        //    {
        //        Id = dto.Id,
        //        isCheckedIn = dto.isCheckedIn,
        //        ReservationNo = dto.ReservationNo,
        //        BookingFrom = dto.BookingFrom,
        //        NoOfDays = dto.NoOfDays,
        //        NoOfRooms = dto.NoOfRooms,
        //        BookingStatus = dto.BookingStatus,
        //        RoomCategory = dto.RoomCategory == null ? null : new Table
        //        {
        //            Id = dto.RoomCategory.Id,
        //            Name = dto.RoomCategory.Name
        //        },
        //        RoomType = dto.RoomType == null ? null : new Table
        //        {
        //            Id = dto.RoomType.Id,
        //            Name = dto.RoomType.Name
        //        },
        //        ACPreference = dto.ACPreference,
        //        NoOfMale = dto.NoOfMale,
        //        NoOfFemale = dto.NoOfFemale,
        //        NoOfChild = dto.NoOfChild,
        //        NoOfInfant = dto.NoOfInfant,
        //        Remark = dto.Remark,
        //        Customer = dto.Customer
        //    };
        //    if (ret.RoomList != null)
        //    {
        //        ret.RoomList = new List<RoomFac.Dto>();
        //        ret.RoomList.AddRange(dto.RoomList);
        //    }
        //    return ret;
        //}

        #endregion

        #region Private

        private List<RoomFac.Dto> RemoveRoomFromList(List<RoomFac.Dto> roomList, RoomFac.Dto room)
        {
            List<RoomFac.Dto> filteredRoomList = new List<RoomFac.Dto>();

            for (int i = 0; i < roomList.Count; i++)
            {
                if (room.Id != roomList[i].Id)
                    filteredRoomList.Add(roomList[i]);
            }

            return filteredRoomList;
        }

        private List<RoomFac.Dto> AvailableRoomList()
        {
            FormDto formDto = this.FormDto as FormDto;
            Dto dto = formDto.Dto as Dto;

            CustCrys.Action.IAction objReservation = new RoomRsvCrys.Server(null);
            ReturnObject<List<CustCrys.Action.Data>> ret = objReservation.Search(new CustCrys.Action.Status.Data { Id = System.Convert.ToInt64(Status.Open) }, dto.BookingFrom, dto.BookingFrom.AddDays(dto.NoOfDays));
            List<CustCrys.Action.Data> allReservation = ret.Value as List<CustCrys.Action.Data>;
            List<RoomFac.Dto> allRoomList = formDto.AllRoomList;

            List<RoomFac.Dto> AvailableRoom = new List<RoomFac.Dto>();
            List<RoomFac.Dto> AllBookedRoom = new List<RoomFac.Dto>();

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

        private void UpdateRoomFromReservation(List<RoomFac.Dto> AllRoom, List<CustCrys.Action.Data> reservationFilter, List<RoomFac.Dto> AllBookedRoom)
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
                            AllBookedRoom.Add(new RoomFac.Dto { Id = roomData.Id });
                    }
                }

                if (NoOfRoom > 0)
                {
                    for (int i = 0; i < NoOfRoom; i++)
                    {
                        foreach (RoomFac.Dto room in AllRoom)
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

                            AllBookedRoom.Add(new RoomFac.Dto { Id = room.Id });
                            break;
                        }


                    }
                }
            }
        }

        private Boolean IsRoomExist(RoomFac.Dto room, List<RoomFac.Dto> roomList)
        {
            Boolean blnValue = false;
            if (roomList == null || roomList.Count == 0)
                blnValue = false;
            else
            {
                foreach (RoomFac.Dto dto in roomList)
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

        private List<RoomFac.Dto> ReadAllAvailableRoom(List<RoomFac.Dto> allRoomList, List<RoomFac.Dto> AllBookedRoom)
        {
            FormDto formDto = this.FormDto as FormDto;
            Dto dto = formDto.Dto as Dto;
            Boolean blnAdd = true;
            List<RoomFac.Dto> AvailableRoomList = new List<RoomFac.Dto>();
            List<RoomFac.Dto> UnOccupiedRoomList = new List<RoomFac.Dto>();
            if (allRoomList != null && allRoomList.Count > 0 && allRoomList.Count > AllBookedRoom.Count)
            {
                foreach (RoomFac.Dto room in allRoomList)
                {
                    if (!IsRoomExist(room, AllBookedRoom))
                        UnOccupiedRoomList.Add(room);
                }
            }

            if (UnOccupiedRoomList != null && UnOccupiedRoomList.Count > 0)
            {
                foreach (RoomFac.Dto room in UnOccupiedRoomList)
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
                        AvailableRoomList.Add(new RoomFac.Dto { Id = room.Id });

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

        private Boolean ValidateRoomWithCategoryTypeAndACPreference(RoomFac.Dto room, Int64 categoryId, Int64 typeId, Int32 acPreference)
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

        private List<RoomFac.Dto> CloneRoomList(List<RoomFac.Dto> roomList)
        {
            List<RoomFac.Dto> lstRoom = new List<RoomFac.Dto>();

            foreach (RoomFac.Dto room in roomList)
            {
                lstRoom.Add(new RoomFac.Dto
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
            }
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
            ReturnObject<List<CustCrys.Action.Data>> ret = reservation.Search(new Crystal.Customer.Component.Action.Status.Data { Id = System.Convert.ToInt64(Status.Open) }, dto.BookingFrom, dto.BookingFrom.AddDays(dto.NoOfDays));

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

        private void Save()
        {
            Boolean isNew = (this.FormDto as FormDto).Dto.Id == 0;
            using (System.Transactions.TransactionScope T = new System.Transactions.TransactionScope())
            {
                Dto dto = (this.FormDto as FormDto).Dto as Dto;
                CustAuto.Data cust = new CustFac.Server(null).Convert(dto.Customer) as CustAuto.Data;

                //Attach reservation
                cust.RoomReserver.Active = this.Convert(dto) as CustCrys.Action.Data;
                cust.RoomReserver.Active.ProductList = dto.RoomList == null ? null : this.GetRoomDataList(dto.RoomList);

                ReturnObject<Boolean> ret = (new CustAuto.Server(cust) as ICrud).Save();
                if(this.IsError = ret.HasError())
                {
                    this.DisplayMessageList = ret.GetMessage((this.IsError) ? Message.Type.Error : Message.Type.Information);
                    return;
                }

                if (cust.RoomReserver.Active != null)
                {
                    (this.FormDto as FormDto).Dto.Id = cust.RoomReserver.Active.Id;
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

        private void ResetRoomList()
        {
            FormDto formDto = this.FormDto as FormDto;
            Dto dto = formDto.Dto as Dto;

            //Reset SelectedRoomList And AllRoomList           
            Boolean blnExists = false;
            List<RoomFac.Dto> removeSelectedRoomList = new List<RoomFac.Dto>();

            for (int selectedList = 0; selectedList < formDto.SelectedRoomList.Count; selectedList++)
            {
                RoomFac.Dto room = formDto.SelectedRoomList[selectedList];

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

        //private ReturnObject<List<Dto>> GetCustomerBooking(Int64 customerId)
        //{
        //    List<Dto> bookingList = new List<Dto>();

        //    //Crystal.Lodge.Reservation.IReservation reservation = new Server(new Crystal.Lodge.Reservation.Data
        //    //{
        //    //    Customer = new Crystal.CustomerManagement.Data()
        //    //    {
        //    //        Id = customerId,
        //    //    },
        //    //});

        //    //ReturnObject<List<BinAff.Core.Data>> reservationDataList = reservation.GetBooking();

        //    //    foreach (BinAff.Core.Data data in reservationDataList.Value)
        //    //    {
        //    //        bookingList.Add(new Dto()
        //    //        {
        //    //            Id = data.Id,
        //    //            BookingDate = ((Crystal.Lodge.Reservation.Data)data).BookingDate,
        //    //            BookingFrom = ((Crystal.Lodge.Reservation.Data)data).BookingFrom,
        //    //            NoOfDays = ((Crystal.Lodge.Reservation.Data)data).NoOfDays,
        //    //            NoOfPersons = ((Crystal.Lodge.Reservation.Data)data).NoOfPersons,
        //    //            NoOfRooms = ((Crystal.Lodge.Reservation.Data)data).NoOfRooms,
        //    //            Advance = ((Crystal.Lodge.Reservation.Data)data).Advance,
        //    //            BookingStatusId = ((Crystal.Lodge.Reservation.Data)data).BookingStatusId,
        //    //            RoomList = GetRoomDtoList(((Crystal.Lodge.Reservation.Data)data).RoomList),
        //    //        });
        //    //    }

        //    return new ReturnObject<List<Dto>>()
        //    {
        //        Value = bookingList,
        //    };

        //}

        #endregion

    }

}
