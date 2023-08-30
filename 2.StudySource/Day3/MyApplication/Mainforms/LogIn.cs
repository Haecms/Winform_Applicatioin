using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mainforms
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }
        public int count = 0;
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string sUserId = txtUserName.Text;
            string sUserPW = txtPassWord.Text;

            string sMessage = "";

            // 아이디나 비밀번호를 입력하지 않은 경우

            if (sUserId == "") sMessage = "아이디 ";
            if (sUserPW == "") sMessage += "비밀번호";

            if (sMessage != "")
            {
                MessageBox.Show($"{sMessage}를 다시 입력해주세요");
                return;
            }
            string strCon = "Server = localhost ; Uid = sa ; Pwd = 1234 ; database = AppDev";
            SqlConnection sCon = new SqlConnection(strCon);

            #region<아이디나 비밀번호 둘 중 하나가 틀리면 알려줌>
            //try
            //{
            //    sCon.Open();
            //    string sSql = $" SELECT * FROM TB_User  WHERE USERID = '{sUserId}'";
            //    SqlDataAdapter sAdapter = new SqlDataAdapter(sSql,sCon);
            //    DataTable dtTemp = new DataTable();
            //    sAdapter.Fill(dtTemp);

            //    if(dtTemp.Rows.Count == 0)
            //    {
            //        MessageBox.Show("존재하지 않는 아이디입니다.");
            //        return;
            //    }
            //    else if(sUserPW != dtTemp.Rows[0]["PW"].ToString())
            //    {
            //        count++;
            //        if(count == 3)
            //        {
            //            MessageBox.Show("비밀번호가 3회 일치하지 않아 종료합니다.");
            //        }
            //        MessageBox.Show($"비밀번호가 {count}회 일치하지 않습니다.");
            //        return;
            //    }
            //    string sUserNAme = dtTemp.Rows[0]["USERNAME"].ToString();
            //    MessageBox.Show($"{sUserNAme}님 반갑습니다.");
            //}
            //catch(Exception ex)
            //{

            //}
            //finally
            //{
            //    sCon.Close();
            //}
            #endregion

            #region< 4. 실습 비밀번호 잘못 입력 하였을 경우를 Database에서 체크 3회 오류 시 프로그램 종료>
            string sSQL = $"SELECT USERID,USERNAME,PW,ISNULL(T_COUNT,0) AS T_COUNT  FROM TB_User WHERE USERID = '{sUserId}'";
            SqlDataAdapter sAdpater = new SqlDataAdapter(sSQL, sCon);
            DataTable dtTemp = new DataTable();
            sAdpater.Fill(dtTemp);

            if (dtTemp.Rows.Count == 0)
            {
                txtUserName.Text = "";
                txtUserName.Focus();
                MessageBox.Show("존재하지 않는 ID입니다.");
                return;
            }
            else if (Convert.ToInt32(dtTemp.Rows[0]["T_COUNT"] == null ? 0: dtTemp.Rows[0]["T_COUNT"]) == 3)
            {
                MessageBox.Show("3회 비밀번호를 틀린 ID입니다. 관리자와 문의하세요");
                return;
            }
            else if(sUserPW != dtTemp.Rows[0]["PW"].ToString()) //toString 써야하나?
            {
                string sUpdate = $"UPDATE TB_User SET T_COUNT = ISNULL(T_COUNT,0) + 1 WHERE USERID != '{sUserId}'";

                SqlTransaction tran = sCon.BeginTransaction();  // 트랜잭션의 의미 알기
                SqlCommand com = new SqlCommand();

                int Login_Fail_Count = Convert.ToInt32(dtTemp.Rows[0]["T_COUNT"]) + 1;

                try
                {
                    com.Connection = sCon;
                    com.Transaction = tran;
                    com.CommandText = sUpdate;

                    com.ExecuteNonQuery();

                    tran.Commit();

                    MessageBox.Show($"PW가 일치하지 않습니다. 남은 횟수 {3 - Login_Fail_Count}");
                }
                catch(Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show(ex.Message);
                    return;
                }
                if(Login_Fail_Count == 3)
                {
                    MessageBox.Show("3회 비밀번호를 잘못입력하여 프로그램을 종료 합니다.");
                    this.Close();
                }
            }
            #endregion
        }

        private void btnPWChange_Click(object sender, EventArgs e)
        {
            PasswordChange pwChange = new PasswordChange();
            this.Visible = false;
            pwChange.ShowDialog();
            this.Visible = true;
        }

        private void txtPassWord_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogIn_Click(null, null);
            }
        }

        private void btnUserReg_Click(object sender, EventArgs e)
        {
            // 회원 가입 버튼 클릭
            this.Visible = false;
            UserRegist UR = new UserRegist();
            UR.ShowDialog();
            this.Visible = true;
        }
    }
}
