using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentAppCore.Core.IServices;
using StudentAppCore.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace StudentDatas.Controllers
{
    public class StudentController : Controller
    {


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLogin userDetails)
        {


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307/api/StudentDataAPI/Login");
                var Posttask = client.PostAsJsonAsync(client.BaseAddress, userDetails);
                Posttask.Wait();
                var result = Posttask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<UserLogin>();
                    readTask.Wait();
                    var resultData = readTask.Result;
                    if (resultData.IsAdmin == true)
                    {
                        HttpContext.Session.SetString("UserId", resultData.UserId.ToString());
                        return RedirectToAction("GetStudentList");
                    }
                    else
                    {
                        HttpContext.Session.SetString("UserId", userDetails.UserId.ToString());
                        return RedirectToAction();
                    }
                }
                return RedirectToAction("GetStudentList");
            }
        }

        [HttpGet]
        public IActionResult GetStudentList()
        {
            IList<StudentMarks>? studentMark = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307/api/StudentDataAPI/GetStudentList");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadFromJsonAsync<IList<StudentMarks>>();
                    readtask.Wait();
                    studentMark = readtask.Result;

                }

            }
            return View(studentMark);
        }




        [HttpGet]

        public IActionResult EditDetails (int? id)
        {
            StudentMarks? resultData = null;
            using (var client= new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44307/api/StudentDataAPI/GetStudentList");
                var responseTask = client.GetAsync(client.BaseAddress);
                responseTask.Wait();
                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadFromJsonAsync<IList<StudentMarks>>();
                    readtask.Wait();
                     resultData = readtask.Result; 
                }

            }
            return View("SaveStudentRecords", resultData);

        }


     

       


    }




  

    
}
            







