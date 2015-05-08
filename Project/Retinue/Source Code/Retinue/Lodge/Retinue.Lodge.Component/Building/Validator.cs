using System.Collections.Generic;

using BinAff.Core;
using BinAff.Utility;
using System;

namespace Retinue.Lodge.Component.Building
{

    public class Validator : Crystal.Organization.Component.Unit.Validator
    {

        public Validator(Data data) 
            : base(data) 
        { 

        }

        protected override List<Message> Validate()
        {
            List<Message> retMsg = base.Validate();
            Data data = base.Data as Data;

            if (ValidationRule.IsNullOrEmpty(data.FloorList) || (data.FloorList.Count == 0))
                retMsg.Add(new Message("Building floor is not present.", Message.Type.Error));
            else if (data.FloorList.Count > 1 && this.IsDuplicateFloorExist(data.FloorList))
                retMsg.Add(new Message("Duplicate floor name entered.", Message.Type.Error));

            return retMsg;
        }

        private Boolean IsDuplicateFloorExist(List<BinAff.Core.Data> FloorList)
        {
            int loopCnt = 1;
            int innerLoopCnt = 1;
            foreach (BinAff.Core.Data floor in FloorList) {                
                foreach (BinAff.Core.Data floorData in FloorList)
                {                  
                    if ((((Building.Floor.Data)floor).Name.Trim() == ((Building.Floor.Data)floorData).Name.Trim()) && loopCnt != innerLoopCnt)
                        return true;

                    ++innerLoopCnt;
                }
                innerLoopCnt = 1;
                ++loopCnt;
            }
            return false;
        }

    }

}
