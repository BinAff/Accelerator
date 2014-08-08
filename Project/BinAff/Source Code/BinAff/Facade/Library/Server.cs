using System;
using System.Collections.Generic;

using BinAff.Core;

namespace BinAff.Facade.Library
{

    public abstract class Server
    {
        public Data Data { get; set; }

        /// <summary>
        /// Data structure of the form
        /// </summary>
        protected FormDto FormDto { get; set; }

        /// <summary>
        /// Message to display in form
        /// </summary>
        public List<String> DisplayMessageList { get; protected set; }

        public Boolean IsError { get; protected set; }

        protected Server(FormDto formDto)
        {
            this.FormDto = formDto;
        }

        /// <summary>
        /// Load the form
        /// </summary>
        /// <returns></returns>
        public abstract void LoadForm();

        /// <summary>
        /// Save data
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public virtual void Add()
        {
            throw new NotImplementedException("Save is not implemented in Facade");
        }

        /// <summary>
        /// Change exisitng record
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public virtual void Change()
        {
            throw new NotImplementedException("Change is not implemented in Facade");
        }

        public virtual void Delete()
        {
            throw new NotImplementedException("Delete is not implemented in Facade");
        }

        public virtual void Read()
        {
            throw new NotImplementedException("Read is not implemented in Facade");
        }

        /// <summary>
        /// Convert business data to DTO
        /// </summary>
        public abstract Dto Convert(Core.Data data);

        /// <summary>
        /// Convert business data from DTO
        /// </summary>
        public abstract Core.Data Convert(Dto dto);
 
    }

}
