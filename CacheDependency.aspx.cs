using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Caching;

public partial class CacheDependency : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if(Cache["CountriesData"]!=null)
        {
            DataSet ds = (DataSet)Cache["CountriesData"];
            GridView1.DataSource = ds;
            GridView1.DataBind();

            Label1.Text = ds.Tables[0].Rows.Count.ToString() + " rows retrived from cache";


        }
        else
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Server.MapPath("~/Data/Countries.xml"));
            Cache.Insert("CountriesData", ds,new System.Web.Caching.CacheDependency( Server.MapPath("~/Data/Countries.xml")), DateTime.Now.AddSeconds(60), Cache.NoSlidingExpiration);
            GridView1.DataSource = ds;
            GridView1.DataBind();
            Label1.Text = ds.Tables[0].Rows.Count.ToString() + " rows retrived from Dataset";
        }
    }



}