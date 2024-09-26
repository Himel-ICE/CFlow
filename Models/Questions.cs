using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace CFlow.Models
{
    public class Questions
    {
        //insert question
        public static int questionPost(string Question, string Description, string Tags)
        {
            int result = 0;

            string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(ConnString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.spQTableIsnertPost";
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@Question", Question));
            cmd.Parameters.Add(new SqlParameter("@Description", Description));
            cmd.Parameters.Add(new SqlParameter("@QTag", Tags));
            cmd.CommandTimeout = 0;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string m = ex.Message;
            }

            cmd.Dispose();
            sqlConnection.Close();


            return result;
        }

        //insert comment
        public static int InsertQuestion(string Comment, int ID)
        {
            int result = 0;

            string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(ConnString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.spCFlowPostComment";
            cmd.Parameters.Clear();
            cmd.Parameters.Add(new SqlParameter("@comment", Comment));
            cmd.Parameters.Add(new SqlParameter("@QID", ID));
            cmd.CommandTimeout = 0;
            try
            {
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string m = ex.Message;
            }

            cmd.Dispose();
            sqlConnection.Close();


            return result;
        } 

        // read the Question table as data table
        public static DataTable QuestionTable()
        {
            DataTable dataTable = new DataTable();

            string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(ConnString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.spCflowSelectQuestion";
            cmd.Parameters.Clear();
            cmd.CommandTimeout = 0;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);


            cmd.Dispose();
            sqlConnection.Close();
            return dataTable;

        }

        // to read comment datatabel
        public static DataTable CommentTable()
        {
            DataTable dataTable = new DataTable();

            string ConnString = ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(ConnString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = sqlConnection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.spCflowSelectComment";
            cmd.Parameters.Clear();
            cmd.CommandTimeout = 0;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dataTable);


            cmd.Dispose();
            sqlConnection.Close();
            return dataTable;

        }
    }
}