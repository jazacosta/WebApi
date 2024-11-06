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

    [HttpGet("List")]
    public IActionResult List()
    {
        return Ok(_customerRepository.List());
    }

    //Obtain customer by id
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        return Ok(_customerRepository.GetById(id));
    }

    //Add customer
    [HttpPost("Add")]
    public IActionResult PostPerson([FromBody] Customer newcustomer)
    {
        return Ok(_customerRepository.PostPerson(newcustomer));
    }

    //Update customer
    [HttpPut("{id}")]
    public IActionResult PutFromRoute([FromRoute] int id, [FromBody] Customer updatecustomer)
    {
        var customer = _customerRepository.PutFromRoute(updatecustomer, id);
        return Ok(customer);
    }

    //Delete customer
    [HttpDelete("{id}")]
    public IActionResult DeleteFromRoute([FromRoute] int id, Customer deletecustomer)
    {
        var customer = _customerRepository.DeleteFromRoute(deletecustomer, id);
        return Ok(customer);
    }

}

