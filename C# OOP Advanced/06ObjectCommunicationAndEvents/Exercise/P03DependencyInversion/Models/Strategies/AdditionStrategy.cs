namespace P03DependencyInversion.Models.Strategies
{
    using Contracts;

    public class AdditionStrategy : ICalculationStrategy
    {
        public int Calculate(int firstOperand, int secondOperand)
        {
            return firstOperand + secondOperand;
        }
    }
}
