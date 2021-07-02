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

    }
}
