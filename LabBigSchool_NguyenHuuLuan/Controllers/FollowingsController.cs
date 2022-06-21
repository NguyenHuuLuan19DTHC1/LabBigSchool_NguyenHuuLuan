using LabBigSchool_NguyenHuuLuan.DTOs;
using LabBigSchool_NguyenHuuLuan.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace LabBigSchool_NguyenHuuLuan.Controllers
{
    public class FollowingsController : ApiController
    {
        // GET: Followings
        private readonly ApplicationDbContext _dbContext;
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(a => a.FollowerId == userId && a.FolloweeId == followingDto.FolloweeId))
                return BadRequest("Following already exist!");
            var folwing = new Following
            {
                FolloweeId = userId,
                FollowerId = followingDto.FolloweeId

            };
            _dbContext.Followings.Add(folwing);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}