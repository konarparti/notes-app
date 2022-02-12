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
        private MyNotionDbContext _db;
        private IEnumerable<Interest> _interests;
        public EFRepository(MyNotionDbContext db)
        {
            _db = db;
            _db.Interests.Load();
            _interests = _db.Interests.Local.ToBindingList();
        }

        public IEnumerable<Interest> GetAll() => _interests;
    }
}
