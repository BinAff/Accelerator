using BinAff.Core;

using VanilaModule = Vanilla.Navigator.Facade.Module;

namespace Vanilla.Navigator.Facade.Container
{

    public class Server : BinAff.Facade.Library.Server
    {

        public Server(FormDto formDto)
            :base(formDto)
        {

        }

        public override void LoadForm()
        {
            new Module.Server((this.FormDto as FormDto).ModuleFormDto).LoadForm();

            this.GetCurrentModules(Artifact.Category.Form);
        }

        public override BinAff.Facade.Library.Dto Convert(Data data)
        {
            //Dto dto = (this.FormDto as FormDto).Dto;
            //dto.Group = Module.Group.Form;

            //foreach (Crystal.License.Module.Data doc in dataList)
            //{
            //    ret.Add(new Module.Dto
            //    {
            //        Id = doc.Id,
            //        Name = doc.Name,
            //    });
            //}
            return null;
        }

        public override Data Convert(BinAff.Facade.Library.Dto dto)
        {
            
            //foreach (Role.Dto dto in ((FormDto)this.FormDto).Dto.RoleList)
            //{
            //    this.data.RoleList.Add(new Crystal.Guardian.Component.Role.Data
            //    {
            //        Id = dto.Id,
            //        Name = dto.Name,
            //    });
            //}
            return null;
        }

        public override void Add()
        {
            VanilaModule.Server moduleFacade = new VanilaModule.Server((this.FormDto as FormDto).ModuleFormDto);
            moduleFacade.Add();
            this.DisplayMessageList = moduleFacade.DisplayMessageList;
            this.IsError = moduleFacade.IsError;
        }

        public void GetCurrentModules(Artifact.Category category)
        {
            Dto dto = new Dto
            {
                Category = category,
            };

            FormDto formDto = this.FormDto as FormDto;

            switch (category)
            {
                case Artifact.Category.Form:
                    dto.Modules = formDto.ModuleFormDto.FormModuleList;
                    break;
                case Artifact.Category.Report:
                    dto.Modules = formDto.ModuleFormDto.ReportModuleList;
                    break;
                case Artifact.Category.Catalogue:
                    dto.Modules = formDto.ModuleFormDto.CatalogueModuleList;
                    break;
            }
            (this.FormDto as FormDto).Dto = dto;

        }

        public void LoadArtifacts(string selectedModule)
        {
            switch (selectedModule)
            {
                case "Customer":

                    break;
            }
            Module.Server moduleFacade = new Module.Server(null);
        }

        public void GetTreeForCurrentModuleList()
        {

        }

        public override void Delete()
        {
            VanilaModule.Server moduleFacade = new VanilaModule.Server((this.FormDto as FormDto).ModuleFormDto);
            moduleFacade.Delete();
            this.DisplayMessageList = moduleFacade.DisplayMessageList;
            this.IsError = moduleFacade.IsError;
        }       

        #region "Menu Handle"

        public void Login()
        {

        }

        #endregion

    }

}
