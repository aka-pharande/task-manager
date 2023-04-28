using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager
{
    public class WorkTask : Task
    {
        public string Assignee { get; set; }
        public string Project { get; set; }

        public WorkTask(int id, string name, string description, DateTime dueDate, Priority priority, Status status, string assignee, string project)
            : base(id, name, description, dueDate, priority, status, TaskType.Work)
        {
            Assignee = assignee;
            Project = project;
        }

        public void Update(string name, string description, DateTime dueDate, Priority priority, Status status, string assignee, string project)
        {
            base.Update(name, description, dueDate, priority, status, TaskType.Work);
            Assignee = assignee;
            Project = project;
        }
    }
}