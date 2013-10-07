using System.Collections.Generic;

namespace Crystal.Customer.Component.Characteristic
{

    public class Data : BinAff.Core.Data
    {

        /// <summary>
        /// Active
        /// </summary>
        public Action.Data Active { get; set; }        

        /// <summary>
        /// List of all actions
        /// </summary>
        public List<BinAff.Core.Data> AllList { get; set; }

        /// <summary>
        /// List of past actions
        /// </summary>
        public List<BinAff.Core.Data> ArchiveList
        {
            get
            {
                return this.AllList.FindAll((p) => { return (p as Action.Data).Status.Name == "Close"; });
            }
        }

        /// <summary>
        /// List of current action
        /// </summary>
        public List<BinAff.Core.Data> CurrentList
        {
            get
            {
                return this.AllList.FindAll((p) => { return (p as Action.Data).Status.Name == "Open"; });
            }
        }
        
    }

}
