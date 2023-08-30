using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services
{
    // interface 형식인 IChildCommand의 멤버를 모두 구현한 틀
    public partial class BaseChildForm : Form, IChildCommand
    {
        // BaseChildForm
        // Interface를 상속 받아 필수로 입력해야 하는 메서드의 기능을 모두 정의해 놓고
        // 시스템 개발에 사용되는 Form의 틀을 정의 하는 역할.
        // 공통 툴바의 기능 메서드를 상속 해주는 역할
        public BaseChildForm()
        {
            InitializeComponent();
        }
        // virtual 이란 재정의해서 사용할 수 있게 해주는 키워드
        // 상속받은 메서드에서 기능을 재정의 할 수 있도록 해주는 키워드
        // 구현을 해도되고 안해도 되는 선택적.
        public virtual void DoDelete()
        {
            
        }

        public virtual void DoInquire()
        {
            
        }

        public virtual void DoNew()
        {
            
        }

        public virtual void DoSave()
        {
            
        }
    }
}
