using ScooterApp.Services.Interfaces;

namespace ScooterApp.Services
{
    public class ScooterServices
    {
        private IDatabaseService _databaseService;

        public ScooterServices(IDatabaseService dbService) {
            _databaseService = dbService;
        }

        public bool HireScooter(int personId, int scooterId) 
        {
            var personToHireScoter = _databaseService.GetPerson(personId);
            var scooterToHire = _databaseService.GetScooter(scooterId);

            if (scooterToHire.IsHired && scooterToHire.HiredBy == personId)
            {
                throw new Exception("Person already has hired This scooter");
            }

            if (personToHireScoter.HasHiredScooter)
            {
                throw new Exception("Person already has hired a scooter");
            }

            if (scooterToHire.IsHired)
            {
                throw new Exception("Scooter is not available because is is already hired");
            }

            return true;
        }

    }
}
