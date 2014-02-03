﻿using System;

namespace BinAff.Tool.Installer
{

    public partial class Welcome : Wizard
    {

        public Welcome()
        {
            InitializeComponent();
        }

        protected override Wizard AssignNextForm()
        {
            return new Legal();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            base.Next();
        }

    }

}
