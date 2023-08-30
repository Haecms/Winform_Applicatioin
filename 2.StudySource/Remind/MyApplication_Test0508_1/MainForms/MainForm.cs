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

            //if(Convert.ToBoolean(login.Tag) == false)
            ////if (Commons.bLoginSF == false)
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
            //// 조회 버튼을 클릭 했을 때 탭 컨트롤에 오픈되어있는 화면의 조회 기능을 수행하고자 할 때
            //ItemMaster it = new ItemMaster();
            //it.DoInquire();
            //// 위 방식처럼 하면 새로운 객체를 만들어서 행동

            //// 탭페이지에 등록된 화면 객체를 뽑아내어서 조회 기능을 수행
            //if (MyTab.SelectedTab.Name == "ItemMaster")
            //{
            //    ItemMaster IT = (ItemMaster)MyTab.SelectedTab.Controls[0];
            //    IT.DoInquire();
            //}
            //else if (MyTab.SelectedTab.Name == "UserMaster")
            //{
            //    UserMaster IT = (UserMaster)MyTab.SelectedTab.Controls[0];
            //    IT.DoInquire();
            //}

            // 3. 공통으로 호출할 수 있는 추상 클래스로 각각의 탭페이지 클래스의 툴바 기능 구현.
            if (MyTab.TabPages.Count == 0) return;

            BaseChildForm Bs = (BaseChildForm)MyTab.SelectedTab.Controls[0];
            Bs.DoInquire();
        }
    }
}
