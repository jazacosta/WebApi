using Core.Interfaces.Repositories;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using Core.DTOs;
using Core.Requests;
using Core.Entities;


namespace WebApi.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _accountRepository.GetById(id));
        }
    }
}
