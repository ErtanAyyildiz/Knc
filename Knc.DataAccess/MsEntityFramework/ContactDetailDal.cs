using Knc.DataAccess.Abstracts;
using Knc.DataAccess.Database;
using Knc.Entity.Modals;
using RailwayStation.DataAccess.Repositories;

namespace Knc.DataAccess.MsEntityFramework
{
    public class ContactDetailDal:Repository<ContactDetail>,IContactDetailDal
    {
        private readonly AppDbContext _db;

        public ContactDetailDal(AppDbContext db) : base(db)
        {
            _db=db;
        }
    }
}
