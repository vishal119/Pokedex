using Pokedex.Interface;
using Pokedex.Services;
using Pokedex.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pokedex
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			//IClientInteractor interactor = new APIInteractor();
		//	BindingContext = new MainViewModel();
			//((PokemonListViewModel)BindingContext).Initialize(this);
			//	((BaseModel)BindingContext).Initialize(this);
			
		}
	}
}
