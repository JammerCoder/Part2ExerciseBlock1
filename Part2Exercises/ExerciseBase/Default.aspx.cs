using BookInfoCompanion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing;
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
                /*
                 * List<string> oListItems = new List<string>();
                 * oListItems.Add("Select 1");
                 * oListItems.Add("Select 2");
                 * oListItems.Add("Select 3");
                 */
                #endregion History
                
                #region Month
                int month = DateTime.Now.Month;
                switch (month)
                {
                    case 1: this.lblMonth.Text = "January"; break;
                    case 2: this.lblMonth.Text = "February"; break;
                    case 3: this.lblMonth.Text = "March"; break;
                    case 4: this.lblMonth.Text = "April"; break;
                    case 5: this.lblMonth.Text = "May"; break;
                    case 6: this.lblMonth.Text = "June"; break;
                    case 7: this.lblMonth.Text = "July"; break;
                    case 8: this.lblMonth.Text = "August"; break;
                    case 9: this.lblMonth.Text = "September"; break;
                    case 10: this.lblMonth.Text = "October"; break;
                    case 11: this.lblMonth.Text = "November"; break;
                    case 12: this.lblMonth.Text = "December"; break;
                    default: this.lblMonth.Text = "Please select a month!"; break;
                }
                #endregion Month

                //this.litSearchResult.Text = this.calDefault..ToString();                
                if(!IsPostBack)
                {
                    string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
                    string sLogPath = ConfigurationManager.AppSettings["LogPath"];

                    Books oBooks = new Books(sCnxn, sLogPath);

                    this.drdList.DataSource = oBooks.Values;
                    this.drdList.DataTextField = "BookTitle";
                    this.drdList.DataValueField = "BookID";
                    this.drdList.DataBind();
                    this.drdList.Items.Insert(0, "-Select-");

                    this.chlCheckList.DataSource = oBooks.Values;
                    this.chlCheckList.DataTextField = "BookTitle";
                    this.chlCheckList.DataValueField = "BookID";
                    this.chlCheckList.DataBind();

                    this.rdoRadioList.DataSource = oBooks.Values;
                    this.rdoRadioList.DataTextField = "BookTitle";
                    this.rdoRadioList.DataValueField = "BookID";
                    this.rdoRadioList.DataBind();

                    List<string> oSelectColor = new List<string>();
                    oSelectColor.Add("-Select Color-");
                    oSelectColor.Add("Red");
                    oSelectColor.Add("Blue");
                    oSelectColor.Add("Green");

                    this.drdSelectColor.DataSource = oSelectColor;
                    this.drdSelectColor.DataBind();

                    this.litCustomMessage.Text = "Not PostBack!";
                }
                else
                {
                    this.litCustomMessage.Text = "Now this is PostBack!";
                }
                    
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
            this.litEventMessage.Text = "<b>Date: <b/>" + this.calDefault.SelectedDate.Month.ToString()
                + "/" + this.calDefault.SelectedDate.Day.ToString()
                + "/" + this.calDefault.SelectedDate.Year.ToString()
                + "<br /><b>Time: <b/>" + this.calDefault.SelectedDate.AddHours(10).Hour.ToString()
                + "AM"
                + "<br /> <b>Next Day: </b>" + this.calDefault.SelectedDate.AddDays(1).ToString();
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

        protected void calDefault_DayRender(object sender, DayRenderEventArgs e)
        {
            Style weekEndStyle = new Style();
            weekEndStyle.BackColor = Color.LightGray;

            if (e.Day.IsWeekend)
            {
                e.Cell.ApplyStyle(weekEndStyle);
                e.Day.IsSelectable = false;
            }

            /*if (e.Day.Date.CompareTo(DateTime.Today) == -1)
            {
                //e.Cell.ApplyStyle(beforeAfterToday);
                e.Day.IsSelectable = false;
            }

            if (e.Day.Date.CompareTo(DateTime.Today) == 1)
            {
                //e.Cell.ApplyStyle(beforeAfterToday);
                e.Day.IsSelectable = false;
            }*/
        }

        protected void drdSelectColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.drdSelectColor.SelectedItem.Value.ToString().ToUpper())
            {
                case "RED":
                    List<string> oRedColorCheckList = new List<string>();
                    oRedColorCheckList.Add("Stop Sign");
                    oRedColorCheckList.Add("Firetruck");
                    
                    this.cblColorSelectItem.DataSource = oRedColorCheckList;                    
                    this.cblColorSelectItem.DataBind();
                    break;

                case "BLUE":
                    List<string> oBlueColorCheckList = new List<string>();
                    oBlueColorCheckList.Add("Sky");
                    oBlueColorCheckList.Add("Blueberry");

                    this.cblColorSelectItem.DataSource = oBlueColorCheckList;
                    this.cblColorSelectItem.DataBind();
                    break;

                case "GREEN":
                    List<string> oGreenColorCheckList = new List<string>();
                    oGreenColorCheckList.Add("Grass");
                    oGreenColorCheckList.Add("Money");

                    this.cblColorSelectItem.DataSource = oGreenColorCheckList;
                    this.cblColorSelectItem.DataBind();
                    break;

                default:
                    this.litCustomMessage.Text = "Nothing Selected!";
                    break;
            }
            
        }
    }
}