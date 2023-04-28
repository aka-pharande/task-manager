using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskManager
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string today = DateTime.Today.ToShortDateString();
            CompareValidator1.ValueToCompare = today;
            task_due_date.Text = today;
        }

        protected int Next_ID() {
            int id = 0;

            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TaskManagerDBConnectionString"].ConnectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("SELECT MAX(Id) Id FROM Tasks", connection);

                id = Convert.ToInt32(command.ExecuteScalar().ToString() == "" ? 0 : command.ExecuteScalar());
            }
            catch (Exception ex)
            {
                // display error message
                result.Text = "Error adding task: " + ex.Message;
                result.ForeColor = System.Drawing.Color.Red;
            }
            id++;
            return id;
        }



        protected void create_Click(object sender, EventArgs e)
        {
            int id = Next_ID();
            string name = task_name.Text;
            string description = task_description.Text;
            DateTime dueDate = DateTime.Parse(task_due_date.Text);
            Priority priority = (Priority)Enum.Parse(typeof(Priority), task_priority.Text, true);
            Status status = (Status)Enum.Parse(typeof(Status), task_status.Text, true);
            TaskType type = (TaskType)Enum.Parse(typeof(Status), task_status.Text, true);
            string location = task_location.Text;
            string assignee = task_assignee.Text;
            string project = task_project.Text;
            Task task = null;

            if (type == TaskType.Generic)
            {
                task = new Task(id, name, description, dueDate, priority, status, type);

            }
            else if (type == TaskType.Personal)
            {
                task = new PersonalTask(id, name, description, dueDate, priority, status, location);
            }
            else if (type == TaskType.Work)
            {
                task = new WorkTask(id, name, description, dueDate, priority, status, assignee, project);
            }


            try
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TaskManagerDBConnectionString"].ConnectionString);
                connection.Open();

                // insert the new task into the database
                string insertQuery = "INSERT INTO Tasks (Id, Name, Description, DueDate, Priority, Status, Type, Location, Assignee, Project) VALUES (@ID, @Name, @Description, @DueDate, @Priority, @Status, @Type, @Location, @Assignee, @Project)";
                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@ID", task.ID);
                command.Parameters.AddWithValue("@Name", task.Name);
                command.Parameters.AddWithValue("@Description", task.Description);
                command.Parameters.AddWithValue("@DueDate", task.DueDate);
                command.Parameters.AddWithValue("@Priority", task.Priority.ToString());
                command.Parameters.AddWithValue("@Status", task.Status.ToString());
                command.Parameters.AddWithValue("@Type", task.Type.ToString());
                command.Parameters.AddWithValue("@Location", location);
                command.Parameters.AddWithValue("@Assignee", assignee);
                command.Parameters.AddWithValue("@Project", project);
                command.ExecuteNonQuery();

                // close the database connection
                connection.Close();

                // display success message
                result.Text = "Task added successfully!";
                result.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                // display error message
                result.Text = "Error adding task: " + ex.Message;
                result.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void type_changed(object sender, EventArgs e)
        {
            if (task_type.SelectedValue == "Generic")
            {
                task_location.Enabled = false;
                task_assignee.Enabled = false;
                task_project.Enabled = false;
            }
            else if (task_type.SelectedValue == "Personal")
            {
                task_location.Enabled = true;
                task_assignee.Enabled = false;
                task_project.Enabled = false;

            }
            else if (task_type.SelectedValue == "Work")
            {
                task_location.Enabled = false;
                task_assignee.Enabled = true;
                task_project.Enabled = true;
            }
        }
    }
}