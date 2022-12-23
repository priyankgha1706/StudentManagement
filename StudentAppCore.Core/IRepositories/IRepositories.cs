using StudentAppCore.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

 namespace StudentAppCore.Core.IRepositories
{
   public  interface IRepositories
    {
        UserLogin newuser(UserLogin model);
        List<StudentMarks> StudentList();
        StudentMarks EditDetails(int id);
        bool GetStudentRecords(StudentMarks studentDetail);
         



    }
}
