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
            _gridUtil.InitColumnGridUtil(Grid1, "PW_F_CNT", "실패횟수", typeof(string),   100, true , true);
            _gridUtil.InitColumnGridUtil(Grid1, "DEPTCODE", "관리부서", typeof(string),   150, true , true);
            _gridUtil.InitColumnGridUtil(Grid1, "MAKEDATE", "등록일시", typeof(DateTime), 200, false, true);
            _gridUtil.InitColumnGridUtil(Grid1, "MAKER",    "생성자",   typeof(string),   150, false, true);
            _gridUtil.InitColumnGridUtil(Grid1, "EDITDATE", "수정일시", typeof(DateTime), 200, false, true);
            _gridUtil.InitColumnGridUtil(Grid1, "EDITOR",   "수정자",   typeof(string),   150, false, true);


            SqlConnection sCon = new SqlConnection(Commons.strCon);
            try
            {
                
                if (sCon.State != ConnectionState.Open) sCon.Open();
                string sSqulSelect = "";

                sSqulSelect += " SELECT ''               AS MAJORCODE,  ";
                sSqulSelect += "        '전체부서'       AS CODENAME    ";
                sSqulSelect += " UNION                                  ";
                sSqulSelect += " SELECT MAJORCODE,                      ";
                sSqulSelect += "        CODENAME                        ";
                sSqulSelect += "   FROM TB_Standard                     ";
                sSqulSelect += "  WHERE MAJORCODE = 'DEPTCODE'          ";

                SqlDataAdapter Adapter = new SqlDataAdapter(sSqulSelect, sCon);
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                cboDept.DataSource = dtTemp;
                cboDept.ValueMember = "MAJORCODE";
                cboDept.DisplayMember = "CODENAME";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());         //return 왜 안들어가죠????????????????
            }
            finally
            {
                sCon.Close();
            }
        }
    }
}
