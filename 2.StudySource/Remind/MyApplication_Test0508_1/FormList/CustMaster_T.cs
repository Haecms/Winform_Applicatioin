using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FormList
{
    public partial class CustMaster_T : Services.BaseChildForm
    {
        public CustMaster_T()
        {
            InitializeComponent();
        }
        public override void DoInquire()
        {
            base.DoInquire();
            // 거래처 조회
        }
    }
}
