using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyFirstCSharp.Lesson05
{
    public partial class Chap33_ProPerty : Form
    {

        // 1. 프로퍼티에 대한 설명. 
        /* 프로퍼티 (ProPerty)
          - 클래스 내부 변수의 값을 읽거나 쓸때 사용하는 방법 
          - 유효성 검사 (벨리데이션)
           . 데이터 의 변질로 인한 오류 사항을 사전에 방지 할 수 있는 방법 
        
        캡슐화 
           . 정보 은닉을 위해 클래스에서 선언된 변수가 외부에서 접근이 안되도록
             Public 이 아닌 Private 로 선언하여 접근을 불가능 하게 하는 객체지향 
             언어에서 지향하는 방식.
        */

        // 6. BookStore 클래스 선언 
        private BookStore B_S = new BookStore();

        public Chap33_ProPerty()
        {
            InitializeComponent();
        }

        private void btnBookStock_Click(object sender, EventArgs e)
        {
            //// 7 서점에 책의 재고 입고 
            //int iBookCount = Convert.ToInt32(txtBookInCNT.Text);
            //B_S.BookCount += iBookCount;
            //txtBookInCNT.Text = "";
            //lblBookStock.Text = B_S.BookCount.ToString();
            //MessageBox.Show(iBookCount + " 권의 책이 입고 되었습니다.");


            // 11. BookCount2 프로퍼티 에 입고 재고 수량 증가 
            int iBookCount = Convert.ToInt32(txtBookInCNT.Text);
            B_S.BookCount2 += iBookCount;
            txtBookInCNT.Text = "";
            lblBookStock.Text = B_S.BookCount2.ToString();
            MessageBox.Show(iBookCount + " 권의 책이 입고 되었습니다.");

        }

        private void btnSalesBook_Click(object sender, EventArgs e)
        {
            //// 8 책을 판매 할 경우 
            //B_S.BookCount--;

            //// 9 . 책의 카운트 는 - 가 될수 없다.
            //// 외부 에서 (또는 다른 개발자가 B_S.BookCount 에 접근하여 - 재고로 생성 할 가능성이 있을경우)
            //// 벨리데이션 체크를 하지 못해 오류가 발생할 수 있다. 
            //if (B_S.BookCount == -1)
            //{
            //    B_S.BookCount = 0;
            //    MessageBox.Show("재고 수량은 0 일수 없습니다.");
            //}

            ////lblBookStock.Text = (B_S.BookCount).ToString();  

            // 10 . BookCount2 프로퍼티 로 재고를 차감 
            B_S.BookCount2--;
            lblBookStock.Text = (B_S.BookCount2).ToString();
        }
    }






    // 2. 서점 이라는 클래스가 있다고 할때 

    class BookStore
    {
        // 프로퍼티 의 원형 포멧 
        private int iBookCount; // 3. 클래스 내에서 관리 할 iBookCount Private 변수
        public int BookCount // 4. 외부에서는 BookCount 로 접근하여 데이터를 변형 할 수 있다. 
        {
            get
            {
                // 외부에서 BookCount 의 값을 호출할때 Get 클래스에서 iBookCount 에 있는 값을 반환함.
                return iBookCount;
            }
            set
            {
                // BookCount 에 값을 대입할때 Set
                iBookCount = value; // Set 에서의 value : 외부에서 BookCount 에 대입한 값, 클래스 에서 iBookCount 로 대입
            }
        }
        // 5. 정보 은닉을 위해 실제 데이터를 관리하는 변수 iBookCount 는  Private 로 선언을 했지만.
        //    public BookCount 를 통하여 Get 와 Set 으로 접근을 가능하게 하니 Public 과 별차이 없어 보인다.


        public int BookCount2
        {
            get
            {
                return iBookCount;
            }
            set
            {
                if (value < 0)
                {
                    MessageBox.Show("책의 재고 는 0 이하일 수 없습니다.");
                }
                else if (value == 0) 
                {
                    MessageBox.Show("재고가 소진되었습니다.");
                    iBookCount = value;
                }
                else iBookCount = value;
            }
        }

        // 자동 프로퍼티의 구현
        public int BookCount3{ get; set;     }

        // 읽기 전용 프로퍼티
        public int BookCount4 { get; } = 100;

        public BookStore()
        {
            BookCount4 = 10;
        }

        private void Set()
        {
            // 읽기전용 프로퍼티 의 경우 외부에서 값을 대입 할 수 없다.
            //BookCount4 = 1999;
        }


    }


  

}
