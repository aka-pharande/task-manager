using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TaskManager
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void grid_RowDeleting(object sender, GridViewDeleteEventArgs e) {
            int id = int.Parse(GridView1.DataKeys[e.RowIndex].Value.ToString());
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["TaskManagerDBConnectionString"].ConnectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("delete from Tasks where Id = "+id, connection);
            command.ExecuteNonQuery();
            connection.Close();
            //bindgrid();
        }

        protected void refresh_Click(object sender, EventArgs e)
        {
            SqlDataSource1.DataBind();
            GridView1.DataBind();
        }

    }
}