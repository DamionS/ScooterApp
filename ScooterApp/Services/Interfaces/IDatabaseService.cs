using ScooterApp.Models;

namespace ScooterApp.Services.Interfaces
{
    public interface IDatabaseService
    {
        public Person GetPerson(int personId);

        public Scooter GetScooter(int scooterId);
    }
}
