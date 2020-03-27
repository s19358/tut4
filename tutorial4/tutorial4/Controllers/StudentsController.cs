using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tutorial4.Models;

namespace tutorial4.Controllers
{

    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {

        private string ConnString = "Data Source=db-mssql;Initial Catalog=s19358;Integrated Security=True";

        [HttpGet]
        public IActionResult GetStudents()
        {


            var listStudents = new List<Student>();
            using (SqlConnection con = new SqlConnection(ConnString))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from Student";

                con.Open();
                SqlDataReader dr = com.ExecuteReader();
                while (dr.Read())
                {
                    var student = new Student();

                    student.IndexNumber = dr["IndexNumber"].ToString();
                    student.FirstName = dr["FirstName"].ToString();
                    student.LastName = dr["LastName"].ToString();
                    student.BirthDate = dr["BirthDate"].ToString();
                    student.idEnrollment = dr["idEnrollment"].ToString();




                    listStudents.Add(student);
                }

                return Ok(listStudents);
            }
        }
    }
}