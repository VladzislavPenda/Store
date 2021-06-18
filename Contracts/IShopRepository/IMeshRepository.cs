using Entities.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.IShopRepository
{
    public interface IMeshRepository
    {
        void CreateMesh(Mesh mesh);
        void CreateMeshRange(IEnumerable<Mesh> mesh);
    }
}
