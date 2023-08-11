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
        public static LessonDTO Add(LessonDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<LessonDTO, Lesson>();
                cfg.CreateMap<Lesson, LessonDTO>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Lesson>(obj);
            var rs = DataAccessFactory.LessonDataAcess().Create(conv);

            return mapper.Map<LessonDTO>(rs);

        }
        public static List<LessonDTO> Get()
        {
            var data = DataAccessFactory.LessonDataAcess().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Lesson, LessonDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<LessonDTO>>(data);
            return cnvrt;
        }
    }
}
