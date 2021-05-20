using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace login
{
    class loginDAL
    {
        DataSet ds = new DataSet("log");
        private bool statuscheck =true;

        public bool Statuscheck
        {
            get { return statuscheck; }
            set { statuscheck = value; }
        }

        public bool status()
        {
            bool res = this.Statuscheck;
               return res;
        }
        public bool InsertData(Login l)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection("server=DESKTOP-I1NL9J5\\sqlexpress;Integrated Security=true;database=northwind");
            SqlDataAdapter da=new SqlDataAdapter("select * from login", cn);
            DataSet ds = new DataSet("log");
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds, "login");
            DataRow row = ds.Tables["login"].NewRow();
            row["username"] = l.UserName;
            row["password"] = l.Password;
            try
            {
                ds.Tables["login"].Rows.Add(row);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                da.Update(ds.Tables["login"]);
                status = true;

            }
            catch (Exception)
            {

                throw;
            }

            return status;
        }
        public bool check(string uname,string upass)
        {
            bool status = false;
            SqlConnection cn = new SqlConnection("server=DESKTOP-I1NL9J5\\sqlexpress;Integrated Security=true;database=northwind");
            SqlDataAdapter da = new SqlDataAdapter("select * from login", cn);
            DataSet ds = new DataSet("log");
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            da.Fill(ds, "login");

            try
            {
                DataRow data = ds.Tables["login"].Rows.Find(uname);
                string name = data[1].ToString();
                string pass = data[2].ToString();
                if (uname == name.Trim() && upass == pass.Trim
                    ())
                {
                 
                    
                    return true;
                }


                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                da.Update(ds.Tables["login"]);

            }
            catch (Exception)
            {

                throw;
            }


            return status;
        }
    }
}
