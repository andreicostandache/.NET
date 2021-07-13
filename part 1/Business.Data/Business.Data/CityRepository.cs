using System;
using System.Linq;
namespace Business.Data
{
    class CityRepository
    {
        ApplicationContext _applicationContext;
        public CityRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public void CreateCity(string name,string description,double latitude,double longitude)
        {
            _applicationContext.Cities.Add(new City(name, description, latitude, longitude));
        }
        public void RemoveCity(Guid guid)
        {
            City city=_applicationContext.Cities.Where(c => c.Id == guid).First();
            _applicationContext.Cities.Remove(city);
        }
    }
}
