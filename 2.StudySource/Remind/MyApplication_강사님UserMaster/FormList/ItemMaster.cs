using MainForms;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/************************************************************
 * NAME   : ItemMaster.cs
 * DESC   : 품목 관리 
 * DATE   : 2023-05-02
 * AUTHOR : 동상현
 * DESC   : 최초 프로그램 작성
 * 
 * 
 * DATE   : 
 * EDITOR : 
 * DESC   : 
 * 
 * *********************************************************/
namespace FormList
{
    // 기준정보
    // 시스템에서 관리되는 주요 항목들을 관리하는 데이터, 시스템이 관리 해야하는 대상. 
    // 품목, 작업자, 사용자, 거래처, 공정, 작업장.......
    
    public partial class ItemMaster : Form
    {
        #region < 필드 멤버 변수 > 

        // 1. 데이터베이스 공통 변수
        // 데이터 베이스 접속 주소 
        SqlConnection sCon = new SqlConnection(Commons.strCon);

        // 2. 조회용 데이터베이스 객체 변수
        //  조회 를 위한 SQL 객체
        SqlDataAdapter adapter;

        // 3. 데이터베이스의 갱신을 위한 변수
        // 그리드 셋팅을 위한 DataTable
        DataTable dtGrid = new DataTable();

        // ExcuteNonQuery를 실행 할 커맨드(명령) 객체
        SqlCommand Command = new SqlCommand();

        // 트랜잭션입니다.
        SqlTransaction sTran;

        #endregion

        public ItemMaster()
        {
            InitializeComponent();
        }

