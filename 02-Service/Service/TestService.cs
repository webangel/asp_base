using Model.Domain;
using Persistence.DbContextScope;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ITestService {
        IEnumerable<Course> GetAll();
    }
    public class TestService : ITestService
    {
        private readonly IDbContextScopeFactory _dbContextScopeFactory;
        private readonly IRepository<Course> _coursePero;

        public TestService(IDbContextScopeFactory dbContextScopeFactory, IRepository<Course> coursePero)
        {
            _dbContextScopeFactory = dbContextScopeFactory;
            _coursePero = coursePero;
    }
    public IEnumerable<Course> GetAll() {
            var courses = new List<Course>();

            using (var ctx = _dbContextScopeFactory.CreateReadOnly()) {
                courses = _coursePero.GetAll(x => x.StudentPerCourses).ToList();
            }

                return courses;
        }
    }
}
