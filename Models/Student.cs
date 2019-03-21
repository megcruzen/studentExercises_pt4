using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercises.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Slack { get; set; }

        // Foreign key integer
        public int CohortId { get; set; }

        // This property is for storing the C# object representing the cohort
        public Cohort Cohort { get; set; }
    }
}