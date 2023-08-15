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
    public class RegistrationService
    {
        public static RegistratioDTO Add(RegistratioDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegistratioDTO, Registration>();
                cfg.CreateMap<Registration, RegistratioDTO>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Registration>(obj);
            var rs = DataAccessFactory.RegistrationDataAccess().Create(conv);

            return mapper.Map<RegistratioDTO>(rs);

        }
        public static List<RegistratioDTO> Get()
        {
            var data = DataAccessFactory.RegistrationDataAccess().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Registration, RegistratioDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<RegistratioDTO>>(data);
            return cnvrt;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.RegistrationDataAccess().Delete(id);
        }
        public static bool Update(RegistratioDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegistratioDTO, Registration>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Registration>(obj);
            var rs = DataAccessFactory.RegistrationDataAccess().Update(conv);

            return rs;
        }
        public static RegistratioDTO Get(int id)
        {
            var data = DataAccessFactory.RegistrationDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Registration, RegistratioDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<RegistratioDTO>(data);
            return cnvrt;
        }
        public static List<RegistratioDTO> GetByName(string name)
        {
            var data = (from p in DataAccessFactory.RegistrationDataAccess().Get()
                        where p.Name == name
                        select p).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Registration, RegistratioDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<RegistratioDTO>>(data);
            return cnvrt;
        }
    }
}
