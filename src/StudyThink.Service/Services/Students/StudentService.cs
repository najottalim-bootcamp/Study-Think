using AutoMapper;
using Microsoft.AspNetCore.Http;
using StudyThink.DataAccess.Interfaces.Students;
using StudyThink.DataAccess.Utils;
using StudyThink.Domain.Entities.Students;
using StudyThink.Domain.Entities.Teachers;
using StudyThink.Domain.Exceptions.Files;
using StudyThink.Domain.Exceptions.Student;
using StudyThink.Domain.Exceptions.Teachers;
using StudyThink.Service.Common.Hasher;
using StudyThink.Service.DTOs.Student;
using StudyThink.Service.Interfaces.Common;
using StudyThink.Service.Interfaces.Studentsk;

namespace StudyThink.Service.Services.Students;

public class StudentService : IStudentService
{
    private IStudentRepository _studentRepository;
    private IFileService _fileService;
    private IMapper _mapper;
    public StudentService(IStudentRepository studentRepository, IFileService fileService, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _fileService = fileService;
        _mapper = mapper;
    }

    public async ValueTask<long> CountAsync()
    {
        long count = await _studentRepository.CountAsync();

        if (count == 0)
            throw new StudentNotFoundExeption();
        return count;
    }

    public async ValueTask<bool> CreateAsync(StudentCreationDto model)
    {
        Student student=_mapper.Map<Student>(model);

        if (model.ImagePath == null)
        {
            throw new ImageNotFoundException();
        }
        else
        {
            student.ImagePath=await _fileService.UploadImageAsync(model.ImagePath);
            student.Password=Hash512.GenerateHash512(model.Password);

            bool dbResult = await _studentRepository.CreateAsync(student);

            if (dbResult)
            
                return true;
            throw new StudentNotFoundExeption();
        }
    }

    public async ValueTask<bool> DeleteAsync(long Id)
    {
        Student student = await _studentRepository.GetByIdAsync(Id);

        if (student == null)
        {
            throw new StudentNotFoundExeption();
        }
        else
        {
            bool image = await _fileService.DeleteImageAsync(student.ImagePath);

            if (image == false) throw new ImageNotFoundException();

            bool res = await _studentRepository.DeleteAsync(Id);

            return res;
        }
    }

    public async ValueTask<bool> DeleteRangeAsync(List<long> studentIds)
    {
        foreach (var i in studentIds)
        {
            Student student = await _studentRepository.GetByIdAsync(i);

            if (student != null)
            {
                await _studentRepository.DeleteAsync(i);
                await _fileService.DeleteImageAsync(student.ImagePath);
            }
        }

        return true;
    }

    public async ValueTask<IEnumerable<Student>> GetAll(PaginationParams @params)
    {
        IEnumerable<Student> students = await _studentRepository.GetAllAsync(@params);

        if (students == null)
        {
            throw new StudentNotFoundExeption();
        }
        else
        {
            return students;
        }
    }

    public async ValueTask<Student> GetByIdAsync(long Id)
    {
        Student student = await _studentRepository.GetByIdAsync(Id);

        if (student == null)
        {
            throw new StudentNotFoundExeption();
        }
        return student;
    }

    public async ValueTask<bool> UpdateAsync(StudentUpdateDto model)
    {
        //Student student = _mapper.Map<Student>(model);

        //if (model.ImagePath == null)
        //{
        //    throw new ImageNotFoundException();
        //}
        //else
        //{
        //    student.ImagePath = await _fileService.UploadImageAsync(model.ImagePath);
        //    student.Password = Hash512.GenerateHash512(model.Password);

        //    bool dbResult = await _studentRepository.UpdateAsync(student);

        //    if (dbResult)

        //        return true;
            throw new StudentNotFoundExeption();
        }
    }

    public ValueTask<bool> UpdateImageAsync(long studentId, IFormFile imageStudent)
    {
        throw new NotImplementedException();
    }
}
