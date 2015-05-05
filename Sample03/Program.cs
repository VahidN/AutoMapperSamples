using System;
using Sample03.IoCConfig;
using Sample03.Services;

namespace Sample03
{
    class Program
    {
        static void Main(string[] args)
        {
            var usersService = SmObjectFactory.Container.GetInstance<IUsersService>();
            var user1 = usersService.GetName(id: 1);
            Console.WriteLine("{0}", user1.RegistrationDate);

            //var users = usersService.GetUsersList();
            //foreach (var user in users)
            //{
            //    Console.WriteLine("{0}", user.Name);
            //}
        }
    }
}
