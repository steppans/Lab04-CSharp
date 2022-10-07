namespace ClassLibrary04
{
    public record Car(string Name, int ProductionYear, int MaxSpeed)
    {
        public override string ToString() => $"{Name} {ProductionYear} max speed: {MaxSpeed}";
    }

    public enum CarComparerType
    {
        Name,
        ProductionYear,
        MaxSpeed
    }

    public class CarComparer: IComparer<Car>
    {
        private CarComparerType _compareType;
        public CarComparer(CarComparerType compareType) => _compareType = compareType;

        public int Compare(Car? left, Car? right)
        {
            if (left == null && right == null) return 0;
            if (left == null) return 1;
            if (right == null) return -1;

            return _compareType switch
            {
                CarComparerType.Name => left.Name.CompareTo(right.Name),
                CarComparerType.ProductionYear => left.ProductionYear.CompareTo(right.ProductionYear),
                CarComparerType.MaxSpeed => left.MaxSpeed.CompareTo(right.MaxSpeed),
                _ => throw new ArgumentException("Unexpected compare type")
            };
        }
    }
}
