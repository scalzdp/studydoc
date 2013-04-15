using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataList1.DataSource = new int[] { 1 };
            DataList1.DataBind();
            //Multisel s1 = new UseMultisel1();
            //string p=s1.GetString("safasd");

            ICustomer customer = new Role();
            customer.Show();
            IAdmin admin = new Role();
            admin.Delete();
        }
    }


    public interface IAdmin
    {
        void Show();
        void Delete();
        void Update();
        void Insert();
    }

    public interface ICustomer
    {
        void Show();
    }

    public class Role:ICustomer,IAdmin
    {
        private HttpContext context = HttpContext.Current;
        public void Show()
        {
            context.Response.Write("show");
        }

        public void Delete()
        {
            context.Response.Write("Delete");
        }

        public void Update()
        {
            context.Response.Write("Update");
        }

        public void Insert()
        {
            context.Response.Write("Insert");
        }
    }

    //public class Multisel
    //{
    //    public abstract string GetString(string s);
    //    public abstract void SetLabelValue(Label lb);

    //}

    ////定义两个实现接口的类
    //public class UseMultisel1 : Multisel
    //{
    //    //实现接口中声明的方法的具体行为动作
    //    public override string GetString(string s) //获得字符串s的大写形式
    //    {
    //        return s.ToUpper();
    //    }
    //    public override void SetLabelValue(Label lb)//为Label控件赋值
    //    {
    //        lb.Text = "Use Multisel Sample 1";
    //    }
    //    public void pp()
    //    {

    //    }
    //}
    //public class UseMultisel2 : Multisel
    //{
    //    //实现接口中声明的方法的具体行为动作
    //    public string GetString(string s)
    //    {
    //        return s.ToLower();
    //    }
    //    public void SetLabelValue(Label lb)
    //    {
    //        lb.Text = "Use Multisel Sample 2";
    //    }
    //}


}




