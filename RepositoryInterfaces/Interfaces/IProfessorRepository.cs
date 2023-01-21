using ApplicationCore.Entities;
using Service.Models;

namespace Repository
{
    public interface IProfessorRepository : IGenericRepository<Professor>
    {
        bool AgeCheck(int input);
        bool SalaryCheck(decimal input);
        bool NationalCheck(string input);
        bool ProfessorExistenceCheck(int id);
        bool ProfessorDuplicateCheck(string nationalCode);
        bool ProfessorSameNationalCheck(string nationalCode, int id);
        Professor AddProfessor(ProfessorPostModel professorPost);

    }
}
