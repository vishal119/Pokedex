using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Models
{
	public class PokemonInfo
	{
		public int Count { get; set; }
		public string Next { get; set; }
		public string Previous { get; set; }
		public List<PokemonDetails> Results { get; set; }
	}
}
