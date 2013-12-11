using System;
using System.Collections.Generic;

using VanRole = Vanilla.Guardian.Facade.Role;

namespace Vanilla.Navigator.Facade.Container
{

    public class RoleManager
    {

        List<VanRole.Dto> roleList;

        private Boolean isSuperAdmin;
        public Boolean IsSuperAdmin
        {
            get
            {
                return this.isSuperAdmin;
            }
        }

        private Boolean isAdmin;
        public Boolean IsAdmin
        {
            get
            {
                return this.isAdmin;
            }
        }

        private Boolean isReceptionist;
        public Boolean IsReceptionist
        {
            get
            {
                return this.isReceptionist;
            }
        }

        private Boolean isCashier;
        public Boolean IsCashier
        {
            get
            {
                return this.isCashier;
            }
        }

        public RoleManager(List<VanRole.Dto> roleList)
        {
            this.roleList = roleList;
            if (this.roleList == null) throw new Exception("No Role Defined!!!");
            this.Load();
        }

        private void Load()
        {
            this.isSuperAdmin = this.roleList.Find((p) =>
            {
                return String.Compare(p.Name, "SuperAdmin") == 0;
            }) != null;
            this.isAdmin = this.roleList.Find((p) =>
            {
                return String.Compare(p.Name, "Admin") == 0;
            }) != null;
            this.isReceptionist = this.roleList.Find((p) =>
            {
                return String.Compare(p.Name, "Receptionist") == 0;
            }) != null;
            this.isCashier = this.roleList.Find((p) =>
            {
                return String.Compare(p.Name, "Cashier") == 0;
            }) != null;
        }

    }

}
