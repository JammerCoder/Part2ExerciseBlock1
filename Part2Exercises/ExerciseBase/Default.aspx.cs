using System;
using System.Collections.Generic;
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
                Global.WorldID = 23456;
                Cache["TeamName"] = "ChicagoCubs";

                this.hypPage2.NavigateUrl = "~/Page2.aspx?ID=65";
                this.hypPage3.NavigateUrl = "~/Page3.aspx";
            }
            catch
            {                
            }
        }
    }
}