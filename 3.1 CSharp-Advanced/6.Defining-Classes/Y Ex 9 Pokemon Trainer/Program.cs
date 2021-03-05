using System;
using System.Collections.Generic;
using System.Linq;

namespace Y_Ex_9_Pokemon_Trainer
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Trainer> allTrainers = new List<Trainer>();

            while(input != "Tournament")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                int pokemonHealth = int.Parse(info[3]);

                Pokemon currentPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                Trainer currentTrainer = new Trainer(trainerName, new List<Pokemon>());

                if (!allTrainers.Any(x => x.Name == trainerName))
                {
                    allTrainers.Add(currentTrainer);
                }

                int indexCurrentTrainer = allTrainers.FindIndex(x => x.Name == trainerName);
                allTrainers[indexCurrentTrainer].PokemonCollection.Add(currentPokemon);

                input = Console.ReadLine();
            }

            string command = Console.ReadLine();

            while(command != "End")
            {
                switch(command)
                {
                    case "Fire":
                        allTrainers = CheckPokemonElement(allTrainers, command);
                        break;
                    case "Water":
                        allTrainers = CheckPokemonElement(allTrainers, command);
                        break;
                    case "Electricity":
                        allTrainers = CheckPokemonElement(allTrainers, command);
                        break;
                }
                
                command = Console.ReadLine();
            }

            allTrainers = allTrainers.OrderByDescending(x => x.NumberBadges).ToList();
            foreach (var trainer in allTrainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberBadges} {trainer.PokemonCollection.Count}");
            }
        }

        static List<Trainer> CheckPokemonElement(List<Trainer> allTrainers, string command)
        {
            for (int j = 0; j < allTrainers.Count; j++)
            {
                bool isHavingPokemon = false;

                for (int i = 0; i < allTrainers[j].PokemonCollection.Count; i++)
                {
                    if (allTrainers[j].PokemonCollection[i].Element == command)
                    {
                        isHavingPokemon = true;
                    }
                }

                if (isHavingPokemon)
                {
                    allTrainers[j].NumberBadges++;
                }
                else
                {
                    for (int i = 0; i < allTrainers[j].PokemonCollection.Count; i++)
                    {
                        allTrainers[j].PokemonCollection[i].Health -= 10;
                        if(allTrainers[j].PokemonCollection[i].Health < 0)
                        {
                            allTrainers[j].PokemonCollection.RemoveAt(i);
                            if(i > 0)
                            {
                                i--;
                            }
                        }
                    }
                }
            }

            //allTrainers = allTrainers.Where(x => x.Name == command).ToList();
            //allTrainers = allTrainers.Where(x => x.PokemonCollection.Count > 2).ToList();


            return allTrainers;
        }
    }
}
