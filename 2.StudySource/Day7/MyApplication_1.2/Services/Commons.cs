using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* namespace 
 *   = (클래스 라이브러리, 어셈블리, DLL , API, 프로젝트)
 *  하나 이상의 앱 에서 호출되는 형식 및 메서드 등을 정의하여 dll 형식으로 제공
 *  단독으로는 실행 되지 않는다. 
 *  
 *  1. 배포및 재사용성이 용이
 *  2. dll 파일 내부의 소스 만 변경 및 배포가 가능 하므로 유지보수 가 용이
 *  2. dll 내부의 소스 는 외부 환경에서 확인 할 수 없으므로 보안성이 향상.
 */

namespace Services
{

    // Services , Common 
    // Services : 실제 프로그램이 실행되는 로직에는 관여하지 않고 
    //            도움을 주는 역활 의 로직들이 있는 모듈 (Biz)
    // Common   : 서비스 로직 이 포함되어 있는 클래스.

    public class Commons
    {
        public const string strCon = "Server = localhost ; Uid = sa ; Pwd = 1234 ; database = AppDev";
        
        //로그인 성공 여부
        public static bool bLoginSF = false;

        // 시스템 사용자 ID
        public static string UserId = "ADMIN";

    }
}
