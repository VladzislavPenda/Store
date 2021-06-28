using Contracts.IShopRepository;
using Entities;
using Entities.Models.Product;
using Microsoft.EntityFrameworkCore;
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
            CreateRange(meshes);
        }

        public void DeleteMeshRange(IEnumerable<Mesh> meshes)
        {
            DeleteRange(meshes);
        }

        public async Task<Mesh[]> GetMeshesForModel(Guid modelId, bool trackChanges)
        {
            return await FindByCondition(e => e.ModelId == modelId, trackChanges).ToArrayAsync(); 
        }
    }
}
