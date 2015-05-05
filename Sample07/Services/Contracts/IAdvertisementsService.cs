using System.Collections.Generic;
using Sample07.Models;

namespace Sample07.Services.Contracts
{
    public interface IAdvertisementsService
    {
        IEnumerable<Advertisement> GetAll();
        Advertisement GetById(int id);
    }
}