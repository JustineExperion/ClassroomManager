﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace App.Core.Entities
{
    public class Student : ContactInfo
    {
        public string Role { get; set; } = "Student";
        public string GradeLevel { get; set; }

        // Nav Props
        public long TeacherId { get; set; }
        [JsonIgnore]
        public Teacher Teacher { get; set; }//In the future prob want a many to many relationship with Teachers and Students
        public List<StudentLesson> StudentLessons { get; set; }
    }
}