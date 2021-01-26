using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Interface
{
    public interface IAPIInteractor
    {
        Task<IEnumerable<PokemonDetails>> GetAllPokemonsAsync();

        Task<PokemonDetails> GetPokemon(string pokemonName);
    }
}
