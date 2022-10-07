using ClassLibrary04;

// Initialization of cars
Car carOne = new("Porsche", 2010, 325);
Car carTwo = new("BMW", 2017, 350);
Car carThree = new("Lada", 2010, 200);
Car carFour = new("KIA", 2014, 220);

CarCatalog carCatalog = new(carOne, carTwo, carThree, carFour);

Console.WriteLine("-----------First to last cars----------");
foreach(Car car in carCatalog)
{
    Console.WriteLine(car);
}

Console.WriteLine("-----------Last to first cars----------");
foreach (Car car in carCatalog.Reverse())
{
    Console.WriteLine(car);
}

Console.WriteLine("-----------Filter by production year----------");
foreach (Car car in carCatalog.ProductionYearFilter(2010))
{
    Console.WriteLine(car);
}

Console.WriteLine("-----------Filter by max speed----------");
foreach (Car car in carCatalog.MaxSpeedFilter(300))
{
    Console.WriteLine(car);
}

