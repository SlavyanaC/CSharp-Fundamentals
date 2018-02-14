using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PokemonTrainer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            string inputLine = string.Empty;
            while ((inputLine = Console.ReadLine()) != "Tournament")
            {
                var trainerInfo = inputLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                trainers = ParseTrainer(trainers, trainerInfo);
            }

            string wantedElement = string.Empty;
            while ((wantedElement = Console.ReadLine()) != "End")
            {
               trainers = ExecureCommand(trainers, wantedElement);
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }

        private static List<Trainer> ExecureCommand(List<Trainer> trainers, string wantedElement)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(p => p.Element == wantedElement))
                {
                    trainer.Badges++;
                }
                else
                {
                    for (int i = 0; i < trainer.Pokemons.Count; i++)
                    {
                        var pokemon = trainer.Pokemons[i];
                        trainer.Pokemons[i].Health -= 10;
                        if (trainer.Pokemons[i].Health <= 0)
                        {
                            trainer.Pokemons.Remove(pokemon);
                        }
                    }
                }
            }

            return trainers;
        }

        private static List<Trainer> ParseTrainer(List<Trainer> trainers, string[] trainerInfo)
        {
            string trainerName = trainerInfo[0];
            string pokemonName = trainerInfo[1];
            string pokemonElement = trainerInfo[2];
            int pokemonHealth = int.Parse(trainerInfo[3]);

            var trainer = trainers.FirstOrDefault(t => t.Name == trainerName);
            if (trainer == null)
            {
                trainer = new Trainer(trainerName);
                trainers.Add(trainer);
            }
            trainer.Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));

            return trainers;
        }
    }
}
