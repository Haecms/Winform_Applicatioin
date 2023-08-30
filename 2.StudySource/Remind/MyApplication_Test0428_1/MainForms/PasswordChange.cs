using Servicesss;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace MainForms
{
    public partial class PasswordChange : Form
    {
        public PasswordChange()
        {
            InitializeComponent();
        }

        private void btnPwChange_Click(object sender, EventArgs e)
        {
            // id/pw 입력여부
            string sMessage = string.Empty;// 필수입력 값 확인

            string sUserId = txtUserId.Text;    // 입력한 사용자 id
            string sPassword = txtNowPw.Text;   //입력한 현재 pw
            string sChangePw = txtChangePw.Text; // 변경할 pw

            if (sUserId == string.Empty) sMessage = "아이디";
            if (sPassword == string.Empty) sMessage = "현재 비밀번호";
            if (sChangePw == string.Empty) sMessage = "변경 비밀번호";

            if(sMessage != string.Empty)
            {
                MessageBox.Show($"{sMessage}를 입력하세요");
                return;
            }

            // ID 와 PW가 일치하는지?
            // 1. 데이터베이스에 접속
            
            SqlConnection sCon = new SqlConnection(Common.strCon);

            sCon.Open();

            try
            {
                // 2.데이터베이스가 수행 할 sql구문을 작성
                string sSQL = "SELECT * " +
                                   "FROM TB_USER"+
                                  $"WHERE USERID = '{sUserId}'"+
                                    $"AND PW     = '{sPassword}'";

                //SQL을 실행 할 ADAPTER 소환
                SqlDataAdapter Adapter = new SqlDataAdapter(sSQL, sCon);

                // 4. adpater 실행
                DataTable dtTemp = new DataTable(); //데이터 테이블을 받아오는 그릇
                Adapter.Fill(dtTemp);
                
                if(dtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("ID/PW가 잘못되었습니다.");
                    return;
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sCon.Close();
            }


            //비밀번호 변경 로직 수행
        }
    }
}
