using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.CloudServices.Interfaces
{
    public interface IFileStoreService
    {
        void UploadFile(byte[] bytes, string fileName);
    }
}