        private void ItemMaster_Load(object sender, EventArgs e)
        {
           
            // 화면이 오픈 될때 기본 셋팅. 

            // 1. 그리드 셋팅. 

            
            dtGrid.Columns.Add("ITEMCODE", typeof(String));
            dtGrid.Columns.Add("ITEMNAME", typeof(String));
            dtGrid.Columns.Add("ITEMTYPE", typeof(String));
            dtGrid.Columns.Add("ITEMDESC", typeof(String));
            dtGrid.Columns.Add("ENDFLAG",  typeof(String));
            dtGrid.Columns.Add("PRODDATE", typeof(String));
            dtGrid.Columns.Add("MAKEDATE", typeof(String));
            dtGrid.Columns.Add("MAKER",    typeof(String));
            dtGrid.Columns.Add("EDITDATE", typeof(String));
            dtGrid.Columns.Add("EDITOR",   typeof(String));

            // 빈 컬럼 테이블을 그리드에 매핑.
            dgtGrid.DataSource = dtGrid;

            // 그리드 속성 세팅
            // 헤더의 명칭 선언
            dgtGrid.Columns["ITEMCODE"].HeaderText = "품목코드";
            dgtGrid.Columns["ITEMNAME"].HeaderText = "품목명";
            dgtGrid.Columns["ITEMTYPE"].HeaderText = "품목유형";
            dgtGrid.Columns["ITEMDESC"].HeaderText = "품목상세";
            dgtGrid.Columns["ENDFLAG"].HeaderText  = "단종여부";
            dgtGrid.Columns["PRODDATE"].HeaderText = "출시일자";
            dgtGrid.Columns["MAKEDATE"].HeaderText = "생성일시";
            dgtGrid.Columns["MAKER"].HeaderText    = "생성자";
            dgtGrid.Columns["EDITDATE"].HeaderText = "수정일시";
            dgtGrid.Columns["EDITOR"].HeaderText   = "수정자";

            // 컬럼 의 폭 지정. 
            dgtGrid.Columns["ITEMCODE"].Width = 100; // 품목 코드
            dgtGrid.Columns[1].Width          = 200; // 품명.
            dgtGrid.Columns["MAKEDATE"].Width = 250; // 등록일시
            dgtGrid.Columns["EDITDATE"].Width = 250; // 수정일시

            // 컬럼의 수정 여부 지정. 
            dgtGrid.Columns["MAKEDATE"].ReadOnly = true;
            dgtGrid.Columns["MAKER"].ReadOnly    = true;
            dgtGrid.Columns["EDITDATE"].ReadOnly = true;
            dgtGrid.Columns["EDITOR"].ReadOnly   = true;

            
            // 2. 콤보박스에 데이터 셋팅. 

            try
            {
                // DB 오픈
               sCon.Open();

                // 콤보박스에 세팅 할 데이터를 DB 에서 가져오는 SQL 구문 작성. 
                string sSqlSelect = string.Empty;

                sSqlSelect += " SELECT ''                              AS CODE_ID,      ";
                sSqlSelect += "                                                         ";
                sSqlSelect += "        '전체조회'                      AS CODE_NAME     ";

                sSqlSelect += " UNION                                                   ";

                sSqlSelect += " SELECT MINORCODE                         AS CODE_ID,    ";
                sSqlSelect += "        '[' + MINORCODE + '] ' + CODENAME AS CODE_NAME   "; // '[ROH]원자재' 이런 형식으로 나옵니다.
                sSqlSelect += "   FROM TB_Standard                                      ";
                sSqlSelect += "  WHERE MAJORCODE = 'ITEMTYPE'                           ";
                sSqlSelect += "  AND MINORCODE<> '$'                                    ";

                // 데이터 베이스에 명령을 전달할 객체 선언
                adapter = new SqlDataAdapter(sSqlSelect, sCon);

                // 데이터베이스 실행및 결과 반환
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                // 데이터베이스에서 가져온 콤보박스 셋팅 데이터를 배치(매핑)
                cboItemType.DataSource    = dtTemp;         // 'ItemMaster 디자인의 ComboBox'에 dtTemp데이터가 들어갑니다.
                cboItemType.ValueMember   = "CODE_ID";      //  코드를 말한다.
                cboItemType.DisplayMember = "CODE_NAME";    // 사용자 눈에 보이는건 CODE_ID의 CODE_NAME이 보이도록 합니다.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sCon.Close();
            }
            // 3. 달력 컨트롤에 현재 일자 표시 및 지정 일자 표시
            dtpStart.Text = string.Format("{0:yyyy-MM-01}" , DateTime.Now);
            dtpEnd.Text   = string.Format("{0:yyyy-MM-dd}" , DateTime.Now); // 기본 세팅이 오늘 날짜까지로 됨 / 바꾸기 가능

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // 조회 버튼을 클릭 하였을 때 조회되는 기능.
            try
            {
                if (sCon.State == ConnectionState.Closed) sCon.Open();
                // 조회 조건이 담기는 변수
                string sItemCode  = txtItemCode.Text;    // 품목 코드
                string sItemName  = txtItemName.Text;    // 품목 명(품명)
                string sStartDate = dtpStart.Text;       // 출시 시작 일자
                string sEndDate   = dtpEnd.Text;         // 출시 종료 일자
                string sItemType  = Convert.ToString(cboItemType.SelectedValue);    // 콤보박스 선택 값
                string sStopFlag = "N";
              //string sStopFlag  = string.Empty;        // 단종여부 "Y 또는 N"
                if (rdbDanjong.Checked == true) sStopFlag = "Y";   // Checked 자체가 불 형식이라 true는 넣어도 되고 밑에처럼 안 넣어도 됨     
              //else if (rdbProd.Checked)       sStopFlag = "N";


                if (chkOnlyName.Checked)
                {
                    sItemCode = "";
                }

                // 조회 조건에 맞는 품목 데이터를 검색하는 SQL 구문
                string sSqlSelect = string.Empty;
                sSqlSelect += " SELECT ITEMCODE,                                         ";
                sSqlSelect += "        ITEMNAME,                                         ";
                sSqlSelect += "        ITEMTYPE,                                         ";
                sSqlSelect += "        ITEMDESC,                                         ";
                sSqlSelect += "        ENDFLAG,                                          ";
                sSqlSelect += "        PRODDATE,                                         ";
                sSqlSelect += "        MAKEDATE,                                         ";
                sSqlSelect += "        MAKER,                                            ";
                sSqlSelect += "        EDITDATE,                                         ";
                sSqlSelect += "        EDITOR                                            ";
                sSqlSelect += "   FROM TB_ItemMaster                                     ";
                sSqlSelect += $" WHERE ITEMCODE LIKE '%{sItemCode}%'                     ";
                sSqlSelect += $"   AND ITEMNAME LIKE '%{sItemName}%'                     ";
                sSqlSelect += $"   AND PRODDATE BETWEEN '{sStartDate}' AND '{sEndDate}'  ";
                sSqlSelect += $"   AND ITEMTYPE LIKE '%{sItemType}'                      ";
                sSqlSelect += $"   AND ENDFLAG = '{sStopFlag}'                           ";

                /*  한 글자만 치고 조회를 누를 수도 있기 때문에
                    그 한 글자를 포함하는 값들을 찾을 수 있어야 합니다.
                    그래서 LIKE '%%'를 넣어서 포함하는 값들을 찾을 수 있게 됩니다.

                    예를 들어 ItemCode를 'a'만 입력하고 다른 값들을 모두 입력하였을 경우
                    ItemCode의 조건은 a를 포함한 모든 데이터가 나옵니다.

                    ItemCode를 입력하지 않았을 경우 무엇을 포함해야한다는 조건이 없기에
                    모든 ItemCode가 나오게 됩니다.
                */
               

                // 데이터베이스에 있는 조건에 맞는 품목 데이터 가져오기
                adapter = new SqlDataAdapter(sSqlSelect, sCon);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                if(dtTemp.Rows.Count == 0)
                {
                    // 조회 할 데이터가 없을 경우

                    //dgtGrid.DataSource = dtGrid; // 1. 깡통 데이터 테이블을 매핑하여 클리어

                    // 2. 데이터그리드에 있는 데이터 소스를 데이터테이블로 형변환해서 rows를 클리어해줌
                    //    데이터소스는 데이터 주소만을 가지고 있는거임
                    ((DataTable)dgtGrid.DataSource).Rows.Clear();
                    MessageBox.Show("조회 조건에 맞는 데이터가 존재하지 않습니다.");
                    return;
                }

                // 데이터가 있을 경우
                dgtGrid.DataSource = dtTemp;

                // 조회되는 행의 수를 받읍시다.
                string sMessage = dgtGrid.Rows.Count + "행이 조회되었습니다.";

                //MainForm.pu_MainForm.SetMessage(sMessage);   // 메인폼에 아래 카운트 할 때 필요함
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // 데이터 베이스의 연결 상태가 OPEN일 경우에는 종료하라.
                if (sCon.State == ConnectionState.Open)
                {
                    sCon.Close();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 품목 정보를 추가 하기 위한 그리드 행 신규등록
            // 데이터 소스가 바라보고 있는 컬럼들과 데이터를 가진 새로운 행이 만들어짐
            DataRow dr = ((DataTable)dgtGrid.DataSource).NewRow();
            ((DataTable)dgtGrid.DataSource).Rows.Add(dr);


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 삭제 버튼을 킄릭하였을 때 기능.
            if (dgtGrid.Rows.Count == 0)  return;

            // 삭제 여부 물어보기
            if(MessageBox.Show("해당 내역을 삭제 하시겠습니까?", "데이터삭제", MessageBoxButtons.YesNo) == DialogResult.No)
            { return; }

            // 데이터 삭제 로직 실행

            try
            {
                // 현재 선택한 행의 품목코드를 받아옴
                string sitemcode = dgtGrid.CurrentRow.Cells["ITEMCODE"].Value.ToString();

                // 데이터베이스 open()
                sCon.Open();

                // 트랜잭션 선언
                sTran = sCon.BeginTransaction(); // Database가 Open이 된 상태에서 선언이 가능

                Command.Transaction = sTran; // 트랜잭션 정보를 가지고 실행.
                Command.Connection = sCon;   // Command가 접속할 주소 정보
                Command.CommandText = $"DELETE TB_ItemMaster WHERE ITEMCODE = '{sitemcode}'";    // 삭제를 위한 SQL 명령어 작성.

                Command.ExecuteNonQuery(); // 커맨드가 실행.

                sTran.Commit();
                
                MessageBox.Show(" 데이터가 정상적으로 삭제되었습니다.");
                btnSearch_Click(null, null);
            }
            catch(Exception ex)
            {
                sTran.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                // 데이터베이스 open 상태이면 close();
                if (sCon.State == ConnectionState.Open) sCon.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // 선택된 행의 데이터를 저장 (update / insert)
            if (dgtGrid.Rows.Count == 0) return;

            // 등록 또는 수정될 데이터를 변수에 등록
            string sItemCode = Convert.ToString(dgtGrid.CurrentRow.Cells["ITEMCODE"].Value);
            string sItemName = Convert.ToString(dgtGrid.CurrentRow.Cells["ITEMNAME"].Value);
            string sItemType = Convert.ToString(dgtGrid.CurrentRow.Cells["ITEMTYPE"].Value);
            string sItemDesc = Convert.ToString(dgtGrid.CurrentRow.Cells["ITEMDESC"].Value);
            string sEndFlag  = Convert.ToString(dgtGrid.CurrentRow.Cells["ENDFLAG"].Value);
            string sProdDate = Convert.ToString(dgtGrid.CurrentRow.Cells["PRODDATE"].Value);

            // 단종 여부 값을 등록하지 않았을 경우 디폴트 값으로 등록되도록 설정. ("N")
            // 아무런 값이 없다면 "N" 아니라면 "Y"
            sEndFlag = sEndFlag == "" ? "N" : sEndFlag;  // 삼항 연산자. inline if

            // 출시일자를 입력하지 않았을 경우 디폴트값으로 오늘 일자로 설정.
            sProdDate = sProdDate == "" ? string.Format("{0:yyyy-MM-dd}", DateTime.Now) : sProdDate;

            // 필수 입력 값 체크
            if(sItemCode == "")
            {
                MessageBox.Show("품목 코드를 입력하지 않았습니다.");
                return;
            }

            if (MessageBox.Show("데이터를 저장 하시겠습니까?", "데이터 갱신", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            // 데이터 등록 로직 수행

            // 1. update ? insert ?

            sCon.Open();
            try
            {
                // 1. 데이터 베이스에 등록된 품목 ID인지 체크
                string sSelect = $"SELECT * FROM TB_ItemMaster WHERE ITEMCODE = '{sItemCode}'";
                adapter = new SqlDataAdapter(sSelect, sCon);
                DataTable dttemp = new DataTable();
                adapter.Fill(dttemp);

                // 만약 dttemp행이 존재한다면 sItemCode가 존재한다는 뜻이라서 업데이트를 해야함
                if(dttemp.Rows.Count != 0)
                {
                    // update

                    string sUpdate = "";
                    sUpdate += $" UPDATE TB_ItemMaster          ";
                    sUpdate += $"    SET ITEMNAME = '{sItemName}',     ";
                    sUpdate += $"        ITEMTYPE = '{sItemType}',     ";
                    sUpdate += $"        ITEMDESC = '{sItemDesc}',     ";
                    sUpdate += $"        ENDFLAG  = '{sEndFlag}' ,     ";
                    sUpdate += $"        PRODDATE = '{sProdDate}'      ";
                    sUpdate += $"        EDITDATE =   GETDATE()        ";
                    sUpdate += $"        EDITOR   = '{Commons.UserId}' ";
                    sUpdate += $"  WHERE ITEMCODE = '{sItemCode}'      ";

                    ExcuteNonQuery(sUpdate);

                }
                else
                {
                    // insert

                    string sInsert = "";
                    sInsert += $"INSERT INTO TB_ItemMaster(ITEMCODE,       ITEMNAME,      ITEMTYPE,      ITEMDESC,      ENDFLAG,      PRODDATE,     MAKEDATE,    MAKER)";

                    sInsert += $"                   VALUES('{sItemCode}', '{sItemName}', '{sItemType}', '{sItemDesc}', '{sEndFlag}', '{sItemCode}', GETDATE(),   '{Commons.UserId}'   )";


                    sInsert += $" UPDATE TB_ItemMaster          ";
                    sInsert += $"    SET ITEMNAME = '{sItemName}',   ";
                    sInsert += $"        ITEMTYPE = '{sItemType}',   ";
                    sInsert += $"        ITEMDESC = '{sItemDesc}',";
                    sInsert += $"        ENDFLAG  = '{sEndFlag}' ,    ";
                    sInsert += $"        PRODDATE = '{sProdDate}'    ";
                    sInsert += $"  WHERE ITEMCODE = '{sItemCode}'     ";

                    ExcuteNonQuery(sInsert);
                }

                MessageBox.Show("정상적으로 등록을 완료 하였습니다.");
            }
            catch (Exception ex)
            {
                sTran.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                sCon.Close();
            }
        }



        private void btnPicLoad_Click(object sender, EventArgs e)
        {
            // 파일 탐색기를 통해서 원하는 이미지를 가져와 픽쳐박스에 표현하기.
            if (dgtGrid.Rows.Count == 0) {return;}

            string sFilePath = string.Empty; // 이미지 파일의 경로를 담을 변수.

            // 파일 탐색기 호출
            OpenFileDialog Dialog = new OpenFileDialog();
            if (Dialog.ShowDialog() != DialogResult.OK) { return; }

            // 파일의 경로 받아오기
            sFilePath = Dialog.FileName;                // Dialog.FileName 선택한 파일의 물리적 위치 경로를 포함합니다.
            picItem.Tag = sFilePath;                    //태그에 데이터를 넣어놓음 Tag에 이미지 경로 저장해 두기
            picItem.Image = Bitmap.FromFile(sFilePath); // 이미지 파일을 bitmap으로 변경하여 픽쳐박스의 image에 등록
                                                        // 파일 경로에 찾아가서 비트맵으로 바꿔서 이미지에 넣음
        }

        private void btnPicSave_Click(object sender, EventArgs e)
        {
            // 픽쳐박스에 등록되어 있는 이미지를 데이터베이스에 저장하는 로직
            if (dgtGrid.Rows.Count == 0) { return;}
            if (picItem.Image == null) { return; }
            if (Convert.ToString(picItem.Tag) == "") { return; };

            if (MessageBox.Show("선택한 이미지를 품목이미지로 등록하시겠습니까?", "이미지 등록", MessageBoxButtons.YesNo)
                == DialogResult.No) { return; }

            // 이미지 등록 로직 이제부터 실행
            try
            {
                // 이미지 파일을 파일스트림으로 메모리에 등록 후 Byte[] 배열로 변경하는 로직이 들어갈거임.
                FileStream stream = new FileStream(Convert.ToString(picItem.Tag), // 파일의 위치 정보로
                                                  FileMode.Open,                 // 접근하여
                                                  FileAccess.Read);              // 읽기 전용으로 가져오겠다.

                BinaryReader reader = new BinaryReader(stream);                   // 스트림은 연결 / 바이너리 리더가 스트림 경로로 가서 2진 데이터로 RAM에 가져옴

                Byte[] bImage = reader.ReadBytes(Convert.ToInt32(stream.Length)); // 2진데이터를 Byte 형식으로 RAM에 패킹

                // 데이터를 메모리에 등록 완료 하였으므로  바이너리 리더와 파일스트림 종료
                reader.Close();
                stream.Close();


                //데이터 베이스에 저장 시작. ('bImage'라는 배열 녀석을 저장)

                // 이미지가 등록될 품목의 정보 / 오픈 하기 전 대상이 있어야 하기에
                string sItemCode = Convert.ToString(dgtGrid.CurrentRow.Cells["ITEMCODE"].Value);

                // 이제 데이터 베이스 오픈
                sCon.Open();
                sTran = sCon.BeginTransaction();

                // 데이터베이스에 등록 할 sql 구문을 작성 할 때
                string sUpdate = "UPDATE TB_ITEMMASTER" +
                                 "   SET ITEMIMAGE = @ITEMIMAGE" +      // 특정 파라매터를 받을 수 있는 SQL 구문
                                $" WHERE ITEMCODE  = '{sItemCode}'";

                // 0. 기존 파라메터 삭제하는 로직
                Command.Parameters.Clear();
                // 1. 명령어 전달
                Command.CommandText = sUpdate;
                // 2. 커맨드에 파라매터 연결을 추가
                Command.Parameters.Add("@ITEMIMAGE", bImage);
                // 3. 트랜잭션 연결
                Command.Transaction = sTran;
                // 4. 접속 주소 연결
                Command.Connection = sCon;

                Command.ExecuteNonQuery();

                sTran.Commit();
                MessageBox.Show("정상적으로 등록을 완료하였습니다.");


            }
            catch(Exception ex)
            {
                sTran.Rollback();
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if(sCon.State == ConnectionState.Open) sCon.Close();
            }
        }

        private void dgtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 그리드에서 품목을 선택 하였을 경우 품목의 이미지를 픽쳐박스에 표현.

            // 선택한 품목 코드의 정보 변수 담기
            string sItemCode = Convert.ToString(dgtGrid.CurrentRow.Cells["ITEMCODE"].Value);

            try
            {
                sCon.Open();

                string sSelect = $"SELECT ITEMIMAGE FROM TB_ITEMMASTER WHERE ITEMCODE = '{sItemCode}'";

                adapter = new SqlDataAdapter(sSelect, sCon);
                DataTable dtTemp = new DataTable();
                adapter.Fill(dtTemp);

                // picItem.Image = null; ************************** 여기에 이렇게 해놓으면 미리 null이 됨. 만약 있다면 밑의 흐름을 타기에 이미지는 불러오기 가능함
                // dtTemp에 품목 이미지 16진수 파일 데이터를 받아옴.
                if (dtTemp.Rows.Count == 0)
                {
                    picItem.Image = null;
                    return;
                }
                if (Convert.ToString(dtTemp.Rows[0]["ITEMIMAGE"]) == "")
                {
                    picItem.Image = null;
                    return;     // NULL처리된 걸 받아올 때 사용
                }


                // 이미지를 표현. (현재 dtTemp는 RAM에 있음. -> BITMAP 형식으로 변형해야함 -> 픽쳐박스의 이미지 속성에 넣어야 함)
                // MemoryStream
                // 메모리 안에있는 파일데이터를 접근하는 Stream

                Byte[] bImages = (byte[])dtTemp.Rows[0]["ITEMIMAGE"];

                if (bImages == null)
                {
                    MessageBox.Show("이미지 형식으로 변형할 수 없는 데이터가 등록되어있습니다.");
                    return;
                }
                // 메모리에 등록되어 있는 byte[] 형식의 데이터를 BitMap(그림)으로 변형하여 Image 속성에 등록

              // MemoryStream memorystream = new MemoryStream(bImages);
              // Bitmap mybitmap = new Bitmap(memorystream));
              // picItem.Image = mybitmap
                picItem.Image = new Bitmap(new MemoryStream(bImages));


                // Image와 BitMap
                // 픽셀 단위의 데이터로 정의된 이미지 작업 클래스 (JPEG, BMP, PNG, JPG 등 다양한 이미지 파일 형식을 지원)
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                DoCloseDB();
            }
        }
        /// <summary>
        /// 데이버 베이스를 종료
        /// </summary>
        private void DoCloseDB()
        {
            if (sCon.State == ConnectionState.Open) sCon.Close();
        }

        private void btnPicDelete_Click(object sender, EventArgs e)
        {
            // 이미지 삭제 (이미지 컬럼에 등록된 데이터를 NULL 처리 하도록 UPDATE)
            if (dgtGrid.Rows.Count == 0) return;

            if (MessageBox.Show("선택한 품목의 이미지를 삭제 하시겠습니까?", "이미지 삭제", MessageBoxButtons.YesNo)
                == DialogResult.No) return;

            string sItemCode = Convert.ToString(dgtGrid.CurrentRow.Cells["ITEMCODE"].Value);
            string sDelete = $"UPDATE TB_ItemMaster SET ITEMIMAGE = NULL WHERE ITEMCODE = '{sItemCode}'";
            ExcuteNonQuery(sDelete);
            picItem.Image = null;
            MessageBox.Show("정상적으로 삭제되었습니다.");

        }
        private void ExcuteNonQuery(string sSqlstring)
        {
            if (sCon.State == ConnectionState.Closed) sCon.Open();
            sTran = sCon.BeginTransaction();

            Command.Transaction = sTran;
            Command.Connection = sCon;
            Command.CommandText = sSqlstring;

            Command.ExecuteNonQuery();

            sTran.Commit();

            DoCloseDB();
        }
    }

}
