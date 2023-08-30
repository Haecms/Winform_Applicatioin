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
        public UserMaster_T()
        {
            InitializeComponent();
        }

        private void UserMaster_T_Load(object sender, EventArgs e)
        {

            GridUtil _gridUtil = new GridUtil();
            _gridUtil.InitColumnGridUtil(Grid1, "USERID",   "사용자ID", typeof(string),   100, true , true);
            _gridUtil.InitColumnGridUtil(Grid1, "USERNAME", "사용자명", typeof(string),   150, true , true);
            _gridUtil.InitColumnGridUtil(Grid1, "PW",       "비밀번호", typeof(string),   100, true , true);
            _gridUtil.InitColumnGridUtil(Grid1, "T_COUNT",  "실패횟수", typeof(string),   100, true , true);
            _gridUtil.InitColumnGridUtil(Grid1, "DEPTCODE", "관리부서", typeof(string),   150, true , true);
            _gridUtil.InitColumnGridUtil(Grid1, "MAKEDATE", "등록일시", typeof(DateTime), 200, false, true);
            _gridUtil.InitColumnGridUtil(Grid1, "MAKER",    "생성자",   typeof(string),   150, false, true);
            _gridUtil.InitColumnGridUtil(Grid1, "EDITDATE", "수정일시", typeof(DateTime), 200, false, true);
            _gridUtil.InitColumnGridUtil(Grid1, "EDITOR",   "수정자",   typeof(string),   150, false, true);

            Commons.GetCombo_Standard("DEPTCODE", cboDept);
        }
        //조회 문
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper();
            try
            {
                ((DataTable)Grid1.DataSource).Clear();

                helper.Adapter = new SqlDataAdapter("SP_UserMaster_S10", Commons.strCon);
                helper.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                helper.Adapter.SelectCommand.Parameters.AddWithValue("@USERID", txtUserId.Text);
                helper.Adapter.SelectCommand.Parameters.AddWithValue("@USERNAME", txtUserName.Text);
                helper.Adapter.SelectCommand.Parameters.AddWithValue("@DEPTCODE", Convert.ToString(cboDept.SelectedValue));

                helper.Adapter.SelectCommand.Parameters.AddWithValue("@LANG", "");
                helper.Adapter.SelectCommand.Parameters.AddWithValue("@RS_CODE","").Direction = ParameterDirection.Output;
                helper.Adapter.SelectCommand.Parameters.AddWithValue("@RS_MSG", "").Direction = ParameterDirection.Output;

                DataTable dtTemp = new DataTable();
                helper.Adapter.Fill(dtTemp);

                if(dtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("조회할 데이터가 없습니다.");
                    return;
                }
                Grid1.DataSource = dtTemp;

                // 그리드의 부서칸에 콤보박스 만들어줄거
                DataTable dttemp = Commons.GetCombo_Standard_Grid("DEPTCODE");
                if (dttemp.Rows.Count == 0) return;

                for (int i=0; i < Grid1.Rows.Count; i++)
                {
                    DataGridViewComboBoxCell cCell = new DataGridViewComboBoxCell();
                    cCell.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                    cCell.DataSource = dttemp;
                    cCell.DisplayMember = "CODENAME";
                    cCell.ValueMember = "MAJORCODE";

                    Grid1.Rows[i].Cells["DEPTCODE"] = cCell;
                }
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
    }
}
