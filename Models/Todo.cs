namespace TodoApi.Models;

public class Todo
{
    public Todo(Guid id, string name, bool isComplete)
    {
        Id = id;
        Name = name;
        IsComplete = isComplete;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsComplete { get; set; }
}