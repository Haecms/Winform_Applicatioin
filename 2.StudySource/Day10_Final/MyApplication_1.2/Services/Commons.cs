using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

/* namespace 
 *   = (클래스 라이브러리, 어셈블리, DLL , API, 프로젝트)
 *  하나 이상의 앱 에서 호출되는 형식 및 메서드 등을 정의하여 dll 형식으로 제공
 *  단독으로는 실행 되지 않는다. 
 *  
 *  1. 배포및 재사용성이 용이
 *  2. dll 파일 내부의 소스 만 변경 및 배포가 가능 하므로 유지보수 가 용이
 *  2. dll 내부의 소스 는 외부 환경에서 확인 할 수 없으므로 보안성이 향상.
 */

namespace Services
{

    // Services , Common 
    // Services : 실제 프로그램이 실행되는 로직에는 관여하지 않고 
    //            도움을 주는 역활 의 로직들이 있는 모듈 (Biz)
    // Common   : 서비스 로직 이 포함되어 있는 클래스.

    public class Commons
    {
        public const string strCon = "Server = localhost ; Uid = sa ; Pwd = 1234 ; database = AppDev";
        
        //로그인 성공 여부
        public static bool bLoginSF = false;

        // 시스템 사용자 ID
        public static string UserId = "";

        static public void GetCombo_Standard(string sMajorCode, ComboBox TempCombo)
        {
            SqlConnection sCon = new SqlConnection(Commons.strCon);
            try
            {
                if (sCon.State != ConnectionState.Open) sCon.Open();
                string sSqulSelect = "";

                sSqulSelect += " SELECT ''                               AS MAJORCODE,  ";
                sSqulSelect += "        '[ALL]전체'                      AS CODENAME    ";
                sSqulSelect += " UNION                                                  ";
                sSqulSelect += " SELECT MINORCODE                        AS MAJORCODE,  ";
                sSqulSelect += "        '[' + MINORCODE + ']' + CODENAME AS CODENAME    ";
                sSqulSelect += "   FROM TB_Standard                                     ";
                sSqulSelect += $" WHERE MAJORCODE = '{sMajorCode}'                      ";
                sSqulSelect += "    AND MINORCODE <> '$'                                ";

                SqlDataAdapter Adapter = new SqlDataAdapter(sSqulSelect, sCon);
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);
                //콤보박스 데이터 생성
                TempCombo.DataSource    = dtTemp;
                TempCombo.ValueMember   = "MAJORCODE";
                TempCombo.DisplayMember = "CODENAME";

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

        static public DataTable GetCombo_Standard_Grid(string sMajorCode)
        {
            SqlConnection sCon = new SqlConnection(Commons.strCon);
            DataTable dtTemp = new DataTable();
            try
            {   
                if (sCon.State != ConnectionState.Open) sCon.Open();
                string sSqulSelect = "";

                sSqulSelect += " SELECT ''                               AS MAJORCODE,  ";
                sSqulSelect += "        '[ALL]전체'                      AS CODENAME    ";
                sSqulSelect += " UNION                                                  ";
                sSqulSelect += " SELECT MINORCODE                        AS MAJORCODE,  ";
                sSqulSelect += "        '[' + MINORCODE + ']' + CODENAME AS CODENAME    ";
                sSqulSelect += "   FROM TB_Standard                                     ";
                sSqulSelect += $" WHERE MAJORCODE = '{sMajorCode}'                      ";
                sSqulSelect += "    AND MINORCODE <> '$'                                ";

                SqlDataAdapter Adapter = new SqlDataAdapter(sSqulSelect, sCon);
                
                Adapter.Fill(dtTemp);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sCon.Close();
            }
            return dtTemp;
        }
        public static void SetGridComboBox(DataGridView dgv, string sMajorcode, string sColumnID = null, bool AfterSearch = true) // sColumnID에 값이 들어오면 그 값으로
                                                                                                                                  // sColumnID에 값이 안들어오면 null로 
        {
            if (sColumnID == null) sColumnID = sMajorcode;
            // 1. 그리드 콤보박스에 셋팅할 공통기준정보의 sMajorcode 데이터 가져오기
            DataTable dttemp = GetCombo_Standard_Grid(sMajorcode);
            if (dttemp.Rows.Count == 0) return;


            if (AfterSearch)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    // 새로 생성한 콤보박스 유형의 그리드콤보박스 컨트롤을 부서 컬럼에 매핑.
                    dgv.Rows[i].Cells[sColumnID] = _MakeGridComboBox(dttemp);
                }
            }
            else
            {
                // 새로 생성한 콤보박스 유형의 그리드콤보박스 컨트롤을 부서 컬럼에 매핑.
                dgv.Rows[dgv.Rows.Count-1].Cells[sColumnID] = _MakeGridComboBox(dttemp);
            }
        }
        private static DataGridViewComboBoxCell _MakeGridComboBox(DataTable dttemp)    //프라이빗으로 생성되는 메서드나 변수는 언더바(_)를 넣어서 구분시키는게 좋음
        {
            // Combobox 유형의 셀을 생성
            DataGridViewComboBoxCell CellC = new DataGridViewComboBoxCell();
            // 콤보박스 셀의 유형을 콤보박스로 선택
            CellC.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
            // 콤보박스에 데이터 등록
            CellC.DataSource = dttemp;
            CellC.DisplayMember = "CODENAME";
            CellC.ValueMember = "MAJORCODE";
            return CellC;
        }
        static public void GetCombo_ItemCode(string sItemCode, ComboBox TempCombo)
        {
            SqlConnection sCon = new SqlConnection(Commons.strCon);
            try
            {
                if (sCon.State != ConnectionState.Open) sCon.Open();
                string sSqulSelect = "";

                sSqulSelect += " SELECT ''                              AS CODE_ID,   ";
                sSqulSelect += "        '전체부서'                      AS CODE_NAME  ";
                sSqulSelect += " UNION                                                ";
                sSqulSelect += " SELECT ITEMCODE                        AS CODE_ID,   ";
                sSqulSelect += "        '[' + ITEMNAME + ']' + ITEMCODE AS CODE_NAME  ";
                sSqulSelect += "   FROM TB_ItemMaster2                                ";

                SqlDataAdapter Adapter = new SqlDataAdapter(sSqulSelect, sCon);
                DataTable dtTemp = new DataTable();
                Adapter.Fill(dtTemp);
                //콤보박스 데이터 생성
                TempCombo.DataSource = dtTemp;
                TempCombo.ValueMember = "CODE_ID";
                TempCombo.DisplayMember = "CODE_NAME";
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
        public void GetImage(PictureBox pboxPicture)
        {
            string sFilePath = string.Empty;

            OpenFileDialog Dialog = new OpenFileDialog();
            if (Dialog.ShowDialog() != DialogResult.OK) return;

            sFilePath = Dialog.FileName;
            pboxPicture.Tag   = sFilePath;
            pboxPicture.Image = Bitmap.FromFile(sFilePath);
        }
    }
}
