using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Y_Ex_9_Pokemon_Trainer
{
    public class Trainer
    {
        public Trainer()
        {
            NumberBadges = 0;
        }
        public Trainer(string name, List<Pokemon> pokemonCollection): this()
        {
            Name = name;
            PokemonCollection = pokemonCollection;
        }
        public string Name { get; set; }
        public List<Pokemon> PokemonCollection { get; set; }
        public int NumberBadges { get; set; }
    }
}
