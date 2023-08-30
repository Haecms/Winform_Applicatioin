using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;

/************************************************************
 * NAME   : LogIn.cs
 * DESC   : 사용자 로그인 화면.
 * DATE   : 2023-04-27
 * AUTHOR : 동상현
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


        // 접속 경로를 커넥터 에게 전달 (커넥터 : 집배원)
        SqlConnection sCon;

        // 1. 필드 멤버 
        // 2. 생성자 멤버 , 객체가 생성될때 (인스턴스화) 메서드 
        // 3. 메서드 멤버. 누군가가 호출을 해야만 실행

        public Login()
        {
            InitializeComponent();
        }
        int icnt=  0;
        /// <summary>
        /// 로그인 버튼 클릭 시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogIn_Click(object sender = null, EventArgs e = null)
        {
            // 1. ID 와 PW를 입력하였는지 확인.
            string sUserId   = txtUserId.Text;
            string sPassword = txtPassWord.Text;

            string sMessage = string.Empty;
            if (sUserId == "")   sMessage  = "아이디, ";
            if (sPassword == "") sMessage += "비밀번호 ";
            
            if (sMessage != "")
            {
                MessageBox.Show(sMessage + " 를 입력하세요");
                return;
            }

            // 데이터베이스 접속 경로 지정.
            
            

            // 접속 경로를 커넥터 에게 전달 (커넥터 : 집배원)
            SqlConnection sCon = new SqlConnection(Commons.strCon);
            try
            {

                //2.ID 와 PW 를 입력하였으므로 ID 와 PW 일치여부를 확인.


                // 데이터 베이스 오픈.
                sCon.Open();

                #region < 1. ID 와 PW 가 동시에 일치 하지 않을 경우 >
                //// SQLAdapter : C# 에서 받아온 명령 을 데이터베이스 에게 실행 지시. 
                ////              실행된 결과를 받아와서 C# 으로 전달하는 역할. 

                //// 데이터 베이스 가 수행 할 SQL 구문 
                //string sSQlCheckLogFlag = $"SELECT * FROM TB_User WHERE USERID = '{sUserId}' AND PW = '{sPassword}'";

                //SqlDataAdapter Adapter = new SqlDataAdapter(sSQlCheckLogFlag, sCon);

                //// 데이터 베이스에서 결과를 받아올 자료형 그릇 준비
                //DataTable dtTemp = new DataTable();
                //Adapter.Fill(dtTemp);


                //// ID 와 PW 가 일치 하지 않을 경우 . 로그인 실패 메세지 및 로그인 리턴.
                //if (dtTemp.Rows.Count == 0)
                //{
                //    txtPassWord.Text = "";
                //    txtPassWord.Focus();
                //    MessageBox.Show("ID 와 PW 를 정확하게 입력 하세요.");
                //    return;
                //}

                //// 로그인 한 사용자의 이름을 받아와서 표현.
                //string sUserName = dtTemp.Rows[0]["USERNAME"].ToString();

                //MessageBox.Show($"{sUserName} 님 반갑습니다.");

                #endregion

                #region < 2. 실습 ID 를 잘못 입력하였는지 , PW 를 잘못 입력 하였는지 확인후 메세지 표현 >
                ////// 1. sql 문 작성  (string 변수에 입력)
                //string sSQl = $"SELECT * FROM TB_USER WHERE USERID = '{sUserId}'";

                ////// 2. 데이터 베이스에 조회 결과 받아오기 (SqlAdapter)
                //SqlDataAdapter Adapter = new SqlDataAdapter(sSQl, sCon);

                //DataTable dtTemp = new DataTable();
                //Adapter.Fill(dtTemp);


                //// 3. 결과에 따라 ID 를 잘못 입력하였는지 판단 (if)
                //if (dtTemp.Rows.Count == 0)
                //{
                //    txtUserId.Text = "";
                //    txtUserId.Focus();
                //    // ID 가 존재하지 않는 경우
                //    MessageBox.Show("존재하지 않는 ID 입니다.");
                //    return;
                //}
                //else if (sPassword != dtTemp.Rows[0]["PW"].ToString())
                //{
                //    icnt++;
                //    if (icnt == 3)
                //    {
                //        MessageBox.Show("비밀번호를 3회 잘못 입력하였습니다.");
                //        this.Close();
                //    }
                //    txtPassWord.Text = "";
                //    txtPassWord.Focus();
                //    // 비밀 번호 가 일치하지 않는 경우.
                //    MessageBox.Show("비밀 번호 가 일치 하지 않습니다.");
                //    return;
                //}

                //// ID 와 PW 가 일치하는경우
                //// LOGIN 로직 

                //string sUserName = dtTemp.Rows[0]["USERNAME"].ToString();
                //MessageBox.Show($"{sUserName} 님 반갑습니다.");
                #endregion

                #region < 3. 실습 PW 3번 잘못입력하였을 경우 프로그램 종료 >

                //// 프로그램 실행 -> ID 별 비밀번호 입력 -> 비밀번호 일치 하지 않을경우 (3)
                //// 프로그램 종료 this.close()



                #endregion

                #region < 4. 비밀번호 잘못 입력 하였을 경우를 Database 에서 체크 3회 오류 시 프로그램 종료 >





                #endregion

                #region < 5. 강사 의 소스 4번내역 코딩 > 

                // 1. ID 와 PW 받아오기 sql 문 작성 
                string sSql = $" SELECT USERID,USERNAME, PW, ISNULL(LOGIN_FCNT,0) AS LOGIN_FCNT FROM TB_USER WHERE USERID = '{sUserId}'";
                SqlDataAdapter adapter = new SqlDataAdapter(sSql, sCon); // sql 실행하고 결과 받아올 녀석
                DataTable dtTemp = new DataTable(); // 데이터담을 그릇
                adapter.Fill(dtTemp); // adapter 실행 및 결과 datatable 에 담기.

                if (dtTemp.Rows.Count == 0)
                {
                    MessageBox.Show("일치하는 ID 가 없습니다.");
                    return;
                }
                // 2. 3회 오류 등록 된 ID 인가 ? 
                else if (Convert.ToInt32(dtTemp.Rows[0]["LOGIN_FCNT"]) == 3)
                {
                    MessageBox.Show("3회 비밀번호를 틀린 ID 입니다. 관리자와 문의하세요.");
                    return;
                }
                // 3. 비밀번호가 맞는지 체크 
                else if (sPassword != dtTemp.Rows[0]["PW"].ToString())
                {
                    // 4. PW 가 일치하지 않을경우. 오류카운트 1 증가. 
                    string sUpdate = $" UPDATE TB_USER SET LOGIN_FCNT = ISNULL(LOGIN_FCNT,0) +  1  WHERE USERID = '{sUserId}'";

                    SqlTransaction tran = sCon.BeginTransaction(); // 트랜잭션 선언 
                    SqlCommand com = new SqlCommand();             // 실행할 객체 선언. 

                    // 지금 현재까지 실패한 로그인 횟수.
                    int iLofingFalilCnt = Convert.ToInt32(dtTemp.Rows[0]["LOGIN_FCNT"]) + 1;

                    try
                    {
                        com.Connection = sCon;     // db 주소 등록
                        com.Transaction = tran;    // 트랜잭션 등록
                        com.CommandText = sUpdate; // SQL 등록

                        com.ExecuteNonQuery();     // 실행.

                        tran.Commit(); // 완료.

                        MessageBox.Show($" PW 가 일치 하지 않습니다. 남은 횟수 : {3 - iLofingFalilCnt}");
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        MessageBox.Show(ex.Message);
                        return;
                    } 
                     
                    if (iLofingFalilCnt == 3)
                    {
                        MessageBox.Show("3회 비밀번호를 잘못입력하여 프로그램을 종료 합니다.");
                        this.Close();
                    } 
                }
                string sUserName = dtTemp.Rows[0]["USERNAME"].ToString();
                Commons.UserId = sUserId;
                MessageBox.Show($"{sUserName} 님 반갑습니다.");

                this.Tag = true;
                //Commons.bLoginSF = true;
                this.Close();
                #endregion
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sCon.Close();
            }


        }

        private void btnPassWordChg_Click(object sender, EventArgs e)
        {
            // 비밀번호 변경 버튼 클릭 

            // 1. 비밀번호 변경 클래스 선언. 
            PasswordChange PwCh = new PasswordChange();


            this.Visible = false;// 로그인 창 숨김


            // 2. 비밀번호 변경 클래스 나타내기.
            PwCh.ShowDialog();

            this.Visible = true;// 로그인 창 나타내기

        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnLogIn_Click();
            }
        }

        private void btnUserReg_Click(object sender, EventArgs e)
        {
            // 회원 가입 버튼 클릭.

            this.Visible = false;

            UserRegist UR = new UserRegist();
            UR.ShowDialog();

            this.Visible = true;
        }
    }
}
