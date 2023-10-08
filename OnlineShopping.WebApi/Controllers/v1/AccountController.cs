using AutoMapper;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Data.Entities;
using OnlineShopping.Infrastructure.Interfaces;
using OnlineShopping.WebApi.Models;
using System.Security.Claims;

namespace OnlineShopping.WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/accounts")]
    public class AccountController
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;


        public AccountController(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        #region POST: api/accounts
        [HttpPost]
        public async Task<string> Login(UserModel model)
        {
            if (!string.IsNullOrEmpty(model.Username) && string.IsNullOrEmpty(model.Password))
                return "";

            var user = await _accountRepository.AuthenticateUser(model.Username, model.Password);

            var userModel = _mapper.Map<User, UserModel>(user);

            ClaimsIdentity? identity = null;

            if (userModel != null)
            {
                identity = new ClaimsIdentity(new[]
                {
                   new Claim(ClaimTypes.Name,userModel.Username),
                   new Claim(ClaimTypes.Role,userModel.Role.Name)
                }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                //var login = await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                var credentials = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets {
                    ClientId = "680375243670-vbf8s3dt9k4rig26rchofn3iv16uc07o.apps.googleusercontent.com",
                    ClientSecret = "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"
                }, null, "user", CancellationToken.None).Result;

                return credentials.GetAccessTokenForRequestAsync().Result;
            }

            return "";
        }
        #endregion
    }

}

