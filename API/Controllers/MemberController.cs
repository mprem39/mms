using System;
using System.Threading.Tasks;
using API.Dtos;
using API.Helpers;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
    public class MemberController: ControllerBase
    {
        
        private readonly IMemberRepository _repo;
        public MemberController(IMemberRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("GetPointsdetails")]
        public  IActionResult GetPointsdetails([FromQuery]MemberParams memberParams)
        {
            var ownpoints = _repo.GetMemberIndividualPoints(memberParams.MemberId);
            var teamPoints= _repo.GetMemberTeamPoints(memberParams.TeamLeadId);
            var totalPoints=ownpoints+teamPoints;
            PointsToReturnDto pointsToReturnDto=new PointsToReturnDto();
             pointsToReturnDto.IndividualPoints=ownpoints;
             pointsToReturnDto.TeamPoints=teamPoints;
             pointsToReturnDto.TotalPoints=totalPoints;
            if (pointsToReturnDto == null) return NotFound();
            return Ok(pointsToReturnDto);
        }

       
       [HttpPost("addmember")]
        public async Task<IActionResult> AddMember([FromBody]Member member)
        {
             _repo.Add(member);

             if (await _repo.SaveAll())
                return NoContent();
            throw new Exception("Creating the message failed on save");
           
        }

         [HttpPost("addpoint")]
        public async Task<IActionResult> AddPoint([FromBody]Point point)
        {
            _repo.Add(point);

             if (await _repo.SaveAll())
                return NoContent();
            throw new Exception("Creating the message failed on save");
           
        }

    }
}