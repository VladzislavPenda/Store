using Contracts;
using Entities.Models;
using Entities.Models.Product;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public async Task<IActionResult> Index()
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

        [HttpPost("image/{id}")]
        public async Task<IActionResult> uploadImage([FromForm] IFormFile file, Guid id)
        {
            ShopModel model = await _repository.ShopModel.GetModelAsync(id, true);
            if (model == null)
            {
                return NotFound();
            }

            if (file != null)
            {
                string fileType;

                switch(file.ContentType)
                {
                    case "image/jpeg": fileType = ".jpg"; break;
                    case "image/png": fileType = ".png"; break;
                    default: return Problem("Unsupported file format (supported formats: PNG, JPG)");
                }

                Guid newFileId = Guid.NewGuid();
                string path = "File/images/" + newFileId + fileType;
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                Ent ent = new Ent
                {
                    Id = newFileId,
                    Value = newFileId + ".jpg",
                    Type = EntType.Picture,
                };

                Mesh mesh = new Mesh
                {
                    EntId = newFileId,
                    ModelId = id,
                };

                _repository.Ent.CreateEnt(ent);
                _repository.Mesh.CreateMesh(mesh);
                await _repository.SaveAsync();
                return CreatedAtAction("Post image", newFileId);
            }
            else
            {
                return Problem("There is no file to upload", statusCode: StatusCodes.Status400BadRequest);
            }
        }

        [HttpGet("model/image/{imageId}")]
        public async Task<IActionResult> downloadImage(Guid imageId)
        {
            Ent ent = await _repository.Ent.GetEntById(imageId);

            if (ent == null)
                return NotFound();

            string filePath = Path.Combine(_appEnvironment.ContentRootPath, "File", "images", ent.Value);
            filePath = Path.GetFullPath(filePath);
            if (System.IO.File.Exists(filePath))
            {
                return PhysicalFile(filePath, "image/jpeg", ent.Value);
            }

            return NotFound();
            
        }
    }
}
