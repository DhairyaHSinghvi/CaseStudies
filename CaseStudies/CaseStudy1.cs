using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace CaseStudies
{
    public class Student
    {
        int id;
        string name;
        string dob;
        static string collegename;
        string[] phoneno = new string[10];

        static Student()
        {
            Collegename = "StaticCollegeName";
        }

        public Student() { }
        public Student(int id, string name, string dob, string[] phone)
        {
            this.id = id;
            this.name = name;
            this.dob = dob;
            this.phoneno = phone;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Dob { get => dob; set => dob = value; }
        public static string Collegename { get => collegename; set => collegename = value; }
        public string[] Phoneno { get => phoneno; set => phoneno = value; }
    }

    class Info
    {
        public void Display(Student student)
        {
            Console.WriteLine("\n-------Student Details-------");
            Console.WriteLine("Student ID = " + student.Id);
            Console.WriteLine("Student Name = " + student.Name);
            Console.WriteLine("Student DOB = " + student.Dob);
            Console.WriteLine("Student College = " + Student.Collegename); //static variable is accessed with Class name and NOT Object name

            foreach (string x in student.Phoneno)
            {
                Console.WriteLine("Student Phone Number = " + x);
            }

            //Console.WriteLine("Student Phone Number = "+String.Join("",student.Phoneno));

        }

        public void Display(Course course)
        {
            Console.WriteLine("------Details------");
            Console.WriteLine("Course ID = " + course.Courseid);
            Console.WriteLine("Course Name = " + course.Coursename);
            Console.WriteLine("Course Duration = " + course.Courseduration + " months");
            Console.WriteLine("Course Fees = " + course.Coursefees);
        }
    }

    class Case1App
    {
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("Select the Scenerio : 1, 2, 3, 4 | Click 0 to exit \n");
                choice = Convert.ToInt32(Console.ReadLine());

                switch(choice)
                {
                    case 1:
                        {
                            Scenerio1();
                            break;
                        }

                    case 2:
                        {
                            Scenerio2();
                            break;
                        }
                    case 3:
                        {
                            Scenerio3();
                            break;
                        }
                    case 4:
                        {
                            Scenerio4();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Enter correct value !");
                            break;
                        }
                }

            } while (choice!=0);

        }

        static void Scenerio1()
        {
            Console.WriteLine("--------- Scenerio 1 -------");
            Student sobj1 = new Student(1, "John", "2000-09-13", new string[] { "9765678765" });
            Student sobj2 = new Student(2, "Andrew", "1999-12-1", new string[] { "9776978765" });
            Student sobj3 = new Student(3, "Bobby", "2001-03-20", new string[] { "9761142765" });

            Info infoobj = new Info();
            infoobj.Display(sobj1);
            infoobj.Display(sobj2);
            infoobj.Display(sobj3);

        }

        static void Scenerio2()
        {
            Console.WriteLine("--------- Scenerio 2-------");
            Student[] sobj = new Student[]{
                    new Student(1, "John", "2000-09-13", new string[] { "9765678765" }),
                    new Student(2, "Andrew", "1999-12-1", new string[] { "9776978765" }),
                    new Student(3, "Bobby", "2001-03-20", new string[] { "9761142765" }) };

            Info infoobj = new Info();
            foreach (Student o in sobj)
            {
                infoobj.Display(o);
            }

        }

        static void Scenerio3()
        {
            Console.WriteLine("--------- Scenerio 3-------");

            Console.WriteLine("Enter the number of Student details you want to enter = ");
            int n = Convert.ToInt32(Console.ReadLine());
            Student[] sobj = new Student[n];
            for (int i = 0; i < n; i++)
            {

                Console.WriteLine("Enter Student ID - ");
                int sid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Student Name - ");
                string sname = Console.ReadLine();
                Console.WriteLine("Enter Student DOB - ");
                string sdob = Console.ReadLine();

                Console.WriteLine("Enter number of Phone Numbers - ");
                int p = Convert.ToInt32(Console.ReadLine());
                string[] sphone = new string[p];
                for (int j = 0; j < p; j++)
                {
                    sphone[j] = Console.ReadLine();
                }


                sobj[i] = new Student(sid, sname, sdob, sphone);

            }

            Info infoobj = new Info();
            foreach (Student s in sobj)
            {
                infoobj.Display(s);
            }

        }

        static void Scenerio4()
        {
            Console.WriteLine("--------- Scenerio 4-------");

            Console.WriteLine("Enter the number of Student details you want to enter = ");
            int n = Convert.ToInt32(Console.ReadLine());
            ArrayList st = new ArrayList();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter Student ID - ");
                int sid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Student Name - ");
                string sname = Console.ReadLine();
                Console.WriteLine("Enter Student DOB - ");
                string sdob = Console.ReadLine();

                Console.WriteLine("Enter number of Phone Numbers - ");
                int p = Convert.ToInt32(Console.ReadLine());
                string[] sphone = new string[p];
                for (int j = 0; j < p; j++)
                {
                    sphone[j] = Console.ReadLine();
                }

                Student s = new Student(sid, sname, sdob, sphone);
                st.Add(s);
            }

            Info infoobj = new Info();
            foreach (Student s in st)
            {
                infoobj.Display(s);
            }

        }
    }



    class Course
    {
        int courseid;
        string coursename;
        int courseduration;
        decimal coursefees;

        public Course() { }
        public Course(int courseid, string coursename, int courseduration, decimal coursefees)
        {
            this.Courseid = courseid;
            this.Coursename = coursename;
            this.Courseduration = courseduration;
            this.Coursefees = coursefees;
        }

        public int Courseid { get => courseid; set => courseid = value; }
        public string Coursename { get => coursename; set => coursename = value; }
        public int Courseduration { get => courseduration; set => courseduration = value; }
        public decimal Coursefees { get => coursefees; set => coursefees = value; }


    }

    class CaseStudy1
    {
        static void Main()
        {
            Console.WriteLine("Enter Course ID - ");
            int cid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Course Name - ");
            string cname = Console.ReadLine();
            Console.WriteLine("Enter Course Duration in months - ");
            int cdur = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Course Fees - ");
            decimal cfee = Convert.ToDecimal(Console.ReadLine());

            Course c = new Course(cid, cname, cdur, cfee);
            Info i = new Info();
            i.Display(c);
        }
    }

}