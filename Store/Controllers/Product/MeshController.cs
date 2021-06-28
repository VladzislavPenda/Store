using AutoMapper;
using Contracts;
using Entities.Models.Product;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Server.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class MeshController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public MeshController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(Guid id)
        {

            //Mesh[] existingMeshes = await _repository.Mesh.GetMeshesForModel(id, trackChanges: true);

            //Guid[] entsToAdd = await _repositoryContext.Ents
            //    .Where(e => model.EntsToAdd.Contains(e.Value))
            //    .Select(e => e.Id)
            //    .ToArrayAsync();

            //List<Mesh> meshesToAdd = new List<Mesh>();
            //foreach (var ent in entsToAdd)
            //    meshesToAdd.Add(new Mesh
            //    {
            //        ModelId = id,
            //        EntId = ent
            //    });

            //Guid[] entsToRemove = await _repositoryContext.Ents
            //    .Where(e => model.EntsToRemove.Contains(e.Value))
            //    .Select(e => e.Id)
            //    .ToArrayAsync();

            //List<Mesh> meshesToRemove = new List<Mesh>();
            //foreach (var ent in entsToRemove)
            //    meshesToRemove.Add(new Mesh
            //    {
            //        ModelId = id,
            //        EntId = ent
            //    });

            //_repository.Mesh.CreateMeshRange(meshesToAdd);
            //_repository.Mesh.DeleteMeshRange(meshesToRemove);
            //await _repository.SaveAsync();
            return Ok();
        }
    }
}
