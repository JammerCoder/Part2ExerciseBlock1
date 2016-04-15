using BookInfoCompanion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExerciseBase
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Global.WorldID = 23456;
                //Cache["TeamName"] = "ChicagoCubs";

                //this.hypPage2.NavigateUrl = "~/Page2.aspx?ID=65";
                //this.hypPage3.NavigateUrl = "~/Page3.aspx";
            }
            catch
            {                
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                //Global.BookID = Convert.ToInt32(this.txtBookID.Text);            
                //Response.Redirect("Page3.aspx");

                int iBookID = Convert.ToInt32(this.txtBookID.Text);

                //Populating connection string
                string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
                string sLogPath = ConfigurationManager.AppSettings["LogPath"];

                Books oBooks = new Books(sCnxn, iBookID, sLogPath);

                if (oBooks.ContainsKey(Convert.ToInt32(this.txtBookID.Text)))
                {
                    this.txtBookTitle.Text = oBooks[Convert.ToInt32(this.txtBookID.Text)].BookTitle.ToString();
                    this.txtAuthorsName.Text = oBooks[Convert.ToInt32(this.txtBookID.Text)].AuthorName.ToString();
                    this.txtLength.Text = oBooks[Convert.ToInt32(this.txtBookID.Text)].Length.ToString();
                    this.txtDateCreated.Text = oBooks[Convert.ToInt32(this.txtBookID.Text)].DateCreated.ToString();
                    if (oBooks[Convert.ToInt32(this.txtBookID.Text)].IsOnAmazon.ToString().ToUpper() == "TRUE")
                        this.chkIsOnAmazon.Checked = true;
                    else
                        this.chkIsOnAmazon.Checked = false;
                    //this.dgBookInfo.DataSource = oBooks.Values;
                    //this.dgBookInfo.DataBind();

                    this.lblErrorMessage.Text = "";
                }
                else
                {
                    this.txtBookTitle.Text = "";
                    this.txtAuthorsName.Text = "";
                    this.txtLength.Text = "";
                    this.txtDateCreated.Text = "";
                    this.chkIsOnAmazon.Checked = false;

                    this.lblErrorMessage.Text = "ID not Found!";
                }
            }
            catch (Exception ex)
            {
                this.lblErrorMessage.Text = ex.Message;
            }

                
        }
    }
}