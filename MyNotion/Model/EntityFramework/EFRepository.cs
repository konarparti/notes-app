using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyNotion.Model.Abstract;

namespace MyNotion.Model.EntityFramework
{
    public class EFRepository : IRepository
    {
        private readonly MyNotionDbContext _context;
        public EFRepository(MyNotionDbContext context)
        {
            _context = context;
        }

        public IQueryable<Interest> Interests => _context.Interests;
        public void SaveInterest(Interest interest)
        {
            if (interest.Id == 0)
            {
                _context.Interests.Add(interest);
            }
            else
            {
                var dbEntry = _context.Interests.FirstOrDefault(i => i.Id == interest.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = interest.Name;
                    dbEntry.Progress = interest.Progress;
                    dbEntry.Scope = interest.Scope;
                    dbEntry.Status = interest.Status;
                    dbEntry.Type = interest.Type;
                }
            }

            _context.SaveChanges();
        }

        public Interest? DeleteInterest(long interestsId)
        {
            var dbEntry = _context.Interests.FirstOrDefault(i => i.Id == interestsId);
            if (dbEntry == null) return dbEntry;
            _context.Interests.Remove(dbEntry);
            _context.SaveChanges();

            return dbEntry;
        }
    }
}
