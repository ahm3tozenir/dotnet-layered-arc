﻿using Business.Abstracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
public class OrdersController : Controller
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _orderService.GetAllAsync());
    }

    [HttpGet("GetById/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        return Ok(await _orderService.GetByIdAsync(id));
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add([FromBody] Order order)
    {
        return Ok(await _orderService.AddAsync(order));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update([FromBody] Order order)
    {
        return Ok(await _orderService.UpdateAsync(order));
    }

    [HttpDelete("DeleteById/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _orderService.DeleteByIdAsync(id);
        return Ok();
    }
}


