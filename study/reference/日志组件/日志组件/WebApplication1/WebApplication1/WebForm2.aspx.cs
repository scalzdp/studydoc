using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebApplication1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Test test=new Test();
            DataTable table = test.Adomd();
            GridView1.DataSource = table;
            GridView1.DataBind();
        }
    }
}