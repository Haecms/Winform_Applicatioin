using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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
            _gridUtil.InitColumnGridUtil(myGrid1, "USERID",   "사용자ID", typeof(string),   DataGridViewContentAlignment.MiddleLeft,   100, true,  true);
            _gridUtil.InitColumnGridUtil(myGrid1, "USERNAME", "사용자명", typeof(string),   DataGridViewContentAlignment.MiddleLeft,   150, true,  true);
            _gridUtil.InitColumnGridUtil(myGrid1, "PW",       "비밀번호", typeof(string),   DataGridViewContentAlignment.MiddleLeft,   100, true,  true);
            _gridUtil.InitColumnGridUtil(myGrid1, "T_COUNT",  "실패횟수", typeof(string),   DataGridViewContentAlignment.MiddleRight,  100, true,  true);
            _gridUtil.InitColumnGridUtil(myGrid1, "DEPTCODE", "관리부서", typeof(string),   DataGridViewContentAlignment.MiddleLeft,   150, true,  true);
            _gridUtil.InitColumnGridUtil(myGrid1, "MAKEDATE", "등록일시", typeof(DateTime), DataGridViewContentAlignment.MiddleCenter, 200, false, true);
            _gridUtil.InitColumnGridUtil(myGrid1, "MAKER",    "생성자",   typeof(string),   DataGridViewContentAlignment.MiddleLeft,   150, false, true);
            _gridUtil.InitColumnGridUtil(myGrid1, "EDITDATE", "수정일시", typeof(DateTime), DataGridViewContentAlignment.MiddleCenter, 200, false, true);
            _gridUtil.InitColumnGridUtil(myGrid1, "EDITOR",   "수정자",   typeof(string),   DataGridViewContentAlignment.MiddleLeft,   150, false, true);

            #region < 콤보박스 세팅>
            Commons.GetCombo_Standard("DEPTCODE", cboDept);
            #endregion
        }

        /* 메서드 오버라이딩
         * Virtual로 상속한 메서드를 
         * 각 화면에 맞는 기능으로 변경하여 재정의 하고 구현하는 방식
         * 상속을 준 클래스의 메서드를 호출 할 경우
         * 해당 클래스의 메서드도 동시에 실행되도록 연결해 주는 방식
         * 
         * base(상속을 준 녀석 즉 추상클래스).DoInquire를 실행하지 않으면 상위 클래스의 DoInquire()메서드는 실행되지 않는다.
         */ 
        public override void DoInquire()
        {
            //base.DoInquire();
            // 저장 프로시저를 사용한 조회 로직
            /* 저장 프로시저
             * 1. 데이터베이스에 쿼리를 등록해 두어서 로그인하지 않으면 확인할 수 없다. (보완성)
             * 2. 등록해 둔 쿼리를 저장프로시저 명으로 호출을 함으로써 재사용성이 증가
             * 3. 프로시저를 한번 호출하면 메모리에 내역이 남아있어 후속 호출 시에 리소스가 줄어든다.
             * 4. 쿼리문을 소스에서 InQuery로 처리할 경우 네트워크 부하를 일으킬 수 있다.
             */

            // 데이터베이스 접속
            /*SqlConnection sCon = new SqlConnection(Commons.strCon);
            sCon.Open();*/
            DBHelper helper = new DBHelper();
            try
            {
                // 그리드에 표현되어 있는 데이터 삭제
                ((DataTable)myGrid1.DataSource).Clear();  // 참조로 연결되어 있다.

                //// 저장프로시저를 실행할 SqlAdapter를 선언.
                //Adapter = new SqlDataAdapter("SP_UserMaster_S1", Commons.strCon);
                //// 저장 프로시저 형태로 실행 하는것을 설정.
                //Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                //// Adapter가 프로시져에게 전달할 매개변수(파라매터) 등록을 합시다.
                //Adapter.SelectCommand.Parameters.AddWithValue("@USERID", txtUserId.Text);
                //Adapter.SelectCommand.Parameters.AddWithValue("@USERNAME", txtUserName.Text);
                //Adapter.SelectCommand.Parameters.AddWithValue("@DEPTCODE", Convert.ToString(cboDept.SelectedValue));


                //Params_ p1 = helper.CreateParameters("@USERID", txtUserId.Text);
                //Params_ p2 = helper.CreateParameters("@USERNAME", txtUserName.Text);
                //Params_ p3 = helper.CreateParameters("@DEPTCODE", Convert.ToString(cboDept.SelectedValue));
                //helper.FillTable("SP_UserMaster_S1", CommandType.StoredProcedure, p1, p2, p3)


                DataTable dtTemp = helper.FillTable("SP_UserMaster_S1", CommandType.StoredProcedure,
                                                    helper.CreateParameters("@USERID", txtUserId.Text), // 파람스 배열 만들어야함 DBHelper ㄱㄱ
                                                    helper.CreateParameters("@USERNAME", txtUserName.Text),
                                                    helper.CreateParameters("@DEPTCODE", Convert.ToString(cboDept.SelectedValue)));
                

                if (dtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("조회할 데이터가 없습니다.");
                    return;
                }
                // 그리드 뷰에 데이터 삽입
                myGrid1.DataSource = dtTemp;

                #region < 그리드 콤보박스 셋팅 (부서)>

                Commons.SetGridComboBox(myGrid1, "DEPTCODE", "DEPTCODE");

                #endregion
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
            // Heap 영역에 있는 그리드 DataSource의 행 정보를 가지고 신규 행을 생성한다.
            myGrid1.InsertRow();

            // 신규 행 추가 후 부서 선택 콤보박스 등록.
            Commons.SetGridComboBox(myGrid1, "DEPTCODE", "DEPTCODE",false);
        }

        public override void DoDelete()
        {
            // 삭제 버튼 클릭 시 로직
            if (myGrid1.Rows.Count == 0) return;
            //int iRowsIndex = myGrid1.CurrentRow.Index;    // 현재 선택한 행의 Index

            //// Heap 영역에 있는 그리드의 데이터 속성을 DataTable로 전달
            //DataTable dtTemp = (DataTable)myGrid1.DataSource;
            ////dtTemp.Rows.RemoveAt(iRowsIndex);   // 선택한 행의 Index를 삭제. // RemoveAt 사용하면 안 됨!!!! (원본 Source를 통채로 삭제) _ 삭제된 상태를 확인할 수가 없다.)
            //dtTemp.Rows[iRowsIndex].Delete();     // 선택한 행의 보이는 부분만 삭제. 즉 DataSource는 살아있음

            myGrid1.DeleteRow();
        }

        public override void DoSave()
        {
            // 저장 버튼 클릭시 일괄 저장 및 일괄 롤백.

            // 1. DataBase Open / Transaction 선언
            DBHelper helper = new DBHelper(true);   //내가 트랜잭션 설정할거다 라는 뜻
            try
            {
                // 2. 그리드에 조회 이후 변경된 이력이 있는지 확인 및 변경 내역 리스트로 추출하기
                DataTable dtTemp = ((DataTable)myGrid1.DataSource).GetChanges();  // 변경된 사항을 dtTemp에 넣어줌
                if (dtTemp.Rows.Count == 0) return;

                if (MessageBox.Show("저장하시겠습니까?", "데이터저장", MessageBoxButtons.YesNo) != DialogResult.Yes) return;

                string sMessage = string.Empty;
                string sRsCode  = string.Empty; //데이터베이스에서 받아온 성공여부
                string sMsg     = string.Empty;
                // 7. 
                foreach (DataRow dr in dtTemp.Rows)
                {
                    switch (dr.RowState)
                    {
                        case DataRowState.Deleted:    // 행이 삭제된 경우
                            dr.RejectChanges();    // 지워진 행의 데이터를 복구

                            helper.ExecuteNonQuery("SP_UserMaster_D1", CommandType.StoredProcedure,
                                                    helper.CreateParameters("@USERID", Convert.ToString(dr["USERID"])));

                            break;                    
                        case DataRowState.Added:      // 행이 추가된 경우

                            if (dr["USERID"] == "") sMessage += "사용자 ID ";
                            if (dr["PW"]     == "") sMessage += "비밀번호 ";
                            if(sMessage != "")
                            {
                                helper.Rollback();
                                MessageBox.Show(sMessage + "을(를) 입력하지 않았습니다");
                                return;
                            }
                            helper.ExecuteNonQuery("SP_UserMaster_I1", CommandType.StoredProcedure,
                                                    helper.CreateParameters("@USERID",   Convert.ToString(dr["USERID"])),
                                                    helper.CreateParameters("@USERNAME", Convert.ToString(dr["USERNAME"])),
                                                    helper.CreateParameters("@PW",       Convert.ToString(dr["PW"])),
                                                    helper.CreateParameters("@T_COUNT",  Convert.ToString(dr["T_COUNT"])),
                                                    helper.CreateParameters("@DEPTCODE", Convert.ToString(dr["DEPTCODE"])),
                                                    helper.CreateParameters("@MAKER",    Commons.UserId));

                            //Com.CommandText = "SP_UserMaster_I1";
                            //Com.Parameters.AddWithValue("@USERID",   dr["USERID"]);
                            //Com.Parameters.AddWithValue("@USERNAME", dr["USERNAME"]);
                            //Com.Parameters.AddWithValue("@PW",       dr["PW"]);
                            //Com.Parameters.AddWithValue("@T_COUNT",  Convert.ToString(dr["T_COUNT"]) == "" ? 0 : dr["T_COUNT"]);
                            //Com.Parameters.AddWithValue("@DEPTCODE", dr["DEPTCODE"]);
                            //Com.Parameters.AddWithValue("@MAKER",    Commons.UserId);

                            //Com.Parameters.AddWithValue("@LANG",    "");
                            //Com.Parameters.AddWithValue("@RS_CODE", "").Direction = ParameterDirection.Output;
                            //Com.Parameters.AddWithValue("@RS_MSG",  "").Direction = ParameterDirection.Output;

                            //Com.ExecuteNonQuery();

                            break;                    
                        case DataRowState.Modified:   // 행이 수정된 경우
                            if (dr["USERID"] == "") sMessage += "사용자 ID ";
                            if (dr["PW"] == "") sMessage += "비밀번호 ";
                            if (sMessage != "")
                            {
                                helper.Rollback();
                                MessageBox.Show(sMessage + "을(를) 입력하지 않았습니다");
                                return;
                            }

                            helper.ExecuteNonQuery("SP_UserMaster_U1", CommandType.StoredProcedure,
                                                    helper.CreateParameters("@USERID",   Convert.ToString(dr["USERID"])),
                                                    helper.CreateParameters("@USERNAME", Convert.ToString(dr["USERNAME"])),
                                                    helper.CreateParameters("@PW",       Convert.ToString(dr["PW"])),
                                                    helper.CreateParameters("@T_COUNT",  Convert.ToString(dr["T_COUNT"])),
                                                    helper.CreateParameters("@DEPTCODE", Convert.ToString(dr["DEPTCODE"])),
                                                    helper.CreateParameters("@EDITOR",   Commons.UserId));

                            //Com.CommandText = "SP_UserMaster_U1";
                            //Com.Parameters.AddWithValue("@USERID",   dr["USERID"]);
                            //Com.Parameters.AddWithValue("@USERNAME", dr["USERNAME"]);
                            //Com.Parameters.AddWithValue("@PW",       dr["PW"]);
                            //Com.Parameters.AddWithValue("@T_COUNT",  Convert.ToString(dr["T_COUNT"]) == "" ? 0 : dr["T_COUNT"]);
                            //Com.Parameters.AddWithValue("@DEPTCODE", dr["DEPTCODE"]);
                            //Com.Parameters.AddWithValue("@EDITOR", Commons.UserId);

                            //Com.Parameters.AddWithValue("@LANG", "");
                            //Com.Parameters.AddWithValue("@RS_CODE", "").Direction = ParameterDirection.Output;
                            //Com.Parameters.AddWithValue("@RS_MSG", "").Direction = ParameterDirection.Output;

                            //Com.ExecuteNonQuery();


                            break;
                    }

                    if(helper.RS_CODE != "S")
                    {
                        //helper.Rollback();
                        //MessageBox.Show(sMsg);
                        //return;
                        throw new Exception(helper.RS_MSG);
                    }
                }

                helper.Commit();
                MessageBox.Show("정상적으로 저장 되었습니다.");
            }
            catch (Exception ex)
            {
                helper.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                helper.Close();
            }
        }
    }
}
