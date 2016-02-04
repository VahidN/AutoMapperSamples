using System;
using Sample07.IoCConfig;
using Sample07.Services.Contracts;

namespace Sample07
{
    class Program
    {
        static void Main(string[] args)
        {
            printUsers();
            printAdvertisements();
        }

        private static void printUsers()
        {
            var usersService = SmObjectFactory.Container.GetInstance<IUsersService>();

            var allUsers = usersService.GetAll();
            foreach (var user in allUsers)
            {
                Console.WriteLine(user.Name);
            }

            var user1 = usersService.GetById(1);
            if (user1 != null)
            {
                Console.WriteLine(user1.Name);
            }
        }

        private static void printAdvertisements()
        {
            var advertisementsService = SmObjectFactory.Container.GetInstance<IAdvertisementsService>();

            var advertisements = advertisementsService.GetAll();
            foreach (var advertisement in advertisements)
            {
                Console.WriteLine(advertisement.Title);
            }

            var ad1 = advertisementsService.GetById(1);
            if (ad1 != null)
            {
                Console.WriteLine(ad1.Title);
            }
        }
    }
}