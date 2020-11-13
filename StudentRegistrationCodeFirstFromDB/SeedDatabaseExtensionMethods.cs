using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using StudentRegistrationCodeFirstFromDB;

namespace SeedDatabaseExtensions
{

	public static class SeedDatabaseExtensionMethods
    {
		/// <summary>
		/// zero out the db tables, then seed all tables with initial data
		/// </summary>
		public static void SeedDatabase(this StudentRegistrationEntities context)
        {
			// set up database log to write to output window in VS
			context.Database.Log = (s => Debug.Write(s));

			// reset the db
			context.Database.Delete();
			context.Database.Create();

			context.SaveChanges();

			// another way to reinitialize the database, resetting everything and zeroing out data

			//Database.SetInitializer(new DropCreateDatabaseAlways<StudentRegistrationEntities>());
			//context.Database.Initialize(true);        

			context.Departments.Load();
			context.Students.Load();
			context.Courses.Load();


			// seed departments data

			List<Department> departmentsList = new List<Department>()  {
				new Department { DepartmentCode = "CSIS", DepartmentName = "Computing Studies" },
				new Department { DepartmentCode = "ACCT", DepartmentName = "Accounting" },
				new Department { DepartmentCode = "MKTG", DepartmentName = "Marketing" },
				new Department { DepartmentCode = "FINC", DepartmentName = "Finance" },
			};

			// use a dictionary to set the department fields in Students and Courses

			Dictionary<string, Department> departments = departmentsList.ToDictionary(x => x.DepartmentCode, x => x);

			context.Departments.AddRange(departments.Values);
			context.SaveChanges();

			// seed student data into Students table

			List<Student> students = new List<Student>() {
				new Student { StudentFirstName = "Svetlana", StudentLastName = "Rostov", Department = departments["CSIS"]},
				new Student { StudentFirstName = "Claire", StudentLastName = "Bloome", Department = departments["ACCT"]},
				new Student { StudentFirstName = "Sven", StudentLastName = "Baertschi", Department = departments["ACCT"]},
				new Student { StudentFirstName = "Cesar", StudentLastName = "Chavez", Department = departments["FINC"]},
				new Student { StudentFirstName = "Debra", StudentLastName = "Manning", Department = departments["CSIS"]},
				new Student { StudentFirstName = "Fadi", StudentLastName = "Hadari", Department = departments["ACCT"]},
				new Student { StudentFirstName = "Hanyeng", StudentLastName = "Fen", Department = departments["ACCT"]},
				new Student { StudentFirstName = "Hugo", StudentLastName = "Victor", Department = departments["FINC"]},
				new Student { StudentFirstName = "Lance", StudentLastName = "Armstrong", Department = departments["ACCT"]},
				new Student { StudentFirstName = "Terry", StudentLastName = "Matthews", Department = departments["CSIS"]},
				new Student { StudentFirstName = "Eugene", StudentLastName = "Fei", Department = departments["FINC"]},
				new Student { StudentFirstName = "Michael", StudentLastName = "Thorson", Department = departments["CSIS"]},
				new Student { StudentFirstName = "Simon", StudentLastName = "Li", Department = departments["CSIS"] },
			};

			context.Students.AddRange(students);

			// seed courses data

			List<Course> courses = new List<Course>() {
				new Course { CourseNumber = 101, CourseName = "Programming I", Department = departments["CSIS"] },
				new Course { CourseNumber = 102, CourseName = "Programming II" , Department = departments["CSIS"] },
				new Course { CourseNumber = 101, CourseName = "Accounting I", Department = departments["ACCT"] },
				new Course { CourseNumber = 102, CourseName = "Accounting II", Department = departments["ACCT"] },
				new Course { CourseNumber = 101, CourseName = "Corporate Finance", Department = departments["FINC"]},
			};

			context.Courses.AddRange(courses);
			context.SaveChanges();

			// set up initial registration
			// note that we can add a student to a course or
			// add a course to a student, both will work and set up proper links

			courses[0].Students.Add(students[0]);
			courses[0].Students.Add(students[1]);
			courses[1].Students.Add(students[0]);
			courses[4].Students.Add(students[0]);

			students[2].Courses.Add(courses[2]);

			context.SaveChanges();
		}
    }
}
