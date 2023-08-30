using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormList
{
    public partial class UserMaster_T : Services.BaseChildForm
    {
        Commons Com = new Commons();
        public UserMaster_T()
        {
            InitializeComponent();
        }

        private void UserMaster_T_Load(object sender, EventArgs e)
        {
            GridUtil _Gridutil = new GridUtil();
            _Gridutil.InitColumnGridUtil(Grid2, "USERID",   "사용자 ID", 150, false, typeof(string));
            _Gridutil.InitColumnGridUtil(Grid2, "USERNAME", "사용자명",  150, false, typeof(string));
            _Gridutil.InitColumnGridUtil(Grid2, "PW",       "비밀번호",  150, false, typeof(string));
            _Gridutil.InitColumnGridUtil(Grid2, "T_COUNT",  "실패횟수",  150, false, typeof(string));
            _Gridutil.InitColumnGridUtil(Grid2, "DEPTCODE", "부서",      150, false, typeof(string));
            _Gridutil.InitColumnGridUtil(Grid2, "MAKEDATE", "등록일시",  150, false, typeof(DateTime));
            _Gridutil.InitColumnGridUtil(Grid2, "MAKER",    "등록자",    150, false, typeof(string));
            _Gridutil.InitColumnGridUtil(Grid2, "EDITDATE", "수정일시",  150, false, typeof(DateTime));
            _Gridutil.InitColumnGridUtil(Grid2, "EDITOR",   "수정자",    150, false, typeof(string));

            Com.GetCombo_Standard(cboDept, "DEPTCODE");
        }
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper(true);
            try
            {
                ((DataTable)Grid2.DataSource).Clear();

                helper.Adapter = new SqlDataAdapter("SP_UserMaster_S11", Commons.strCon);
                helper.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                helper.Adapter.SelectCommand.Parameters.AddWithValue("@USERID"  , txtUserId.Text);
                helper.Adapter.SelectCommand.Parameters.AddWithValue("@USERNAME", txtUserName.Text);
                helper.Adapter.SelectCommand.Parameters.AddWithValue("@DEPTCODE", Convert.ToString(cboDept.SelectedValue));

                helper.Adapter.SelectCommand.Parameters.AddWithValue("@LANG"   , "");
                helper.Adapter.SelectCommand.Parameters.AddWithValue("@RS_CODE", "").Direction = ParameterDirection.Output;
                helper.Adapter.SelectCommand.Parameters.AddWithValue("@RS_MSG" , "").Direction = ParameterDirection.Output;

                DataTable dtTemp = new DataTable();
                helper.Adapter.Fill(dtTemp);

                if(dtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("조회할 데이터가 없습니다.");
                    return;
                }
                Grid2.DataSource = dtTemp;

                // 그리드 칸에 콤보박스 셋팅할거임 ㅍㅋ
                Com.SetGridComboBox(Grid2, "DEPTCODE", "DEPTCODE");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {
                helper.Close();
            }
        }
        public override void DoNew()
        {
            DataRow dr = ((DataTable)Grid2.DataSource).NewRow();
            ((DataTable)Grid2.DataSource).Rows.Add(dr);

            Com.SetGridComboBox(Grid2, "DEPTCODE", "DEPTCODE", false);
        }
        public override void DoDelete()
        {
            if (Grid2.Rows.Count == 0) return;
            int iRowsIndex = Grid2.CurrentRow.Index;

            DataTable dtTemp = (DataTable)Grid2.DataSource;
            dtTemp.Rows[iRowsIndex].Delete();
        }
        public override void DoSave()
        {
            DBHelper helper = new DBHelper(true);
            try
            {
                DataTable dtTemp = ((DataTable)Grid2.DataSource).GetChanges();
                if (dtTemp.Rows.Count == 0) return;

                if (MessageBox.Show("저장하시겠습니까?", "데이터 저장", MessageBoxButtons.YesNo) == DialogResult.No) return;

                SqlCommand Command = new SqlCommand();
                Command.Transaction = helper.Tran;
                Command.Connection = helper.sCon;
                Command.CommandType = CommandType.StoredProcedure;

                string sMessage = string.Empty;
                string sRsCode  = string.Empty;
                string sMsg     = string.Empty;

                foreach(DataRow dr in dtTemp.Rows)
                {
                    switch (dr.RowState)
                    {
                        case DataRowState.Deleted:
                            dr.RejectChanges();

                            Command.CommandText = "SP_UserMaster_D10";
                            Command.Parameters.AddWithValue("@USERID", dr["USERID"]);

                            Command.Parameters.AddWithValue("@LANG", "");
                            Command.Parameters.AddWithValue("@RS_CODE", "").Direction = ParameterDirection.Output;
                            Command.Parameters.AddWithValue("@RS_MSG", "").Direction  = ParameterDirection.Output;

                            Command.ExecuteNonQuery();

                            break;
                        case DataRowState.Added:
                            if (dr["USERID"] == "") sMessage += "사용자 ID ";
                            if (dr["PW"] == "")     sMessage += "비밀번호 ";

                            if(sMessage != "")
                            {
                                helper.RollBack();
                                MessageBox.Show(sMessage + "을(를) 입력하지 않았습니다.");
                                return;
                            }

                            Command.CommandText = "SP_UserMaster_I10";
                            Command.Parameters.AddWithValue("@USERID",                   dr["USERID"]);
                            Command.Parameters.AddWithValue("@USERNAME",                 dr["USERNAME"]);
                            Command.Parameters.AddWithValue("@PW"                      , dr["PW"]);
                            Command.Parameters.AddWithValue("@T_COUNT", Convert.ToString(dr["T_COUNT"]));
                            Command.Parameters.AddWithValue("@DEPTCODE",                 dr["DEPTCODE"]);
                            Command.Parameters.AddWithValue("@MAKER",   Commons.UserId);

                            Command.Parameters.AddWithValue("@LANG", "") ;
                            Command.Parameters.AddWithValue("@RS_CODE", "").Direction = ParameterDirection.Output;
                            Command.Parameters.AddWithValue("@RS_MSG", "").Direction  = ParameterDirection.Output;

                            Command.ExecuteNonQuery();

                            break;
                        case DataRowState.Modified:
                            if (dr["USERID"] == "") sMessage += "사용자 ID ";
                            if (dr["PW"] == "") sMessage += "비밀번호 ";

                            if (sMessage != "")
                            {
                                helper.RollBack();
                                MessageBox.Show(sMessage + "을(를) 입력하지 않았습니다.");
                                return;
                            }

                            Command.CommandText = "SP_UserMaster_U10";
                            Command.Parameters.AddWithValue("@USERID"  , dr["USERID"]);
                            Command.Parameters.AddWithValue("@USERNAME", dr["USERNAME"]);
                            Command.Parameters.AddWithValue("@PW"      , dr["PW"]);
                            Command.Parameters.AddWithValue("@T_COUNT" , Convert.ToString(dr["T_COUNT"]));
                            Command.Parameters.AddWithValue("@DEPTCODE", dr["DEPTCODE"]);
                            Command.Parameters.AddWithValue("@EDITOR"  , Commons.UserId);

                            Command.Parameters.AddWithValue("@LANG"   , "");
                            Command.Parameters.AddWithValue("@RS_CODE", "").Direction = ParameterDirection.Output;
                            Command.Parameters.AddWithValue("@RS_MSG" , "").Direction = ParameterDirection.Output;

                            Command.ExecuteNonQuery();
                            break;
                    }
                    sRsCode = Convert.ToString(Command.Parameters["@RS_CODE"].Value);
                    sMsg    = Convert.ToString(Command.Parameters["@RS_MSG"].Value);

                    if (sRsCode != "S")
                    {
                        throw new Exception(sMsg);
                    }
                    Command.Parameters.Clear();
                }
                helper.Commit();
                MessageBox.Show("정상적으로 저장되었습니다.");
            }
            catch(Exception ex)
            {
                helper.RollBack();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
    }
}
