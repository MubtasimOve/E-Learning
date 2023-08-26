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
    public class AuthService
    {
        public static TokenDTO Login(string Username, string Password)
        {
            var data = DataAccessFactory.AuthDataAccess().Authenticate(Username, Password);
            if (data != null)
            {
                var token = new Token();
                token.UId = data.Id;
                token.TokenKey = Guid.NewGuid().ToString();
                token.CreatedAt = DateTime.Now;
                token.ExpiredAt = null;
                var tk = DataAccessFactory.TokenDataAccess().Create(token);

                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Token, TokenDTO>();
                });
                var mapper = new Mapper(config);
                var ret = mapper.Map<TokenDTO>(tk);
                return ret;
            }
            return null;
        }
        public static bool IsTokenValid(string token)
        {
            var tk = (from t in DataAccessFactory.TokenDataAccess().Get()
                      where t.TokenKey.Equals(token)
                      && t.ExpiredAt == null
                      select t).SingleOrDefault();
            if (tk != null)
            {
                return true;
            }
            return false;
        }

        public static bool IsTeacher(string token)
        {
            var tk = (from t in DataAccessFactory.TokenDataAccess().Get()
                      where t.TokenKey.Equals(token)
                      && t.ExpiredAt == null
                      && t.Registration.Type.Equals("Teacher")
                      select t).SingleOrDefault();
            return tk != null;
        }


        public static bool IsStudent(string token)
        {
            var tk = (from t in DataAccessFactory.TokenDataAccess().Get()
                      where t.TokenKey.Equals(token)
                      && t.ExpiredAt == null
                      && t.Registration.Type.Equals("Student")
                      select t).SingleOrDefault();
            return tk != null;
        }


        public static bool IsParent(string token)
        {
            var tk = (from t in DataAccessFactory.TokenDataAccess().Get()
                      where t.TokenKey.Equals(token)
                      && t.ExpiredAt == null
                      && t.Registration.Type.Equals("Parent")
                      select t).SingleOrDefault();
            return tk != null;
        }

    }
}
