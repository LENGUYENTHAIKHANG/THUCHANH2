using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace LeNguyenThaiKhang_5951071043.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string f_name { get; set; }
        public string m_name { get; set; }
        public string l_name { get; set; }
        public string address { get; set; }
        public string birthday { get; set; }
        public string score { get; set; }
        public string dep_id { get; set; }

    }
    public class ReadStudent : Student
    { public ReadStudent(DataRow row)
        {
            Id = Convert.ToInt32(row["Id"]);
            f_name = row["f_name"].ToString();
            m_name = row["m_name"].ToString();
            l_name = row["l_name"].ToString();
            address = row["address"].ToString();
            birthday = row["birthday"].ToString();
            dep_id = row["dep_id"].ToString();

        }

        }
public class CreateStudent: Student
    {

    }
}