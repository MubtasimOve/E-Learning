using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CourseService
    {
        public static CourseDTO Add(CourseDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CourseDTO, Course>();
                cfg.CreateMap<Course, CourseDTO>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Course>(obj);
            var rs = DataAccessFactory.CourseDataAccess().Create(conv);

            return mapper.Map<CourseDTO>(rs);

        }
        public static List<CourseDTO> Get()
        {
            var data = DataAccessFactory.CourseDataAccess().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Course, CourseDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<CourseDTO>>(data);
            return cnvrt;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.CourseDataAccess().Delete(id);
        }
        public static bool Update(CourseDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CourseDTO, Course>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Course>(obj);
            var rs = DataAccessFactory.CourseDataAccess().Update(conv);

            return rs;
        }
        public static CourseDTO Get(int id)
        {
            var data = DataAccessFactory.CourseDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Course, CourseDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<CourseDTO>(data);
            return cnvrt;
        }
        public static List<CourseDTO> GetByName(string name)
        {
            var data = (from p in DataAccessFactory.CourseDataAccess().Get()
                        where p.Name == name
                        select p).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Course, CourseDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<CourseDTO>>(data);
            return cnvrt;
        }
    }
}
