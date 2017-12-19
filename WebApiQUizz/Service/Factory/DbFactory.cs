using Models;

namespace WebApiQUizz.Service
{
    public class DbFactory : IDbFactory
    {
        QuizzContext dbContext;

        public QuizzContext Init()
        {
            return dbContext ?? (dbContext = new QuizzContext());
        }
    }
}