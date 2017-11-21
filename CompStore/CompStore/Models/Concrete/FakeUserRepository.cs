using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompStore.Models.Abstract;

namespace CompStore.Models.Concrete
{
    public class FakeUserRepository : IUserRepository
    {
        private static IQueryable<User> UsersList = new List<User>
        {
           new User {Login = "1", Password = "1", Surname = "1",  Name = "1", Patronymic = "1", Post = "1", n_per_file = 1, Id_shop = 1, Salary =1, Id_role="1" }
        }.AsQueryable();

      public  IQueryable<User> Users
        {
            get
            {
                return UsersList;
            }
        }
    }
    }
