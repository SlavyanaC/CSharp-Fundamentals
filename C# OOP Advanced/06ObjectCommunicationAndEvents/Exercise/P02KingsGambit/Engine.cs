namespace P02KingsGambit
{
    using Contracts;
    using System;
    using System.Linq;

    public class Engine
    {
        private IKing king;

        public Engine(IKing king)
        {
            this.king = king;
        }

        public void Run()
        {
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split();
                var command = tokens[0];
                if (command == "Attack")
                {
                    king.GetAttacked();
                }
                else if (command == "Kill")
                {
                    string subordinateName = tokens[1];
                    ISubordinate subordinate = king.Subordinates.FirstOrDefault(s => s.Name == subordinateName);
                    subordinate.Die();
                }
            }
        }
    }
}
