using Domain.Entities;
using Message.Commands;
using Message.DTOs;
using Message.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Repository;
using Service.Interfaces;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace Service.ControllersServices
{
    public class UniversityService : IUniversityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UniversityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddUniversityAsync(AddUniversityCommand command, Guid userId)
        {
            await Task.Run(() =>
            {
                University university = _unitOfWork.UniversityRepository.AddUniversity(command);
                university.CreatorId = userId;
                _unitOfWork.UniversityRepository.Add(university);
                _unitOfWork.Complete();
            });
        }

        public async Task<GetReturnDTO<UniversityDTO>> GetListUniversity(int pageNumber, int pageSize, string search)
        {
            return await Task.Run(() =>
            {
                var result = _unitOfWork.UniversityRepository.GetListUniversity(search);

                GetReturnDTO<UniversityDTO> dto = new()
                {
                    List = result
                    .Select(u => new UniversityDTO
                    {
                        UniversityId = u.Id,
                        Name = u.Name,
                        Address = u.Address,
                        EstablishedYear = u.EstablishedYear,
                        Budget = u.Budget
                    })
                    .ToPagedList(pageNumber, pageSize),
                    Count = result.Count()
                };

                return dto;
            });
        }

        public async Task UpdateUniversityForUser(UpdateUniversityForUserCommand command, Guid userId, Guid universityId)
        {
            await Task.Run(() =>
            {
                University university = _unitOfWork.UniversityRepository.GetById(universityId);

                university.Name = command.Name;
                university.Address = command.Address;
                university.EstablishedYear = command.EstablishedYear;
                university.Budget = command.Budget;
                university.ModifierId = userId;
                university.ModificationDate = DateTime.Now;
                _unitOfWork.UniversityRepository.Update(university);
                _unitOfWork.Complete();
            });
        }

        public async Task UpdateUniversityForAdmin(UpdateUniversityForAdminCommand command, Guid userId)
        {
            await Task.Run(() =>
            {
                University university = _unitOfWork.UniversityRepository.GetById(command.UniversityId);

                university.Name = command.Name;
                university.Address = command.Address;
                university.EstablishedYear = command.EstablishedYear;
                university.Budget = command.Budget;
                university.ModifierId = userId;
                university.ModificationDate = DateTime.Now;
                _unitOfWork.UniversityRepository.Update(university);
                _unitOfWork.Complete();
            });
        }

        public async Task RemoveUniversity(Guid universityId, Guid userId)
        {
            await Task.Run(() =>
            {
                if (!_unitOfWork.UniversityRepository.CheckUniversityExistence(universityId))
                    throw new NullReferenceException("دانشگاه تعریف نشده است");

                var university = _unitOfWork.UniversityRepository.GetById(universityId);
                var semesters = _unitOfWork.SemesterRepository.GetListSemesterByUniversityId(universityId);
                var courses = _unitOfWork.CourseRepository.GetListCourseByUniversityId(universityId);
                var professors = _unitOfWork.ProfessorRelationsRepository.GetListProfessor(courses);
                var students = _unitOfWork.StudentRelationsRepository.GetListStudents(courses);

                _unitOfWork.StudentRepository.RemoveStudents(students, userId);
                _unitOfWork.ProfessorRepository.RemoveProfessors(professors, userId);
                _unitOfWork.CourseRepository.RemoveListCourse(courses, userId);
                _unitOfWork.SemesterRepository.RemoveSemesters(semesters, userId);
                _unitOfWork.UniversityRepository.RemoveUniversity(university, userId);
                _unitOfWork.Complete();
            });
        }
    }
}
