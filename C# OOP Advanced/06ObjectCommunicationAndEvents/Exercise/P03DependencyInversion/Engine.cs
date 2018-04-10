namespace P03DependencyInversion
{
    using Contracts;
    using Models;
    using Models.Strategies;
    using System;

    public class Engine
    {
        private PrimitiveCalculator primitiveCalculator;

        public Engine(PrimitiveCalculator primitiveCalculator)
        {
            this.primitiveCalculator = primitiveCalculator;
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] args = input.Split();
                int.TryParse(args[1], out int secondElement);
                if (args[0] == "mode")
                {
                    char @operator = char.Parse(args[1]);
                    ICalculationStrategy calculationStrategy = GetCalculationgStrategy(@operator);
                    this.primitiveCalculator.ChangeStrategy(calculationStrategy);
                }
                else
                {
                    int firsOperand = int.Parse(args[0]);
                    int secondOperand = int.Parse(args[1]);
                    Console.WriteLine(this.primitiveCalculator.PerformCalculation(firsOperand, secondOperand));
                }
            }
        }

        private ICalculationStrategy GetCalculationgStrategy(char @operator)
        {
            ICalculationStrategy calculationStrategy = null;

            switch (@operator)
            {
                case '+':
                    calculationStrategy = new AdditionStrategy();
                    break;
                case '-':
                    calculationStrategy = new SubtractionStrategy();
                    break;
                case '*':
                    calculationStrategy = new MultiplicationStrategy();
                    break;
                case '/':
                    calculationStrategy = new DivisionStrategy();
                    break;
            }

            return calculationStrategy;
        }
    }
}
