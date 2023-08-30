using FormList;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MainForms
{
    public partial class MainForm : Form
    {
        public static MainForm pu_MainForm;
        private Thread TimerThread;
        public MainForm()
        {
            //Login login = new Login();
            //login.ShowDialog();

            ////if (Convert.ToBoolean(Commons.bLoginSF) == false)
            //if (Commons.bLoginSF == false)
            //{
            //    // 로그인 을 실패하였을 경우 또는 로그인 창을 그냥 닫아버렸을 경우
            //    // 프로그램 종료

            //    // 객체의 생성자 에서 Close() 시 정상 종료를 할 수 없음.
            //    //this.Close();

            //    // 프로그램 강제종료
            //    Environment.Exit(0);

            //}
            // 폼에 구성되는 컨트롤을 코딩 하는 함수.
            InitializeComponent();
        }

        private void WinTimer_Tick(object sender, EventArgs e)
        {
            tssNowTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 1. 타이머 스레드 를 구현.

            // 1-1 스레드가 실행 할 메서드 연결
            ThreadStart threadStart = new ThreadStart(SetNowTime);

            // 1-2 Delegate 를 실행할 스레드 객체 생성 및 연결.
            TimerThread = new Thread(threadStart);

            // 1-3 스레드 시작 
            TimerThread.Start();
        }

        /// <summary>
        /// 타이머 스레드가 구현 할 메서드 로직.
        /// </summary>
        private void SetNowTime()
        {
            // 스레드의 메서드는 한번만 호출 된다. 
            // 따라서 반복적으로 수행해야 하는 로직은 
            // 무한 루프를 통해 별도의 프로세스로 구현 할 수 있다. 

            //int iCnt = 0;
            while (true)
            {
                Thread.Sleep(1000);
                tssNowTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
                //iCnt++;
                //if (iCnt == 10) { break; }
            }
            //MessageBox.Show("10 초 종료");
        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            // Envirement.Exit(0) : 현시점에서 해당 어플리케이션을 강제 종료한다.(불안정 종료)

            // 프로그램의 종료 여부를 묻고 싶거나 
            // 멀티 스레드 등을 안정적으로 종료 후 프로그램을 종료 하기 위해서는 아래 기능을 사용한다.
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 메인 폼이 종료될때 

            if (MessageBox.Show("프로그램을 종료 하시겠습니까?", "프로그램 종료", MessageBoxButtons.YesNo)
                == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            if (TimerThread.IsAlive) TimerThread.Abort();
        }

        private void M_TEST_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            //// 1. MDI_Test1 클래스 화면을 직접 호출
            //MDI_Test1 MDI1 = new MDI_Test1();
            //MDI1.Show();

            // 2. MDI Container 를 이용한 방식 
            //    부모 창을 컨테이너로 두고 그안에 자식의 형태로 표현하는 방식. 

            // MDI (Multiple Document Insertface) : 한개의 창에서 여러가지 작업을 하는 화면을 
            //                                      호출하는 방식을 말한다.

            //MDI_Test1 MDI1 = new MDI_Test1();

            //// MDI_Test1 클래스 객체 화면의 부모 컨테이너로 MainForm 을 선택하겠다.
            ////this.IsMdiContainer = true;
            //MDI1.MdiParent = this;

            //MDI1.Show();


            //// 3. TEST 매뉴 클릭시 오픈 되어야 할 폼 표시
            //if (e.ClickedItem.Name == "MDI_Test1")
            //    MessageBox.Show("MDI_Test1 화면을 탭컨트롤에 표현합니다.");
                      //if (e.ClickedItem.Name == "MDI_Test2")
            //    MessageBox.Show("MDI_Test2 화면을 탭컨트롤에 표현합니다.");
            

            // 이미 등록 되어있는 페이지의 매뉴를 클릭 하였을 경우 
            // 해당 페이지 활성화
            for (int i = 0; i< MyTab.TabPages.Count; i++)
            {
                if (MyTab.TabPages[i].Name == e.ClickedItem.Name.ToString())
                {
                    MyTab.SelectedTab = MyTab.TabPages[i];
                    return;

                }
            }

            // 열려있는 페이지 가 없을경우 신규 등록 
            // 4. 선택한 매뉴 의 이름에 맞는 클래스를 찾아서 폼 형식으로 형변환 하기.
            // 4-1. FormList.DLL 을 호출 
            Assembly FormList = Assembly.LoadFrom($"{Application.StartupPath}\\FormList.DLL");

            // 4-2 Assembly 에서 클릭한 매뉴의 이름에 맞는 클래스 정보 추출하기. 
            Type type = FormList.GetType("FormList." + e.ClickedItem.Name.ToString(), true);

            // 4-3 Form 형식으로 전환. 
            Form NewForm = (Form)Activator.CreateInstance(type); 

            // 4-4 탭 페이지에 폼을 추가하여 오픈한다. 
            MyTab.AddForm(NewForm);

            // 하단 FormName은 추가한 탭의 이름을 가져옴
            tssFormName.Text = NewForm.Text;
        }

        private void tsbtnClose_Click(object sender, EventArgs e)
        {
            // 닫기 버튼 클릭
            if (MyTab.TabPages.Count == 0) return;
            MyTab.SelectedTab.Dispose();
        }

        public void SetMessage(string sRowCnt)
        {
            tssRowCnt.Text = sRowCnt;
        }

        private void tsbtnSearch_Click(object sender, EventArgs e)
        {
            if (MyTab.TabPages.Count == 0) return;

            // 메인 메뉴의 조회 버튼을 클릭 했을 때.

            #region< 시나리오 1, 2 >
            // 1번 시나리오 품목 마스터 객체를 생성해서 조회 메서드를 호출
            // * 객체가 다르므로 오픈된 화면의 품목 마스터 조회 내역을 확인 할 수 없다.
            // ItemMaster It = new ItemMaster();
            // It.DoInquire();  (실패)

            // 2. 탭페이지에 등록되어있는 클래스를 가지고 와서 실행.
            // * 모든 화면의 기능을 일일이 다 연결 해야 한다. (확장성이 저하됨 - 만들어야 할게 많으니까 부담이 됨)
            // * 변경 내역이 존재할 경우 수정해야할 항목들이 늘어남. (유지보수성이 저하됨 - 불필요한 일이 늘어나서
            //if(MyTab.SelectedTab.Name == "ItemMaster")
            //{
            //    ItemMaster it = (ItemMaster)MyTab.SelectedTab.Controls[0];  // 폼을 말하는거임!!! 이 폼을 아이템마스터로 클래스화해서 it에 넣는거임.
            //    it.DoInquire();
            //}
            //else if(MyTab.SelectedTab.Name == "UserMaster")
            //{
            //    UserMaster um = (UserMaster)MyTab.SelectedTab.Controls[0];
            //    um.doinq();
            //}
            #endregion

            // 3. 오픈하고자 하는 화며들을 하나의 추상클래스에 연결해서 공통으로 호출


            // sender의 정보를 가져올거임
            ToolStripButton TSB = (ToolStripButton)sender; // TSB의 이름에는 조회를 누르면 조회에관한 정보, 삭제는 삭제정보가 들어감
            ChildCommand(Convert.ToString(TSB.Tag).ToUpper());
        }

        // 조회기능을 구현할 수 있도록 연결하는 작업
        private void ChildCommand(string sToolBarName)
        {
            // 1. 현재 탭화면이 등록되어 있지 않은 경우 return;
            if (MyTab.TabPages.Count == 0) return;

            // 툴바를 눌렀을 때 활성화된 창의 유형이 BaseChildForm을 상속받지 않았을 경우를 찾는 로직
            if (MyTab.SelectedTab.Controls[0] is BaseChildForm == false) return;

            // 2. 업 캐스팅을 통한 부모의 상속 메서드 호출
            IChildCommand NewChild = (BaseChildForm)MyTab.SelectedTab.Controls[0];
            //인터페이스             인터페이스를 상속받은 베이스차일드폼
            // 은닉성과 캡슐화 땜에 사용함 - 부모 클래스는 자식클래스의 속성을 사용할 수 없지만 호출은 가능함

            // 3. 비교
            if (NewChild == null) return;

            switch(sToolBarName)
            {
                case "SEARCH":
                NewChild.DoInquire(); // 할머니가 손자의 DoInquire를 실행시킴
                    break;
                case "ADD":
                NewChild.DoNew();
                    break;
                case "SAVE":
                NewChild.DoSave();
                    break;
                case "DELETE":
                NewChild.DoDelete();
                    break;
            }
            // 추상화 클래스의 사용 목적
            // ***** 클래스를 상속받은 부모 클래스에게 제어권을 줌으로서 상속받은 모든 클래스를
            //       제어할 수 있도록 함
            //  **   메서드 명칭의 규격화
            //       툴바의 기능을 실행할때에 (DoInquire, DoSave, DoDelete, DoAdd)와 같은
            //       정해진 이름으로만 기능을 구현하여야 툴바의 기능을 사용할 수 있음.
            // ****  상속받은 클래스의 캡슐화
            //       상속받은 클래스가 업캐스팅 되었을 경우 내부의 메서드를 확인 할 수 없음.
            // ****  유지보수성이 용이
            //       자식 클래스에서 상속한 메서드를 수정하거나 변경하더라도 
            //       메인 폼에서 호출하는 부모 클래스는 변경 하지 않고 그대로 유지되어 사용할 수 있다.
        }

        private void MyTab_Selected(object sender, TabControlEventArgs e)
        {
            if (MyTab.TabCount == 0)
            {
                tssFormName.Text = "FormName";
            }
            tssFormName.Text = MyTab.SelectedTab.Text;
        }
    }
}
