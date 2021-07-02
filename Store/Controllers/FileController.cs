using Microsoft.AspNetCore.Mvc;
using Contracts;
using AutoMapper;
using Contracts.DataShape;
using Entities.DataTransferObjects.IncludeDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting; // для IWebHostEnvironment
using System.IO;
using Entities.RequestFeatures;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Collections;
using Entities.Models;
using System.Collections.Generic;
using System.Net.Http;
using System;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IDataShaper<ModelFullInfo> _dataShaper;
        HttpClient http = new HttpClient();

        public FileController(IWebHostEnvironment appEnvironment, IRepositoryManager repository, IMapper mapper, IDataShaper<ModelFullInfo> dataShaper)
        {
            _repository = repository;
            _mapper = mapper;
            _appEnvironment = appEnvironment;
            _dataShaper = dataShaper;
        }
        [HttpGet]
        public async Task<FileResult> Index()
        {
            var requestMessage = new HttpRequestMessage()
            {
                Method = new HttpMethod("GET"),
                RequestUri = new Uri("https://localhost:44320/api/shopModels?pageSize=60")
            };
            requestMessage.Headers.Add("Accept", "text/xml");
            var response = await http.SendAsync(requestMessage);
            var responseBody = await response.Content.ReadAsStringAsync();
            string file_path = Path.Combine(_appEnvironment.ContentRootPath, "File/text.txt");
            string writePath = "File/text.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                
                sw.WriteLine(responseBody);
            }
            
            string file_type = "text/plain";
            string file_name = "text.txt";
            return PhysicalFile(file_path, file_type, file_name);
        }
    }
}
