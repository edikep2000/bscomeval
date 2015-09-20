using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.OpenAccess;
using TestApp.Models;

namespace TestApp.Service
{
    public class EntityService : BaseService<Entity>
    {
        public EntityService(OpenAccessContext context) : base(context)
        {
        }
    }
}