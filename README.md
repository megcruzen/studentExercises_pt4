## Exploring Student Exercises in the database using ADO.NET
https://github.com/nashville-software-school/bangazon-inc/blob/master/book-1-orientation/chapters/STUDENT_EXERCISES_ADONET.md


### Instructions
1. Create a new "Console App (.NET Core)" project.
1. Add the `System.Data.SqlClient` nuget package to your project.
1. Create a `Repository` class to interact with the `StudentExercises` database you created in Student Exercises Part 3.
1. Write the necessary C# code in `Repository.cs` and `Program.cs` to perform the following actions. Make sure to print results of each action to the console. 
    1. Query the database for all the Exercises.
    1. Find all the exercises in the database where the language is JavaScript.
    1. Insert a new exercise into the database.
    1. Find all instructors in the database. Include each instructor's cohort.
    1. Insert a new instructor into the database. Assign the instructor to an existing cohort.
    1. Assign an existing exercise to an existing student.
