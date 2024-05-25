using Microsoft.AspNetCore.Mvc;
using Pokemon.Services;

namespace Examen_Progra_2.Controllers;

[ApiController]
[Route("[controller]")]
public class ControladorPokemon : Controller
{
    private readonly ServiciosPokemon _services;

    public ControladorPokemon(ServiciosPokemon services)
    {
        _services = services;
    }
    [HttpGet("{PokeName}")]

    public async Task<ActionResult<ServiciosPokemon>> Get(string PokemonName)
    {
        var Poke = await _services.GetPokemon(PokemonName);
        return Ok(Poke);
    }
}