﻿namespace Domain.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public int Unit { get; set; }
        public Guid UniversityId { get; set; }
    }
}