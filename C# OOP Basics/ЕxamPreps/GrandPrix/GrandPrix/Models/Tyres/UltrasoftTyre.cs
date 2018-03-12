using System;

public class UltrasoftTyre : Tyre
{
    public UltrasoftTyre(double hardness, double grip)
        : base(hardness)
    {
        this.Grip = grip;
    }

    public override string Name => "Ultrasoft";

    public double Grip { get; }

    public override double Degradation
    {
        get => this.degradation;
        protected set
        {
            if (value < 30)
            {
                throw new ArgumentException("Blown Tyre");
            }
            this.degradation = value;
        }
    }

    public override void ReduceDegradation()
    {
        this.Degradation -= this.Hardness + this.Grip;
    }
}
