using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class CacheMultipleResponses : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetProducts("All");
        }

        Label1.Text = DateTime.Now.ToString();
    }

    public void GetProducts(string ProductName)
    {
        string cs = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

        using (SqlConnection con = new SqlConnection(cs)) { 
        
            SqlDataAdapter da = new SqlDataAdapter("spGetProductByName", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter paramProduct = new SqlParameter();
            paramProduct.ParameterName = "@ProductName";
            paramProduct.Value = ProductName;
            da.SelectCommand.Parameters.Add(paramProduct);

            DataSet ds = new DataSet();
            da.Fill(ds);

            GridView1.DataSource = ds;
            GridView1.DataBind();


        }
    }






    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetProducts(DropDownList1.SelectedValue);
    }
}