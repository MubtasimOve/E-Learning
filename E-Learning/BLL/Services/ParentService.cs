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
    public class ParentService
    {
        public static ParentDTO Add(ParentDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ParentDTO, Parent>();
                cfg.CreateMap<Parent, ParentDTO>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Parent>(obj);
            var rs = DataAccessFactory.ParentDataAccess().Create(conv);

            return mapper.Map<ParentDTO>(rs);

        }
        public static List<ParentDTO> Get()
        {
            var data = DataAccessFactory.ParentDataAccess().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Parent, ParentDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<ParentDTO>>(data);
            return cnvrt;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.ParentDataAccess().Delete(id);
        }
        public static bool Update(ParentDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ParentDTO, Parent>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Parent>(obj);
            var rs = DataAccessFactory.ParentDataAccess().Update(conv);

            return rs;
        }
        public static ParentDTO Get(int id)
        {
            var data = DataAccessFactory.ParentDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Parent, ParentDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<ParentDTO>(data);
            return cnvrt;
        }
        public static List<ParentDTO> GetByName(string fname)
        {
            var data = (from p in DataAccessFactory.ParentDataAccess().Get()
                        where p.fname == fname
                        select p).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Parent, ParentDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<ParentDTO>>(data);
            return cnvrt;
        }
    }
}
