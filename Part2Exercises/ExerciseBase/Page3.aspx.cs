using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using BookInfoCompanion;

namespace ExerciseBase
{
    public partial class Page3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                #region Refactored Area
                 
                #endregion 
                
                int iBookID = Global.BookID;
                
                //Populating connection string
                string sCnxn = ConfigurationManager.AppSettings["Cnxn"];
                string sLogPath = ConfigurationManager.AppSettings["LogPath"];

                Books oBooks = new Books(sCnxn, iBookID, sLogPath);                
 
                this.dgBookInfo.DataSource = oBooks.Values;
                this.dgBookInfo.DataBind();
                

            }
            catch (Exception ex)
            {
                this.lblErrorMessage.Text = ex.Message;
            }

        }
    }
}