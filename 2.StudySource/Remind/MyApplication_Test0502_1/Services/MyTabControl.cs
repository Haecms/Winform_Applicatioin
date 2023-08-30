using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services
{
    // 사용자 정의 컨트롤
    public class MyTabControl : TabControl
    {
        public  void AddForm(Form NewForm)
        {
            if(NewForm == null) { return;  }
            NewForm.TopLevel = false;

            TabPage page = new TabPage();
            page.Controls.Clear();
            page.Controls.Add(NewForm);

            base.TabPages.Add(page);
            NewForm.Show();
            base.SelectedTab = page;
        }
    }
}
