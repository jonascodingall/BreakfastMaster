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
    public class BreadRollController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBreadRollService _breadRollService;

        public BreadRollController(IMapper mapper, IBreadRollService breadRollService)
        {
            _mapper = mapper;
            _breadRollService = breadRollService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateBreadRoll(BreadRollDtoRequest request)
        {
            var breadRoll = _mapper.Map<BreadRollModel>(request);
            try
            {
                await _breadRollService.CreateBreadRoll(breadRoll);
                var response = _mapper.Map<BreadRollDtoResponse>(breadRoll);
                return CreatedAtAction(nameof(GetBreadRollById), new { id = breadRoll.Id }, response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BreadRollModel>>> GetBreadRolls()
        {
            try
            {
                var breadRolls = await _breadRollService.ReadBreadRoll();
                var response = _mapper.Map<IEnumerable<BreadRollDtoResponse>>(breadRolls);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BreadRollModel>> GetBreadRollById(int id)
        {
            try
            {
                var breadRoll = await _breadRollService.ReadBreadRolls(id);
                if (breadRoll == null)
                {
                    return NotFound();
                }
                var response = _mapper.Map<BreadRollDtoResponse>(breadRoll);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBreadRoll(int id, BreadRollDtoRequest request)
        {
            try
            {
                var newBreadRoll = _mapper.Map<BreadRollModel>(request);
                await _breadRollService.UpdateBreadRoll(id, newBreadRoll);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBreadRoll(int id)
        {
            try
            {
                await _breadRollService.DeleteBreadRoll(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
