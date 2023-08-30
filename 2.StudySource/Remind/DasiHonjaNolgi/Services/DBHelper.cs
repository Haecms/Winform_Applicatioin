using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services
{
    public class DBHelper
    {
        public SqlConnection sCon = new SqlConnection(Commons.strCon);
        public SqlDataAdapter Adapter;
        public SqlTransaction Tran;

        public string RS_CODE {  get; set; }
        public string RS_MSG { get; set; }

        public DBHelper(bool Transaction = false)
        {
            sCon.Open();
            if(Transaction)
            {
                Tran = sCon.BeginTransaction();
            }
        }

        public void Close()
        {
            sCon.Close();
        }
        public void RollBack()
        {
            if(Tran != null)
            {
                Tran.Rollback();
            }
        }
        public void Commit()
        {
            if(Tran != null)
            {
                Tran.Commit();
            }
        }
        public DataTable FillTable(string sSpName, CommandType ComType, params Params_[] parameters)
        {
            Adapter = new SqlDataAdapter(sSpName, Commons.strCon);
            Adapter.SelectCommand.CommandType = ComType;

            foreach(Params_ param in parameters)
            {
                Adapter.SelectCommand.Parameters.AddWithValue(param.ParamsName, param.ParamValue);
            }

            Adapter.SelectCommand.Parameters.AddWithValue("LANG", "");
            Adapter.SelectCommand.Parameters.AddWithValue("RS_CODE", "").Direction = ParameterDirection.Output;
            Adapter.SelectCommand.Parameters.AddWithValue("RS_MSG", "").Direction  = ParameterDirection.Output;

            DataTable dtTemp = new DataTable();
            Adapter.Fill(dtTemp);

            return dtTemp;
        }
        public Params_ CreateParameters(string sParamsName, string sParamsValue)
        {
            Params_ param = new Params_();
            param.ParamsName = sParamsName;
            param.ParamValue = sParamsValue;
            return param;
        }
        public void ExecuteNonQuery(string sCommandText, CommandType ComType, params Params_[] parameters)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Transaction = Tran;
            cmd.CommandText = sCommandText;
            cmd.Connection = sCon;

            cmd.CommandType = ComType;

            foreach(Params_ param in parameters)
            {
                cmd.Parameters.AddWithValue(param.ParamsName, param.ParamValue);
            }

            cmd.Parameters.AddWithValue("@LANG", "");
            cmd.Parameters.AddWithValue("@RS_CODE", "").Direction = ParameterDirection.Output;
            cmd.Parameters.AddWithValue("@RS_MSG", "").Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();

            RS_CODE = Convert.ToString(cmd.Parameters["@RS_CODE"].Value);
            RS_MSG  = Convert.ToString(cmd.Parameters["@RS_MSG"].Value);
        }
        public class Params_
        {
            public string ParamsName { get; set; }
            public string ParamValue { get; set; }
        }
    }
}
