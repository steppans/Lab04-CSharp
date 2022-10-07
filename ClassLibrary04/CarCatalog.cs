namespace ClassLibrary04
{
    public class CarCatalog
    {
        private List<Car> _cars = new();

        public CarCatalog(params Car[] cars)
        {
            foreach(Car car in cars)
            {
                _cars.Add(car);
            }
        }

        public IEnumerator<Car> GetEnumerator()
        {
            for (int i = 0; i < _cars.Count; ++i)
            {
                yield return _cars[i];
            }
        }

        public IEnumerable<Car> Reverse()
        {
            for (int i = _cars.Count - 1; i >= 0; --i)
            {
                yield return _cars[i];
            }
        }

        public IEnumerable<Car> ProductionYearFilter(int year)
        {
            
            for (int i = 0; i < _cars.Count; ++i)
            {
                if (_cars[i].ProductionYear == year)
                {
                    yield return _cars[i];
                }
               
            }
        }

        public IEnumerable<Car> MaxSpeedFilter(int speed)
        {
            for (int i = 0; i < _cars.Count; ++i)
            {
                if (_cars[i].MaxSpeed > speed)
                {
                    yield return _cars[i];

                }
            }
        }




    }
}
