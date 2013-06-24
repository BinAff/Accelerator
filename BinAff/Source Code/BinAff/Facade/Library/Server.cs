using System;

using BinAff.Core;

namespace BinAff.Facade.Library
{

    public abstract class Server
    {

        protected FormDto FormDto { get; set; }
        //private Core.Data data;
        //private Crud crud;

        protected Server(FormDto formDto)
        {
            this.FormDto = formDto;
            //this.LoadForm();
            //this.crud = crud;
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
        public virtual ReturnObject<Boolean> Save()
        {
            throw new NotImplementedException("Save is not implemented in Facade");
        }

        public virtual ReturnObject<Boolean> Delete()
        {
            throw new NotImplementedException("Delete is not implemented in Facade");
        }

        /// <summary>
        /// Convert business data to DTO
        /// </summary>
        public abstract void ConvertToDto();

        /// <summary>
        /// Convert business data from DTO
        /// </summary>
        public abstract void ConvertFromDto();

    }

}
