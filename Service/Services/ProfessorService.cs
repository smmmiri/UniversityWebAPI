using Domain.Entities;
using Message.Commands;
using Message.DTOs;
using Message.ExtensionMethods;
using Repository;
using Service.Interfaces;

namespace Service.ControllersServices
{
    public class ProfessorService : IProfessorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProfessorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddOnlyProfessor(AddOnlyProfessorCommand command, Guid userId, Guid universityId)
        {
            await Task.Run(() =>
            {
                var id = _unitOfWork.ProfessorRepository.CheckProfessorNationalCodeExistence(command.NationalCode);
                if (id != Guid.Empty)
                    if (_unitOfWork.UniversityProfessorRepository.IsProfessorInUniversity(id, universityId))
                        throw new InvalidDataException("استاد در دانشگاه شما وجود دارد");

                Professor professor = _unitOfWork.ProfessorRepository.AddProfessor(command);
                professor.CreatorId = userId;
                _unitOfWork.ProfessorRepository.Add(professor);
                _unitOfWork.Complete();

                var universityProfessor =
                _unitOfWork.UniversityProfessorRepository.AddUniversityProfessor(professor.Id, universityId);
                _unitOfWork.UniversityProfessorRepository.Add(universityProfessor);
                _unitOfWork.Complete();
            });
        }

        public async Task AddProfessor(AddProfessorCommand command, Guid userId, Guid universityId)
        {
            await Task.Run(() =>
            {
                var semester = _unitOfWork.SemesterRepository.GetById(command.SemesterId);

                if (semester == null)
                    throw new NullReferenceException("ترم تعریف نشده است");

                if (semester.UniversityId != universityId)
                    throw new InvalidDataException("این ترم در دانشگاه شما تعریف نشده است");

                if (!_unitOfWork.CourseRepository.CheckListCourseExistence(command.CoursesId))
                    throw new NullReferenceException("درس تعریف نشده است");

                if (command.CoursesId.Count != command.Salaries.Count)
                    throw new InvalidDataException("تعداد درس‌ها و دستمزد‌ها برابر نیست");

                var message = _unitOfWork.CourseRepository.AreCoursesInUniversity(command.CoursesId, universityId);
                if (message != string.Empty)
                    throw new InvalidDataException($":این دروس در دانشگاه شما تعریف نشده‌اند\n{message}");

                var id = _unitOfWork.ProfessorRepository.CheckProfessorNationalCodeExistence(command.NationalCode);
                if (id != Guid.Empty)
                    if (!_unitOfWork.UniversityProfessorRepository.IsProfessorInUniversity(id, universityId))
                        throw new InvalidDataException("استاد در دانشگاه شما تعریف نشده است");

                AddOnlyProfessorCommand onlyProfessor = new()
                {
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    NationalCode = command.NationalCode,
                    Birthday = command.Birthday
                };

                Professor professor = _unitOfWork.ProfessorRepository.AddProfessor(onlyProfessor);
                professor.CreatorId = userId;
                _unitOfWork.ProfessorRepository.Add(professor);
                _unitOfWork.Complete();

                var universityProfessor =
                _unitOfWork.UniversityProfessorRepository.AddUniversityProfessor(professor.Id, universityId);
                _unitOfWork.UniversityProfessorRepository.Add(universityProfessor);

                if (_unitOfWork.Complete() > 0)
                {
                    for (int i = 0; i < command.CoursesId.Count; i++)
                    {
                        var course = _unitOfWork.CourseRepository.GetById(command.CoursesId[i]);

                        var professorRelation =
                        _unitOfWork.ProfessorRelationsRepository
                        .AddProfessorRelations(semester, course, professor, command.Salaries[i], userId);
                        _unitOfWork.ProfessorRelationsRepository.Add(professorRelation);
                        _unitOfWork.Complete();
                    }
                }
            });
        }

