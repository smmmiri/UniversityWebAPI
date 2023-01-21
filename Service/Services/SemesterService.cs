using Message.Commands;
using Message.DTOs;
using Message.ExtensionMethods;
using Repository;
using Service.Interfaces;

namespace Service.Services
{
    public class SemesterService : ISemesterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SemesterService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddSemester(AddSemesterCommand command, Guid userId, Guid universityId)
        {
            await Task.Run(() =>
            {
                if (_unitOfWork.SemesterRepository.CheckSemesterExistence(command.SemesterNumber))
                    throw new InvalidDataException("ترم وجود دارد");

                var semester = _unitOfWork.SemesterRepository.AddSemester(command, universityId);
                semester.CreatorId = userId;
                _unitOfWork.SemesterRepository.Add(semester);
                _unitOfWork.Complete();
            });
        }

        public async Task<GetReturnDTO<SemesterDTO>> GetListSemesters
            (int pageNumber, int pageSize, string search, Guid universityId)
        {
            return await Task.Run(() =>
            {
                var result = _unitOfWork.SemesterRepository.GetListSemester(search, universityId);

                GetReturnDTO<SemesterDTO> dto = new()
                {
                    List = result.ToPagedList(pageNumber, pageSize),
                    Count = result.Count()
                };

                return dto;
            });
        }

        public async Task UpdateSemester(UpdateSemesterCommand command, Guid userId, Guid universityId)
        {
            await Task.Run(() =>
            {
                var semester = _unitOfWork.SemesterRepository.GetById(command.SemesterId);

                if (semester.UniversityId != universityId)
                    throw new InvalidDataException("این ترم در دانشگاه شما تعریف نشده است");

                semester.SemesterNumber = command.SemesterNumber;
                semester.SemesterType = command.SemesterType;
                semester.SemesterYear = command.SemesterYear;
                semester.ModifierId = userId;
                semester.ModificationDate = DateTime.Now;
                _unitOfWork.Complete();
            });
        }

        public async Task RemoveSemester(Guid semesterId, Guid userId, Guid universityId)
        {
            await Task.Run(() =>
            {
                var semester = _unitOfWork.SemesterRepository.GetById(semesterId);

                if (semester.UniversityId != universityId)
                    throw new InvalidDataException("این ترم در دانشگاه شما تعریف نشده است");

                var professorRelations = 
                _unitOfWork.ProfessorRelationsRepository.GetListProfessorRelationsBySemesterId(semesterId);
                var studentRelations = 
                _unitOfWork.StudentRelationsRepository.GetListStudentRelationsBySemesterId(semesterId);

                _unitOfWork.StudentRelationsRepository.DeleteListStudentRelations(studentRelations);
                _unitOfWork.ProfessorRelationsRepository.DeleteListProfessorRelations(professorRelations);

                semester.IsActive = false;
                semester.ModifierId = userId;
                semester.ModificationDate = DateTime.Now;
                _unitOfWork.Complete();
            });
        }
    }
}