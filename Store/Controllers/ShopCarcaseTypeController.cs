using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.CarcaseDTO;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace Store.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopCarcaseTypeController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public ShopCarcaseTypeController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCarcaseTypes()
        {
            var carcases = _repository.ShopCarcaseType.GetAllCarcaseTypes(trackChanges: false);
            var carcasesDTO = _mapper.Map<CarcaseDTO>(carcases);
            return Ok(carcasesDTO);
        }

        [HttpGet("{id}", Name = "CarcaseTypeById")]
        public IActionResult GetCarcase(int id)
        {
            var model = _repository.ShopModel.GetModel(id, trackChanges: false);
            if (model == null)
            {
                return NotFound();
            }

            var carcase = _repository.ShopCarcaseType.GetCarcaseType(model.carcaseTypeId, trackChanges: false);
            var carcaseDTO = _mapper.Map<CarcaseDTO>(carcase);
            return Ok(carcaseDTO);
        }

        [HttpPost]
        public IActionResult CreateCarcase([FromBody]CarcaseForCreationDTO carcaseType)
        {
            if (carcaseType == null)
            {
                return BadRequest("CarcaseForCreationDTO object send from the client was null");
            }

            var carcaseEntity = _mapper.Map<ShopCarcaseType>(carcaseType);
            _repository.ShopCarcaseType.CreateCarcaseType(carcaseEntity);
            _repository.Save();

            var carcaseTypeToReturn = _mapper.Map<CarcaseDTO>(carcaseEntity);
            return CreatedAtRoute("CarcaseTypeById", new { id = carcaseTypeToReturn.id }, carcaseTypeToReturn);
        }
    }
}
