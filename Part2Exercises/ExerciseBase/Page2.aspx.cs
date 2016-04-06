using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExerciseBase
{
    public partial class Page2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Global.WorldID.ToString());
            decimal dGID = Global.WorldID / 2;
            this.lblGlobalID.Text = "<b><i>" + dGID.ToString() + "</i></b>" ;
            this.lblCacheVal.Text = Cache["TeamName"].ToString();

            //this.lblPassOnValue.Text = Request.QueryString["ID"];
            int iPassOnValue = Convert.ToInt32(Request.QueryString["ID"].ToString()) * 2;
            this.lblPassOnValue.Text = iPassOnValue.ToString();
        }
    }
}