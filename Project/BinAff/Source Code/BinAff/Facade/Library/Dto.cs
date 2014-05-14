using System;

namespace BinAff.Facade.Library
{

    public class Dto : ICloneable
    {

        /// <summary>
        /// Unique identifier
        /// </summary>
        public Int64 Id { get; set; }

        public String artifactPath { get; set; }
        public String fileName { get; set; }

        public System.Windows.Forms.TreeView trvForm { get; set; }

        /// <summary>
        /// Mark required action on dto
        /// </summary>
        public ActionType Action { get; set; }

        public enum ActionType
        {
            Create,
            Update,
            Delete,
            Read
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }

}
