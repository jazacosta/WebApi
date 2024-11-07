using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;

namespace WebApi.Controllers;
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    //inyeccion de dependencias
    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    [HttpGet("list")]
    public async Task<IActionResult> List()
    {
        return Ok(await _customerRepository.List());
    }

    //Obtain customer by id
    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        return Ok(_customerRepository.Get(id));
    }

    //Add customer
    [HttpPost("add")]
    public IActionResult Add([FromBody] Customer customer)
    {
        return Ok(_customerRepository.Add(customer.FirstName));
    }

    //Update customer
    [HttpPut("update")]
    public IActionResult Update([FromRoute] int id, [FromBody] Customer customer)
    {
        return Ok(_customerRepository.Update(customer.Id, customer.FirstName);
    }

    //Delete customer
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        return Ok(_customerRepository.Delete(id));
    }

}

