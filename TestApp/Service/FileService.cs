using Telerik.OpenAccess;
using TestApp.Models;

namespace TestApp.Service
{
    public class FileService : BaseService<Files>
    {
        public FileService(OpenAccessContext context) : base(context)
        {
        }
    }
}