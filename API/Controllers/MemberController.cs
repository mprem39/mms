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

        [HttpGet("getpointdetails")]
        public  IActionResult GetPointsdetails([FromQuery]MemberParams memberParams)
        {
            var ownpoints = _repo.GetMemberIndividualPoints(memberParams.MemberId);
            var teamPoints= _repo.GetMemberTeamPoints(memberParams.MemberId,memberParams.TeamLeadId);
            PointsToReturnDto pointsToReturnDto=new PointsToReturnDto();
             pointsToReturnDto.IndividualPoints=ownpoints;
             pointsToReturnDto.TeamPoints=teamPoints;
             if (pointsToReturnDto == null) return NotFound();
            return Ok(pointsToReturnDto);
        }

        [HttpGet("getallmembers")]
        public  IActionResult GetMembers()
        {
            var members=_repo.GetMembers();
            if (members == null) return NotFound();
            return Ok(members);
        }
        
       
       [HttpPost("addmember")]
        public async Task<IActionResult> AddMember([FromBody]Member member)
        {
             _repo.Add(member);

             if (await _repo.SaveAll())
                return NoContent();
            throw new Exception("Creating the member failed on save");
           
        }

         [HttpPost("addpoint")]
        public async Task<IActionResult> AddPoint([FromBody]Point point)
        {
            _repo.Add(point);

             if (await _repo.SaveAll())
                return NoContent();
            throw new Exception("Creating the point failed on save");
           
        }

    }
}