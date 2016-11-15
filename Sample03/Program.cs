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
            /*var user1 = usersService.GetName(id: 1);
            Console.WriteLine("{0}", user1.RegistrationDate);*/

            var users = usersService.GetUsersList();
            foreach (var user in users)
            {
                Console.WriteLine("{0} - {1}", user.Name, user.RegistrationDate);
            }

            var people = usersService.GetPeopleList();
            foreach (var person in people)
            {
                Console.WriteLine("{0} - {1}", person.Name, person.LastName);
            }

            var appUsers = usersService.GetApplicationUsersList();
            foreach (var user in appUsers)
            {
                Console.WriteLine("{0} - {1}", user.UserName, user.LastName);
            }

            Console.WriteLine("\nPress a key...");
            Console.ReadKey();
        }
    }
}
