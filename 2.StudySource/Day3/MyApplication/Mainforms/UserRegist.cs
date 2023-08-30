using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mainforms
{
    public partial class UserRegist : Form
    {
        public UserRegist()
        {
            InitializeComponent();
        }

        private void btnUserReg_Click(object sender, EventArgs e)
        {
            string sUserId = txtUserId.Text;
            string sUserName = txtUserName.Text;
            string sPassword = txtUserPw.Text;
            string sEmail = txtEmail.Text;
            string sAddress = txtAddress.Text;

            string sMessage = string.Empty;
            if (sUserId == "") sMessage = "ID ";
            if (sUserName == "") sMessage += "이름 ";
            if (sPassword == "") sMessage += "비밀번호";
            
            if(sMessage != "")
            {
                MessageBox.Show(sMessage + "을(를) 입력하지 않았습니다.");
                return;
            }

            // 2. 중복 된 ID 를 입력 하였는지 확인

            // 접속 주소

            SqlConnection Con = new SqlConnection(Commons.strCon);
            Con.Open();

            // DB에 등록된 사용자 정보를 조회 하는 sql
            string sSql = $"SELECT * FROM TB_User WHERE USERID = '{sUserId}'";

            //SQL Adapter 호출
            SqlDataAdapter Adapter = new SqlDataAdapter(sSql, Con);

            // Adapter 실행.
            DataTable dtTemp = new DataTable();
            Adapter.Fill(dtTemp);

            if(dtTemp.Rows.Count != 0)
            {
                MessageBox.Show("중복된 ID가 존재 합니다.");
                Con.Close();
                return;
            }

            // 데이터 베이스에 신규 사용자를 등록하는 로직

            // Command 객체 선언
            SqlCommand com = new SqlCommand();

            // 데이터 베이스 트랜잭션 선언
            SqlTransaction tran = Con.BeginTransaction();

            try
            {
                // Command 실행할 SQL문을 스트링으로 만들자
                string sInsert = "INSERT INTO TB_USER (USERID,       USERNAME,        PW,        EMAIL,    C_ADDRESS) +" +
                                 $"             VALUES('{sUserId}','{sUserName}','{sPassword}','{sEmail}','{sAddress}')";

                com.CommandText = sInsert;
                com.Transaction = tran;
                com.Connection  = Con;

                //등록 실행
                com.ExecuteNonQuery();
                tran.Commit();
                MessageBox.Show("환영합시다. 회원가입을 완료 하였습니다.");
            }
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message);
            }
            
            finally
            {
                Con.Close();
            }

        }
    }
}
