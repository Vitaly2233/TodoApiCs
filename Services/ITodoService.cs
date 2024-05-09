using TodoApi.Models;

namespace TodoApi.Services;

public interface ITodoService
{
    public void CreateTodo(Todo todo);
    public Todo? GetTodo(Guid id);
    public Todo[] GetAllTodos();
    public void UpdateTodo(Guid id, Todo todo);
    public void DeleteTodo(Guid id);
}