namespace P03DependencyInversion.Contracts
{
    public interface ICalculator
    {
        void ChangeStrategy(ICalculationStrategy calculationStrategy);

        int PerformCalculation(int firstOperand, int secondOperand);
    }
}
