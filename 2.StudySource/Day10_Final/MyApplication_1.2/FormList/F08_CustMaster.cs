using MainForms;
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
    public partial class F08_CustMaster : Services.BaseChildForm
    {
        Login login = new Login();
        public F08_CustMaster()
        {
            InitializeComponent();
        }

        private void F08_CustMaster_Load(object sender, EventArgs e)
        {
            GridUtil _girdutil = new GridUtil();
            _girdutil.InitColumnGridUtil(Grid1, "CUSTTYPE"  , "거래처구분"    , typeof(string)  , DataGridViewContentAlignment.MiddleCenter, 100, true , true);
            _girdutil.InitColumnGridUtil(Grid1, "CUSTCODE"  , "거래처코드"    , typeof(string)  , DataGridViewContentAlignment.MiddleCenter, 150, false, true);
            _girdutil.InitColumnGridUtil(Grid1, "CUSTNAME"  , "거래처명"      , typeof(string)  , DataGridViewContentAlignment.MiddleCenter, 150, true , true);
            _girdutil.InitColumnGridUtil(Grid1, "BIZREQNO"  , "사업자등록번호", typeof(string)  , DataGridViewContentAlignment.MiddleCenter, 150, true , true);
            _girdutil.InitColumnGridUtil(Grid1, "BIZADDRESS", "주소"          , typeof(string)  , DataGridViewContentAlignment.MiddleCenter, 150, true , true);
            _girdutil.InitColumnGridUtil(Grid1, "PHONE"     , "전화번호"      , typeof(string)  , DataGridViewContentAlignment.MiddleCenter, 150, true , true);
            _girdutil.InitColumnGridUtil(Grid1, "OWNERNAME" , "대표자"        , typeof(string)  , DataGridViewContentAlignment.MiddleCenter, 100, true , true);
            _girdutil.InitColumnGridUtil(Grid1, "MAKEDATE"  , "생성일시"      , typeof(DateTime), DataGridViewContentAlignment.MiddleLeft,   150, false, true);
            _girdutil.InitColumnGridUtil(Grid1, "MAKER"     , "생성자"        , typeof(string)  , DataGridViewContentAlignment.MiddleCenter, 100, false, true);
            _girdutil.InitColumnGridUtil(Grid1, "EDITDATE"  , "수정일시"      , typeof(DateTime), DataGridViewContentAlignment.MiddleLeft,   150, false, true);
            _girdutil.InitColumnGridUtil(Grid1, "EDITOR"    , "수정자"        , typeof(string)  , DataGridViewContentAlignment.MiddleCenter, 100, false, true);
                                                                              
            Commons.GetCombo_Standard("CUSTTYPE", cboClient);
        }
        public override void DoInquire()
        {
            DBHelper helper = new DBHelper();
            try
            {
                ((DataTable)Grid1.DataSource).Clear();

                DataTable dtTemp = helper.FillTable("SP_CUSTMASTER_S1", CommandType.StoredProcedure,
                                                    helper.CreateParameters("@CUSTCODE", txtComCode.Text),
                                                    helper.CreateParameters("@CUSTNAME", txtComName.Text),
                                                    helper.CreateParameters("@CUSTTYPE", Convert.ToString(cboClient.SelectedValue)));


                if (dtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("조회할 데이터가 없습니다.");
                    return;
                }

                Grid1.DataSource = dtTemp;
                Commons.SetGridComboBox(Grid1, "CUSTTYPE", "CUSTTYPE");
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
            Grid1.InsertRow();
            Commons.SetGridComboBox(Grid1, "CUSTTYPE", "CUSTTYPE", false);
        }
        public override void DoDelete()
        {
            if (Grid1.Rows.Count == 0) return;
            Grid1.DeleteRow();
        }
        public override void DoSave()
        {
            DBHelper helper = new DBHelper(true);
            try
            {
                DataTable dtTemp = ((DataTable)Grid1.DataSource).GetChanges();
                if (dtTemp.Rows.Count == 0) return;

                if (MessageBox.Show("데이터를 저장하시겠습니까?", "데이터 저장", MessageBoxButtons.YesNo) == DialogResult.No) return;

                string sMessage = "";
                
                foreach (DataRow dr in dtTemp.Rows)
                {
                    switch (dr.RowState)
                    {
                        case DataRowState.Added:
                            if (dr["CUSTCODE"].ToString() == "") sMessage += "거래처 코드 ";
                            if (dr["CUSTTYPE"].ToString() == "") sMessage += "거래처 구분 ";
                            if (sMessage != "")
                            {
                                helper.Rollback();
                                MessageBox.Show(sMessage + "을(를) 입력하지 않았습니다.");
                                return;
                            }
                            helper.ExecuteNonQuery("SP_CUSTMASTER_I1", CommandType.StoredProcedure,
                                                    helper.CreateParameters("@CUSTCODE",   Convert.ToString(dr["CUSTCODE"])),
                                                    helper.CreateParameters("@CUSTNAME",   Convert.ToString(dr["CUSTNAME"])),
                                                    helper.CreateParameters("@CUSTTYPE",   Convert.ToString(dr["CUSTTYPE"])),
                                                    helper.CreateParameters("@BIZREQNO",   Convert.ToString(dr["BIZREQNO"])),
                                                    helper.CreateParameters("@BIZADDRESS", Convert.ToString(dr["BIZADDRESS"])),
                                                    helper.CreateParameters("@PHONE",      Convert.ToString(dr["PHONE"])),
                                                    helper.CreateParameters("@OWNERNAME",  Convert.ToString(dr["OWNERNAME"])),
                                                    helper.CreateParameters("@MAKER",      Commons.UserId));
                            break;

                        case DataRowState.Deleted:
                            dr.RejectChanges();
                            helper.ExecuteNonQuery("SP_CUSTMASTER_D1", CommandType.StoredProcedure,
                                                    helper.CreateParameters("@CUSTCODE", Convert.ToString(dr["CUSTCODE"])),
                                                    helper.CreateParameters("@CUSTTYPE", Convert.ToString(dr["CUSTTYPE"])));
                            break;

                        case DataRowState.Modified:
                            if (dr["CUSTCODE"].ToString() == "") sMessage += "거래처 코드 ";
                            if (dr["CUSTTYPE"].ToString() == "") sMessage += "거래처 구분 ";
                            if(sMessage != "")
                            {
                                helper.Rollback();
                                MessageBox.Show(sMessage + "을(를) 입력하지 않았습니다.");
                                return;
                            }

                            helper.ExecuteNonQuery("SP_CUSTMASTER_U1", CommandType.StoredProcedure,
                                                    helper.CreateParameters("@CUSTCODE",   Convert.ToString(dr["CUSTCODE"])),
                                                    helper.CreateParameters("@CUSTNAME",   Convert.ToString(dr["CUSTNAME"])),
                                                    helper.CreateParameters("@CUSTTYPE",   Convert.ToString(dr["CUSTTYPE"])),
                                                    helper.CreateParameters("@BIZREQNO",   Convert.ToString(dr["BIZREQNO"])),
                                                    helper.CreateParameters("@BIZADDRESS", Convert.ToString(dr["BIZADDRESS"])),
                                                    helper.CreateParameters("@PHONE",      Convert.ToString(dr["PHONE"])),
                                                    helper.CreateParameters("@OWNERNAME",  Convert.ToString(dr["OWNERNAME"])),
                                                    helper.CreateParameters("@EDITOR",     Commons.UserId));

                            break;
                    }
                    if(helper.RS_CODE != "S")
                    {
                        throw new Exception(helper.RS_MSG);
                    }
                }
                helper.Commit();
                MessageBox.Show("정상적으로 저장되었습니다.");
            }
            catch(Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }

        private void Grid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sCode = Convert.ToString(Grid1.CurrentRow.Cells["CUSTCODE"].Value);
            string sUserId = $"SELECT CUSTCODE FROM TB_CustMaster WHERE CUSTCODE = '{sCode}'";
            SqlDataAdapter Adapter1 = new SqlDataAdapter(sUserId, Commons.strCon);
            DataTable tTemp = new DataTable();
            Adapter1.Fill(tTemp);

            if (tTemp.Rows.Count == 0)
            {
                Grid1.CurrentRow.Cells["CUSTCODE"].ReadOnly = false;
            }
            else
            {
                Grid1.CurrentRow.Cells["CUSTCODE"].ReadOnly = true;
            }
        }
    }
}
