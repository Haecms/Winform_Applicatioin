using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        /// <summary>
        /// 1. 버튼 btnHello를 클릭 할 때
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHello_Click(object sender, EventArgs e)
        {
            // 2. 텍스트박스 tboxName에 있는 text 속성의 값을 받아서.
            string sName = tboxName.Text;

            // 3. 메세지로 출력하라 + ??님 반갑습니다.
            MessageBox.Show($"{sName} 님 반갑습니다.");
        }
    }
}
