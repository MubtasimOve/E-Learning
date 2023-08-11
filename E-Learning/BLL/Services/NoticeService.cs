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
    public class NoticeService
    {
        public static NoticeDTO Add(NoticeDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NoticeDTO, Notice>();
                cfg.CreateMap<Notice, NoticeDTO>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Notice>(obj);
            var rs = DataAccessFactory.NoticeDataAccess().Create(conv);

            return mapper.Map<NoticeDTO>(rs);

        }
        public static List<NoticeDTO> Get()
        {
            var data = DataAccessFactory.NoticeDataAccess().Get();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Notice, NoticeDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<NoticeDTO>>(data);
            return cnvrt;
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.NoticeDataAccess().Delete(id);
        }
        public static bool Update(NoticeDTO obj)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<NoticeDTO, Notice>();
            });
            var mapper = new Mapper(config);
            var conv = mapper.Map<Notice>(obj);
            var rs = DataAccessFactory.NoticeDataAccess().Update(conv);

            return rs;
        }
        public static NoticeDTO Get(int id)
        {
            var data = DataAccessFactory.NoticeDataAccess().Get(id);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Notice, NoticeDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<NoticeDTO>(data);
            return cnvrt;
        }
        public static List<NoticeDTO> GetByName(string title)
        {
            var data = (from n in DataAccessFactory.NoticeDataAccess().Get()
                        where n.Title == title
                        select n).ToList();
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Notice, NoticeDTO>();
            });
            var mapper = new Mapper(config);
            var cnvrt = mapper.Map<List<NoticeDTO>>(data);
            return cnvrt;
        }
    }
}
