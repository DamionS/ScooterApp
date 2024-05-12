using ScooterApp.Models;
using ScooterApp.Services.Interfaces;

namespace ScooterApp.Services
{
    public class DatabaseService : IDatabaseService
    {

        public Person GetPerson(int personId)
        {
            return new Person();
        }

        public Scooter GetScooter(int scooterId)
        {
            return new Scooter();
        }
    }
}
