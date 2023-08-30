using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormList
{
    public partial class ProPerty : Services.BaseChildForm
    {
        public ProPerty()
        {
            InitializeComponent();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            // 입고 등록 시
            if (txtInQty.Text == "") return;

            lblStock.Text = Convert.ToString(Convert.ToInt32(lblStock.Text == "" ? "0" : lblStock.Text) + Convert.ToInt32(txtInQty.Text));
            ProPerty_Common.StockQty += Convert.ToInt32(txtInQty.Text); // 내가 놓친 부분
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            
            // 1씩 차감
            if (ProPerty_Common.StockQty - 1 < 0)
            {
                MessageBox.Show("재고수량이 0보다 작을 수는 없습니다.");
                return;
            }
            ProPerty_Common.StockQty = (Convert.ToInt32(lblStock.Text == "" ? "0" : lblStock.Text) - 1); // 내가 놓친 부분
            lblStock.Text = Convert.ToString(ProPerty_Common.StockQty);
            
        }
    }
}
