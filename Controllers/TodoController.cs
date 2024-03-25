using Microsoft.AspNetCore.Mvc;
using TodoApi.Contracts;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private ITodoService _service;

    public TodoController(ITodoService todoService)
    {
        _service = todoService;
    }

    [HttpPost]
    public IActionResult CreateTodo(CreateTodoDto dto)
    {
        var todo = new Todo(Guid.NewGuid(), dto.Name, dto.IsComplete);
        _service.CreateTodo(todo);
        return CreatedAtTodo(todo);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetTodo(Guid id)
    {
        var todo = _service.GetTodo(id);
        return Ok(todo);
    }

    [HttpGet]
    public IActionResult GetAllTodos()
    {
        var todos = _service.GetAllTodos();
        return Ok(todos);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateTodo(Guid id, UpdateTodoDto dto)
    {
        var todo = new Todo(id, dto.Name, dto.IsComplete);
        _service.UpdateTodo(id, todo);
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteTodo(Guid id)
    {
        _service.DeleteTodo(id);
        return Ok();
    }

    private CreatedAtActionResult CreatedAtTodo(Todo todo)
    {
        return CreatedAtAction(
            actionName: nameof(GetTodo),
            routeValues: new { id = todo.Id },
            value: todo);
    }
}