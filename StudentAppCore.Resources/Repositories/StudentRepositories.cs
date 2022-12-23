using StudentAppCore.Core.IRepositories;
using StudentAppCore.Core.Models;
using StudentAppCore.Entity.Student_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentAppCore.Resources.Repositories
{
    public class StudentRepositories : IRepositories
    {


        #region
        public UserLogin newuser(UserLogin model)
        {
            UserLogin userDetails = null;

            if (model != null)
            {
                using (var entity = new Student_ManagementContext())
                {
                    var dbdetails = entity.User_Login.Where(x => x.User_Name == model.UserName && !x.Is_Deleted).SingleOrDefault();
                    if (dbdetails != null)
                    {
                        if (dbdetails.Password == model.Password)
                        {
                            userDetails = new UserLogin();
                            userDetails.IsAdmin = dbdetails.Is_Admin;
                            userDetails.UserId = dbdetails.User_Id;
                            userDetails.UserName = "";
                            userDetails.Password = "";
                            return userDetails;
                        }


                    }
                }

            }
            return userDetails;
        }
        #endregion


        #region
        public List<StudentMarks> StudentList()
        {
            List<StudentMarks> studentMarks = new List<StudentMarks>();
            {
                using (var entity = new Student_ManagementContext())
                {
                    var dbdetails = entity.Student_Marks.Where(x => !x.Is_Deleted).ToList();
                    if (dbdetails != null && dbdetails.Count > 0)
                    {
                        foreach (var item in dbdetails)
                        {
                            StudentMarks newstudent = new StudentMarks();
                            newstudent.StdId = item.Std_Id;
                            newstudent.RollNo = item.Roll_No;
                            newstudent.Name = item.Name;
                            newstudent.OS = item.OS;
                            newstudent.DBMS = item.DBMS;
                            newstudent.JAVA = item.JAVA;
                            newstudent.PYTHON = item.PYTHON;
                            newstudent.CS = item.CS;
                            newstudent.Total = item.Total;
                            newstudent.Average = item.Average;
                            studentMarks.Add(newstudent);
                        }
                    }
                }
            }
            return studentMarks;
        }
        #endregion



        
        public StudentMarks GetStudentRecords(int? id)
        {
            StudentMarks studentValue = null;
            if (id != null && id > 0)
            {
                studentValue = new StudentMarks();
                using (var entity = new Student_ManagementContext())
                {
                    var dbdetails = entity.Student_Marks.Where(x => x.User_Id == id).SingleOrDefault();
                    if (dbdetails != null)
                    {
                        studentValue.StdId = dbdetails.Std_Id;
                        studentValue.RollNo = dbdetails.Roll_No;
                        studentValue.Name = dbdetails.Name;
                        studentValue.OS = dbdetails.OS;
                        studentValue.DBMS = dbdetails.DBMS;
                        studentValue.JAVA = dbdetails.JAVA;
                        studentValue.PYTHON = dbdetails.PYTHON;
                        studentValue.CS = dbdetails.CS;
                    }
                }

            }
            return studentValue;
        }


        public bool SaveStudentRecords(StudentMarks studentDetail)

        {
            bool recordSaved = false;
            if (studentDetail != null)
            {
                using (var entity = new Student_ManagementContext())
                {
                    bool isRecordExist = false;
                    Student_Marks entityclass = null;
                    entityclass = entity.Student_Marks.Where(x => x.Std_Id == studentDetail.StdId && !x.Is_Deleted).SingleOrDefault();
                    if (entityclass != null)
                    {
                        isRecordExist = true;
                    }
                    else
                    {
                        entityclass = new Student_Marks();
                    }

                    entityclass.Roll_No = studentDetail.RollNo;
                    entityclass.Name = studentDetail.Name;
                    entityclass.OS = studentDetail.OS;
                    entityclass.DBMS = studentDetail.DBMS;
                    entityclass.CS = studentDetail.CS;
                    entityclass.JAVA = studentDetail.JAVA;
                    entityclass.PYTHON = studentDetail.PYTHON;
                    entityclass.Total = studentDetail.OS + studentDetail.DBMS + studentDetail.CS + studentDetail.JAVA + studentDetail.PYTHON;
                    entityclass.Average = (entityclass.Total / 5);
                    entityclass.Update_Time_Stamp = DateTime.Now;
                    if (isRecordExist == false)
                    {
                        entityclass.Is_Deleted = false;
                        entityclass.Create_Time_Stamp = DateTime.Now;
                        entity.Student_Marks.Add(entityclass);
                    }

                    entity.SaveChanges();

                    recordSaved = true;
                }
            }
            return recordSaved;
        }



    }
}











