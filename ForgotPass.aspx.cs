using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.Mail;
using System.Net;

public partial class ForgetPass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSubEmail_Click(object sender, EventArgs e)
    {
        String connStr = ConfigurationManager.ConnectionStrings["ShopDBConnectionString1"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users where Email='" + txtBoxEmail.Text + "'", conn);
            conn.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                String objGUID = Guid.NewGuid().ToString();
                int UserId = Convert.ToInt32(dt.Rows[0][0]);
                String userEmail = dt.Rows[0][3].ToString();
                String userPass = dt.Rows[0][4].ToString();
                SqlCommand cmdFPR = new SqlCommand("INSERT INTO ForgotPassRequests VALUES('" +objGUID+ "', '" +UserId+ "', getdate())", conn);
                cmdFPR.ExecuteNonQuery();

                // Send Email
                String destEmailAddress = dt.Rows[0][3].ToString();
                String userName = dt.Rows[0][1].ToString();
                String emailBody = "Dear " + userName + ",<br/><br/> Click the link below to reset your password <br/><br/> http://localhost:52822/RecoverPass.aspx?UserId="+objGUID;
                MailMessage objMailMessage = new MailMessage("email@gmail.com", destEmailAddress);

                objMailMessage.Body = emailBody;
                objMailMessage.IsBodyHtml = true;
                objMailMessage.Subject = "Recover Password";

                SmtpClient objSmtp = new SmtpClient("smtp.gmail.com", 587);
                objSmtp.Credentials = new NetworkCredential()
                {
                    UserName = "saadahmed090078601@gmail.com",
                    Password = "saadahmed12"
                };
                objSmtp.EnableSsl = true;
                objSmtp.Send(objMailMessage);

                lblPassReq.Text = "Please Check your inbox. An Email has been sent to you which will enable you to reset your password";
                lblPassReq.ForeColor = Color.Green;
            }
            else
            {
                lblPassReq.Text = "The email you entered is not registered here";
                lblPassReq.ForeColor = Color.Red;
            }
        }
    }
}