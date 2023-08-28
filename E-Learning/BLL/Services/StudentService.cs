using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService
    {
        public static bool Add(StudentDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentDTO, Student>();
                cfg.CreateMap<Student, StudentDTO>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Student>(obj);
            var rs = DataAccessFactory.StudentDataAccess().Create(conv);

            return mapper.Map<bool>(rs);

        }
        public static List<StudentDTO> Get()
        {
            var data = DataAccessFactory.StudentDataAccess().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<StudentDTO>>(data);
            return cnvrt;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.StudentDataAccess().Delete(id);
        }
        public static bool Update(StudentDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<StudentDTO, Student>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Student>(obj);
            var rs = DataAccessFactory.StudentDataAccess().Update(conv);

            return rs;
        }
        public static StudentDTO Get(int id)
        {
            var data = DataAccessFactory.StudentDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<StudentDTO>(data);
            return cnvrt;
        }
        public static List<StudentDTO> GetByName(string fname)
        {
            var data = (from p in DataAccessFactory.StudentDataAccess().Get()
                        where p.fname == fname
                        select p).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student, StudentDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<StudentDTO>>(data);
            return cnvrt;
        }
        public static List<ParentDTO> GetParentDetailsByStudentName(string studentFirstName)
        {
            var data = (from student in DataAccessFactory.StudentDataAccess().Get()
                        where student.fname == studentFirstName
                        select student.Parent).ToList();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Parent, ParentDTO>();
            });
            var mapper = new Mapper(config);
            var parentDetails = mapper.Map<List<ParentDTO>>(data);

            return parentDetails;
        }
        public static ParentDTO GetParentByStudentId(int studentId)
        {
            var student = DataAccessFactory.StudentDataAccess().Get(studentId);

            var parent = student.Parent;
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Parent, ParentDTO>();
            });
            var mapper = new Mapper(config);
            var parentDto = mapper.Map<ParentDTO>(parent);

            return parentDto;
        }
    }
}
