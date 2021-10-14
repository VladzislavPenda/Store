using Contracts;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : Controller
    {
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IRepositoryManager _repository;
        HttpClient http = new HttpClient();

        public FileController(IWebHostEnvironment appEnvironment, IRepositoryManager repository)
        {
            _appEnvironment = appEnvironment;
            _repository = repository;
        }
        [HttpGet]
        public async Task<FileResult> Index()
        {
            ShopModel[] allModels = await _repository.ShopModel.GetAllShopModelsAsync(false);
            StringBuilder sb = new StringBuilder();
            sb.Append($"Общее количество авто: {allModels.Length}\n");
            foreach(ShopModel model in allModels)
            {
                string modelInfo = $"{model.Model}\n" +
                    $"  Стоимость: {model.Price}\n" +
                    $"  Год производства: {model.Year}\n" +
                    $"  Местонахождение: {model.Storage.Address}\n";
                sb.Append(modelInfo);
            }

            string file_path = Path.Combine(_appEnvironment.ContentRootPath, "File/text.txt");
            string writePath = "File/text.txt";
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(sb);
            }
            
            string file_type = "text/plain";
            string file_name = "text.txt";
            return PhysicalFile(file_path, file_type, file_name);
        }
    }
}
