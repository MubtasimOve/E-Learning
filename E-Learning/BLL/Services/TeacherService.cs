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
    public class TeacherService
    {
        public static TeacherDTO Add(TeacherDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TeacherDTO, Teacher>();
                cfg.CreateMap<Teacher, TeacherDTO>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Teacher>(obj);
            var rs = DataAccessFactory.TeacherDataAccess().Create(conv);

            return mapper.Map<TeacherDTO>(rs);

        }
        public static List<TeacherDTO> Get()
        {
            var data = DataAccessFactory.TeacherDataAccess().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Teacher, TeacherDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<TeacherDTO>>(data);
            return cnvrt;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.TeacherDataAccess().Delete(id);
        }
        public static bool Update(TeacherDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TeacherDTO, Teacher>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Teacher>(obj);
            var rs = DataAccessFactory.TeacherDataAccess().Update(conv);

            return rs;
        }
        public static TeacherDTO Get(int id)
        {
            var data = DataAccessFactory.TeacherDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Teacher, TeacherDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<TeacherDTO>(data);
            return cnvrt;
        }
        public static List<TeacherDTO> GetByName(string name)
        {
            var data = (from p in DataAccessFactory.TeacherDataAccess().Get()
                        where p.Name == name
                        select p).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Teacher, TeacherDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<TeacherDTO>>(data);
            return cnvrt;
        }
    }
}
