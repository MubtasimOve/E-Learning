using DAL.EF.Model;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, int, Token>
    {
        public Token Create(Token obj)
        {
            db.Token.Add(obj);
            db.SaveChanges();
            return obj;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Token> Get()
        {
            return db.Token.ToList();
        }

        public Token Get(int id)
        {
            return db.Token.Find(id);
        }

        public Token Update(Token obj)
        {
            throw new NotImplementedException();
        }
    }
}
