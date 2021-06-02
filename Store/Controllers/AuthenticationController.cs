using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.UserDto;
using Entities.DataTransferObjects.UserDTO;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.ActionFilters;
using Store.Server.Extensions;
using System;
using System.Threading.Tasks;

namespace Store.Controllers
{
    [Route("api/authentication")]
    [ApiController]
    
    public class AuthenticationController : Controller
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IAuthenticationManager _authManager;
        public AuthenticationController(IMapper mapper, UserManager<User> userManager, IAuthenticationManager authManager, IRepositoryManager repositoryManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _authManager = authManager;
            _repository = repositoryManager;
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            var user = _mapper.Map<User>(userForRegistrationDto);
            var result = await _userManager.CreateAsync(user, userForRegistrationDto.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return BadRequest(ModelState);
            }
            else
            {
                EmailService emailService = new EmailService();
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                // создаем ссылку для подтверждения
                var callbackUrl = Url.Action("authentication", "api", new { userId = user.Id, code = code },
                           protocol: Request.Scheme);

                
                // отправка письма
                await emailService.SendEmailAsync(user.Email, "Подтверждение электронной почты",
                           "Для завершения регистрации перейдите по ссылке:: <a href=\""
                                                           + callbackUrl + "\">завершить регистрацию</a>");
            }

            await _userManager.AddToRolesAsync(user, userForRegistrationDto.Roles);
            return StatusCode(201);
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Authenticate([FromBody] UserForAuthenticationDto user)
        {
            if (!await _authManager.ValidateUser(user))
            {
                return Unauthorized();
            }

            return Ok(new { Token = await _authManager.CreateToken() });
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            var user = await _repository.User.GetUser(userId, trackChanges: true);
            
            user.EmailConfirmed = true;
            _repository.SaveAsync();
            return View();
        }
    }
}
