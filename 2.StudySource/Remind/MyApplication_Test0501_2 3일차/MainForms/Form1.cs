using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCorrect_Click(object sender, EventArgs e)
        {
            string sUserID = txtId.Text;

            SqlConnection sCon = new SqlConnection(Commons.strCon);
            try
            {
                sCon.Open();
                string sSql = $" SELECT USERID FROM TB_USER WHERE USERID = '{sUserID}'";
                SqlDataAdapter adapter = new SqlDataAdapter(sSql, sCon); 
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                if(dtTemp.Rows.Count != 0 || txtId.Text == "")
                {
                    txtId.Text = "";
                    MessageBox.Show("사용불가능한 아이디 입니다..");
                    return;
                }
                MessageBox.Show("사용 가능한 아이디 입니다.");
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sCon.Close();
            }
        }
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            string sUserID = txtId.Text;
            string sUserPW = txtPW.Text;
            string sName = txtName.Text;
            string sEmail = txtEmail.Text;
            string sAddress = txtAddress.Text;
            string sInsert = $"INSERT INTO  TB_USER (USERID, USERNAME, PW, EMAIL, C_ADDRESS)  VALUES ('{sUserID}', '{sName}', '{sUserPW}', '{sEmail}', '{sAddress}')";
            SqlConnection sCon = new SqlConnection(Commons.strCon);

            try
            {
                sCon.Open();
                SqlTransaction tran = sCon.BeginTransaction();
                SqlCommand com = new SqlCommand();
                {

                }
                if(sUserID != "" && sUserPW != "" && sName  != "" && sEmail != "" && sAddress != "")
                {
                    com.Connection = sCon;     
                    com.Transaction = tran;    
                    com.CommandText = sInsert; 

                    com.ExecuteNonQuery();     

                    tran.Commit();
                    MessageBox.Show("정상적으로 회원가입이 완료되었습니다.");
                }
                else
                {
                    MessageBox.Show("빈 공간이 없는지 다시 확인해 주세요");
                    return;
                }

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                sCon.Close();
            }
        }


    }
}
