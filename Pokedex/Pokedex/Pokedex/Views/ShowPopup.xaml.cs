using Pokedex.Models;
using Pokedex.ViewModels;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokedex.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShowPopup : PopupPage
	{
		public ShowPopup(PokemonDetails pokemonDetails)
		{
			InitializeComponent();
			BindingContext = pokemonDetails;

		}
	}
}