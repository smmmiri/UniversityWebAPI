namespace Domain.Entities
{
    public class StudentRelations
    {
        public StudentRelations()
        {
        }

        public StudentRelations(ProfessorRelations professorRelations, Student student)
        {
            ProfessorRelations = professorRelations;
            Student = student;
        }

        public Guid Id { get; set; }
        public Guid CreatorId { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid ModifierId { get; set; }
        public DateTime ModificationDate { get; set; }
        public bool IsActive { get; set; }
        public double Score { get; set; }
        
        public ProfessorRelations ProfessorRelations { get; set; }
        public Student Student { get; set; }
    }
}
