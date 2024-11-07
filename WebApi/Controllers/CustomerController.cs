using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Core.Requests;

namespace WebApi.Controllers;
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    //inyeccion de dependencias
    public CustomerController(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    //implementar paginacion
    [HttpGet("list")]
    public async Task<IActionResult> List([FromQuery] PaginationRequest request)
    {
        return Ok(await _customerRepository.List(request));
    }

    //Obtain customer by id
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        return Ok(await _customerRepository.Get(id));
    }

    //Add customer
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] Customer customer)
    {
        return Ok(await _customerRepository.Add(customer.FirstName, customer.LastName));
    }

    //Update customer
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] Customer customer)
    {
        return Ok(await _customerRepository.Update(customer.Id, customer.FirstName, customer.LastName));
    }

    //Delete customer
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await _customerRepository.Delete(id));
    }

}

