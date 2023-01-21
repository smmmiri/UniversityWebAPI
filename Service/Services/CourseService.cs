using Domain.Entities;
using Message.Commands;
using Message.DTOs;
using Message.ExtensionMethods;
using Repository;
using Service.Interfaces;

namespace Service.ControllersServices
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddCourse(AddCourseCommand command, Guid userId, Guid universityId)
        {
            await Task.Run(() =>
            {
                Course course = _unitOfWork.CourseRepository.AddCourse(command, universityId);
                course.CreatorId = userId;
                _unitOfWork.CourseRepository.Add(course);
                _unitOfWork.Complete();
            });
        }

        public async Task AddScore(AddScoreCommand command, Guid userId, Guid universityId)
        {
            await Task.Run(() =>
            {
                if (!_unitOfWork.SemesterRepository.CheckSemesterExistence(command.SemesterId))
                    throw new NullReferenceException("ترم تعریف نشده است");

                if (!_unitOfWork.SemesterRepository.IsSemesterInUniversity(command.SemesterId, universityId))
                    throw new InvalidDataException("ترم در این دانشگاه تعریف نشده‌اند");

                if (!_unitOfWork.CourseRepository.CheckCourseExistence(command.CourseId))
                    throw new NullReferenceException("درس تعریف نشده است");

                if (!_unitOfWork.CourseRepository.IsCourseInUniversity(command.CourseId, universityId))
                    throw new InvalidDataException("درس در این دانشگاه تعریف نشده‌اند");

                if (!_unitOfWork.StudentRepository.CheckStudentExistence(command.StudentId))
                    throw new NullReferenceException("دانشجو تعریف نشده است");

                if (!_unitOfWork.UniversityStudentRepository.IsStudentInUniversity(command.StudentId, universityId))
                    throw new InvalidDataException("دانشجو در این دانشگاه تعریف نشده‌اند"); 

                var courseStudent = 
                _unitOfWork.StudentRelationsRepository
                .GetStudentRelations(command.StudentId, command.CourseId, command.SemesterId, universityId);

                courseStudent.Score = command.Score;
                courseStudent.IsActive = true;
                courseStudent.CreatorId = userId;
                courseStudent.CreationDate = DateTime.Now;
                _unitOfWork.Complete();
            });
        }

        public async Task<GetReturnDTO<OnlyCourseDTO>> GetListCourse
            (int pageNumber, int pageSize, string search, Guid universityId)
        {
            return await Task.Run(() =>
            {
                var courses = _unitOfWork.CourseRepository.GetListCourse(search, universityId);

                GetReturnDTO<OnlyCourseDTO> dto = new()
                {
                    List = courses
                    .Select(r => new OnlyCourseDTO
                    {
                        CourseId = r.Id,
                        Name = r.Name,
                        Unit = r.Unit
                    })
                    .ToPagedList(pageNumber, pageSize),
                    Count = courses.Count()
                };

                return dto;
            });
        }

        public async Task<GetReturnDTO<CourseDTO>> GetListCourse
            (int pageNumber, int pageSize, string search, Guid semesterId, Guid universityId)
        {
            return await Task.Run(() =>
            {
                if (!_unitOfWork.SemesterRepository.CheckSemesterExistence(semesterId) && semesterId != Guid.Empty)
                    throw new NullReferenceException("ترم تعریف نشده است");

                if (!_unitOfWork.SemesterRepository.IsSemesterInUniversity(semesterId, universityId) && 
                semesterId != Guid.Empty)
                    throw new InvalidDataException("این ترم در دانشگاه شما تعریف نشده است");

                var courses = _unitOfWork.ProfessorRelationsRepository
                .GetListCourse(search, semesterId, universityId);

                GetReturnDTO<CourseDTO> dto = new()
                {
                    List = courses
                    .Select(c => new CourseDTO
                    {
                        CourseId = c.Course.Id,
                        Name = c.Course.Name,
                        Unit = c.Course.Unit,
                        ProfessorId = c.Professor.Id,
                        ProfessorFirstName = c.Professor.FirstName,
                        ProfessorLastName = c.Professor.LastName,
                        SemesterId = c.Semester.Id,
                        SemesterNumber = c.Semester.SemesterNumber
                    })
                    .ToPagedList(pageNumber, pageSize),
                    Count = courses.Count()
                };

                return dto;
            });
        }

        public async Task<GetReturnDTO<CourseWithStudentDTO>> GetListCourseOfStudent
            (int pageNumber, int pageSize, Guid studentId, Guid semesterId, Guid universityId)
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

                var courses = _unitOfWork.StudentRelationsRepository
                .GetListCourse(studentId, semesterId, universityId);

                GetReturnDTO<CourseWithStudentDTO> dto = new()
                {
                    List = courses
                    .Select(c => new CourseWithStudentDTO
                    {
                        CourseId = c.ProfessorRelations.Course.Id,
                        Name = c.ProfessorRelations.Course.Name,
                        Unit = c.ProfessorRelations.Course.Unit,
                        StudentId = c.Student.Id,
                        StudentFirstName = c.Student.FirstName,
                        StudentLastName = c.Student.LastName,
                        ProfessorId = c.ProfessorRelations.Professor.Id,
                        ProfessorFirstName = c.ProfessorRelations.Professor.FirstName,
                        ProfessorLastName = c.ProfessorRelations.Professor.LastName,
                        SemesterId = c.ProfessorRelations.Semester.Id,
                        SemesterNumber = c.ProfessorRelations.Semester.SemesterNumber
                    })
                    .ToPagedList(pageNumber, pageSize),
                    Count = courses.Count()
                };

                return dto;
            });
        }

        public async Task<GetReturnDTO<CourseDTO>> GetListCourseOfProfessor
            (int pageNumber, int pageSize, Guid professorId, Guid semesterId, Guid universityId)
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

                var courses = _unitOfWork.ProfessorRelationsRepository
                .GetListCourse(semesterId, professorId, universityId);

                GetReturnDTO<CourseDTO> dto = new()
                {
                    List = courses
                    .Select(c => new CourseDTO
                    {
                        CourseId = c.Course.Id,
                        Name = c.Course.Name,
                        Unit = c.Course.Unit,
                        ProfessorId = c.Professor.Id,
                        ProfessorFirstName = c.Professor.FirstName,
                        ProfessorLastName = c.Professor.LastName,
                        SemesterId = c.Semester.Id,
                        SemesterNumber = c.Semester.SemesterNumber
                    })
                    .ToPagedList(pageNumber, pageSize),
                    Count = courses.Count()
                };

                return dto;
            });
        }

        public async Task UpdateCourse(UpdateCourseCommand command, Guid userId, Guid universityId)
        {
            await Task.Run(() =>
            {
                var course = _unitOfWork.CourseRepository.GetById(command.CourseId);

                if (course.UniversityId != universityId)
                    throw new InvalidDataException("این درس در دانشگاه شما تعریف نشده است");

                course.Name = command.Name;
                course.Unit = command.Unit;
                course.ModifierId = userId;
                course.ModificationDate = DateTime.Now;
                _unitOfWork.Complete();
            });
        }

        public async Task UpdateScore(UpdateScoreCommand score, Guid userId, Guid universityId)
        {
            await Task.Run(() =>
            {
                if (!_unitOfWork.SemesterRepository.CheckSemesterExistence(score.SemesterId))
                    throw new NullReferenceException("ترم تعریف نشده است");

                if (!_unitOfWork.SemesterRepository.IsSemesterInUniversity(score.SemesterId, universityId))
                    throw new InvalidDataException("این ترم در دانشگاه شما تعریف نشده است");

                if (!_unitOfWork.CourseRepository.CheckCourseExistence(score.CourseId))
                    throw new InvalidDataException("درس تعریف نشده است");

                if (!_unitOfWork.CourseRepository.IsCourseInUniversity(score.CourseId, universityId))
                    throw new InvalidDataException("این درس در دانشگاه شما تعریف نشده است");

                if (!_unitOfWork.StudentRepository.CheckStudentExistence(score.StudentId))
                    throw new InvalidDataException("دانشجو تعریف نشده است");

                if (!_unitOfWork.UniversityStudentRepository.IsStudentInUniversity(score.StudentId, universityId))
                    throw new InvalidDataException("این دانشجو در دانشگاه یا ترم شما تعریف نشده است");

                var courseStudent = 
                _unitOfWork.StudentRelationsRepository
                .GetStudentRelations(score.StudentId, score.CourseId, score.SemesterId, universityId);

                courseStudent.Score = score.Score;
                courseStudent.ModifierId = userId;
                courseStudent.ModificationDate = DateTime.Now;
                _unitOfWork.Complete();
            });
        }

        public async Task RemoveCourse(Guid courseId, Guid userId, Guid universityId)
        {
            await Task.Run(() =>
            {
                var course = _unitOfWork.CourseRepository.GetById(courseId);

                if (course == null)
                    throw new NullReferenceException("درس تعریف نشده است");

                if (course.UniversityId != universityId)
                    throw new InvalidDataException("این درس در دانشگاه شما تعریف نشده است");

                _unitOfWork.CourseRepository.RemoveCourse(course, userId);

                if (_unitOfWork.Complete() > 0)
                {
                    var professorRelations = 
                    _unitOfWork.ProfessorRelationsRepository.GetListProfessorRelationsByCourseId(courseId);
                    var studentRelations = 
                    _unitOfWork.StudentRelationsRepository.GetListStudentRelationsByCourseId(courseId);

                    _unitOfWork.StudentRelationsRepository.DeleteListStudentRelations(studentRelations);
                    _unitOfWork.ProfessorRelationsRepository.DeleteListProfessorRelations(professorRelations);
                    _unitOfWork.Complete();
                }
            });
        }
    }
}
