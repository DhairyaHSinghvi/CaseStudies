using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CaseStudies
{

    public class Course2
    {
        int courseid;
        string coursename;
        int courseduration;
        float coursefees;

        public Course2() { }
        public Course2(int courseid, string coursename, int courseduration, float coursefees)
        {
            this.Courseid = courseid;
            this.Coursename = coursename;
            this.Courseduration = courseduration;
            this.Coursefees = coursefees;
        }

        public int Courseid { get => courseid; set => courseid = value; }
        public string Coursename { get => coursename; set => coursename = value; }
        public int Courseduration { get => courseduration; set => courseduration = value; }
        public float Coursefees { get => coursefees; set => coursefees = value; }


        public virtual void CalculateMonthlyFee()
        {
            coursefees = coursefees + ((float)0.18 * coursefees);
        }
    }

    class DegreeCourse : Course2
    {
        public enum level { bachelors, masters };
        bool IsPlacementAvailable;


        public DegreeCourse() { }
        public bool IsPlacementAvailable1 { get => IsPlacementAvailable; set => IsPlacementAvailable = value; }

        public DegreeCourse(bool isplacementavailable, int courseid, string coursename, int courseduration, float coursefees):
            base (courseid, coursename, courseduration, coursefees)
        {
            this.IsPlacementAvailable = isplacementavailable;
        }

        

        public override void CalculateMonthlyFee()
        {
            if (IsPlacementAvailable1)
            {
                Coursefees += (float)0.1 * Coursefees;
            }
            
                
        }

    }

    class DiplomaCourse : Course2
    {
       
        public enum type { professional, academic };
        
        public DiplomaCourse () { }
        public DiplomaCourse(int courseid, string coursename, int courseduration, float coursefees) :
            base(courseid, coursename, courseduration, coursefees)
        {
            
        }

        public override void CalculateMonthlyFee() 
        {
            Console.WriteLine("Choose your type of Diploma Course : ");
            string diplomatype = Console.ReadLine();
            if (diplomatype == type.professional.ToString())
            {
                Coursefees += (float)0.1 * Coursefees;
            }
            else if (diplomatype == type.academic.ToString())
            {
                Coursefees += (float)0.05 * Coursefees;
            }
            
        }
    }

    //class Testing
    //{
    //    static void Main()
    //    {
    //        Course2 c = new Course2(1, "Java", 4, 50000);
    //        Info2 info = new Info2();
    //        info.Display(c);

    //        DegreeCourse deg = new DegreeCourse(true, 2, "Python", 3, 7000);
    //        deg.CalculateMonthlyFee();
    //        info.Display(deg);

    //        DiplomaCourse dip = new DiplomaCourse(3, ".NET", 2, 8000);
    //        dip.CalculateMonthlyFee();
    //        info.Display(dip);

    //    }
    //}

    public class Enroll 
    {
        private Student student;
        private Course2 course;
        private DateTime enrollmentDate;

        public Enroll() { }
        public Enroll(Student student, Course2 course, DateTime enrollmentDate)  
        {
            this.Student = student;
            this.Course = course;
            this.EnrollmentDate = enrollmentDate;
        }

        public DateTime EnrollmentDate { get => enrollmentDate; set => enrollmentDate = value; }
        internal Student Student { get => student; set => student = value; }
        internal Course2 Course { get => course; set => course = value; }
    }

    class Info2
    {
        public void Display(Student student)
        {
            Console.WriteLine("-------Student Details-------");
            Console.WriteLine("Student ID = " + student.Id);
            Console.WriteLine("Student Name = " + student.Name);
            Console.WriteLine("Student DOB = " + student.Dob);
            Console.WriteLine("Student College = " + Student.Collegename);
            foreach (string x in student.Phoneno)
            {
                Console.WriteLine("Student Phone Number = " + x);
            }
        }

        public void Display(Course2 course)
        {
            Console.WriteLine("Course ID = " + course.Courseid);
            Console.WriteLine("Course Name = " + course.Coursename);
            Console.WriteLine("Course Duration = " + course.Courseduration + " months");
            Console.WriteLine("Course Fees = " + course.Coursefees);
        }

        public void Display(Enroll enroll)
        {
            Console.WriteLine("------Details of Enrollment------");

            Display(enroll.Student);
            Display(enroll.Course);
            Console.WriteLine("Enrollment Date =" + enroll.EnrollmentDate);
        }
    }

    interface IAppEngine
    {
        public void introduce(Course2 course); 
        public void register(Student student);
        public List<Student> listOfStudents();
        public void enroll(Student student, Course2 course);
        public List<Enroll> listOfEnrollments();

    }

    class InMemoryAppEngine : IAppEngine
    {
        //static List<Student> slist = new List<Student>();
        //static List<Course2> clist = new List<Course2>();

        //public InMemoryAppEngine() { }
        //public void introduce()
        //{
        //    Console.WriteLine("Introducing the Courses Available - ");
        //    Console.WriteLine("Select 1.Degree Course 2.Diploma Course \n");
        //    int choice = Convert.ToInt32(Console.ReadLine());

        //    switch (choice)
        //    {
        //        case 1:
        //            {
        //                Course2 cdeg = new DegreeCourse();
        //                Console.WriteLine("Available Level are - ");
        //                foreach (string x in Enum.GetNames(typeof(DegreeCourse.level)))
        //                {
        //                    Console.WriteLine(x + "\n");
        //                }
        //                break;
        //            }
        //        case 2:
        //            {
        //                Course2 cdeg = new DiplomaCourse();
        //                Console.WriteLine("Available Type are - ");
        //                foreach (string x in Enum.GetNames(typeof(DiplomaCourse.type)))
        //                {
        //                    Console.WriteLine(x + "\n");
        //                }
        //                break;
        //            }
        //        default:
        //            {
        //                Console.WriteLine("Enter correct value");
        //                break;
        //            }
        //    }


        //}
        //public void register(Student student)
        //{

        //    Info2 infoobj = new Info2();
        //    infoobj.Display(student);

        //}
        //public List<Student> listOfStudents()
        //{

        //}
        //public void enroll(Student student, Course2 course)
        //{
        //    Info2 infoobj = new Info2();
        //    infoobj.Display(student);
        //    infoobj.Display(course);

        //}
        //public List<Enroll> listOfEnrollments()
        //{

        //}

        public static List<Student> students = new List<Student>();
        public static List<Course2> courses = new List<Course2>();
        public static List<Enroll> enrolls = new List<Enroll>();

        //Course2 c2 = new Course2(2, "Diploma", 12, (decimal)40000);

        //Student sobj2 = new Student(2, "Andrew", "1999-12-1", new string[] { "9776978765" });
        //Student sobj3 = new Student(3, "Bobby", "2001-03-20", new string[] { "9761142765" });

        //Info infoobj = new Info();

        public InMemoryAppEngine() { }

        public List<Student> Students { get => students; set => students = value; }
        public List<Course2> Courses { get => courses; set => courses = value; }
        public List<Enroll> Enrolls { get => enrolls; set => enrolls = value; }

        
        public void enroll(Student student, Course2 course)
        {
            Enroll e = new Enroll(student, course, DateTime.Now);
            Enrolls.Add(e); //Add this enrollment to the enroll List
            DisplayEnrollList();
        }

        public void introduce(Course2 course)
        {
            courses.Add(course);
            DisplayCourseList();
        }

        public List<Enroll> listOfEnrollments()
        {
            return Enrolls;
        }

        public List<Student> listOfStudents()
        {
            return Students;
        }

        public void register(Student student)
        {
            Students.Add(student);
            DisplayStudentList();
        }

        public void DisplayCourseList()
        {
            Console.WriteLine("------Details of Courses------");
            foreach (Course2 s in Courses)
            {
                Info2 info = new Info2();
                info.Display(s);
            }
        }

        public void DisplayStudentList()
        {
            Console.WriteLine("------Details of Students------");
            foreach (Student s in Students)
            {
                Info2 info = new Info2();
                info.Display(s);
            }
        }

        public void DisplayEnrollList()
        {
            Console.WriteLine("------Details of Enrollment------");
            foreach (Enroll s in Enrolls)
            {
                Info2 info = new Info2();
                info.Display(s);
            }
        }

    }

    class CaseStudy2
    {
        static void Main(string[] args)
        {

            InMemoryAppEngine ie = new InMemoryAppEngine();
            Course2 c1 = new Course2(1, "Degree", 12, 60000);
            ie.Courses.Add(c1);
            ie.Courses.Add(new Course2(2, "Degree", 24, 100000));
            ie.Courses.Add(new Course2(3, "Diploma", 12, 40000));
            ie.Courses.Add(new Course2(4, "Diploma", 6, 20000));
            Console.WriteLine("Courses added");

            ie.Students.Add(new Student(1, "Andrew", "2000-09-08", new string[] { "9765678765" }));
            ie.Students.Add(new Student(2, "John", "2000-12-23", new string[] { "9765109765" }));
            ie.Students.Add(new Student(3, "Alice", "2000-07-18", new string[] { "9765800765" }));
            Console.WriteLine("Students added");

            int x;
            do
            {
                Console.WriteLine("Select the options : \n1.Introduction of Courses\n2.Register Student\n3.Enroll for Course\n");
                 x = Convert.ToInt32(Console.ReadLine());
                switch (x)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter Course details - ");
                            Console.WriteLine("Enter Course ID - ");
                            int cid = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Course name - ");
                            string cname = Console.ReadLine();
                            Console.WriteLine("Enter Course Duration in months - ");
                            int cdur = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Course Fees - ");
                            float cfee = float.Parse(Console.ReadLine());
                            Course2 addcourse = new Course2(cid, cname, cdur, cfee);
                            InMemoryAppEngine imae = new InMemoryAppEngine();
                            imae.introduce(addcourse);
                            

                            break;
                        }
                    case 2:
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
                            InMemoryAppEngine imae = new InMemoryAppEngine();
                            imae.register(s);
                            

                            break;
                        }

                    case 3:
                        {
                            //student
                            Console.WriteLine("Enter Student Details for Enrollment - ");
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

                            //course
                            Console.WriteLine("Enter Course you want to enroll in: Degree or Diploma - ");
                            string cname = Console.ReadLine();
                            
                            if(cname.Equals("Degree"))
                            {
                                Console.WriteLine("Enter Course ID - ");
                                int cid = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter Course Duration in months - ");
                                int cdur = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter Course Fees - ");
                                float cfee = float.Parse(Console.ReadLine());

                                Console.WriteLine("Do you have Placement (true/false) ? - ");
                                bool b = Convert.ToBoolean(Console.ReadLine());
                                //Console.WriteLine("Select the level - ");
                                //foreach (string lev in Enum.GetNames(typeof(DegreeCourse.level)))
                                //{
                                //    Console.WriteLine(lev + "\n");
                                //}
                                //string clevel = Console.ReadLine();
                                DegreeCourse dc = new DegreeCourse(b,cid,cname,cdur,cfee);
                                dc.CalculateMonthlyFee();

                                InMemoryAppEngine imae = new InMemoryAppEngine();
                                imae.enroll(s, dc);


                            }
                            else
                                if(cname.Equals("Diploma"))
                                {
                                Console.WriteLine("Enter Course ID - ");
                                int cid = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter Course Duration in months - ");
                                int cdur = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter Course Fees - ");
                                float cfee = float.Parse(Console.ReadLine());

                                Console.WriteLine("Do you have Placement (true/false) ? - ");
                                bool b = Convert.ToBoolean(Console.ReadLine());
                                //Console.WriteLine("Select the level - ");
                                //foreach (string lev in Enum.GetNames(typeof(DegreeCourse.level)))
                                //{
                                //    Console.WriteLine(lev + "\n");
                                //}
                                //string clevel = Console.ReadLine();
                                DiplomaCourse dc = new DiplomaCourse(cid,cname,cdur,cfee);
                                dc.CalculateMonthlyFee();

                                InMemoryAppEngine imae = new InMemoryAppEngine();
                                imae.enroll(s, dc);

                            }
                            

                            
                            break;
                        }
                }
            } while (x != 0);
           
        }
    }
 }

