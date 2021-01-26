using MonkeyCache.FileStore;
using Newtonsoft.Json;
using Pokedex.Interface;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Pokedex.Services
{
	class APIManager : IAPIInteractor
	{
		private string baseUrl = @"https://pokeapi.co/api/v2/";
		private readonly HttpClient _client;

		public APIManager()
		{
			Barrel.ApplicationId = "PokemonCacheData";
			_client = new HttpClient
			{
				BaseAddress = new Uri(baseUrl)
			};
		}
		public async Task<IEnumerable<PokemonDetails>> GetAllPokemonsAsync()
		{
			try
			{
				if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
					!Barrel.Current.IsExpired(key: baseUrl + "pokemon/"))
				{
					
					return Barrel.Current.Get<IEnumerable<PokemonDetails>>(key: baseUrl + "pokemon/");
				}

				var response = _client.GetAsync("pokemon/").Result;
				if (response.IsSuccessStatusCode)
				{
					var data = await response.Content.ReadAsStringAsync();
					var pokemon = JsonConvert.DeserializeObject<PokemonInfo>(data);
					Barrel.Current.Add(key: baseUrl + "pokemon/", data: pokemon.Results, expireIn: TimeSpan.FromDays(1));
					return pokemon.Results;
				}
				return null;
			}
			catch (Exception ex)
			{
				//Handle exception here
			}
			return null;
		}

		public async Task<PokemonDetails> GetPokemon(string pokemonName)
		{
			try
			{
				if (Connectivity.NetworkAccess != NetworkAccess.Internet &&
					!Barrel.Current.IsExpired(key: baseUrl + $"pokemon/{pokemonName}"))
				{
					//await Task.Yield();
					//UserDialogs.Instance.Toast("Please check your internet connection", TimeSpan.FromSeconds(5));
					return Barrel.Current.Get<PokemonDetails>(key: baseUrl + $"pokemon/{pokemonName}");
				}
				var response =   _client.GetAsync($"pokemon/{pokemonName}").Result;
				if (response.IsSuccessStatusCode)
				{
					var data = await response.Content.ReadAsStringAsync();
					var pokemon = JsonConvert.DeserializeObject<PokemonDetails>(data);
					var image = _client.GetAsync(pokemon.Sprites.FrontDefaultURI).Result;
					if (image.IsSuccessStatusCode)
					{
						var imageData = await image.Content.ReadAsByteArrayAsync();
						pokemon.PokemonImage = imageData;
						Barrel.Current.Add(key: baseUrl + $"pokemon/{pokemonName}", data: pokemon, expireIn: TimeSpan.FromDays(1));
					}
					return pokemon;
				}
				return null;
				
			}
			catch (Exception ex)
			{
				//Handle exception here
			}
			return null;
		}
	}
}
