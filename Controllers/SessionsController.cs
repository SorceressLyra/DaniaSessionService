using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DaniaSessionService
{

    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {

        [HttpGet("Verify")]
        public IActionResult AuthorizationTest(string endpoint)
        {
            if (!SessionStorage.Sessions.ContainsValue(endpoint))
                return NotFound($"No user session found for ip:{endpoint}");

            return Ok(SessionStorage.Sessions.FirstOrDefault(x => x.Value == endpoint).Key);
        }


        [HttpPost("Add")    ]
        public IActionResult AddSession(string username, string endpoint)
        {
            if (SessionStorage.Sessions.ContainsKey(username))
                return BadRequest($"Session already created for {username}");
            ;
            SessionStorage.Add(username, endpoint);
            return Ok($"Session created for {username} at ip:{endpoint}");
        }

        [HttpPost("Remove")]
        public IActionResult RemoveSession(string username)
        {
            if (!SessionStorage.Sessions.ContainsKey(username))
                return NotFound($"No sessions found for user: {username}");


            SessionStorage.Remove(username);
            return Ok($"Removed session from user: {username}");
        }


        [HttpGet("All")]
        public IActionResult GetSessions()
        {
            return Ok(SessionStorage.Sessions);
        }
    }
}
