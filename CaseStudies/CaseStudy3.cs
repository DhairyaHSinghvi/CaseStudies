using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CaseStudies
{
    class CaseStudy3
    {
        static void Main(string [] args)
        {
            Console.WriteLine("Admin or Student ?");
            int visitor = Convert.ToInt32(Console.ReadLine());

            switch(visitor)
            {
                case 1:
                    {
                        break;
                    }


            }

        }

        static void AddStudent()
        {
            Console.WriteLine("Enter the number of Student details you want to enter = ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {

                Console.WriteLine("Enter Student ID - ");
                int sid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Student Name - ");
                string sname = Console.ReadLine();
                Console.WriteLine("Enter Student DOB - ");
                string sdob = Console.ReadLine();
                Console.WriteLine("Enter number of Phone Numbers - ");
                string sphone = Console.ReadLine();

                string constr = "Data Source=DESKTOP-3D1MPLH; database = CsharpCaseStudy; integrated security = true";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmdsp = new SqlCommand("sp_AddStudentsADO", con);
                cmdsp.CommandType = CommandType.StoredProcedure; 
                cmdsp.Parameters.AddWithValue("@sid", sid);
                cmdsp.Parameters.AddWithValue("@sname", sname);
                cmdsp.Parameters.AddWithValue("@sdob", sdob);
                cmdsp.Parameters.AddWithValue("@sphone", sphone);

                SqlDataReader dr = cmdsp.ExecuteReader(); //we use executereader because we have included SELECT statement in SP in SQL Server
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + "---" + dr[1]+"---"+dr[2]+"---"+dr[3]);
                }
                con.Close(); //close connection
            }
        }

        static void AddCourse()
        {
            Console.WriteLine("Enter the number of Course details you want to enter = ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {

                Console.WriteLine("Enter Course ID - ");
                int cid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Course Name - ");
                string cname = Console.ReadLine();
                Console.WriteLine("Enter Course Category (Degree/Diploma) - ");
                string ccategory = Console.ReadLine();
                Console.WriteLine("Enter duration in years - ");
                int cdur = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Course Fee - ");
                decimal cfee = Convert.ToDecimal(Console.ReadLine());

                string constr = "Data Source=DESKTOP-3D1MPLH; database = CsharpCaseStudy; integrated security = true";
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmdsp = new SqlCommand("sp_AddCoursesADO", con);
                cmdsp.CommandType = CommandType.StoredProcedure;
                cmdsp.Parameters.AddWithValue("@cid", cid);
                cmdsp.Parameters.AddWithValue("@cname", cname);
                cmdsp.Parameters.AddWithValue("@ccategory", ccategory);
                cmdsp.Parameters.AddWithValue("@cdur", cdur);
                cmdsp.Parameters.AddWithValue("@cfee", cfee);

                SqlDataReader dr = cmdsp.ExecuteReader(); //we use executereader because we have included SELECT statement in SP in SQL Server
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + "---" + dr[1] + "---" + dr[2] + "---" + dr[3]+" years---"+dr[4]);
                }
                con.Close(); //close connection
            }
        }

        static void AddEnrolls()
        {
            string constr = "Data Source=DESKTOP-3D1MPLH; database = CsharpCaseStudy; integrated security = true";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand dqlcmd2 = new SqlCommand("select * from Students; select * from Courses", con);
            SqlDataAdapter da = new SqlDataAdapter(dqlcmd2);
            DataSet ds = new DataSet();
            da.Fill(ds);
            Console.WriteLine("Displaying Students Table ------");
            foreach (DataRow drow in ds.Tables[0].Rows)
            {
                Console.WriteLine(drow[0] + "----" + drow[1] + "----" + drow[2] + "----" + drow[3]);
            }
            Console.WriteLine("Displaying Courses Table ------");
            foreach (DataRow drow in ds.Tables[1].Rows)
            {
                Console.WriteLine(drow[0] + "----" + drow[1] + "----" + drow[2] + "----" + drow[3] + " years----" + drow[4]);
            }

            Console.WriteLine("Enter the Student ID for enrollment - ");
            int sid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Course ID you want to enroll student in - ");
            int cid = Convert.ToInt32(Console.ReadLine());

            //check using category name
            SqlCommand c = new SqlCommand("sp_CheckEnrollsADO", con);
            c.CommandType = CommandType.StoredProcedure;
            c.Parameters.AddWithValue("@sid", sid);
            //c.Parameters.AddWithValue("@cid", cid);
            int dcount = Convert.ToInt32(c.ExecuteScalar());//get the count of courses student is enrolled into

            if(dcount < 3)
            {
                SqlCommand cmdsp = new SqlCommand("sp_AddEnrollADO", con);
                cmdsp.CommandType = CommandType.StoredProcedure;
                cmdsp.Parameters.AddWithValue("@sid", sid);
                cmdsp.Parameters.AddWithValue("@cid", cid);
                cmdsp.Parameters.AddWithValue("@edate", DateTime.Now);

                SqlDataReader dr = cmdsp.ExecuteReader(); //we use executereader because we have included SELECT statement in SP in SQL Server
                while (dr.Read())
                {
                    Console.WriteLine(dr[0] + "---" + dr[1] + "---" + dr[2]);
                }
            }
            else
            {
                Console.WriteLine("Student is already registered in 3 courses !!");
            }

            

            con.Close();
        }

        

    }
}
