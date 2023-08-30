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
        public SqlConnection sCon = new SqlConnection(Commons.strCon);

        // 2. 데이터베이스 조회 및 결과반환 Adapter
        public SqlDataAdapter Adapter;

        // 3. 트랜잭션을 위한 객체 생성.
        public SqlTransaction Tran;
        public DBHelper(bool Transaction = false)
        {
            // DBHelper 클래스를 인스턴스화 할 때 시점.
            sCon.Open();
            if (Transaction)
            {
                Tran = sCon.BeginTransaction();
            }
        }

        public void Close()
        {
            sCon.Close();
        }

        public void Rollback()
        {
            if(Tran != null)        // 트랜이 초기화된 값이 아니다. 즉 값이 들어있다면
            {
                Tran.Rollback();    
            }
        }
        public void Commit()
        {
            if(Tran != null)
            {
                Tran.Commit();
            }
        }
    }
}
