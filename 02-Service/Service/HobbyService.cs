using Model.Domain;
using NLog;
using Persistence.DbContextScope;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IHobbyService
    {
        IEnumerable<Hobby> GetAll();
        void Insert(Hobby model);
        void Deleted(int id);
    }
    public class HobbyService: IHobbyService
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Hobby> _hobbyRepo;

        public HobbyService(IDbContextScopeFactory dbContextScopeFactory, IRepository<Hobby> hobbyRepo)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _hobbyRepo = hobbyRepo;

        }

        public IEnumerable<Hobby> GetAll() {
            var result = new List<Hobby>();

            try
            {
                using (var ctx = _dbContextScopeFactory.CreateReadOnly())
                {
                    result = _hobbyRepo.GetAll().ToList();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }

            return result;
        }

        public void Insert(Hobby model) {
           // var rh = new ResponseHelper();

            try
            {
                using (var ctx = _dbContextScopeFactory.Create())
                {              
                    _hobbyRepo.Insert(model);
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
        }

        public void Deleted(int id) {
            try
            {
                using(var ctx = _dbContextScopeFactory.Create())
                {
                    var model = _hobbyRepo.Single(X => X.Id == id);
                    _hobbyRepo.Delete(model);
                    ctx.SaveChanges();
                }
            }
            catch (Exception e)
            {
                logger.Error(e.Message);
            }
        }
    }
}
