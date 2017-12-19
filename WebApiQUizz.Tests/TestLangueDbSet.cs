using Models;
using System;
using System.Linq;


namespace WebApiQUizz.Tests
{
    class TestLangueDbSet : TestDbSet<Langue>
    {
        public override Langue Find(params object[] keyValues)
        {
            return this.SingleOrDefault(langue => langue.Id == (int)keyValues.Single());
        }
    }


}
