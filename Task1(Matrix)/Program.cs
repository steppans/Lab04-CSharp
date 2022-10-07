using ClassLibrary04;

// Debug for matrix
MyMatrix matr1 = new(2, 2);
MyMatrix matr2 = new(2, 2);
matr1.SetData(1, 5);
matr2.SetData(2, 5);
matr1.PrintMatrix();
matr2.PrintMatrix();

MyMatrix result = matr1 * 3;
matr1 /= 32;
matr1.PrintMatrix();
result.PrintMatrix();
result = result / 3;
result.PrintMatrix();

try
{
    var matr3 = matr1 + matr2;
    matr3.PrintMatrix();
} catch (Exception e)
{
    Console.WriteLine(e);
}

try
{
    var matr3 = matr1 * matr2;
    matr3.PrintMatrix();
}
catch (Exception e)
{
    Console.WriteLine(e);
}
