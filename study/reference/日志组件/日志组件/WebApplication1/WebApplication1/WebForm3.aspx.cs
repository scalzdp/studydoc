using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataList1.DataSource = new int[] { 1,2 };
            DataList1.DataBind();
            List<obj> list = new List<obj>();
            for (int i = 0; i < 3; i++)
            {
                obj tmp = new obj();
                tmp.IDs = i.ToString();
                list.Add(tmp);
            }
            dgDataList.DataSource = list;
            dgDataList.DataBind();
        }

        protected void dgDataList_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                e.Item.CssClass = "show";
            }
        }
    }
    public class obj
    {
        public obj()
        {
        }
        public string IDs
        {
            get;
            set;
        }
    }
}