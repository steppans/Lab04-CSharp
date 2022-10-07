using ClassLibrary04;

// Initialization of cars
Car carOne = new("Porsche", 2010, 225);
Car carTwo = new("BMW", 2017, 250);
Car carThree = new("Lada", 2012, 200);

// Collection of cars
List<Car> cars = new List<Car>() { carOne, carTwo, carThree };
//cars.Add(carOne);
//cars.Add(carTwo);
//cars.Add(carThree);

Console.WriteLine("-----------Unsoreted collection of cars----------");
DisplayCollection(cars);
Console.WriteLine("-----------Sort by name----------");
cars.Sort(new CarComparer(CarComparerType.Name));
DisplayCollection(cars);
Console.WriteLine("-----------Sort by production year----------");
cars.Sort(new CarComparer(CarComparerType.ProductionYear));
DisplayCollection(cars);
Console.WriteLine("-----------Sort by max speed----------");
cars.Sort(new CarComparer(CarComparerType.MaxSpeed));
DisplayCollection(cars);


// For print cars in console
void DisplayCollection(List<Car> cars)
{
    for (int i = 0; i < cars.Count; ++i)
    {
        Console.WriteLine(cars[i]);
    }
}
