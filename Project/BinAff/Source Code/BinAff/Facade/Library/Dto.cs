using System;

namespace BinAff.Facade.Library
{

    public class Dto
    {

        /// <summary>
        /// Unique identifier
        /// </summary>
        public Int64 Id { get; set; }

        /// <summary>
        /// Mark required action on dto
        /// </summary>
        public ActionType Action { get; set; }

        public virtual Dto Clone()
        {
            return this.MemberwiseClone() as Dto;
        }

        public enum ActionType
        {
            Create,
            Update,
            Delete,
            Read
        }

    }

}
