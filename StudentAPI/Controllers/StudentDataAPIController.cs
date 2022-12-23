using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAppCore.Core.IServices;
using StudentAppCore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentDataAPIController : Controller
    {
        private IServices _Iservice;

        public StudentDataAPIController(IServices Iservices)
        {
            _Iservice = Iservices;
        }

        #region
        [HttpGet]
        public IActionResult Login()
        {
            return Ok();
        }
        [HttpPost]
        public IActionResult Login(UserLogin userDetails)
        {
            UserLogin newuser = _Iservice.newuser(userDetails);
            return Ok(newuser);
        }
        #endregion

        #region
        [HttpGet]
        public IActionResult GetStudentList()
        {
            List<StudentMarks> List = new List<StudentMarks>();
                List = _Iservice.StudentList();
                return Ok(List);
        }
        #endregion


        #region
        [HttpGet]
        public IActionResult GetStudentRecords(int? id)
        {
            StudentMarks studentvalue = new StudentMarks();
            studentvalue = _Iservice.GetStudentRecords(id);
            return Ok(studentvalue);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="studentDetail"></param>
        /// <returns></returns>
        #region
        [HttpPost]
        public ActionResult SaveStudentRecords(StudentMarks studentDetail)
        {
            bool isRecordSaved = _Iservice.SaveStudentRecords(studentDetail);
            if (isRecordSaved)
            {
                return RedirectToAction("GetStudentList");
            }
            return View();

        }
        #endregion




    }

}

