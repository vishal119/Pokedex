using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms.Internals;

namespace Pokedex.Models
{
	public class PokemonDetails : PropertyChangeNotifier
	{
		[JsonProperty(PropertyName = "name")]
		public string PokemonName { get; set; }
		public double Height { get; set; }
		public int Id { get; set; }
		public Sprites Sprites { get; set; }
		public List<Types> Types { get; set; }
		public double Weight { get; set; }
		private byte[] _pokemonImage;
		public byte[] PokemonImage
		{
			get {
				return _pokemonImage;
			} set
			{
				_pokemonImage = value;
				OnPropertyChanged();
			}
		}

		

	}
}
