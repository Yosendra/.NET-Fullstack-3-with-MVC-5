﻿using System.Web.Http;
using GigHub.Core;
using GigHub.Core.Dtos;
using GigHub.Core.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class AttendancesController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public AttendancesController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        [HttpPost]
        public IHttpActionResult Attend([FromBody] AttendanceDto dto)
        {
            var gigId = dto.GigId;
            var userId = User.Identity.GetUserId();
            var isAttendanceExist = _unitOfWork.Attendances.GetAttendance(gigId, userId) != null;
            
            if (isAttendanceExist)
                return BadRequest("The attendance already exists.");

            var attendance = new Attendance(gigId, userId);
            _unitOfWork.Attendances.Add(attendance);
            _unitOfWork.Complete();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteAttendance(int id)
        {
            var userId = User.Identity.GetUserId();
            var attendance = _unitOfWork.Attendances.GetAttendance(id, userId);

            if (attendance == null)
                return NotFound();

            _unitOfWork.Attendances.Remove(attendance);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