        public async Task AddProfessorToCourse(AddProfessorToCourseCommand command, Guid userId, Guid universityId)
        {
            await Task.Run(() =>
            {
                var semester = _unitOfWork.SemesterRepository.GetById(command.SemesterId);
                var professor = _unitOfWork.ProfessorRepository.GetById(command.ProfessorId);
                var course = _unitOfWork.CourseRepository.GetById(command.CourseId);

                if (semester == null)
                    throw new NullReferenceException("ترم تعریف نشده است");

                if (semester.UniversityId != universityId)
                    throw new InvalidDataException("این ترم در دانشگاه شما تعریف نشده است");

                if (course == null)
                    throw new NullReferenceException("درس تعریف نشده است");

                if (course.UniversityId != universityId)
                    throw new InvalidDataException("این درس در دانشگاه شما تعریف نشده است");

                if (professor == null)
                    throw new NullReferenceException("استاد تعریف نشده است");

                if (!_unitOfWork.UniversityProfessorRepository.IsProfessorInUniversity(command.ProfessorId, universityId))
                    throw new InvalidDataException("این استاد در دانشگاه شما تعریف نشده است");

                var professorRelation = _unitOfWork.ProfessorRelationsRepository
                .AddProfessorRelations(semester, course, professor, userId, command.Salary);
                _unitOfWork.ProfessorRelationsRepository.Add(professorRelation);
                _unitOfWork.Complete();
            });
        }

        public async Task AddSalaryForProfessor(AddSalaryForProfessorCommand command, Guid universityId, Guid userId)
        {
            await Task.Run(() =>
            {
                var semester = _unitOfWork.SemesterRepository.GetById(command.SemesterId);
                var professor = _unitOfWork.ProfessorRepository.GetById(command.ProfessorId);
                var course = _unitOfWork.CourseRepository.GetById(command.CourseId);

                if (semester == null)
                    throw new NullReferenceException("ترم تعریف نشده است");

                if (semester.UniversityId != universityId)
                    throw new InvalidDataException("این ترم در دانشگاه شما تعریف نشده است");

                if (course == null)
                    throw new NullReferenceException("درس تعریف نشده است");

                if (course.UniversityId != universityId)
                    throw new InvalidDataException("این درس در دانشگاه شما تعریف نشده است");

                if (professor == null)
                    throw new NullReferenceException("استاد تعریف نشده است");

                if (!_unitOfWork.UniversityProfessorRepository.IsProfessorInUniversity(command.ProfessorId, universityId))
                    throw new InvalidDataException("این استاد در دانشگاه شما تعریف نشده است");

                var professorRelation =
                _unitOfWork.ProfessorRelationsRepository
                .GetProfessorRelations(professor.Id, course.Id, semester.Id, universityId);
                professorRelation.Salary = command.Salary;
                professorRelation.CreatorId = userId;
                professorRelation.CreationDate = DateTime.Now;
                _unitOfWork.Complete();
            });
        }

        public async Task<GetReturnDTO<OnlyProfessorDTO>> GetListProfessor(int pageNumber, int pageSize, string search, 
            Guid universityId)
        {
            return await Task.Run(() =>
            {
                var result = _unitOfWork.ProfessorRepository.GetListProfessor(search, universityId);

                GetReturnDTO<OnlyProfessorDTO> dto = new()
                {
                    List = result
                    .Select(r => new OnlyProfessorDTO
                    {
                        ProfessorId = r.Id,
                        FirstName = r.FirstName,
                        LastName = r.LastName,
                        Birthday = r.Birthday,
                        Age = DateTime.Now.Year - r.Birthday.Year,
                        NationalCode = r.NationalCode
                    })
                    .ToPagedList(pageNumber, pageSize),
                    Count = result.Count()
                };

                return dto;
            });
        }

        public async Task<GetReturnDTO<ProfessorRelationsDTO>> GetListProfessor(int pageNumber, int pageSize, string search, 
            Guid semesterId, Guid universityId)
        {
            return await Task.Run(() =>
            {
                if (!_unitOfWork.SemesterRepository.CheckSemesterExistence(semesterId) && semesterId != Guid.Empty)
                    throw new NullReferenceException("ترم تعریف نشده است");

                if (!_unitOfWork.SemesterRepository.IsSemesterInUniversity(semesterId, universityId) &&
                semesterId != Guid.Empty)
                    throw new InvalidDataException("این ترم در دانشگاه شما تعریف نشده است");

                var professorRelations = _unitOfWork.ProfessorRelationsRepository
                .GetListProfessor(search, semesterId, universityId);

                GetReturnDTO<ProfessorRelationsDTO> dto = new()
                {
                    List = professorRelations
                    .Select(p => new ProfessorRelationsDTO
                    {
                        ProfessroRelationsId = p.Id,
                        ProfessorId = p.Professor.Id,
                        FirstName = p.Professor.FirstName,
                        LastName = p.Professor.LastName,
                        NationalCode = p.Professor.NationalCode,
                        Birthday = p.Professor.Birthday,
                        Age = DateTime.Now.Year - p.Professor.Birthday.Year,
                        Salary = p.Salary,
                        CourseId = p.Course.Id,
                        CourseName = p.Course.Name,
                        SemesterId = p.Semester.Id,
                        SemesterNumber = p.Semester.SemesterNumber
                    })
                    .ToPagedList(pageNumber, pageSize),
                    Count = professorRelations.Count()
                };

                return dto;
            });
        }

