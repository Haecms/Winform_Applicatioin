using System;
using System.Collections.Generic;
using System.Data;
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
        // 프로시저 성공여부
        public string RS_CODE { get; set; }

        // 프로시저 메시지
        public string RS_MSG { get; set; }

        // 1. 데이터베이스 접속 정보
        public SqlConnection sCon = new SqlConnection(Commons.strCon);



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

        /// <summary>
        /// 데이터 베이스 조회하는 공통메서드 (프로시져)
        /// </summary>
        /// <param name="sSpName">     호출할 프로시저의 이름                                </param>
        /// <param name="ComType">     SQL 호출 유형 (text : Insql, SP : Sotred Procedure )  </param>
        /// <param name="parameters">  파라매터에 등록할 이름과 값                           </param>
        public DataTable FillTable(string sSpName, CommandType ComType, params Params_[] parameters)
        {
            // 2. 데이터베이스 조회 및 결과반환 Adapter
            SqlDataAdapter Adapter;

            // 저장프로시저를 실행할 SqlAdapter를 선언.
            Adapter = new SqlDataAdapter(sSpName, Commons.strCon);
            // 저장 프로시저 형태로 실행 하는것을 설정.
            Adapter.SelectCommand.CommandType = ComType;

            foreach(Params_ param in parameters)
            {
                Adapter.SelectCommand.Parameters.AddWithValue(param.ParamsName, param.ParamValue);
            }
            
            // Adapter가 프로시져에게 전달할 매개변수(파라매터) 등록을 합시다.

            Adapter.SelectCommand.Parameters.AddWithValue("@LANG", ""); // 아무것도 지정되지 않아서 기본값 KO를 가지고 시작함
            Adapter.SelectCommand.Parameters.AddWithValue("@RS_CODE", "").Direction = ParameterDirection.Output;
            Adapter.SelectCommand.Parameters.AddWithValue("@RS_MSG", "").Direction = ParameterDirection.Output;

            DataTable dtTmep = new DataTable();
            Adapter.Fill(dtTmep);

            return dtTmep;
        }
        public Params_ CreateParameters(string sParamName, string sParamValue)
        {
            // 프로시저에 전달할 파라매터 이름과 값을 셋팅할 메서드
            Params_ param = new Params_(); // { ParamsName = sParamName, ParamValue = sParamValue };
            param.ParamsName = sParamName;
            param.ParamValue = sParamValue;
            return param;
        }

        public void ExecuteNonQuery(string sSpName, CommandType ComType, params Params_[] parameters)
        {
            // 3. 커맨드 객체 생성
            SqlCommand Com = new SqlCommand();
            Com.Transaction = Tran;
            Com.Connection = sCon;
            Com.CommandType = ComType;

            Com.CommandText = sSpName;   // 프로시져 명

            foreach(Params_ param in parameters)
            {
                Com.Parameters.AddWithValue(param.ParamsName, param.ParamValue);
            }

            Com.Parameters.AddWithValue("@LANG", "");
            Com.Parameters.AddWithValue("@RS_CODE", "").Direction = ParameterDirection.Output;
            Com.Parameters.AddWithValue("@RS_MSG", "").Direction = ParameterDirection.Output;

            Com.ExecuteNonQuery();

            RS_CODE = Convert.ToString(Com.Parameters["@RS_CODE"].Value);
            RS_MSG  = Convert.ToString(Com.Parameters["@RS_MSG"].Value);

        }
    }
    // 데이터베이스에 전달할 파라매터 인수 이름과 값을 저장할 클래스
    public class Params_
    {
        // 인수의 이름이 들어갈 변수
        public string ParamsName { get; set; }

        // 인수가 전달할 값이 들어갈 변수
        public string ParamValue { get; set; }
    }


}
