using TodoApi.Models;

namespace TodoApi.Services;

public class TodoService : ITodoService
{
    private Dictionary<Guid, Todo> _todos = new();

    public void CreateTodo(Todo todo)
    {
        _todos.Add(todo.Id, todo);
    }

    public Todo GetTodo(Guid id)
    {
        return _todos[id];
    }

    public Todo[] GetAllTodos()
    {
        return new List<Todo>(_todos.Values).ToArray();
    }

    public void UpdateTodo(Guid id, Todo todo)
    {
        _todos[id] = todo;
    }

    public void DeleteTodo(Guid id)
    {
        _todos.Remove(id);
    }
}