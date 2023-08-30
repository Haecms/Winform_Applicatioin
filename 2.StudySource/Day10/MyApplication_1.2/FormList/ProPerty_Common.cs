using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormList
{
    public  class ProPerty_Common
    {

        private static int _StockQty;
        public static int StockQty // 재고수량
        {
            get 
            {
                return _StockQty;
            }
            set
            {
                if( value < 0)
                {
                    MessageBox.Show("재고가 0 보다 작을 수 없습니다.");
                }
                else if(value == 0)
                {
                    MessageBox.Show("재고수량이 0입니다.");
                }
                else _StockQty = value;
            }
        } 
        //public int iValues { get; set; } // 이렇게만 쓸거면 그냥 public int iValues; 쓰는거랑 별반 차이가 없는거같음!
    }
}
