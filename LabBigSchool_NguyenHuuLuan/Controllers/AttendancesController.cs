using LabBigSchool_NguyenHuuLuan.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LabBigSchool_NguyenHuuLuan.DTOs;

namespace LabBigSchool_NguyenHuuLuan.Controllers
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var userID = User.Identity.GetUserId();

            if (_dbContext.Attendances.Any(a => a.AttendaneeId == userID && a.CourseId == attendanceDto.CourseId))
            { 
                return BadRequest("The Attendance Already exists!");
            }
            var attendance = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendaneeId = userID
            };
            
            _dbContext.Attendances.Add(attendance);
            _dbContext.SaveChanges();
            
            return Ok();
        }
            
    }
}
