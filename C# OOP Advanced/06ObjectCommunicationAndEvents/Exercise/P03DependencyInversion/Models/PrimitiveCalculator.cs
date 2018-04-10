namespace P03DependencyInversion.Models
{
    using Contracts;

    public class PrimitiveCalculator : ICalculator
    {
        private ICalculationStrategy calculationStrategy;

        public PrimitiveCalculator(ICalculationStrategy calculationStrategy)
        {
            ChangeStrategy(calculationStrategy);
        }

        public void ChangeStrategy(ICalculationStrategy calculationStrategy)
        {
            this.calculationStrategy = calculationStrategy;
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
           return this.calculationStrategy.Calculate(firstOperand, secondOperand);
        }
    }
}
