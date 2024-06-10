using AutoMapper;
using BreakfastMasterAPI.Dtos.Requests;
using BreakfastMasterAPI.Dtos.Responses;
using BreakfastMasterAPI.Models;
using BreakfastMasterAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BreakfastMasterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IBreadRollService _breadRollService;

        public UserController(IMapper mapper, IUserService userService, IBreadRollService breadRollService)
        {
            _mapper = mapper;
            _userService = userService;
            _breadRollService = breadRollService;
        }

        // CRUD
        [HttpPost]
        public async Task<ActionResult> CreateUser(UserDtoRequest request)
        {
            var user = _mapper.Map<UserModel>(request);
            try
            {
                await _userService.CreateUser(user);
                var response = _mapper.Map<UserDtoResponse>(user);
                return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDtoResponse>>> GetUsers()
        {
            try
            {
                var users = await _userService.ReadUsers();
                var response = _mapper.Map<IEnumerable<UserDtoResponse>>(users);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDtoResponse>> GetUserById(int id)
        {
            try
            {
                var user = await _userService.ReadUser(id);
                if (user == null)
                {
                    return NotFound();
                }
                var response = _mapper.Map<UserDtoResponse>(user);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UserDtoRequest request)
        {
            try
            {
                var newUser = _mapper.Map<UserModel>(request);
                await _userService.UpdateUser(id, newUser);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // ADD REMOVE BREADROLL
        [HttpPost("{userId}/BreadRoll/{breadRollId}")]
        public async Task<ActionResult> AddBreadRollToUser(int userId, int breadRollId)
        {
            try
            {
                await _userService.AddBreadRollToUser(userId, breadRollId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{userId}/BreadRoll/{breadRollId}")]
        public async Task<ActionResult> RemoveBreadRollFromUser(int userId, int breadRollId)
        {
            try
            {
                await _userService.RemoveBreadRollFromUser(userId, breadRollId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
