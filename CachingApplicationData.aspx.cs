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

public partial class CachingApplicationData : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        System.Text.StringBuilder spMessage = new System.Text.StringBuilder();
        DateTime dtStartTime = DateTime.Now;
        if(Cache["ProductsData"]!=null)
        {
            DataSet ds =(DataSet)Cache["ProductsData"];
            Cache["ProductsData"] = ds;
            GridView1.DataSource = ds;
            GridView1.DataBind();
            spMessage.Append(ds.Tables[0].Rows.Count.ToString() + " rows retrived from DataBase. ");
        }
        else
        {
            DataSet ds = GetProducts();
           // Cache["ProductsData"] = ds;
            //Cache.Insert("ProductsData",ds);

            Cache.Add("ProductsData", ds, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.Default, null);

            GridView1.DataSource = ds;
            GridView1.DataBind();
           spMessage.Append( ds.Tables[0].Rows.Count.ToString() + " rows retrived from DataBase. ");
        }
        DateTime dtStopTime = DateTime.Now;

        int totalSeconds = (dtStartTime - dtStopTime).Seconds;
        spMessage.Append(totalSeconds.ToString() + " seconds load time.");
        Label1.Text = spMessage.ToString();
    }

    protected DataSet GetProducts()
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
        using(SqlConnection con = new SqlConnection(cs))
        {
            SqlDataAdapter da = new SqlDataAdapter("spGetProducts", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;


            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }




}