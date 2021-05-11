using Envision.DataAccess.Common;
using Envision.Entity.Common;
using Envision.Entity.Common.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Business.Common
{
    public class SessionComponent
    {
        public SessionComponent()
        {
            session = new DbSession();
        }
        private DbSession session  {get;set;}

        public string SignIn(UserInfo obj, string Ip)
        {
            deactiveCurrentSession(obj.Id);
            session.Item.Id = 0;
            session.Item.EmpId = obj.Id;
            session.Item.Status = "A";  //A :Alive, I :??
            session.Item.SessionGuid = HelperComponent.GUID();
            session.Item.IpAddressCurrent = Ip;
            session.Item.LogOnTimeStamp = DateTime.Now;
            session.Item.LogOnType = "D";
            session.Item.OrgId = obj.OrgId;
            session.Item.CreatedBy = obj.Id;
            session.Item.CreatedOn = DateTime.Now;

            session.LogIn();
            return session.Item.SessionGuid;
        }
        public void SignOut(string token)
        {
            session.Item.SessionGuid = token;
            session.Item.Status = "I";
            session.Item.LogOutType = "O";
            session.Item.LogOutTimeStamp = DateTime.Now;
            session.Item.ModifiedOn = DateTime.Now;
            session.LogOut();
        }

        public Session GetByToken(string token)
        {
            session.Item.SessionGuid = token;
            return session.GetByGuid();
        }

        private void deactiveCurrentSession(int empId)
        {
            session.DeactiveSession(empId);
        }
    }
}
