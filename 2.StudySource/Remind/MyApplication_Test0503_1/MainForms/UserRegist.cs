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

namespace MainForms
{
    public partial class UserRegist : Form
    {
        public UserRegist()
        {
            InitializeComponent();
        }

        private void btnUserReg_Click(object sender, EventArgs e)
        {
            // 회원 가입 버튼 클릭

            // 1. 필수 입력값 
            string sUserId   = txtUserId.Text;   // 사용자 ID
            string sUserName = txtUserName.Text; // 사용자 명
            string sPassword = txtPw.Text;       // 비밀번호
            string sEMail    = txtEMail.Text;    // 메일
            string sAddress  = txtAddress.Text;  // 주소

            // 입력 을 하였는지 확인할 Messge string
            string sMessage = string.Empty;
            if (sUserId == "") sMessage   += "ID ";
            if (sUserName == "") sMessage += "이름 ";
            if (sPassword == "") sMessage += "비밀번호 ";

            if (sMessage != "")
            {
                MessageBox.Show(sMessage + "을(를) 입력하지 않았습니다.");
                return;
            }

            // 2. 중복 된 ID 를 입력 하였는지 확인

            // 접속 주소
            SqlConnection Con = new SqlConnection(Commons.strCon);
            Con.Open();

            // DB 에 등록된 사용자 정보 를 조회 하는 sql
            string sSql = $"SELECT * FROM TB_USER WHERE USERID = '{sUserId}'";

            // SQL Adaper 호출
            SqlDataAdapter Adapter = new SqlDataAdapter(sSql, Con);

            // Adapter 실행.
            DataTable dtTemp = new DataTable();
            Adapter.Fill(dtTemp);

            if (dtTemp.Rows.Count != 0)
            {
                MessageBox.Show("중복된 ID 가 존재 합니다.");
                Con.Close();
                return;
            }

            // 데이터 베이스에 신규 사용자 를 등록 로직.

            // Command 객체 선언
            SqlCommand Com = new SqlCommand();

            // Database 트랜잭션 선언.
            SqlTransaction tran = Con.BeginTransaction();

            try
            {
                // Command 실행할 SQL 문
                string sInsert = "INSERT INTO TB_USER (USERID,     USERNAME,      PW,           EMAIL,        C_ADDRESS)" +
                                 $"             VALUES('{sUserId}','{sUserName}','{sPassword}', '{sEMail}',  '{sAddress}')";

                Com.CommandText = sInsert;
                Com.Transaction = tran;
                Com.Connection = Con;

                // 등록 실행.
                Com.ExecuteNonQuery();
                tran.Commit(); // 완료

                MessageBox.Show("환영합니다. 회원가입을 완료 하였습니다.", "회원가입");
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
