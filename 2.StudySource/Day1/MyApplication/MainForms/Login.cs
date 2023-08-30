using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/************************************************************
 * NAME   : LogIn.cs
 * DESC   : 사용자 로그인 화면.
 * DATE   : 2023-04-27
 * AUTHOR : 조해찬
 * DESC   : 최초 프로그램 작성
 * 
 * 
 * DATE   : 2023-04-27
 * EDITOR : 홍길동
 * DESC   : 프로그램이 뭐 같아서 어떻게 수정했음 ㅍㅋㅍㅋ
 * 
 * *********************************************************/
namespace MainForms
{
    public partial class Login : Form
    {
        int count = 0;
        public Login()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 로그인 버튼 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogIn_Click(object sender = null, EventArgs e = null)
        {
            // 1. ID 와 PW를 입력하였는지 확인.
            string sUserId = txtUserId.Text;
            string sPasswor = txtPassWord.Text;

            string sMessage = string.Empty;
            if (sUserId == "")  sMessage = "아이디, ";
            if (sPasswor == "") sMessage += "비밀번호, ";

            if(sMessage != "")
            {
                MessageBox.Show(sMessage + " 를 입력하세요");
                return;
            }

            //2. ID 와 PW를 입력하였으므로 ID와 PW의 일치여부를 확인
            // localhost = 내 피시
            // 데이터베이스 접속 경로 지정.
            string strCon = "Server = localhost ; Uid = sa ; Pwd = 1234 ; database = AppDev";

            // 접속 경로를 커넥터에게 전달 (커넥터 : 집배원)
            SqlConnection sCon = new SqlConnection(strCon);
            try
            {
                //데이터 베이스 오픈(이 3줄로 데이터베이스에 연결됨)
                sCon.Open();

                //#region < 1. ID 와 PW가 동시에 일치하지 않을 경우>
                //// SQLadapter : C#에서 받아온 명령을 데이터베이스에게 실행하라고 지시
                ////              실행된 결과를 받아와서 c#으로 전달하는 역할 (수행자)

                ////데이터베이스가 수행할 SQL 구문
                //string sSQLCheckLogFlag = $"SELECT * FROM TB_User WHERE USERID = '{sUserId}'  AND PW = '{sPasswor}'";
                //// sCon 열어놨으니까 sSQLCheckLogFlag이거 수행하고 데이터베이스에서 반환된 한 행을 알려줘
                //SqlDataAdapter Adapter = new SqlDataAdapter(sSQLCheckLogFlag, sCon);

                //// 데이터베이스에서 결과를 받아올 자료형 그릇을 준비해야 함
                //DataTable dtTemp = new DataTable();
                //Adapter.Fill(dtTemp);


                //// ID와 PW가 일치하지 않을 경우. 로그인 실패 메세지 및 로그인 리턴.
                //if(dtTemp.Rows.Count == 0)
                //{
                //    txtPassWord.Text = "";
                //    txtPassWord.Focus(); //커서가 비밀번호로 가서 깜빡깜빡
                //    MessageBox.Show("ID 와 PW를 정확하게 입력하세요");
                //    return;
                //}

                //// 로그인 한 사용자의 이름을 받아와서 표현.
                //string sUserNAme = dtTemp.Rows[0]["USERNAME"].ToString();
                //MessageBox.Show($"{sUserNAme}님 반갑습니다.");
                //#endregion

                //#region <2. ID를 잘못 입력하였는지, PW를 잘못 입력 하였는지 확인 후 메세지 표현>
                ////수행할 구문
                //string sSQL = $"SELECT * FROM TB_User WHERE USERID = '{sUserId}'";
                //// 위를 수행하고 반환하는 구문
                //SqlDataAdapter Adapter = new SqlDataAdapter(sSQL, sCon);
                //// 반환한 구문을 받는 테이블 생성
                //DataTable dtTemp = new DataTable();
                //Adapter.Fill(dtTemp);

                //if(dtTemp.Rows.Count == 0)
                //{
                //    // ID가 존재하지 않는 경우
                //    txtUserId.Text = "";
                //    txtUserId.Focus();
                //    MessageBox.Show("존재하지 않는 ID입니다.");
                //    return;
                //}
                //else if(sPasswor != dtTemp.Rows[0]["PW"].ToString())
                //{
                //    //비밀번호가 일치하지 않는 경우
                //    txtPassWord.Text = "";
                //    txtPassWord.Focus();
                //    MessageBox.Show("비밀번호가 일치하지 않습니다.");
                //    return;
                //}
                //// ID와 PW가 일치하는 경우
                //string sUserNAme = dtTemp.Rows[0]["USERNAME"].ToString();
                //MessageBox.Show($"{sUserNAme}님 반갑습니다.");
                //#endregion
                #region< 3. 실습 PW 3번 잘못입력하였을 경우 프로그램 종료>
                // 프로그램 실행 -> ID별 비밀번호 입력 -> 비밀번호 일치 하지 않을 경우 (3)
                // 프로그램 종료 this.Close()
                string sSql = $"SELECT * FROM TB_User WHERE USERID = '{sUserId}'";
                SqlDataAdapter ADapter = new SqlDataAdapter(sSql, sCon);
                DataTable dttemp = new DataTable();
                ADapter.Fill(dttemp);
                

                if(dttemp.Rows.Count == 0)
                {
                    MessageBox.Show("존재하지 않는 ID입니다.");
                    return;
                }
                else if(sPasswor != dttemp.Rows[0]["PW"].ToString())
                {
                    count++;
                    if(count == 3)
                    {
                        MessageBox.Show($"비밀번호 {count}회 틀리셔서 종료합니다.");
                        this.Close();
                    }
                    MessageBox.Show($"비밀번호 {count}회 틀리셨습니다.");
                }
                string sUserNAme = dttemp.Rows[0]["USERNAME"].ToString();
                MessageBox.Show($"{sUserNAme}님 반갑습니다.");
                #endregion
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sCon.Close();
            }
        }

        private void btnPassWordChg_Click(object sender, EventArgs e)
        {
            // 비밀번호 변경 버튼 클릭

            // 1. 비밀번호 변경 클래스 선언
            PasswordChange PwCh = new PasswordChange();

            this.Visible = false; // 로그인 창 숨김

            // 2. 비밀번호 변경 클래스 나타내기
            PwCh.ShowDialog();

            this.Visible = true; // 로그인 창 나타내기

        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogIn_Click();
            }
        }
    }
}
