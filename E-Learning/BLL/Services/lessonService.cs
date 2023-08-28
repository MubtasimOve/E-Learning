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
    public class lessonService
    {

        public static bool Add(LessonDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LessonDTO, Lesson>();
                cfg.CreateMap<Lesson, LessonDTO>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Lesson>(obj);
            var rs = DataAccessFactory.LessonDataAccess().Create(conv);

            return mapper.Map<bool>(rs);

        }
        public static List<LessonDTO> Get()
        {
            var data = DataAccessFactory.LessonDataAccess().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Lesson, LessonDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<LessonDTO>>(data);
            return cnvrt;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.LessonDataAccess().Delete(id);
        }
        public static bool Update(LessonDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LessonDTO, Lesson>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Lesson>(obj);
            var rs = DataAccessFactory.LessonDataAccess().Update(conv);

            return rs;
        }
        public static LessonDTO Get(int id)
        {
            var data = DataAccessFactory.LessonDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Lesson, LessonDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<LessonDTO>(data);
            return cnvrt;
        }
        public static List<LessonDTO> GetByName(string title)
        {
            var data = (from l in DataAccessFactory.LessonDataAccess().Get()
                        where l.Title == title
                        select l).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Lesson, LessonDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<LessonDTO>>(data);
            return cnvrt;
        }
        public static List<LessonDTO> GetLessonsByCourseName(string courseName)
        {
            var data = (from c in DataAccessFactory.CourseDataAccess().Get()
                        where c.Name == courseName
                        select c.Lesson).ToList();

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Lesson, LessonDTO>();
            });
            var mapper = new Mapper(config);
            var convertedLessons = mapper.Map<List<LessonDTO>>(data.Select(c => c.Courses).ToList());

            return convertedLessons;
        }
    }
}
