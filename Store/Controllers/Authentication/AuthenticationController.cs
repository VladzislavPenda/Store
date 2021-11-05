﻿using AutoMapper;
using Contracts;
using Entities.DataTransferObjects.UserDto;
using Entities.DataTransferObjects.UserDTO;
using Entities.DataTransferObjects.UserInfo;
using Entities.Models;
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

        [HttpGet("{id}")]
        //[ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> GetUserInfo(string id)
        {
            User user = await _repository.User.GetUser(id, false);
            UserInfoDto dto = _mapper.Map<UserInfoDto>(user);
            return Ok(dto);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> RegisterUser([FromBody] UserForRegistrationDto userForRegistrationDto)
        {
            User user = _mapper.Map<User>(userForRegistrationDto);
            IdentityResult result = await _userManager.CreateAsync(user, userForRegistrationDto.Password);
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
                string code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                string callbackUrl = Url.Action("authentication", "api", new { userId = user.Id, code = code }, protocol: Request.Scheme);
                await emailService.SendEmailAsync(user.Email, "Подтверждение электронной почты", 
                    "Для завершения регистрации перейдите по ссылке:: <a href=\"" + callbackUrl + "\">завершить регистрацию</a>");
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

            string token = await _authManager.CreateToken();

            return Ok(new { token });
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            User user = await _repository.User.GetUser(userId, trackChanges: true);
            user.EmailConfirmed = true;
            await _repository.SaveAsync();
            return View();
        }
    }
}
