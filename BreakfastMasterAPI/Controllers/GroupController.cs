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
    public class GroupController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGroupService _groupService;

        public GroupController(IMapper mapper, IGroupService groupService)
        {
            _mapper = mapper;
            _groupService = groupService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateGroup(GroupDtoRequest request)
        {
            var group = _mapper.Map<GroupModel>(request);
            try
            {
                await _groupService.CreateGroup(group);
                var response = _mapper.Map<GroupDtoResponse>(group);
                return CreatedAtAction(nameof(GetGroupById), new { id = group.Id }, response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDtoResponse>>> GetGroups()
        {
            try
            {
                var groups = await _groupService.ReadGroups();
                var response = _mapper.Map<IEnumerable<GroupDtoResponse>>(groups);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDtoResponse>> GetGroupById(int id)
        {
            try
            {
                var group = await _groupService.ReadGroup(id);
                if (group == null)
                {
                    return NotFound();
                }
                var response = _mapper.Map<GroupDtoResponse>(group);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGroup(int id, GroupDtoRequest request)
        {
            try
            {
                var newGroup = _mapper.Map<GroupModel>(request);
                await _groupService.UpdateGroup(id, newGroup);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGroup(int id)
        {
            try
            {
                await _groupService.DeleteGroup(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
