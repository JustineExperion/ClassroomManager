﻿using System;
using System.Collections.Generic;
using System.Text;

namespace App.Core.Entities
{
    public class StudentLesson
    {
        //NOTE: Need to setup model in DB context
        public long StudentId { get; set; }
        public Student Student { get; set; }

        public long LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}