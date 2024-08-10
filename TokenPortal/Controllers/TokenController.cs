using Microsoft.AspNetCore.Mvc;
using TokenPortal.Entities;
using TokenPortal.Interface;

namespace TokenPortal.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet]
        public ActionResult<List<Token>> Get()
        {
            var tokens = _tokenService.GetTokens();
            return Ok(tokens);
        }

        [HttpPut]
        public ActionResult Update([FromBody] Token token)
        {
            _tokenService.UpdateToken(token);
            return NoContent();
        }
    }
}
