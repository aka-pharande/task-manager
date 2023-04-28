using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager
{
    public class PersonalTask : Task
    {
        public string Location { get; set; }

        public PersonalTask(int id, string name, string description, DateTime dueDate, Priority priority, Status status, string location)
            : base(id, name, description, dueDate, priority, status, TaskType.Personal)
        {
            Location = location;
        }

        public void Update(string name, string description, DateTime dueDate, Priority priority, Status status, string location)
        {
            base.Update(name, description, dueDate, priority, status, TaskType.Personal);
            Location = location;
        }
    }
}