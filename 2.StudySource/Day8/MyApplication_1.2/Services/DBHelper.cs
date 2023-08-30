using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    // 시스템에서 데이터베이스 관련 작업을 할 경우
    // 데이터베이스 작업을 도와줄 수 있는 로직이 포함되어 있는 클래스
    public class DBHelper
    {
        // 1. 데이터베이스 접속 정보
        SqlConnection sCon = new SqlConnection(Commons.strCon);

        // 2. 데이터베이스 조회 및 결과반환 Adapter
        public SqlDataAdapter Adapter;
        public DBHelper()
        {
            // DBHelper 클래스를 인스턴스화 할 때 시점.

            sCon.Open();
        }

        public void Close()
        {
            sCon.Close();
        }
    }
}
