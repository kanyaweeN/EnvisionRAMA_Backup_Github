using Envision.DataAccess.Common;
using Envision.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Envision.Business.Common
{
    public class EnvComponent
    {
        public EnvComponent()
        {
            Item = new Env();
        }

        private DbEnv env = new DbEnv();
        public Env Item { get; set; }

        public Env GetById()
        {
            env.Item.Id = Item.Id;
            return env.GetById();
        }
    }
}
