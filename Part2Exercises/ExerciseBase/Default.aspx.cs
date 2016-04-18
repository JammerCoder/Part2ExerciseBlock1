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
                #region History
                //Global.WorldID = 23456;
                //Cache["TeamName"] = "ChicagoCubs";
                //this.hypPage2.NavigateUrl = "~/Page2.aspx?ID=65";
                //this.hypPage3.NavigateUrl = "~/Page3.aspx";
                #endregion History

                List<string> oListItems = new List<string>();

                oListItems.Add("Select 1");
                oListItems.Add("Select 2");
                oListItems.Add("Select 3");

                this.chlCheckList.DataSource = oListItems;
                this.chlCheckList.DataBind();

                this.drdList.DataSource = oListItems;
                this.drdList.DataBind();

                this.rdoRadioList.DataSource = oListItems;
                this.rdoRadioList.DataBind();

            }
            catch (Exception ex)
            {
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void btnSearchID_Click(object sender, EventArgs e)
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
                    this.litSearchResult.Text = "";
                    this.litSearchResult.Text += "<b>Book ID: </b>" + this.txtBookID.Text + "<br />";
                    this.litSearchResult.Text += "<b>Book Title: </b>" + oBooks[Convert.ToInt32(this.txtBookID.Text)].BookTitle.ToString() + "<br />";
                    this.litSearchResult.Text += "<b>Author's Name: </b>" + oBooks[Convert.ToInt32(this.txtBookID.Text)].AuthorName.ToString() + "<br />";
                    this.litSearchResult.Text += "<b>Length: </b>" + oBooks[Convert.ToInt32(this.txtBookID.Text)].Length.ToString() + "<br />";
                    this.litSearchResult.Text += "<b>Date Created: </b>" + oBooks[Convert.ToInt32(this.txtBookID.Text)].DateCreated.ToString() + "<br />";
                    this.litSearchResult.Text += "<b>Selling Price: </b>" + oBooks[Convert.ToInt32(this.txtBookID.Text)].SellingPrice.ToString() + "<br />";

                    this.txtBookTitle.Text = oBooks[Convert.ToInt32(this.txtBookID.Text)].BookTitle.ToString();
                    this.txtAuthorsName.Text = oBooks[Convert.ToInt32(this.txtBookID.Text)].AuthorName.ToString();
                    this.txtLength.Text = oBooks[Convert.ToInt32(this.txtBookID.Text)].Length.ToString();
                    this.txtDateCreated.Text = oBooks[Convert.ToInt32(this.txtBookID.Text)].DateCreated.ToString();
                    this.txtSellingPrice.Text = oBooks[Convert.ToInt32(this.txtBookID.Text)].SellingPrice.ToString();

                    if (oBooks[Convert.ToInt32(this.txtBookID.Text)].IsOnAmazon.ToString().ToUpper() == "TRUE")
                    {
                        this.litSearchResult.Text += "<b>Remarks: </b> The Book is on Amazon <br />";
                        this.chkIsOnAmazon.Checked = true;
                    }
                    else
                    {
                        this.litSearchResult.Text += "<b>Remarks: </b> The Book is not on Amazon <br />";
                        this.chkIsOnAmazon.Checked = false;
                    }

                    //this.dgBookInfo.DataSource = oBooks.Values;
                    //this.dgBookInfo.DataBind();

                    this.txtBookID.Text = "";
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

                this.txtBookTitle.Text = "";
                this.txtAuthorsName.Text = "";
                this.txtLength.Text = "";
                this.txtDateCreated.Text = "";
                this.chkIsOnAmazon.Checked = false;
                this.litSearchResult.Text = "";
            }


        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
                string sLogPath = ConfigurationManager.AppSettings["LogPath"];

                Book oBook = new Book();

                oBook.BookID = 0;
                oBook.BookTitle = this.txtBookTitle.Text;
                oBook.AuthorName = this.txtAuthorsName.Text;
                oBook.Length = Convert.ToInt32(this.txtLength.Text);
                oBook.SellingPrice = Convert.ToDecimal(this.txtSellingPrice);
                //oBook.DateCreated = this.txtDateCreated.Text;
                if (this.chkIsOnAmazon.Checked == true)
                    oBook.IsOnAmazon = true;
                else
                    oBook.IsOnAmazon = false;


                this.litSearchResult.Text = oBook.Save(sCnxn, sLogPath);

                this.btnNew.Enabled = true;
                this.btnSave.Enabled = false;
                this.txtBookID.Enabled = true;
                this.txtBookID.Text = "";
                this.txtDateCreated.Enabled = true;

                Books oBooks = new Books(sCnxn, sLogPath);
                this.grdBookInfo.DataSource = oBooks.Values;
                this.grdBookInfo.DataBind();

            }
            catch (Exception ex)
            {
                this.lblErrorMessage.Text = ex.Message;
            }

        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            this.txtBookID.Text = "AutoNumber...";
            this.txtBookID.Enabled = false;
            this.txtBookTitle.Text = "";
            this.txtAuthorsName.Text = "";
            this.txtLength.Text = "";
            this.txtDateCreated.Text = "AutoDate fill... ";
            this.txtDateCreated.Enabled = false;
            this.txtSellingPrice.Text = "";
            this.chkIsOnAmazon.Checked = false;
            this.txtBookTitle.Focus();
            this.btnSave.Enabled = true;
            this.btnNew.Enabled = false;
        }

        protected void btnSearchTitle_Click(object sender, EventArgs e)
        {
            try
            {
                string sBookTitle = this.txtBookTitle.Text;

                //Populating connection string
                string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
                string sLogPath = ConfigurationManager.AppSettings["LogPath"];

                Books oBooks = new Books(sCnxn, sBookTitle, sLogPath);

                if (oBooks.Count()>0)
                {
                    this.litSearchResult.Text = "<b>Total Price: </b>" + oBooks.TotalPrice.ToString() + "<br />";
                    this.litSearchResult.Text += "<b>Average Price: </b>" + oBooks.AveragePrice.ToString() + "<br />";

                    this.grdBookInfo.DataSource = oBooks.Values;
                    this.grdBookInfo.DataBind();
                }
                else
                {
                    this.grdBookInfo.DataSource = oBooks.Values;
                    this.grdBookInfo.DataBind();

                    this.txtBookTitle.Text = "";
                    this.txtAuthorsName.Text = "";
                    this.txtLength.Text = "";
                    this.txtDateCreated.Text = "";
                    this.txtSellingPrice.Text = "";
                    this.chkIsOnAmazon.Checked = false;

                    this.lblErrorMessage.Text = "Book not Found!";
                }
            }
            catch (Exception ex)
            {
                this.lblErrorMessage.Text = ex.Message;
            }        
        }

        protected void calDefault_SelectionChanged(object sender, EventArgs e)
        {
            this.litEventMessage.Text = "Something Selected in the Calender Items!";
        }

        protected void drdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.litEventMessage.Text = "Something Selected in DropDownList Items!";
        }

        protected void chlCheckList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.litEventMessage.Text = "Something Selected in CheckListBox Items!";
        }

        protected void rdoRadioList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.litEventMessage.Text = "Something Selected in RadioButtonListBox Items!";
        }

        protected void ibtnImageBtn_Click(object sender, ImageClickEventArgs e)
        {
            this.litEventMessage.Text = "The Image Button was pressed!";
        }
    }
}