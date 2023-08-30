using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Services
{

    // 사용자 정의 컨트롤 생성
    public class MyTabControl :TabControl
    {
        /*클래스 상속 을 통한 사용자 정의 컨트롤 생성
         * TabControl 의 모든 기능을 상속 받고 
         * 새로운 기능을 추가 할 수있다. */

        /// <summary>
        /// 탭 컨트롤에 폼 클래스를 탭 페이지에 추가하는 메서드
        /// </summary>
        /// <param name="NewForm">탭 페이지에 추가할 폼 클래스.</param>
        public void AddForm(Form NewForm)
        {
            if (NewForm == null) return;   // 인자로 받은 폼이 없을경우 리턴.
            NewForm.TopLevel = false;      // 추가로 호출되는 화면이 뒤에 표시 되도록 첫페이지 고정 하지 않음
            TabPage myPage = new TabPage(); // 폼을 담을 탭 페이지 객체 생성.

            myPage.Controls.Clear();      // 탭페이지 방청소
            myPage.Controls.Add(NewForm); // 페이지에 폼 추가
            myPage.Text = NewForm.Text;   // 페이지의 제목 을 폼의 text 로설정.
            myPage.Name = NewForm.Name;   // 페이지의 고유 명칭 설정. 

            base.TabPages.Add(myPage); // 탭컨트롤에 페이지를 추가한다.
            NewForm.Show();            // 화면을 보여준다. 
            base.SelectedTab = myPage; // 지금 추가한 페이지를 활성화해서 보이게한다.
        }
    }
}
