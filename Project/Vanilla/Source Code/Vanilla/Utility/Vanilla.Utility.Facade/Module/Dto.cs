using System;
using System.Collections.Generic;

namespace Vanilla.Utility.Facade.Module
{
    public class Dto : BinAff.Facade.Library.Dto
    {
        public String Name { get; set; }

        public String Code { get; set; }

        public String ComponentFormType { get; set; }

        public List<Category.Dto> CategoryList { get; set; }

        //public BinAff.Facade.Library.Dto ComponentFormDto { get; set; }

        public Artifact.Dto Artifact { get; set; }

        public override BinAff.Facade.Library.Dto Clone()
        {
            Dto dto = base.Clone() as Dto;
            if (this.CategoryList != null)
            {
                dto.CategoryList = new List<Category.Dto>();
                foreach (Category.Dto category in this.CategoryList)
                {
                    dto.CategoryList.Add((category != null) ? category.Clone() as Category.Dto : null);
                }
            }
            if (this.Artifact != null) dto.Artifact = this.Artifact.Clone() as Artifact.Dto;
            return dto;
        }
    }
}
