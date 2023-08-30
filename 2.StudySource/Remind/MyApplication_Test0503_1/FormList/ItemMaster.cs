using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/************************************************************
 * NAME   : ItemMaster.cs
 * DESC   : 품목 관리.
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
    // 품목, 작업자, 사용자, 거래처, 공정, 작업장......
    public partial class ItemMaster : Form
    {
        public ItemMaster()
        {
            InitializeComponent();
        }

        private void ItemMaster_Load(object sender, EventArgs e)
        {
            // 화면이 오픈 될 때 기본 셋팅.

            // 1. 그리드 셋팅.

            DataTable dtGrid = new DataTable(); // 그리드 셋팅을 위한 DataTable
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

            // 빈 컬럼 테이블을 그리드에 매핑
            dgtGrid.DataSource = dtGrid;

            // 그리드 속성 세팅
            // 헤더의 명칭을 선언
            dgtGrid.Columns["ITEMCODE"].HeaderText = "품목코드";
            dgtGrid.Columns["ITEMNAME"].HeaderText = "품목명";
            dgtGrid.Columns["ITEMTYPE"].HeaderText = "품목유형";
            dgtGrid.Columns["ITEMDESC"].HeaderText = "품목상세";
            dgtGrid.Columns["ENDFLAG"].HeaderText  = "단종여부";
            dgtGrid.Columns["PRODDATE"].HeaderText = "출시일자";
            dgtGrid.Columns["MAKEDATE"].HeaderText = "생성일시";
            dgtGrid.Columns["MAKER"].HeaderText    = "생성자";
            dgtGrid.Columns["EDITDATE"].HeaderText = "생성일시";
            dgtGrid.Columns["EDITOR"].HeaderText   = "수정자";

            // 컬럼의 폭 지정
            dgtGrid.Columns["ITEMCODE"].Width = 100; // 품목 코드
            dgtGrid.Columns[1].Width          = 200; // 품명.
            dgtGrid.Columns["MAKEDATE"].Width = 250; // 등록 일시
            dgtGrid.Columns["EDITDATE"].Width = 250; // 수정 일시

            // 컬럼의 수정 여부 지정.
            dgtGrid.Columns["MAKEDATE"].ReadOnly = true;     // ReadOnly 라서 수정 불가능
            dgtGrid.Columns["MAKER"].ReadOnly    = true;
            dgtGrid.Columns["EDITDATE"].ReadOnly = true;
            dgtGrid.Columns["EDITOR"].ReadOnly   = true;


            // 2. 콤보박스에 데이터 셋팅.

        }
    }
}
