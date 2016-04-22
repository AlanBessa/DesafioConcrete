using DCS.Infra.Data.Context;
using DCS.Infra.Data.UnitOfWork.Interface;

namespace DCS.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DCSContext _context;

        public UnitOfWork(DCSContext dbContext)
        {
            _context = dbContext;
        }
        
        public void Commit()
        {
            _context.SaveChanges();
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
