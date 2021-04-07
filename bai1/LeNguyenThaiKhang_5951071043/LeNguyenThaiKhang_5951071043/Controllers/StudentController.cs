using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.SqlClient;
using LeNguyenThaiKhang_5951071043.Models;
using System.Data;

namespace LeNguyenThaiKhang_5951071043.Controllers
{
    public class StudentController : ApiController
    {
        private SqlConnection _conn;

        private SqlDataAdapter _adepter;
        // GET api/<controller>
        public IEnumerable<Student> Get()
        {
            _conn = new SqlConnection("Data Source=DESKTOP-G0PNN12;Initial Catalog=Nawab;Integrated Security=True");
            DataTable _dt = new DataTable();
            var query = "select * from Student";
            _adepter = new SqlDataAdapter
            {
                SelectCommand = new SqlCommand(query, _conn)
            };
            _adepter.Fill(_dt);
            List<Student> student = new List<Models.Student>(_dt.Rows.Count);
            if (_dt.Rows.Count > 0)
            {
                foreach (DataRow studentReocord in _dt.Rows)
                {
                    student.Add(new ReadStudent(studentReocord));
                }
            }



            return student;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public string Post([FromBody] CreateStudent value)
        {
            _conn = new SqlConnection("Data Source=DESKTOP-G0PNN12;Initial Catalog=Nawab;Integrated Security=True");
            var query = "insert into Student(f_name,m_name,l_name,address,birthday,score)values(@f_name,@m_name,@l_name,@address,@birthday,@score)";
            SqlCommand insertcommand = new SqlCommand(query, _conn);
            insertcommand.Parameters.AddWithValue("@f_name", value.f_name);
            insertcommand.Parameters.AddWithValue("@m_name", value.m_name);
            insertcommand.Parameters.AddWithValue("@l_name", value.l_name);
            insertcommand.Parameters.AddWithValue("@address", value.address);
            insertcommand.Parameters.AddWithValue("@birthday", value.birthday);
            insertcommand.Parameters.AddWithValue("@score", value.score);


            _conn.Open();
            int result = insertcommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "thêm thành công";

            }
            else
            {
                return "thêm thất bại";
            }
        }

        // PUT api/<controller>/5
        public string Put(int id, [FromBody] CreateStudent value)
        {

            _conn = new SqlConnection("Data Source=DESKTOP-G0PNN12;Initial Catalog=Nawab;Integrated Security=True");
            var query = "update Student set f_name=@f_name,m_name=@m_name,l_name=@l_name,address=@address,birthday=@birthday,score=@score where id=" + id;
            SqlCommand insertcommand = new SqlCommand(query, _conn);
            insertcommand.Parameters.AddWithValue("@f_name", value.f_name);
            insertcommand.Parameters.AddWithValue("@m_name", value.m_name);
            insertcommand.Parameters.AddWithValue("@l_name", value.l_name);
            insertcommand.Parameters.AddWithValue("@address", value.address);
            insertcommand.Parameters.AddWithValue("@birthday", value.birthday);
            insertcommand.Parameters.AddWithValue("@score", value.score);


            _conn.Open();
            int result = insertcommand.ExecuteNonQuery();
            if (result > 0)
            {
                return "update thành công";

            }
            else
            {
                return "update thất bại";
            }
        }
    

    // DELETE api/<controller>/5
    public string Delete(int id)
    {
        _conn = new SqlConnection("Data Source=DESKTOP-G0PNN12;Initial Catalog=Nawab;Integrated Security=True");
        var query = "delete from Student where id=" + id;
        SqlCommand insertcommand = new SqlCommand(query, _conn);



        _conn.Open();
        int result = insertcommand.ExecuteNonQuery();
        if (result > 0)
        {
            return "detele thành công";

        }
        else
        {
            return "delete thất bại";
        }
    }
}
}
    
