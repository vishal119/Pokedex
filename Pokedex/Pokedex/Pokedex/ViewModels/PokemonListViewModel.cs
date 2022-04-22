using Pokedex.Interface;
using Pokedex.Models;
using Pokedex.Services;
using Pokedex.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace Pokedex.ViewModels
{
	
	class PokemonListViewModel : BaseModel
	{

		private readonly IAPIInteractor _apiInteractor;
		public PokemonListViewModel()
		{

		}
		public PokemonListViewModel(IAPIInteractor apiInteractor)
		{
			_apiInteractor = apiInteractor;
			_pokemonCollection = new ObservableCollection<PokemonDetails>();
		}


		private ObservableCollection<PokemonDetails> _pokemonCollection { get; set; }
		
		public ObservableCollection<PokemonDetails> PokemonCollections
		{
			get { return _pokemonCollection; }
			set
			{
				OnPropertyChanged();
				
			}
		}
		private PokemonDetails _selectedPokemon;
		public PokemonDetails SelectedPokemon
		{
			get { return _selectedPokemon; }
			set
			{
				_selectedPokemon = value;
				OnPropertyChanged();
				ShowPopUp();
			}
		}

		

		private bool _isVisible;

		public bool IsVisible
		{
			get { return _isVisible; }
			set
			{
				_isVisible = value;
				OnPropertyChanged();
			}
		}

		public async void ShowPopUp()
		{
			await PopupNavigation.Instance.PushAsync(new ShowPopup(SelectedPokemon));
			//await PopupNavigation.Instance.PopAllAsync(new ShowPopup());
		}

		protected override void CurrentPageOnAppearing(object sender, EventArgs eventArgs)
		{
			IsVisible = true;
			var pokemonList = this.GetDataloaded();
			IsVisible = false;
			GetPokemonDetails(_pokemonCollection);

		}


		public IEnumerable<PokemonDetails> GetDataloaded()
		{
			var pokemons = _apiInteractor.GetAllPokemonsAsync().Result;
			foreach (var pokemon in pokemons) { 
				_pokemonCollection.Add(pokemon);
			}
			return pokemons;
		}
		public  void GetPokemonDetails(ObservableCollection<PokemonDetails> Pokemons )
		{
			foreach (var pokemon in Pokemons)
			{
				 var pokemonDetail =  _apiInteractor.GetPokemon(pokemon.PokemonName).Result;
				pokemon.Weight = pokemonDetail.Weight;
				pokemon.Id = pokemonDetail.Id;
				pokemon.Types = pokemonDetail.Types;
				pokemon.PokemonImage = pokemonDetail.PokemonImage;
				pokemon.Height = pokemonDetail.Height;
				
			}
		}
		public void CTD001()
        {
            Console.WriteLine(	"CTD001");
        }
		
	}
}
