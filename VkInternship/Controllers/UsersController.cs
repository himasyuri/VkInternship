using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VkInternship.Models;
using VkInternship.Requests;
using VkInternship.Services;

namespace VkInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly ICustomLoggerService logger;

        public UsersController(IUserService userService, ICustomLoggerService logger)
        {
            this.userService = userService;
            this.logger = logger;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]AllUsersParametersRequest request)
        {
            try
            {
                var users = await userService.GetAll(request);

                var metadata = new
                {
                    users.TotalCount,
                    users.PageSize,
                    users.CurrentPage,
                    users.TotalPages,
                    users.HasNext,
                    users.HasPrevious
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

                return Ok(users);
            }
            catch (Exception ex) 
            {
                logger.Log(ex);

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var user = await userService.Get(id);

                return Ok(user);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Sequence contains no elements."))
                {
                    return NotFound();
                }
                else
                {
                    logger.Log(ex);

                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserRequest request)
        {
            try
            {
                await userService.Create(request);

                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("exist"))
                {
                    return StatusCode(StatusCodes.Status409Conflict, ex.Message);
                }
                if (ex.Message.Contains("admin"))
                {
                    return StatusCode(StatusCodes.Status409Conflict, ex.Message);
                }
                else
                {
                    logger.Log(ex);

                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await userService.Delete(id);

                return Ok();
            }
            catch (Exception ex) 
            {
                if (ex.Message.Contains("Sequence contains no elements."))
                {
                    return NotFound();
                }
                else
                {
                    logger.Log(ex);

                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }
    }
}
