using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class GetData
    {
        public SqlConnection m_Conn;
       // private Hashtable m_Erroobj;
        private string dbCon = null;

        public GetData(string str)
        {
            dbCon = str;
        }

        private DataSet GetDataSet(SqlCommand cmd)
        {
            string error = null;

            try
            {
                SqlConnection con = new SqlConnection(dbCon);
                //  con.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                cmd.Connection = con;
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception ex)
            {
                error = ex.Message;
                DataSet ds2 = new DataSet();
               // ds2.Tables[0].TableName = "ErrorTable";
                return ds2;
            }
        }
        public DataSet GetDataSetResult(SQLParams pap)
        {

            DataSet DS1 = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = pap.ProcName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@ProcID", pap.Segment));
            cmd.Parameters.Add(new SqlParameter("@Desc01", pap.var01));
            cmd.Parameters.Add(new SqlParameter("@Desc02", pap.var02));
            cmd.Parameters.Add(new SqlParameter("@Desc03", pap.var03));
            cmd.Parameters.Add(new SqlParameter("@Desc04", pap.var04));
            cmd.Parameters.Add(new SqlParameter("@Desc05", pap.var05));
            cmd.Parameters.Add(new SqlParameter("@Desc06", pap.var06));
            cmd.Parameters.Add(new SqlParameter("@Desc07", pap.var07));
            cmd.Parameters.Add(new SqlParameter("@Desc08", pap.var08));
            cmd.Parameters.Add(new SqlParameter("@Desc09", pap.var09));
            cmd.Parameters.Add(new SqlParameter("@Desc10", pap.var10));
            cmd.Parameters.Add(new SqlParameter("@Desc11", pap.var11));
            cmd.Parameters.Add(new SqlParameter("@Desc12", pap.var12));
            cmd.Parameters.Add(new SqlParameter("@Desc13", pap.var13));
            cmd.Parameters.Add(new SqlParameter("@Desc14", pap.var14));
            cmd.Parameters.Add(new SqlParameter("@Desc15", pap.var15));
            cmd.Parameters.Add(new SqlParameter("@Desc16", pap.var16));
            cmd.Parameters.Add(new SqlParameter("@Desc17", pap.var17));
            cmd.Parameters.Add(new SqlParameter("@Desc18", pap.var18));
            cmd.Parameters.Add(new SqlParameter("@Desc19", pap.var19));
            cmd.Parameters.Add(new SqlParameter("@Desc20", pap.var20));
            cmd.Parameters.Add(new SqlParameter("@Desc21", pap.var21));
            cmd.Parameters.Add(new SqlParameter("@Desc22", pap.var22));
            cmd.Parameters.Add(new SqlParameter("@Dbin01", pap.varBin01));
            cmd.Parameters.Add(new SqlParameter("@Dxml01", pap.varXml01));
            cmd.Parameters.Add(new SqlParameter("@Dxml02", pap.varXml02));
            cmd.Parameters.Add(new SqlParameter("@ComCod", pap.ComCod));
            DS1 = GetDataSet(cmd);
            return DS1;
        }
    }
}
