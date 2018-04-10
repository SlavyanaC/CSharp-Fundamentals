namespace P03DependencyInversion
{
    using Models;
    using Models.Strategies;

    class StartUp
    {
        static void Main(string[] args)
        {
            PrimitiveCalculator primitiveCalculator = new PrimitiveCalculator(new AdditionStrategy());
            Engine engine = new Engine(primitiveCalculator);
            engine.Run();
        }
    }
}
