using System;
using System.Collections.Generic;
using System.Linq;
using CW_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace CW_3.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        List<Student> students = new List<Student>();

        public StudentsController()
        {
            var studentStrings = System.IO.File.ReadAllLines(@"Data/students.csv");
            foreach (var studentString in studentStrings)
            {
                var student = studentString.Split(',');
                students.Add(new Student
                {
                    FirstName = student[0],
                    LastName = student[1],
                    IndexNumber = student[2],
                    DateOFBirth = student[3],
                    Studies = student[4],
                    Form = student[5],
                    Email = student[6],
                    FatherName = student[7],
                    MotherName = student[8]
                }); ;
            }
        }
        // api/students/{indexNumber}
        [HttpGet("{indexNumber}")]
        public IActionResult GetStudent(string indexNumber)
        {
            var res = students.Where(st => st.IndexNumber == indexNumber).FirstOrDefault();
            return Ok(res.ToString());
        }

        [HttpGet]
        public IActionResult GetStudents(string orderBy)
        {
            string res = "";
            students.ForEach(st => res += st.ToString());
            return Ok(res);
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (student.FirstName == null || student.LastName == null || student.DateOFBirth == null || student.Studies == null || student.Form == null || student.Email == null || student.FatherName == null || student.MotherName == null)
            {
                return Problem(" Nie wszystkie dane na temat studenta są kompletne");
            }
            student.IndexNumber = $"s{new Random().Next(1, 20000)}";
            students.Add(student);
            return Ok(student);
        }

        [HttpPut("{indexNumber}")]
        public IActionResult UpdateStudent(string indexNumber)
        {
            return Ok("Student was updated");
        }

        [HttpDelete("{indexNumber}")]
         public IActionResult DeleteStudent(string indexNumber )
        {
            string res = " ";
            
            students.ForEach(st => res += st.ToString().Remove)
            if (res != null)
            {
                return Ok(res);
            }

              return NotFound("You can not delete this student");

        }


    }
}
