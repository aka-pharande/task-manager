using TaskManager;
namespace TaskManagerTests
{
    [TestClass]
    public class TaskTests
    {
        [TestMethod]
        public void Task_WithValidInput_Created()
        {
            int id = 1;
            string name = "Task 1";
            string description = "This is task 1";
            DateTime dueDate = DateTime.Now.AddDays(1);
            Priority priority = Priority.High;
            Status status = Status.InProgress;
            TaskType type = TaskType.Personal;

            TaskManager.Task task = new TaskManager.Task(id, name, description, dueDate, priority, status, type);

            Assert.AreEqual(id, task.ID);
            Assert.AreEqual(name, task.Name);
            Assert.AreEqual(description, task.Description);
            Assert.AreEqual(dueDate, task.DueDate);
            Assert.AreEqual(priority, task.Priority);
            Assert.AreEqual(status, task.Status);
            Assert.AreEqual(type, task.Type);
        }

        [TestMethod]
        public void Task_WithValidInput_UpdatedStatus()
        {
            int id = 1;
            string name = "Task 1";
            string description = "This is task 1";
            DateTime dueDate = DateTime.Now.AddDays(1);
            Priority priority = Priority.High;
            Status status = Status.InProgress;
            TaskType type = TaskType.Personal;

            TaskManager.Task task = new TaskManager.Task(id, name, description, dueDate, priority, status, type);

            Status updatedStatus = Status.Completed;

            task.Update(updatedStatus);

            Assert.AreEqual(updatedStatus, task.Status);
        }

        [TestMethod]
        public void Task_WithValidInput_Updated()
        {
            int id = 1;
            string name = "Task 1";
            string description = "This is task 1";
            DateTime dueDate = DateTime.Now.AddDays(1);
            Priority priority = Priority.High;
            Status status = Status.InProgress;
            TaskType type = TaskType.Personal;

            TaskManager.Task task = new TaskManager.Task(id, name, description, dueDate, priority, status, type);

            string updatedName = "Task 1 updated";
            string updatedDescription = "This is task 1 updated";
            DateTime updatedDueDate = DateTime.Now.AddDays(2);
            Priority updatedPriority = Priority.Medium;
            Status updatedStatus = Status.Completed;
            TaskType updatedType = TaskType.Work;

            task.Update(updatedName, updatedDescription, updatedDueDate, updatedPriority, updatedStatus, updatedType);

            Assert.AreEqual(updatedName, task.Name);
            Assert.AreEqual(updatedDescription, task.Description);
            Assert.AreEqual(updatedDueDate, task.DueDate);
            Assert.AreEqual(updatedPriority, task.Priority);
            Assert.AreEqual(updatedStatus, task.Status);
            Assert.AreEqual(updatedType, task.Type);
        }

        [TestMethod]
        public void Task_WithValidInput_ConvertedToString()
        {
            TaskManager.Task task = new TaskManager.Task(1, "Task 1", "This is task 1", new DateTime(2023, 4, 20), Priority.Medium, Status.InProgress, TaskType.Personal);

            string expected = "ID: 1\nName: Task 1\nDescription: This is task 1\nDue Date: 2023-04-20\nPriority: Medium\nStatus: InProgress\nType: Personal";
            string actual = task.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}