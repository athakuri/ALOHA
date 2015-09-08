using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Caching;
using System.Web.Security;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using Microsoft.Ajax.Utilities;

namespace ALOHA.Models
{
    public class CategoryModel
    {
        public bool Add(Category category)
        {
            SqlConnection con = null;
            bool result = false;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Insert into Category(name_Category,description_Category) values ('" + category.C_Name + category.C_desc+"')";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                return result = true;
            }
            catch (Exception ex)
            {
                return result = false;
            }
            finally
            {
                con.Close();
            }
        }
         public List<Category> SelectAll()
        {
            SqlConnection con = null;
            DataTable dt = null;
            List<Category> list = new List<Category>();
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from Category";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                dt = new DataTable();
                da.Fill(dt);
                list = dt.AsEnumerable().Select(r => new Category()
                {
                    Name = (string) r["Name"],
                    Id = (int) r["Id"]
                }
                    ).ToList();

                return list;
            }
            catch (Exception ex)
            {
                return list;
            }
            finally
            {
                con.Close();
            }
        }

        public bool Edit(Category category)
        {
            SqlConnection con = null;
            bool result = false;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Update Category set name_category='" + category.C_Name + "' + description_category='" + category.C_desc + "';
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                return result = true;
            }
            catch (Exception ex)
            {
                return result = false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool delete(String C_Name)
        {
            System.Data.SqlClient.SqlConnection con = null;
            bool result = false;
            try
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
                System.Data.SqlClient.SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Delete * from Category where name_category = " + C_Name;
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                con.Open();
                cmd.ExecuteNonQuery();
                return result = true;
            }
            catch (Exception ex)
            {
                return result = false;
            }
            finally
            {
                con.Close();
            }
        }
    }

    public class Category
    {
        public int C_Id { get; set; }
        public string C_Name { get; set; }
        public string C_desc { get; set; }

    }
}