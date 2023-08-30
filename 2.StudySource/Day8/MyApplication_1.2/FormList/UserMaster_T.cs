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
            _gridUtil.InitColumnGridUtil(Grid1, "USERID",   "사용자ID", typeof(string),   DataGridViewContentAlignment.MiddleLeft,   100, true,  true);
            _gridUtil.InitColumnGridUtil(Grid1, "USERNAME", "사용자명", typeof(string),   DataGridViewContentAlignment.MiddleLeft,   150, true,  true);
            _gridUtil.InitColumnGridUtil(Grid1, "PW",       "비밀번호", typeof(string),   DataGridViewContentAlignment.MiddleLeft,   100, true,  true);
            _gridUtil.InitColumnGridUtil(Grid1, "T_COUNT",  "실패횟수", typeof(string),   DataGridViewContentAlignment.MiddleRight,  100, true,  true);
            _gridUtil.InitColumnGridUtil(Grid1, "DEPTCODE", "관리부서", typeof(string),   DataGridViewContentAlignment.MiddleLeft,   150, true,  true);
            _gridUtil.InitColumnGridUtil(Grid1, "MAKEDATE", "등록일시", typeof(DateTime), DataGridViewContentAlignment.MiddleCenter, 200, false, true);
            _gridUtil.InitColumnGridUtil(Grid1, "MAKER",    "생성자",   typeof(string),   DataGridViewContentAlignment.MiddleLeft,   150, false, true);
            _gridUtil.InitColumnGridUtil(Grid1, "EDITDATE", "수정일시", typeof(DateTime), DataGridViewContentAlignment.MiddleCenter, 200, false, true);
            _gridUtil.InitColumnGridUtil(Grid1, "EDITOR",   "수정자",   typeof(string),   DataGridViewContentAlignment.MiddleLeft,   150, false, true);

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
                ((DataTable)Grid1.DataSource).Clear();  // 참조로 연결되어 있다.

                // 저장프로시저를 실행할 SqlAdapter를 선언.
                helper.Adapter = new SqlDataAdapter("SP_UserMaster_S1", Commons.strCon);
                // 저장 프로시저 형태로 실행 하는것을 설정.
                helper.Adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                // Adapter가 프로시져에게 전달할 매개변수(파라매터) 등록을 합시다.
                helper.Adapter.SelectCommand.Parameters.AddWithValue("@USERID", txtUserId.Text);
                helper.Adapter.SelectCommand.Parameters.AddWithValue("@USERNAME", txtUserName.Text);
                helper.Adapter.SelectCommand.Parameters.AddWithValue("@DEPTCODE", Convert.ToString(cboDept.SelectedValue));

                helper.Adapter.SelectCommand.Parameters.AddWithValue("@LANG", ""); // 아무것도 지정되지 않아서 기본값 KO를 가지고 시작함
                helper.Adapter.SelectCommand.Parameters.AddWithValue("@RS_CODE", "").Direction = ParameterDirection.Output;
                helper.Adapter.SelectCommand.Parameters.AddWithValue("@RS_MSG", "").Direction = ParameterDirection.Output;

                DataTable dtTmep = new DataTable();
                helper.Adapter.Fill(dtTmep);

                if (dtTmep.Rows.Count == 0)
                {
                    MessageBox.Show("조회할 데이터가 없습니다.");
                    return;
                }
                // 그리드 뷰에 데이터 삽입
                Grid1.DataSource = dtTmep;

                #region < 그리드 콤보박스 셋팅 (부서)>
                // 1. 그리드 콤보박스에 셋팅할 관리 부서 정보 가져오기
                DataTable dttemp = Commons.GetCombo_Standard_Grid("DEPTCODE");
                if (dttemp.Rows.Count == 0) return;

                for (int i =0; i < Grid1.Rows.Count; i++)
                {
                    // Combobox 유형의 셀을 생성
                    DataGridViewComboBoxCell CellC = new DataGridViewComboBoxCell();
                    // 콤보박스 셀의 유형을 콤보박스로 선택
                    CellC.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                    // 콤보박스에 데이터 등록
                    CellC.DataSource = dttemp;
                    CellC.DisplayMember = "CODENAME";
                    CellC.ValueMember = "MAJORCODE";

                    // 새로 생성한 콤보박스 유형의 그리드콤보박스 컨트롤을 부서 컬럼에 매핑.
                    Grid1.Rows[i].Cells["DEPTCODE"] = CellC;
                }

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
    }
}
