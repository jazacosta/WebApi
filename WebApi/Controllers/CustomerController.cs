﻿using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Core.Requests;
using FluentValidation;
using Core.DTOs.Customer;

namespace WebApi.Controllers;
public class CustomerController : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IValidator<CreateCustomerDTO> _createValidation;
    private readonly IValidator<UpdateCustomerDTO> _updateValidation;

    //inyeccion de dependencias
    public CustomerController(ICustomerRepository customerRepository, IValidator<CreateCustomerDTO> createValidation, IValidator<UpdateCustomerDTO> updateValidation)
    {
        _customerRepository = customerRepository;
        _createValidation = createValidation;
        _updateValidation = updateValidation;
    }

    //implementar paginacion
    [HttpGet("Customer/list")]
    public async Task<IActionResult> List([FromQuery] PaginationRequest request, CancellationToken cancellationToken)
    {
        return Ok(await _customerRepository.List(request, cancellationToken));
    }

    //Obtain customer by id
    [HttpGet("Customer/get/{id}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        return Ok(await _customerRepository.Get(id));
    }

    //Add customer
    [HttpPost("Customer/add")]
    public async Task<IActionResult> Add([FromBody] CreateCustomerDTO createCustomerDTO)
    {
        var result = await _createValidation.ValidateAsync(createCustomerDTO);
        if (!result.IsValid)
        {
            return BadRequest(result);
        }
        return Ok(await _customerRepository.Add(createCustomerDTO));
    }

    //Update customer
    [HttpPut("Customer/update")]
    public async Task<IActionResult> Update([FromBody] UpdateCustomerDTO updateCustomerDTO)
    {
        var result = await _updateValidation.ValidateAsync(updateCustomerDTO);
        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }
        return Ok(await _customerRepository.Update(updateCustomerDTO));
    }

    //Delete customer
    [HttpDelete("Customer/delete/{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        return Ok(await _customerRepository.Delete(id));
    }

    [HttpGet("Customer/get/products/{ProductId}")]
    public async Task<IActionResult> GetProducts([FromRoute] int ProductId)
    {
        return Ok(await _customerRepository.GetProducts(ProductId));
    }

}

