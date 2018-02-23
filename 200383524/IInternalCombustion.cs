namespace _200383524
{
    public interface IInternalCombustion : IPowerPlant
    {
        int Cylinders { get; }
        int Displacement { get; }

        int GetCylinders();
        int GetDisplacement();
    }
}