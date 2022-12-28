using System;
using System.Collections;
using System.Collections.Generic;

namespace _5_D_in_SOLID
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var manager = new UserManager();

            var user = new BigonUser();


            manager.CreateAsync(user);
        }
    }

    //high level
    public class UserManager
    {
        public IEnumerable<IUser> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public void CreateAsync(IUser user)
        {
        }
    }

    //low level
    public class BigonUser : IUser
    {

    }

    public interface IUser
    {

    }
}
