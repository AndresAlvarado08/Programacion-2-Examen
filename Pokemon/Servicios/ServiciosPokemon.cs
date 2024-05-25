using Pokemon.Services;
using System.Net.Http.Json;
using System.Text.Json;

namespace Pokemon.Services;
public class ServiciosPokemon
{
    private readonly HttpClient _httpClient;

    public ServiciosPokemon(HttpClient httpClient)
    { _httpClient = httpClient; }

    public async Task<Pokemon> GetPokemon(string PokemonName)
    {
        var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{PokemonName}");
        response.EnsureSuccessStatusCode();

        var PokemonData = await response.Content.ReadFromJsonAsync<JsonElement>();

        var Poke = new Pokemon
        {
            Name = PokemonName,
            Type = PokemonData.GetProperty("types").EnumerateArray().First().GetProperty("type").GetProperty("name").GetString(),
            URL = PokemonData.GetProperty("sprites").GetProperty("front_default").GetString(),
            Moves = PokemonData.GetProperty("moves").EnumerateArray().Select(m => m.GetProperty("move").GetProperty("name").GetString()).ToList()
        };
        return Poke;
    }
}