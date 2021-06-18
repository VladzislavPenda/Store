using Contracts.IShopRepository;
using Entities;
using Entities.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.ShopRepository
{
    public class MeshRepository : RepositoryBase<Mesh>, IMeshRepository
    {
        private readonly RepositoryContext repository;
        public MeshRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            repository = repositoryContext;
        }

        public void CreateMesh(Mesh mesh) 
        {
            Create(mesh);
        }

        public async void CreateMeshRange(IEnumerable<Mesh> meshes)
        {
            await repository.AddRangeAsync(meshes);
        }
    }
}
