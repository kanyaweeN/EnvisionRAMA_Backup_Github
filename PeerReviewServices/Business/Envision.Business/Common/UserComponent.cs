using Envision.DataAccess.Common;
using Envision.Entity.Common.User;
using Envision.Entity.Common.UserForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Business.Common
{
    public class UserComponent
    {
        
        public UserComponent()
        {
            session = new DbSession();
            user = new DbUser();
        }

        private DbSession session { get; set; }
        private DbUser user { get; set; }
        public UserInfo Item { get; set; }

        public UserInfo Authen(string userName, string password)
        {
            user.Item.UserName = userName;
            user.Item.Password = HelperComponent.Encryp(password);
            return user.GetByUserNameAndPassword();
        }
        public List<Menu> GetUserMenu()
        {
            DbUserForm userForm = new DbUserForm();
            List<Module> mnuList = userForm.GetModuleByUserId(Item.Id);
            List<Menu> itemList = null;
            if (mnuList != null && mnuList.Count > 0)
            {
                itemList = new List<Menu>();
                List<Form> subList = userForm.GetFormByUserId(Item.Id);
                if (subList != null && subList.Count > 0)
                {
                    foreach (var mnu in mnuList)
                    {
                        var itemFormList = subList.Where(obj => obj.ParentId == mnu.Id).ToList();
                        if (itemFormList != null && itemFormList.Count > 0)
                        {
                            Menu item = new Menu();
                            item.Module = mnu;
                            itemFormList = itemFormList.OrderBy(x => x.SL).ToList();
                            item.FormList = itemFormList;
                            itemList.Add(item);
                        }
                    }
                }
            }
            return itemList;
        }
    }
}
