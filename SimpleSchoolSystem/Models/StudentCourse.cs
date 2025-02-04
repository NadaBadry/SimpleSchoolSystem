﻿using System.ComponentModel.DataAnnotations;

namespace SimpleSchoolSystem.Models
{
    public class StudentCourse
    {
        public int StudentId {  get; set; }
        
        public int CourseId { get; set; }   
        public Course? Course { get; set; }
        public Student? Student { get; set; }
    }
}
