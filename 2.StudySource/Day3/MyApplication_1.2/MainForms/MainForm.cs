using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainForms
{
    public partial class MainForm : Form
    {
        private Thread TimerThread;
        public MainForm()
        {
            //Login login = new Login();
            //login.ShowDialog();

            //if(Convert.ToBoolean(login.Tag) == false)
          //if(!Commons.bLoginSF) // == Commons.bLoginSF == 0 ////// Commons.bLoginSF만 적으면 트루라서 내려옴
            {
                // 로그인을 실패하였을 경우 또는 로그인 창을 그냥 닫아버렸을 경우 
                // 프로그램 종료

                // 객체의 생성자에서 Close()시 정상 종료를 할 수 없음
                //this.Close(); 

                // 프로그램 강제 종료
                //Environment.Exit(0);    // 로그인을 강제 종료
            }
            // 폼에 구성되는 컨트롤을 코딩 하는 함수
            InitializeComponent();  
        }

        private void WinTimer_Tick(object sender, EventArgs e)
        {
            tssNowTime.Text = string.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 1. 타이머 스레드를 구현.

            // 1-1 스레드가 실행할 메서드 연결
            ThreadStart threadStart = new ThreadStart(SetNowTime);

            // 1-2 Delegate를 실행할 스레드 객체 생성 및 연결
            TimerThread = new Thread(threadStart);

            // 1-3 스레드 시작
            TimerThread.Start();
        }

        /// <summary>
        /// 타이머 스레드가 구현할 메서드 로직
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
            //    iCnt++;
            //    if(iCnt == 10)
            //    {
            //        break;
            //    }
            }
            //MessageBox.Show("10초 종료");
        }

        private void tsbtnExit_Click(object sender, EventArgs e)
        {
            // Environment.Exit(0) : 현시점에서 해당 어플리케이션을 강제 종료한다. (불안정 종료)

            // 프로그램의 종료 여부를 묻고 싶거나
            // 멀티 스레드 등을 안정적으로 종료 후 프로그램을 종료 하기 위해서는 아래 기능을 사용한다.
            Application.Exit(); //클로징 하려는 마음 먹게 함////// 이걸 이용해서 밑에 메서드로 넘어감
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("프로그램을 종료하시겠습니까?", "프로그램 종료", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            if(TimerThread.IsAlive) TimerThread.Abort();
        }
    }
}
