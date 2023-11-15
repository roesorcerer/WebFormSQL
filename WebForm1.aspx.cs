using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace COP2664CWinter2021
{
        public partial class WebForm1 : System.Web.UI.Page
        {
        //established SQL connection using connection string. You'll need to get your connection string from the Azure dashboard. Make sure you replace the username and password in the string.
        SqlConnection sqlCon = new SqlConnection(SqlDataSource = "Server=tcp:servercop2664c.database.windows.net,1433;Initial Catalog=COP2664CWinter2021;Persist Security Info=False;User ID=annastratton;Password=Password8!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        public static string SqlDataSource { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //executes the PersonCreateorUpdate stored procedure when the user enters info in the form and clicks SAVE
        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            //check to see if SQL connection is opn
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("TweetCreateorUpdate", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@tweet_id", hftweet_id.Value == "" ? 0 : Convert.ToInt32(hftweet_id.Value));
            sqlCmd.Parameters.AddWithValue("@airline_sentiment", txtairline_sentiment.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@airline_sentiment_confidence", txtairline_sentiment_confidence.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@negativereason", txtnegativereason.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@negativereason_confidence", txtnegativereason_confidence.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@airline", txtairline.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            string TweetID = hftweet_id.Value;
            Clear();
            if (TweetID == "")
                SuccessMessage.Text = "Record Saved Successfully!";
            else
                SuccessMessage.Text = "Record Updated Successfully!";
            FillGridView();

        }


        //Fills the Grid Table using the PersonViewAll stored procedure to show all records
        void FillGridView()
        {
            //check to see if SQL connection is opn
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("TweetViewTop10", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            gvtweets.DataSource = dtbl;
            gvtweets.DataBind();
        }
        //displays the record in the form using stored procedure PersonViewbyID, allowing you to update the field.
        protected void lnk_OnClick(object sender, EventArgs e)
        {
            int TweetID = Convert.ToInt32((sender as LinkButton).CommandArgument);
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter("TweetViewbyID", sqlCon);
            sqlDa.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlDa.SelectCommand.Parameters.AddWithValue("@tweet_id", TweetID);
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            sqlCon.Close();
            hftweet_id.Value = TweetID.ToString();
            txtairline_sentiment.Text = dtbl.Rows[0]["airline_sentiment"].ToString();
            txtairline_sentiment_confidence.Text = dtbl.Rows[0]["airline_sentiment_confidence"].ToString();
            txtnegativereason.Text = dtbl.Rows[0]["negativereason"].ToString();
            txtnegativereason_confidence.Text = dtbl.Rows[0]["negativereason_confidence"].ToString();
            txtairline.Text = dtbl.Rows[0]["airline"].ToString();
            ButtonSave.Text = "Update";
          //  ButtonDelete.Enabled = true;
        }
        //adds clear function to the Clear button and clears the form
        protected void ButtonClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        //creates the clear function to clear the form
        public void Clear()
        {
            hftweet_id.Value = "";
            txtairline_sentiment_confidence.Text = txtairline_sentiment.Text = txtnegativereason.Text = txtnegativereason_confidence.Text = txtairline.Text = "";
            SuccessMessage.Text = ErrorMessage.Text = "";
            ButtonSave.Text = "Save";
         //   ButtonDelete.Enabled = false;
        }


     /*   //calls the stored procedure PersonDeletebyID to delete the record viewed
        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            //    ButtonDelete.Enabled = false;
                FillGridView();
            }
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
            SqlCommand sqlCmd = new SqlCommand("TweetDeletebyID", sqlCon);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.AddWithValue("@tweet_id", Convert.ToInt32(hftweet_id.Value));
            sqlCmd.ExecuteNonQuery();
            sqlCon.Close();
            Clear();
            FillGridView();
            SuccessMessage.Text = "Record Deleted Successfully.";

        }*/
    }
}