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
        public static bool Add(RegistrationDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegistrationDTO, Registration>();
                cfg.CreateMap<Registration, RegistrationDTO>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Registration>(obj);
            var rs = DataAccessFactory.RegistrationDataAccess().Create(conv);

            return mapper.Map<bool>(rs);

        }
        public static List<RegistrationDTO> Get()
        {
            var data = DataAccessFactory.RegistrationDataAccess().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Registration, RegistrationDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<RegistrationDTO>>(data);
            return cnvrt;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.RegistrationDataAccess().Delete(id);
        }
        public static bool Update(RegistrationDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegistrationDTO, Registration>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Registration>(obj);
            var rs = DataAccessFactory.RegistrationDataAccess().Update(conv);

            return rs;
        }
        public static RegistrationDTO Get(int id)
        {
            var data = DataAccessFactory.RegistrationDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Registration, RegistrationDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<RegistrationDTO>(data);
            return cnvrt;
        }
        public static List<RegistrationDTO> GetByName(string name)
        {
            var data = (from p in DataAccessFactory.RegistrationDataAccess().Get()
                        where p.Name == name
                        select p).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Registration, RegistrationDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<RegistrationDTO>>(data);
            return cnvrt;
        }
    }
}
