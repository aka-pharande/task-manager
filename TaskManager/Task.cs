using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager
{

    public enum Priority
    {
        High,
        Medium,
        Low
    }

    public enum Status
    {
        NotStarted,
        InProgress,
        Completed,
        Postponed
    }

    public enum TaskType
    {
        Generic,
        Personal,
        Work,
        Errand
    }

    public class Task
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; }
        public TaskType Type { get; set; }

        public Task(int id, string name, string description, DateTime dueDate, Priority priority, Status status, TaskType type)
        {
            ID = id;
            Name = name;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            Status = status;
            Type = type;
        }

        public void Update(string name, string description, DateTime dueDate, Priority priority, Status status, TaskType type)
        {
            Name = name;
            Description = description;
            DueDate = dueDate;
            Priority = priority;
            Status = status;
            Type = type;
        }

        public void Update(Status status)
        {
            Status = status;
        }

        public override string ToString()
        {
            return $"ID: {ID}\nName: {Name}\nDescription: {Description}\nDue Date: {DueDate.ToString("yyyy-MM-dd")}\nPriority: {Priority}\nStatus: {Status}\nType: {Type}";
        }
    }
}