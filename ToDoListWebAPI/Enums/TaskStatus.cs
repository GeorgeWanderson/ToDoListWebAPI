using System.ComponentModel;

namespace ToDoListWebAPI.Enums
{
    public enum TaskStatus
    {
        [Description("To Do")]
        ToDo = 1,
        [Description("In Progress")]
        InProgress = 2,
        [Description("Completed")]
        Completed = 3
    }
}
