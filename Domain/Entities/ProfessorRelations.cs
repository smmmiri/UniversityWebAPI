namespace Domain.Entities
{
    public class ProfessorRelations
    {
        public ProfessorRelations()
        {
        }
        public ProfessorRelations(Course course, Professor professor, Semester semester)
        {
            Course = course;
            Professor = professor;
            Semester = semester;
        }

        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public decimal Salary { get; set; }

        public Course Course { get; set; }
        public Professor Professor { get; set; }
        public Semester Semester { get; set; }
    }
}
