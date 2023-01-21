using Domain.Entities;
using Message.Commands;
using Message.DTOs;
using Message.ExtensionMethods;
using Repository;
using Service.Interfaces;

namespace Service.ControllersServices
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddOnlyStudent(AddOnlyStudentCommand command, Guid userId, Guid universityId)
        {
            await Task.Run(() =>
            {
                var id = _unitOfWork.StudentRepository.CheckStudentNationalCodeExistence(command.NationalCode);
                if (id != Guid.Empty)
                    if (_unitOfWork.UniversityStudentRepository.IsStudentInUniversity(id, universityId))
                        throw new InvalidDataException("دانشجویی با این کد ملی در دانشگاه شما تعریف شده است");

                id = _unitOfWork.StudentRepository.CheckStudentNumberExistence(command.StudentNumber);
                if (id != Guid.Empty)
                    if (_unitOfWork.UniversityStudentRepository.IsStudentInUniversity(id, universityId))
                        throw new InvalidDataException("دانشجویی با این شماره دانشجویی در دانشگاه شما تعریف شده است");

                Student student = _unitOfWork.StudentRepository.AddStudent(command);
                student.CreatorId = userId;
                _unitOfWork.StudentRepository.Add(student);
                _unitOfWork.Complete();

                var universityStudent =
                _unitOfWork.UniversityStudentRepository.AddUniversityStudent(student.Id, universityId);
                _unitOfWork.UniversityStudentRepository.Add(universityStudent);
                _unitOfWork.Complete();
            });
        }

        public async Task AddStudent(AddStudentCommand command, Guid userId, Guid universityId)
        {
            await Task.Run(() =>
            {
                foreach (var item in command.ProfessorRelationIds)
                {
                    var professorRelation = _unitOfWork.ProfessorRelationsRepository.GetById(item);
                    if (professorRelation == null)
                        throw new NullReferenceException($"رابطه‌ای با این شناسه تعریف نشده است:\n{item}");
                }

                var id = _unitOfWork.StudentRepository.CheckStudentNationalCodeExistence(command.NationalCode);
                if (id != Guid.Empty)
                    if (_unitOfWork.UniversityStudentRepository.IsStudentInUniversity(id, universityId))
                        throw new InvalidDataException("دانشجویی با این کد ملی در دانشگاه شما تعریف شده است");

                id = _unitOfWork.StudentRepository.CheckStudentNumberExistence(command.StudentNumber);
                if (id != Guid.Empty)
                    if (_unitOfWork.UniversityStudentRepository.IsStudentInUniversity(id, universityId))
                        throw new InvalidDataException("دانشجویی با این شماره دانشجویی در دانشگاه شما تعریف شده است");

                AddOnlyStudentCommand onlyStudent = new()
                {
                    FirstName = command.FirstName,
                    LastName = command.LastName,
                    NationalCode = command.NationalCode,
                    Birthday = command.Birthday,
                    StudentNumber = command.StudentNumber
                };

                Student student = _unitOfWork.StudentRepository.AddStudent(onlyStudent);
                student.CreatorId = userId;
                _unitOfWork.StudentRepository.Add(student);
                _unitOfWork.Complete();

                var universityStudent =
                _unitOfWork.UniversityStudentRepository.AddUniversityStudent(student.Id, universityId);
                _unitOfWork.UniversityStudentRepository.Add(universityStudent);

                if (_unitOfWork.Complete() > 0)
                {
                    for (int i = 0; i < command.ProfessorRelationIds.Count; i++)
                    {
                        var professorRelation =
                        _unitOfWork.ProfessorRelationsRepository.GetById(command.ProfessorRelationIds[i]);

                        var studentRelation =
                        _unitOfWork.StudentRelationsRepository.AddStudentRelations(student, professorRelation);
                        _unitOfWork.StudentRelationsRepository.Add(studentRelation);
                        _unitOfWork.Complete();
                    }
                }
            });
        }

        public async Task AddStudentToCourse(AddStudentToCourseCommand command, Guid universityId)
        {
            await Task.Run(() =>
            {
                var professorRelation = _unitOfWork.ProfessorRelationsRepository.GetById(command.ProfessorRelationId);

                if (professorRelation == null)
                    throw new NullReferenceException("رابطه تعریف نشده است");

                var student = _unitOfWork.StudentRepository.GetById(command.StudentId);

                if (student == null)
                    throw new NullReferenceException("دانشجو تعریف نشده است");

                var studentRelation =
                _unitOfWork.StudentRelationsRepository.AddStudentRelations(student, professorRelation);
                _unitOfWork.StudentRelationsRepository.Add(studentRelation);
                _unitOfWork.Complete();
            });
        }

        public async Task<GetReturnDTO<OnlyStudentDTO>> GetListStudent(int pageNumber, int pageSize, string search,
            Guid universityId)
        {
            return await Task.Run(() =>
            {
                var result = _unitOfWork.StudentRepository.GetListStudent(search, universityId);

                GetReturnDTO<OnlyStudentDTO> dto = new()
                {
                    List = result
                    .Select(r => new OnlyStudentDTO
                    {
                        StudentId = r.Id,
                        StudentFirstName = r.FirstName,
                        StudentLastName = r.LastName,
                        Birthday = r.Birthday,
                        Age = DateTime.Now.Year - r.Birthday.Year,
                        NationalCode = r.NationalCode,
                        StudentNumber = r.StudentNumber
                    })
                    .ToPagedList(pageNumber, pageSize),
                    Count = result.Count()
                };

                return dto;
            });
        }

        public async Task<GetReturnDTO<StudentDTO>> GetListStudentOfCourse(int pageNumber, int pageSize,
            Guid professorRelationsId, Guid semesterId, Guid universityId)
        {
            return await Task.Run(() =>
            {
                if (!_unitOfWork.SemesterRepository.CheckSemesterExistence(semesterId) && semesterId != Guid.Empty)
                    throw new NullReferenceException("ترم تعریف نشده است");

                if (!_unitOfWork.SemesterRepository.IsSemesterInUniversity(semesterId, universityId) &&
                semesterId != Guid.Empty)
                    throw new InvalidDataException("این ترم در دانشگاه شما تعریف نشده است");

                if (!_unitOfWork.ProfessorRelationsRepository.CheckProfessorRelationsExistence(professorRelationsId))
                    throw new NullReferenceException("رابطه درس و استاد تعریف نشده است");

                if (!_unitOfWork.ProfessorRelationsRepository
                .IsProfessorRelationsInUniversity(professorRelationsId, universityId))
                    throw new InvalidDataException("رابطه درس و استاد در دانشگاه شما تعریف نشده است");

                var students = _unitOfWork.StudentRelationsRepository
                .GetListStudentByProfessorRelationsId(professorRelationsId, semesterId, universityId);

                GetReturnDTO<StudentDTO> dto = new()
                {
                    List = students
                    .Select(s => new StudentDTO
                    {
                        StudentId = s.Student.Id,
                        StudentFirstName = s.Student.FirstName,
                        StudentLastName = s.Student.LastName,
                        Birthday = s.Student.Birthday,
                        Age = DateTime.Now.Year - s.Student.Birthday.Year,
                        NationalCode = s.Student.NationalCode,
                        StudentNumber = s.Student.StudentNumber,
                        CourseId = s.ProfessorRelations.Course.Id,
                        Name = s.ProfessorRelations.Course.Name,
                        ProfessorId = s.ProfessorRelations.Professor.Id,
                        ProfessorFirstName = s.ProfessorRelations.Professor.FirstName,
                        ProfessorLastName = s.ProfessorRelations.Professor.LastName,
                        SemesterId = s.ProfessorRelations.Semester.Id,
                        SemesterNumber = s.ProfessorRelations.Semester.SemesterNumber
                    })
                    .ToPagedList(pageNumber, pageSize),
                    Count = students.Count()
                };

                return dto;
            });
        }

        public async Task<StudentWithScoreDTO> GetScoreOfStudentInTheCourse(Guid studentId, Guid courseId,
            Guid semsterId, Guid universityId)
        {
            return await Task.Run(() =>
            {
                if (!_unitOfWork.SemesterRepository.CheckSemesterExistence(semsterId) && semsterId != Guid.Empty)
                    throw new NullReferenceException("ترم تعریف نشده است");

                if (!_unitOfWork.SemesterRepository.IsSemesterInUniversity(semsterId, universityId) &&
                semsterId != Guid.Empty)
                    throw new InvalidDataException("این ترم در دانشگاه شما تعریف نشده است");

                if (!_unitOfWork.CourseRepository.CheckCourseExistence(courseId))
                    throw new NullReferenceException("درس تعریف نشده است");

                if (!_unitOfWork.CourseRepository.IsCourseInUniversity(courseId, universityId))
                    throw new InvalidDataException("این درس در دانشگاه شما تعریف نشده است");

                if (!_unitOfWork.StudentRepository.CheckStudentExistence(studentId))
                    throw new NullReferenceException("دانشجو تعریف نشده است");

                if (!_unitOfWork.UniversityStudentRepository.IsStudentInUniversity(studentId, universityId))
                    throw new InvalidDataException("این دانشجو در دانشگاه شما تعریف نشده است");

                var result = _unitOfWork.StudentRelationsRepository
                .GetStudentScore(studentId, courseId, semsterId, universityId);

                StudentWithScoreDTO dto = new()
                {
                    Score = result.Score,
                    StudentId = result.Student.Id,
                    StudentFirstName = result.Student.FirstName,
                    StudentLastName = result.Student.LastName,
                    CourseId = result.ProfessorRelations.Course.Id,
                    Name = result.ProfessorRelations.Course.Name,
                    ProfessorId = result.ProfessorRelations.Professor.Id,
                    ProfessorFirstName = result.ProfessorRelations.Professor.FirstName,
                    ProfessorLastName = result.ProfessorRelations.Professor.LastName,
                    SemesterId = result.ProfessorRelations.Semester.Id,
                    SemesterNumber = result.ProfessorRelations.Semester.SemesterNumber
                };

                return dto;
            });
        }

        public async Task<GetReturnDTO<StudentDTO>> GetListStudentOfProfessor(int pageNumber, int pageSize,
            Guid professorId, Guid semesterId, Guid universityId)
        {
            return await Task.Run(() =>
            {
                if (!_unitOfWork.SemesterRepository.CheckSemesterExistence(semesterId) && semesterId != Guid.Empty)
                    throw new NullReferenceException("ترم تعریف نشده است");

                if (!_unitOfWork.SemesterRepository.IsSemesterInUniversity(semesterId, universityId) &&
                semesterId != Guid.Empty)
                    throw new InvalidDataException("این ترم در دانشگاه شما تعریف نشده است");

                if (!_unitOfWork.ProfessorRepository.CheckProfessorExistence(professorId))
                    throw new NullReferenceException("استاد تعریف نشده است");

                if (!_unitOfWork.UniversityProfessorRepository.IsProfessorInUniversity(professorId, universityId))
                    throw new InvalidDataException("این استاد در دانشگاه شما تعریف نشده است");

                var students = _unitOfWork.StudentRelationsRepository
                .GetListStudentByProfessorId(professorId, semesterId, universityId);

                GetReturnDTO<StudentDTO> dto = new()
                {
                    List = students
                    .Select(s => new StudentDTO
                    {
                        StudentId = s.Student.Id,
                        StudentFirstName = s.Student.FirstName,
                        StudentLastName = s.Student.LastName,
                        Birthday = s.Student.Birthday,
                        Age = DateTime.Now.Year - s.Student.Birthday.Year,
                        NationalCode = s.Student.NationalCode,
                        StudentNumber = s.Student.StudentNumber,
                        CourseId = s.ProfessorRelations.Course.Id,
                        Name = s.ProfessorRelations.Course.Name,
                        ProfessorId = s.ProfessorRelations.Professor.Id,
                        ProfessorFirstName = s.ProfessorRelations.Professor.FirstName,
                        ProfessorLastName = s.ProfessorRelations.Professor.LastName,
                        SemesterId = s.ProfessorRelations.Semester.Id,
                        SemesterNumber = s.ProfessorRelations.Semester.SemesterNumber
                    })
                    .ToPagedList(pageNumber, pageSize),
                    Count = students.Count()
                };

                return dto;
            });
        }

        public async Task<GetReturnDTO<StudentDTO>> GetListStudent(int pageNumber, int pageSize, string search,
            Guid semesterId, Guid universityId)
        {
            return await Task.Run(() =>
            {
                if (!_unitOfWork.SemesterRepository.CheckSemesterExistence(semesterId) && semesterId != Guid.Empty)
                    throw new NullReferenceException("ترم تعریف نشده است");

                if (!_unitOfWork.SemesterRepository.IsSemesterInUniversity(semesterId, universityId) &&
                semesterId != Guid.Empty)
                    throw new InvalidDataException("این ترم در دانشگاه شما تعریف نشده است");

                var result = _unitOfWork.StudentRelationsRepository.GetListStudent(search, semesterId, universityId);

                GetReturnDTO<StudentDTO> dto = new()
                {
                    List = result
                    .Select(s => new StudentDTO
                    {
                        StudentId = s.Student.Id,
                        StudentFirstName = s.Student.FirstName,
                        StudentLastName = s.Student.LastName,
                        Birthday = s.Student.Birthday,
                        Age = DateTime.Now.Year - s.Student.Birthday.Year,
                        NationalCode = s.Student.NationalCode,
                        StudentNumber = s.Student.StudentNumber,
                        CourseId = s.ProfessorRelations.Course.Id,
                        Name = s.ProfessorRelations.Course.Name,
                        ProfessorId = s.ProfessorRelations.Professor.Id,
                        ProfessorFirstName = s.ProfessorRelations.Professor.FirstName,
                        ProfessorLastName = s.ProfessorRelations.Professor.LastName,
                        SemesterId = s.ProfessorRelations.Semester.Id,
                        SemesterNumber = s.ProfessorRelations.Semester.SemesterNumber
                    })
                    .ToPagedList(pageNumber, pageSize),
                    Count = result.Count()
                };

                return dto;
            });
        }

        public async Task UpdateStudent(UpdateStudentCommand command, Guid userId, Guid universityId)
        {
            await Task.Run(() =>
            {
                if (_unitOfWork.StudentRepository
                .CheckStudentNationalCodeRepetivity(command.NationalCode, command.StudentId))
                    throw new InvalidDataException("کد ملی تکراری است");

                if (_unitOfWork.StudentRepository
                .CheckStudentNumberRepetivity(command.StudentNumber, command.StudentId))
                    throw new InvalidDataException("شماره دانشجویی تکراری است");

                if (!_unitOfWork.UniversityStudentRepository.IsStudentInUniversity(command.StudentId, universityId))
                    throw new InvalidDataException("دانشجو مورد نطر در دانشگاه شما تعریف نشده است");

                var student = _unitOfWork.StudentRepository.GetById(command.StudentId);

                student.FirstName = command.FirstName;
                student.LastName = command.LastName;
                student.Birthday = command.Birthday;
                student.NationalCode = command.NationalCode;
                student.StudentNumber = command.StudentNumber;
                student.ModifierId = userId;
                student.ModificationDate = DateTime.Now;
                _unitOfWork.Complete();
            });
        }

        public async Task RemoveStudent(Guid studentId, Guid userId, Guid universityId)
        {
            await Task.Run(() =>
            {
                if (!_unitOfWork.StudentRepository.CheckStudentExistence(studentId))
                    throw new NullReferenceException("دانشجو تعریف نشده است");

                if (!_unitOfWork.UniversityStudentRepository.IsStudentInUniversity(studentId, universityId))
                    throw new InvalidDataException("دانشجو مورد نطر در دانشگاه شما تعریف نشده است");

                var student = _unitOfWork.StudentRepository.GetById(studentId);

                _unitOfWork.StudentRepository.RemoveStudent(student, userId);

                if (_unitOfWork.Complete() > 0)
                {
                    var universityStudents = _unitOfWork.UniversityStudentRepository
                    .GetListUniversityStudent(studentId);
                    _unitOfWork.UniversityStudentRepository.DeleteListUniversityStudent(universityStudents);

                    var studentRelations = _unitOfWork.StudentRelationsRepository
                    .GetListStudentRelationsByStudentId(studentId);
                    _unitOfWork.StudentRelationsRepository.DeleteListStudentRelations(studentRelations);
                    _unitOfWork.Complete();
                }
            });
        }

        public async Task DeleteStudentFromCourse(DeleteStudentFromCourseCommand command, Guid universityId)
        {
            await Task.Run(() =>
            {
                var student = _unitOfWork.StudentRepository.GetById(command.StudentId);

                if (student == null)
                    throw new NullReferenceException("دانشجو تعریف نشده است");

                if (_unitOfWork.UniversityStudentRepository.IsStudentInUniversity(command.StudentId, universityId))
                    throw new InvalidDataException("این دانشجو در دانشگاه شما تعریف نشده است");

                var professorRelation = _unitOfWork.ProfessorRelationsRepository.GetById(command.ProfessorRelationId);

                if (professorRelation == null)
                    throw new NullReferenceException("رابطه درس و استاد تعریف نشده است");

                if (!_unitOfWork.ProfessorRelationsRepository.IsProfessorRelationsInUniversity(command.ProfessorRelationId, universityId))
                    throw new InvalidDataException("رابطه درس و استاد در دانشگاه شما تعریف نشده است");

                var studentRelation =
                _unitOfWork.StudentRelationsRepository.GetStudentRelation(student.Id, professorRelation.Id);

                if (studentRelation == null)
                    throw new NullReferenceException("این دانشجو درسی با این استاد در این ترم ندارد");

                _unitOfWork.StudentRelationsRepository.Delete(studentRelation.Id);
                _unitOfWork.Complete();
            });
        }
    }
}
