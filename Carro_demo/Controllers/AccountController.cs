using Microsoft.AspNetCore.Mvc;
using Carro_demo.Model;
using Carro_demo.Service;
using Microsoft.AspNetCore.Authorization;
using Org.BouncyCastle.Asn1.Ocsp;

namespace Carro_demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        public readonly ICrudOperationSL _crudOperationSL;
        private readonly AuthenController authenController;

        public AccountController(ICrudOperationSL crudOperationSL)
        {
            _crudOperationSL = crudOperationSL;
           
        }


        [HttpPost]
        [Route(template: "CreateReacord")]
        public async Task<IActionResult> CreateReacord(CreateUserRequest request)
        {
            CreateUserRespones respones = null;


            try
            {
                respones = await _crudOperationSL.CreateRecord(request);
            }
            catch (Exception ex)
            {
                respones.IsSuccess = false;
                respones.Message = ex.Message;
            }

            return Ok(respones);
        }


        [HttpGet]
        [Route(template: "ReadRecord")]
        public async Task<IActionResult> ReadRecord()
        {

            ReadRecordResponse respones = null;
            try
            {
                respones = await _crudOperationSL.ReadRecord();

            }
            catch (Exception ex)
            {

            }
            return Ok(respones);
        }

        [HttpPost]
        [Route(template: "Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {

            LoginResponse respones = null;
            try
            {
                respones = await _crudOperationSL.Login(request);

            }
            catch (Exception ex)
            {

            }
            return Ok(respones);
        }
    }
}