        public async Task<GetReturnDTO<ProfessorDTO>> GetListProfessorOfCourse(int pageNumber, int pageSize, Guid courseId, 
            Guid semesterId, Guid universityId)
        {
            return await Task.Run(() =>
            {
                if (!_unitOfWork.SemesterRepository.CheckSemesterExistence(semesterId) && semesterId != Guid.Empty)
                    throw new NullReferenceException("ترم تعریف نشده است");

                if (!_unitOfWork.SemesterRepository.IsSemesterInUniversity(semesterId, universityId) &&
                semesterId != Guid.Empty)
                    throw new InvalidDataException("این ترم در دانشگاه شما تعریف نشده است");

                if (!_unitOfWork.CourseRepository.CheckCourseExistence(courseId))
                    throw new NullReferenceException("درس تعریف نشده است");

                if (!_unitOfWork.CourseRepository.IsCourseInUniversity(courseId, universityId))
                    throw new InvalidDataException("این درس در دانشگاه شما تعریف نشده است");

                var professors = _unitOfWork.ProfessorRelationsRepository
                .GetListProfessorRelations(semesterId, universityId)
                .Where(pr => pr.Course.Id == courseId);

                GetReturnDTO<ProfessorDTO> dto = new()
                {
                    List = professors
                    .Select(p => new ProfessorDTO
                    {
                        ProfessorId = p.Professor.Id,
                        FirstName = p.Professor.FirstName,
                        LastName = p.Professor.LastName,
                        Birthday = p.Professor.Birthday,
                        Age = DateTime.Now.Year - p.Professor.Birthday.Year,
                        NationalCode = p.Professor.NationalCode,
                        Salary = p.Salary,
                        CourseId = p.Course.Id,
                        CourseName = p.Course.Name,
                        SemesterId = p.Semester.Id,
                        SemesterNumber = p.Semester.SemesterNumber
                    })
                    .ToPagedList(pageNumber, pageSize),
                    Count = professors.Count()
                };

                return dto;
            });
        }

        public async Task<GetReturnDTO<ProfessorWithStudentDTO>> GetListProfessorOfStudent(int pageNumber, int pageSize, 
            Guid studentId, Guid semesterId, Guid universityId)
        {
            return await Task.Run(() =>
            {
                if (!_unitOfWork.SemesterRepository.CheckSemesterExistence(semesterId) && semesterId != Guid.Empty)
                    throw new NullReferenceException("ترم تعریف نشده است");

                if (!_unitOfWork.SemesterRepository.IsSemesterInUniversity(semesterId, universityId) &&
                semesterId != Guid.Empty)
                    throw new InvalidDataException("این ترم در دانشگاه شما تعریف نشده است");

                if (!_unitOfWork.StudentRepository.CheckStudentExistence(studentId))
                    throw new NullReferenceException("دانشجو تعریف نشده است");

                if (!_unitOfWork.UniversityStudentRepository.IsStudentInUniversity(studentId, universityId))
                    throw new InvalidDataException("این دانشجو در دانشگاه شما تعریف نشده است");

                var professors = _unitOfWork.StudentRelationsRepository
                .GetListProfessor(studentId, semesterId, universityId);
                
                GetReturnDTO<ProfessorWithStudentDTO> dto = new()
                {
                    List = professors
                    .Select(p => new ProfessorWithStudentDTO
                    {
                        ProfessorId = p.ProfessorRelations.Professor.Id,
                        ProfessorFirstName = p.ProfessorRelations.Professor.FirstName,
                        ProfessorLastName = p.ProfessorRelations.Professor.LastName,
                        ProfessorBirthday = p.ProfessorRelations.Professor.Birthday,
                        Age = DateTime.Now.Year - p.ProfessorRelations.Professor.Birthday.Year,
                        ProfessorNationalCode = p.ProfessorRelations.Professor.NationalCode,
                        ProfessorSalary = p.ProfessorRelations.Salary,
                        CourseId = p.ProfessorRelations.Course.Id,
                        CourseName = p.ProfessorRelations.Course.Name,
                        StudentId = p.Student.Id,
                        StudentFirstName = p.Student.FirstName,
                        StudentLastName = p.Student.LastName,
                        SemesterId = p.ProfessorRelations.Semester.Id,
                        SemesterNumber = p.ProfessorRelations.Semester.SemesterNumber
                    })
                    .ToPagedList(pageNumber, pageSize),
                    Count = professors.Count()
                };

                return dto;
            });
        }

