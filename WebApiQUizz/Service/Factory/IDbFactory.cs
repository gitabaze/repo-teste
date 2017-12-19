using Models;

namespace WebApiQUizz.Service
{
   public  interface IDbFactory
    {
        QuizzContext Init();
    }
}
