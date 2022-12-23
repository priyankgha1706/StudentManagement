using StudentAppCore.Core.IRepositories;
using StudentAppCore.Core.IServices;
using StudentAppCore.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCoreApp.Services.Services
{
    public class StudentServices : IServices
    {
        private readonly IRepositories LoginDetails;
        public StudentServices(IRepositories UserDetails)
        {
            LoginDetails = UserDetails;
        }
        public UserLogin newuser(UserLogin model)
        {
            return LoginDetails.newuser(model);

        }
         public List<StudentMarks> StudentList()
        {
           return LoginDetails.StudentList();
        }
        public StudentMarks EditDetails(int id)
        {
            return LoginDetails.EditDetails(id);
        }

        public bool GetStudentRecords(StudentMarks studentDetail)
        {
            return LoginDetails.GetStudentRecords(studentDetail);
        }
    }
}



