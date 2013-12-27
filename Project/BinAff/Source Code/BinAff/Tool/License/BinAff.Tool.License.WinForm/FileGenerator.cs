using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

using BinAff.Presentation.Library.Extension;

namespace BinAff.Tool.License
{

    public partial class FileGenerator : Form
    {

        public FileGenerator()
        {
            InitializeComponent();
        }

        private void Generator_Load(object sender, EventArgs e)
        {
            this.InitializeListControls();
            this.cboProduct.Bind<SecurityHandler.Product.Data>(new Facade.FileGenerator.Server().Load());
            this.cboProduct.SelectedIndex = -1;
        }

        private void cboProduct_Click(object sender, EventArgs e)
        {
            this.Clear();
            SecurityHandler.Product.Data data = this.cboProduct.SelectedItem as SecurityHandler.Product.Data;
            this.txtProductId.Text = data.Code;
            this.txtProductDesc.Text = data.Description;

            //Load moduls
            if (data.ModuleList != null && data.ModuleList.Count > 0)
            {
                List<SecurityHandler.Module.Data> moduleList = data.ModuleList.ConvertAll<SecurityHandler.Module.Data>(new Converter<Core.Data, SecurityHandler.Module.Data>(Convert));
                this.lstSourceModule.Bind<SecurityHandler.Module.Data>(moduleList);
            }
        }

        public SecurityHandler.Module.Data Convert(Core.Data data)
        {
            SecurityHandler.Module.Data module = data as SecurityHandler.Module.Data;
            return new SecurityHandler.Module.Data
            {
                Id = data.Id,
                Name = module.Name,
                Code = module.Code,
                Description = module.Description,
                IsForm = module.IsForm,
                IsCatalogue = module.IsCatalogue,
                IsReport = module.IsReport,
            };
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.AddModule();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            this.RemoveModule();
        }

        private void lstSourceModule_DoubleClick(object sender, EventArgs e)
        {
            this.AddModule();
        }

        private void lstLicensedModule_DoubleClick(object sender, EventArgs e)
        {
            this.RemoveModule();
        }

        private void AddModule()
        {
            SecurityHandler.Module.Data currentModule = this.lstSourceModule.SelectedItem as SecurityHandler.Module.Data;
            this.lstLicensedModule.Items.Add(currentModule);
            this.lstSourceModule.Items.Remove(currentModule);
        }

        private void RemoveModule()
        {
            SecurityHandler.Module.Data currentModule = this.lstLicensedModule.SelectedItem as SecurityHandler.Module.Data;
            this.lstSourceModule.Items.Add(currentModule);
            this.lstLicensedModule.Items.Remove(currentModule);
        }

        private void btnGenerateLicenseFile_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialog.SelectedPath = System.IO.Directory.GetDirectoryRoot(Application.ExecutablePath);
            this.folderBrowserDialog.ShowDialog();

            new Facade.FileGenerator.Server().Generate(this.cboProduct.SelectedItem as SecurityHandler.Product.Data, this.lstLicensedModule.DataSource<SecurityHandler.Module.Data>() as List<SecurityHandler.Module.Data>, this.folderBrowserDialog.SelectedPath + @"\Splash.lic");
            MessageBox.Show("License file is generated.");
        }

        private void InitializeListControls()
        {
            this.cboProduct.DisplayMember = "Name";
            this.cboProduct.ValueMember = "Id";
            this.lstSourceModule.DisplayMember = "Name";
            this.lstSourceModule.ValueMember = "Id";
            this.lstLicensedModule.DisplayMember = "Name";
            this.lstLicensedModule.ValueMember = "Id";
        }

        private void Clear()
        {
            this.txtProductId.Text = String.Empty;
            this.txtProductDesc.Text = String.Empty;
            this.lstSourceModule.Items.Clear();
            this.lstLicensedModule.Items.Clear();
        }

    }

}
