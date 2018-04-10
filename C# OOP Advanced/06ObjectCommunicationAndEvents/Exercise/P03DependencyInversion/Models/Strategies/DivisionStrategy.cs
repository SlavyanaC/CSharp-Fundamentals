namespace P03DependencyInversion.Models.Strategies
{
    using Contracts;

    public class DivisionStrategy : ICalculationStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand / secondOperand;
        }
    }
}
