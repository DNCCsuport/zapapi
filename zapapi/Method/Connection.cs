using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Xml.Linq;

namespace zapapi.Method
{
    public class Connection
    {
        //string connectionString = "Data Source=SUSHANT\\SQLEXPRESS;Initial Catalog=dncctech_16march;Integrated Security=true;Timeout=5000";
        string connectionString = "Data Source=103.21.58.78;Initial Catalog=dncctech;uid='dncc_admin';pwd='Support@2020'";

        public Boolean LeaddetInsert(string utc, string utmsource, string utmterm, string name, string mobile, string email, string lrd_rmks, int prodid, int lpid, int srcid, int pubid, string date1, int vendpubid, string preftime, string schedtime)
        {

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("sp_lms_ms_lead_details_i", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ltdet_utc", utc);
            cmd.Parameters.AddWithValue("@ltdet_utmsource", utmsource);
            cmd.Parameters.AddWithValue("@ltdet_utmterm", utmterm);
            cmd.Parameters.AddWithValue("@lpdet_fname", name);
            cmd.Parameters.AddWithValue("@lpdet_mobile", mobile);
            cmd.Parameters.AddWithValue("@lpdet_email_id", email);
            cmd.Parameters.AddWithValue("@ltdet_rmks", lrd_rmks);
            cmd.Parameters.AddWithValue("@fk_lpdet_prod_id", prodid);
            cmd.Parameters.AddWithValue("@fk_ltdet_lp_id", lpid);
            cmd.Parameters.AddWithValue("@fk_ltdet_src_id", srcid);
            cmd.Parameters.AddWithValue("@fk_ltdet_pub_id", pubid);
            cmd.Parameters.AddWithValue("@fk_ltdet_vendpub_id", vendpubid);
            cmd.Parameters.AddWithValue("@ltdet_preferred_consult_time", preftime);
            cmd.Parameters.AddWithValue("@ltdet_sched_consult_time", schedtime);
            con.Open();
            int k = cmd.ExecuteNonQuery();
            con.Close();
            if (k != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataTable GetProdId(string prod)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand comm = new SqlCommand())
            {
                {
                    var withBlock = comm;
                    withBlock.Connection = con;
                    withBlock.CommandType = CommandType.Text;
                    withBlock.CommandText = "IF EXISTS (select pk_proddet_id from ms_product_details where proddet_name like '"+prod.ToString()+"')\r\nBEGIN\r\n    select pk_proddet_id from ms_product_details where proddet_name like '"+prod.ToString()+"'\r\nEND\r\n else\r\n  begin\r\n   select 1 pk_proddet_id\r\n  end ";
                }
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(comm);
                sda.Fill(dt);
                con.Close();
            }
            return dt;
        }
        public DataTable GetLPId(string LP)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand comm = new SqlCommand())
            {
                {
                    var withBlock = comm;
                    withBlock.Connection = con;
                    withBlock.CommandType = CommandType.Text;
                    withBlock.CommandText = "IF EXISTS (select pk_lp_id from ms_lp_details where lp_name like '" + LP.ToString()+ "')\r\nBEGIN\r\n    select pk_lp_id from ms_lp_details where lp_name like '" + LP.ToString()+ "'\r\nEND\r\n else\r\n  begin\r\n   select 138 pk_lp_id\r\n  end ";
                }
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(comm);
                sda.Fill(dt);
                con.Close();
            }
            return dt;
        }
        public DataTable GetPubId(string pubid)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(connectionString);
            using (SqlCommand comm = new SqlCommand())
            {
                {
                    var withBlock = comm;
                    withBlock.Connection = con;
                    withBlock.CommandType = CommandType.Text;
                    withBlock.CommandText = "IF EXISTS (select pk_pubdet_id from ms_publisher_details where pubdet_short_name like '" + pubid.ToString()+ "')\r\nBEGIN\r\n    select pk_pubdet_id from ms_publisher_details where pubdet_short_name like '" + pubid.ToString()+ "'\r\nEND\r\n else\r\n  begin\r\n   select 3 pk_pubdet_id\r\n  end ";
                }
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(comm);
                sda.Fill(dt);
                con.Close();
            }
            return dt;
        }




    }
}
