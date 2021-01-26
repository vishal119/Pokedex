using Pokedex.Interface;
using Pokedex.Services;
using Pokedex.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokedex.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PokemonListview : ContentPage
	{
		public PokemonListview()
		{
			InitializeComponent();
			//IClientInteractor interactor = new APIInteractor();
			IAPIInteractor apiManager = new APIManager();
			BindingContext = new PokemonListViewModel(apiManager);
			((PokemonListViewModel)BindingContext).Initialize(this);
			//	((BaseModel)BindingContext).Initialize(this);
		}

		
	}
}
