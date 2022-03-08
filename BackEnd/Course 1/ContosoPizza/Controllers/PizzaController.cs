using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase 
{
    public PizzaController() { }

    [HttpGet]
    public IActionResult GetAll() => Ok(PizzaService.GetAll());

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var pizza = PizzaService.Get(id);

        if (pizza == null) { return NotFound(); }

        return Ok(pizza);
    }

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        PizzaService.Add(pizza);
        return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id) { return BadRequest(); }

        var existingPizza = PizzaService.Get(id);
        if (existingPizza is null) { return NotFound(); }

        PizzaService.Update(pizza);
        
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) 
    {
        var pizza = PizzaService.Get(id);
        if (pizza is null) { return NotFound(); }

        PizzaService.Delete(id);

        return NoContent();
    }
}
