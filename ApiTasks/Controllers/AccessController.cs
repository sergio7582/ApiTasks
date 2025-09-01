using ApiTasks.Common;
using ApiTasks.DataBase;
using ApiTasks.DTOs;
using ApiTasks.DTOs.Access;
using ApiTasks.Interfaces.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiTasks.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AccessController(Utilitys utilitys, IPostService postService, IGetService getService) : ControllerBase
    {
        private readonly Utilitys _utilitys = utilitys;
        private readonly IPostService _postService = postService;
        private readonly IGetService _getService = getService;

        [HttpPost]
        [Route("CheckIn")]
        public async Task<IActionResult> CheckIn([FromBody] UsuarioDTO usuario)
        {

            if (usuario == null)
                return Ok(_utilitys.GetResponse(Message: "Usuario data is null",Success: false, StatusCode: 400));

            //Check if the username not duplicate
            int IdUser = await _getService.GetUserByName(UserName: usuario.Username);
            if (IdUser != 0)
                return Ok(_utilitys.GetResponse(Message: "Username already use", Success: false,StatusCode: 409, Data: usuario));

            TUser user = await _postService.CheckIn(usuario);
            if (user.Id == 0)
                return Ok(_utilitys.GetResponse(Message: "A ocurred error to create", Success: false, StatusCode: 400));

            return Ok(_utilitys.GetResponse(Message: "User created succesfuly", Success: true,StatusCode: 201, Data: user));
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto usuario)
        {
            UsuarioView UserData = await _getService.Login(usuario);
            if (UserData != null)
                return Ok(_utilitys.GetResponse(Message: "User found", Success: true, StatusCode: 200, Data: new { user = UserData, token = _utilitys.GenerateToken(UserData) }));
            
                

            return Ok(_utilitys.GetResponse(Message: "User not found", Success: false,StatusCode: 401, Errors: new { details = "User or password incorrect" }));
        }
    }
}
