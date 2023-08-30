using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FormList
{
    public partial class UserMaster : Form
    {
        SqlConnection sCon = new SqlConnection(Commons.strCon);
        SqlDataAdapter Adapter;
        SqlTransaction sTran;
        SqlCommand Com = new SqlCommand();
        public UserMaster()
        {
            InitializeComponent();
        }
        private void Open()
        {
            if (sCon.State != ConnectionState.Open) sCon.Open(); 
        }
        private void Close()
        {
            if (sCon.State == ConnectionState.Open) sCon.Close();
        }

        private void UserMaster_Load(object sender, EventArgs e)
        {
            DataTable dtGrid = new DataTable();
            dtGrid.Columns.Add("USERID",   typeof(String));
            dtGrid.Columns.Add("USERNAME", typeof(String));
            dtGrid.Columns.Add("PW",       typeof(String));
            dtGrid.Columns.Add("PW_F_CNT", typeof(String));
            dtGrid.Columns.Add("DEPTCODE", typeof(String));
            dtGrid.Columns.Add("MAKEDATE", typeof(String));
            dtGrid.Columns.Add("MAKER",    typeof(String));
            dtGrid.Columns.Add("EDITDATE", typeof(String));
            dtGrid.Columns.Add("EDITOR",   typeof(String));

            dgtGRid.DataSource = dtGrid;

            dgtGRid.Columns["USERID"].HeaderText = "사용자ID";
            dgtGRid.Columns["USERNAME"].HeaderText = "사용자명";
            dgtGRid.Columns["PW"].HeaderText = "비밀번호";
            dgtGRid.Columns["PW_F_CNT"].HeaderText = "실패횟수";
            dgtGRid.Columns["DEPTCODE"].HeaderText = "부서";
            dgtGRid.Columns["MAKEDATE"].HeaderText = "등록일시";
            dgtGRid.Columns["MAKER"].HeaderText = "등록자";
            dgtGRid.Columns["EDITDATE"].HeaderText = "수정일시";
            dgtGRid.Columns["EDITOR"].HeaderText = "수정자";

            dgtGRid.Columns["MAKEDATE"].ReadOnly = true;
            dgtGRid.Columns["MAKER"].ReadOnly = true;
            dgtGRid.Columns["EDITDATE"].ReadOnly = true;
            dgtGRid.Columns["EDITOR"].ReadOnly = true;

            try
            {
                Open();
                string sSqulSelect = "";

                sSqulSelect += " SELECT ''                               AS MAJORCODE,    ";
                sSqulSelect += "        '전체부서'                       AS CODENAME      ";
                sSqulSelect += " UNION                                                    ";
                sSqulSelect += " SELECT MINORCODE                        AS MAJORCODE,    ";
                sSqulSelect += "        '[' + MINORCODE + ']' + CODENAME AS CODENAME      ";
                sSqulSelect += "   FROM TB_Standard                                       ";
                sSqulSelect += "  WHERE MAJORCODE = 'DEPTCODE'                            ";
                sSqulSelect += "    AND MINORCODE <> '$'                                  ";

                Adapter = new SqlDataAdapter(sSqulSelect, sCon);
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                cbboxDepart.DataSource = dtTemp;
                cbboxDepart.ValueMember = "MAJORCODE";
                cbboxDepart.DisplayMember = "CODENAME";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());         //return 왜 안들어가죠????????????????
            }
            finally
            {
                Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Open();
                string sUserId = tboxUser.Text;
                string sUserName = tboxUserName.Text;
                string sDepartment = Convert.ToString(cbboxDepart.SelectedValue);

                string sSqlSelect = "";
                sSqlSelect += "SELECT USERID               AS USERID,  ";
                sSqlSelect += "       USERNAME             AS USERNAME,";
                sSqlSelect += "       PW                   AS PW,      ";
                sSqlSelect += "       T_COUNT              AS PW_F_CNT,";
                sSqlSelect += "       DEPTCODE             AS DEPTCODE,";
                sSqlSelect += "       MAKEDATE             AS MAKEDATE,";
                sSqlSelect += "       MAKER                AS MAKER,   ";
                sSqlSelect += "       EDITDATE             AS EDITDATE,";
                sSqlSelect += "       EDITOR               AS EDITOR   ";
                sSqlSelect += "  FROM TB_USER               ";
                sSqlSelect += $" WHERE USERID LIKE '%{sUserId}%'      ";
                sSqlSelect += $"   AND USERNAME LIKE '%{sUserName}%'    ";
                sSqlSelect += $"   AND ISNULL(DEPTCODE,'') LIKE '%{sDepartment}'    ";

                Adapter = new SqlDataAdapter(sSqlSelect, sCon);
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                if(dtTemp.Rows.Count == 0)
                {
                    ((DataTable)dgtGRid.DataSource).Rows.Clear();
                    MessageBox.Show("조회 조건에 맞는 데이터가 없습니다.");
                    return;
                }
                dgtGRid.DataSource = dtTemp;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Close();
            }
        }

        private void btnGridAdd_Click(object sender, EventArgs e)
        {
            DataRow dr = ((DataTable)dgtGRid.DataSource).NewRow();
            ((DataTable)dgtGRid.DataSource).Rows.Add(dr);
        }

        private void btnGridDelete_Click(object sender, EventArgs e)
        {
            // 로그인 이벤트가 발생한 시점에서 아이디 값을 저장해야함
            if (dgtGRid.Rows.Count == 0) return;
            if (dgtGRid.CurrentRow.Cells["USERID"].Value.ToString() == "") return;

            if (MessageBox.Show("해당 내역을 삭제하시겠습니까?", "데이터 삭제", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                string sUserId = dgtGRid.CurrentRow.Cells["USERID"].Value.ToString();
                string sCommand = $"DELETE TB_USER WHERE USERID = '{sUserId}'";
                ExecuteNonQuery(sCommand);

                MessageBox.Show("데이터가 정상적으로 삭제되었습니다.");
                btnSearch_Click(null, null);


            }
            catch (Exception ex)
            {
                sTran.Rollback();   
                MessageBox.Show(ex.ToString());
                return;
            }
            finally
            {
                Close();
            }
        }
        /// <summary>
        /// 실행에 도움 되는 거
        /// </summary>
        /// <param name="sSqlString"></param>
        private void ExecuteNonQuery(string sSqlString)
        {
            if (sCon.State == ConnectionState.Closed) sCon.Open();
            sTran = sCon.BeginTransaction();
            

            Com.Transaction = sTran;
            Com.Connection = sCon;
            Com.CommandText = sSqlString;

            Com.ExecuteNonQuery();

            sTran.Commit();
            
        }

        private void btnGridSave_Click(object sender, EventArgs e)
        {
            if (dgtGRid.Rows.Count == 0) return;

            string sUserId        = Convert.ToString(dgtGRid.CurrentRow.Cells["USERID"].Value);
            string sUserName      = Convert.ToString(dgtGRid.CurrentRow.Cells["USERNAME"].Value);
            string sUserPw        = Convert.ToString(dgtGRid.CurrentRow.Cells["PW"].Value);
            string sUserFailCount = Convert.ToString(dgtGRid.CurrentRow.Cells["PW_F_CNT"].Value);
            string sUserDept      = Convert.ToString(dgtGRid.CurrentRow.Cells["DEPTCODE"].Value);

            string sWarning = "";


            if (sUserId == "") sWarning = "사용자 ID ";
            if (sUserName == "") sWarning += "사용자명 ";
            if (sUserPw == "") sWarning += "비밀번호 ";
            
            if(sWarning.Length != 0)
            {
                MessageBox.Show($"{sWarning}을(를) 입력해주십시오.");
                return;
            }

            if (MessageBox.Show("데이터를 저장 하시겠습니까?", "데이터 갱신", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            try
            {
                string sSelect = $"SELECT * FROM TB_USER WHERE USERID = '{sUserId}'";
                Adapter = new SqlDataAdapter(sSelect, sCon);
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                if(dtTemp.Rows.Count == 0)  // 추가
                {
                    string sInsert = "";
                    sInsert += $"INSERT INTO TB_USER (USERID,      USERNAME,      PW,          DEPTCODE,      MAKEDATE,    MAKER)";

                    sInsert += $"             VALUES('{sUserId}', '{sUserName}', '{sUserPw}', '{sUserDept}',   GETDATE(), '{Commons.UserId}')";

                    ExecuteNonQuery(sInsert);
                }
                else                        // 갱신, 업데이트
                {
                    if (Convert.ToString(dtTemp.Rows[0]["USERID"]) == sUserId)
                    {
                        MessageBox.Show("기존에 존재하는 아이디입니다.");
                        return;
                    }
                    string sUpdate = "";
                    sUpdate += $"UPDATE TB_USER                       ";
                    sUpdate += $"   SET USERNAME = '{sUserName}',     ";
                    sUpdate += $"       PW       = '{sUserPw}',       ";
                    sUpdate += $"       T_COUNT  = '{sUserFailCount}' ";
                    sUpdate += $"       DEPTCODE = '{sUserDept}',     ";
                    sUpdate += $"       EDITDATE = GETDATE(),         ";
                    sUpdate += $"       EDITOR   = '{Commons.UserId}' ";
                    sUpdate += $" WHERE USERID   = '{sUserId}'        ";

                    ExecuteNonQuery(sUpdate);
                }
                btnSearch_Click(null, null);
                MessageBox.Show("정상적으로 등록을 완료 하였습니다.");
            }
            catch(Exception ex)
            {
                sTran.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Close();
            }

        }

        private void btnImageCall_Click(object sender, EventArgs e)
        {
            if (dgtGRid.Rows.Count == 0) return;

            string sFilePath = string.Empty;

            OpenFileDialog Dialog = new OpenFileDialog();
            if (Dialog.ShowDialog() != DialogResult.OK) return;

            sFilePath = Dialog.FileName;
            pboxPicture.Tag = sFilePath;
            pboxPicture.Image = Bitmap.FromFile(sFilePath);
        }

        private void btnImageSave_Click(object sender, EventArgs e)
        {
            if (dgtGRid.Rows.Count == 0) return;
            if (pboxPicture.Image == null) return;
            if (Convert.ToString(pboxPicture.Tag) == "") return;

            if (MessageBox.Show("선택한 이미지를 사용자이미지로 등록하시겠습니까?", "이미지 등록", MessageBoxButtons.YesNo)
                == DialogResult.No) return;
            try
            {
                FileStream fStream = new FileStream(Convert.ToString(pboxPicture.Tag), FileMode.Open, FileAccess.Read);

                BinaryReader bReader = new BinaryReader(fStream);

                Byte[] bImage = bReader.ReadBytes(Convert.ToInt32(fStream.Length));

                bReader.Close();
                fStream.Close();

                string sUser = Convert.ToString(dgtGRid.CurrentRow.Cells["USERID"].Value);
                string sUpdate = "";
                sUpdate += "UPDATE TB_USER                  ";
                sUpdate +=  "   SET USERIMAGE = @USERIMAGE  ";
                sUpdate += $" WHERE USERID = '{sUser}'      ";

                Open();
                sTran = sCon.BeginTransaction();

                Com.Parameters.Clear();
                Com.CommandText = sUpdate;
                Com.Parameters.Add("@USERIMAGE", bImage);
                Com.Transaction = sTran;
                Com.Connection = sCon;

                Com.ExecuteNonQuery();

                sTran.Commit();
                MessageBox.Show("정상적으로 등록이 완료되었습니다.");
            }
            catch (Exception ex)
            {
                sTran.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Close();
            }

        }

        private void dgtGRid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sUser = Convert.ToString(dgtGRid.CurrentRow.Cells["USERID"].Value);

            try
            {
                Open();

                string sImage = $"SELECT USERIMAGE FROM TB_USER WHERE USERID = '{sUser}'";
                Adapter = new SqlDataAdapter(sImage, sCon);
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);

                if (dtTemp.Rows.Count == 0)
                {
                    pboxPicture.Image = null;
                    return;
                }
                if (Convert.ToString(dtTemp.Rows[0]["USERIMAGE"]) == "")
                {
                    pboxPicture.Image = null;
                    return;
                }
                Byte[] bImages = (byte[])dtTemp.Rows[0]["USERIMAGE"];

                if (bImages == null)
                {
                    MessageBox.Show("이미지 형식으로 변형할 수 없는 데이터가 등록되어있습니다.");
                    return;
                }
                pboxPicture.Image = new Bitmap(new MemoryStream(bImages));

                string sUserId = $"SELECT USERID FROM TB_USER WHERE USERID = '{sUser}'";
                SqlDataAdapter Adapter1 = new SqlDataAdapter(sUserId, sCon);
                DataTable tTemp = new DataTable();
                Adapter1.Fill(tTemp);

                if(tTemp.Rows.Count == 0)
                {
                    dgtGRid.CurrentRow.Cells["USERID"].ReadOnly = false;
                }
                dgtGRid.CurrentRow.Cells["USERID"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Close();
            }
        }
        private void btnImageDelete_Click(object sender, EventArgs e)
        {
            if (dgtGRid.Rows.Count == 0) return;

            if (MessageBox.Show("선택한 품목의 이미지를 삭제 하시겠습니까?", "이미지 삭제", MessageBoxButtons.YesNo)
                == DialogResult.No) return;
            try
            {
                string sUser = Convert.ToString(dgtGRid.CurrentRow.Cells["USERID"].Value);
                string sDelete = $"UPDATE TB_USER SET USERIMAGE = NULL WHERE USERID = '{sUser}'";
                ExecuteNonQuery(sDelete);
                pboxPicture.Image = null;
                MessageBox.Show("정상적으로 삭제되었습니다.");
            }
            catch(Exception ex)
            {
                sTran.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                Close();
            }
        }
    }
}