        public async Task UpdateProfessor(UpdateProfessorCommand command, Guid userId, Guid universityId)
        {
            await Task.Run(() =>
            {
                if (_unitOfWork.ProfessorRepository
                .CheckProfessorNationalCodeRepetivity(command.NationalCode, command.ProfessorId))
                    throw new InvalidDataException("کد ملی تکراری است");

                if (!_unitOfWork.UniversityProfessorRepository
                .IsProfessorInUniversity(command.ProfessorId, universityId))
                    throw new InvalidDataException("استاد مورد نظر در این دانشگاه تعریف نشده است");

                var professor = _unitOfWork.ProfessorRepository.GetById(command.ProfessorId);

                professor.FirstName = command.FirstName;
                professor.LastName = command.LastName;
                professor.Birthday = command.Birthday;
                professor.NationalCode = command.NationalCode;
                professor.ModifierId = userId;
                professor.ModificationDate = DateTime.Now;
                _unitOfWork.Complete();
            });
        }

        public async Task RemoveProfessor(Guid professorId, Guid userId, Guid universityId)
        {
            await Task.Run(() =>
            {
                var professor = _unitOfWork.ProfessorRepository.GetById(professorId);

                if (professor == null)
                    throw new NullReferenceException("استاد تعریف نشده است");

                if (!_unitOfWork.UniversityProfessorRepository.IsProfessorInUniversity(professorId, universityId))
                    throw new InvalidDataException("استاد مورد نظر در دانشگاه شما تعریف نشده است");

                _unitOfWork.ProfessorRepository.RemoveProfessor(professor, userId);

                if (_unitOfWork.Complete() > 0)
                {
                    var universityProfessors =
                    _unitOfWork.UniversityProfessorRepository.GetListUniversityProfessor(professorId);
                    _unitOfWork.UniversityProfessorRepository.DeleteListUniversityProfessor(universityProfessors);

                    var professorRelations =
                    _unitOfWork.ProfessorRelationsRepository.GetListProfessorRelationsByProfessorId(professorId);
                    _unitOfWork.ProfessorRelationsRepository.DeleteListProfessorRelations(professorRelations);
                    _unitOfWork.Complete();
                }
            });
        }

        public async Task DeleteProfessorFromCourse(DeleteProfessorFromCourseCommand command, Guid universityId)
        {
            await Task.Run(() =>
            {
                if (!_unitOfWork.SemesterRepository.CheckSemesterExistence(command.SemesterId))
                    throw new NullReferenceException("ترم تعریف نشده است");

                if (!_unitOfWork.SemesterRepository.IsSemesterInUniversity(command.SemesterId, universityId))
                    throw new InvalidDataException("این ترم در دانشگاه شما تعریف نشده است");

                if (!_unitOfWork.CourseRepository.CheckCourseExistence(command.CourseId))
                    throw new NullReferenceException("درس تعریف نشده است");

                if (!_unitOfWork.CourseRepository.IsCourseInUniversity(command.CourseId, universityId))
                    throw new InvalidDataException("این درس در دانشگاه شما تعریف نشده است");

                if (!_unitOfWork.ProfessorRepository.CheckProfessorExistence(command.ProfessorId))
                    throw new NullReferenceException("استاد تعریف نشده است");

                if (!_unitOfWork.UniversityProfessorRepository.IsProfessorInUniversity(command.ProfessorId, universityId))
                    throw new InvalidDataException("این استاد در دانشگاه شما تعریف نشده است");

                var professorRelation = _unitOfWork.ProfessorRelationsRepository
                .GetProfessorRelations(command.ProfessorId, command.CourseId, command.SemesterId, universityId);
                _unitOfWork.ProfessorRelationsRepository.Delete(professorRelation.Id);
                _unitOfWork.Complete();
            });
        }
    }
}
