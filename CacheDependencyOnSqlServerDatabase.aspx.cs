using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class CacheDependencyOnSqlServerDatabase : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if(Cache["ProductsData"]!=null)
        {
            GridView1.DataSource=Cache["ProductsData"];
            GridView1.DataBind();

            Label1.Text="Data retrived from cache @ "+DateTime.Now.ToString();
        }

        else {

        
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        SqlCacheDependencyAdmin.EnableNotifications(cs);
        SqlCacheDependencyAdmin.EnableTableForNotifications(cs, "tblProducts");

        using(SqlConnection con = new SqlConnection(cs))
        {
            SqlDataAdapter da = new SqlDataAdapter("spGetProducts",con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();

            da.Fill(ds);

            CacheItemRemovedCallback onCacheItemRemoved = new CacheItemRemovedCallback(CacheItemRemovedCallbackMethod);

            SqlCacheDependency sqlDependency = new SqlCacheDependency("Sample1", "tblProducts");
            Cache.Insert("ProductsData", ds, sqlDependency, DateTime.Now.AddHours(24), Cache.NoSlidingExpiration, CacheItemPriority.Default, onCacheItemRemoved);
            
            GridView1.DataSource=ds;
            GridView1.DataBind();

            Label1.Text="Data retrived from database @ "+DateTime.Now.ToString();
           
        }


        }
             



    }
    public void CacheItemRemovedCallbackMethod(string key, object value, CacheItemRemovedReason reason)
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            SqlConnection con = new SqlConnection(cs);

            SqlDataAdapter da = new SqlDataAdapter("spGetProducts", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();

            da.Fill(ds);

            CacheItemRemovedCallback onCacheItemRemoved = new CacheItemRemovedCallback(CacheItemRemovedCallbackMethod);

            SqlCacheDependency sqlDependency = new SqlCacheDependency("Sample1", "tblProducts");
            Cache.Insert("ProductsData", ds, sqlDependency, DateTime.Now.AddHours(24), Cache.NoSlidingExpiration, CacheItemPriority.Default, onCacheItemRemoved);
    }
}