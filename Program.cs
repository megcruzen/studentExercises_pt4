using System;
using System.Collections.Generic;
using System.Linq;
using StudentExercises.Data;
using StudentExercises.Models;

namespace StudentExercises
{
    public class Program
    {
        ///  The Main method is the starting point for a .net application.
        static void Main(string[] args)
        {
            /// Create an instance of the Repository class in order to use its methods to interact with the database.
            Repository repository = new Repository();
            List<Exercise> exercises = repository.GetAllExercises();
            List<Student> students = repository.GetAllStudentsWithCohorts();
            List<StudentExercise> studentExercises = repository.GetAllStudentExercises();
            List<Instructor> instructors = repository.GetAllInstructorsWithCohorts();

            PrintExerciseReport("All Exercises", exercises);

            Pause();

            // Find all the exercises in the database where the language is JavaScript.
            IEnumerable<Exercise> JsExercises = exercises.Where(e => e.ExerciseLanguage == "Javascript");
            PrintExerciseReport("Javascript Exercises", JsExercises.ToList());

            Pause();


            // Insert a new exercise into the database.
            Exercise adoNetSql = new Exercise { ExerciseName = "Using ADO.NET and SQL", ExerciseLanguage = "C#" };

            // Pass the exercise object as an argument to the repository's AddExercise() method.
            repository.AddExercise(adoNetSql);

            exercises = repository.GetAllExercises();
            PrintExerciseReport("All Departments after adding new C# exercise", exercises);

            Pause();

            // Find all instructors in the database. Include each instructor's cohort.
            PrintInstructorReport("All Instructors", instructors);

            Pause();

            // Insert a new instructor into the database. Assign the instructor to an existing cohort.
            Instructor brenda = new Instructor { FirstName = "Brenda", LastName = "Long", Slack = "brenda", CohortId = 1 };

            // Pass the exercise object as an argument to the repository's AddExercise() method.
            repository.AddInstructor(brenda);
            instructors = repository.GetAllInstructorsWithCohorts();
            PrintInstructorReport("All Instructors after adding new instructor", instructors);
            Pause();

            PrintStudentExerciseReport("All Student Exercises", studentExercises);
            Pause();

            // Assign an existing exercise to an existing student.
            StudentExercise newAssignment = new StudentExercise { StudentId = 9, ExerciseId = 1 };
            repository.AddExerciseToStudent(newAssignment);
            studentExercises = repository.GetAllStudentExercises();
            PrintStudentExerciseReport("All Student Exercises after assigning a new one", studentExercises);
            Pause();
        }

        public static void PrintExerciseReport(string title, List<Exercise> exercises)
        {
            Console.WriteLine(title);
            foreach (Exercise exercise in exercises)
            {
                Console.WriteLine($"{exercise.Id}: {exercise.ExerciseName} ({exercise.ExerciseLanguage})");
            }
        }

        public static void PrintInstructorReport(string title, List<Instructor> instructors)
        {
            Console.WriteLine(title);
            foreach (Instructor instructor in instructors)
            {
                Console.WriteLine($"{instructor.FirstName} {instructor.LastName} ({instructor.Cohort.CohortName})");
            }
        }

        public static void PrintStudentExerciseReport(string title, List<StudentExercise> studentExercises)
        {
            Console.WriteLine(title);
            foreach (StudentExercise exercise in studentExercises)
            {
                Console.WriteLine($"{exercise.Student.FirstName} {exercise.Student.LastName}: {exercise.Exercise.ExerciseName} ({exercise.Exercise.ExerciseLanguage})");
            }
        }

        ///  Custom function that pauses execution of the console app until the user presses a key
        public static void Pause()
        {
            Console.WriteLine();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
