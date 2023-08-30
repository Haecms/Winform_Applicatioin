using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* namespace
 *   = (클래스 라이브러리, 어셈블리, DLL. API, 프로젝트 정도로 불림)
 *  하나 이상의 앱에서 호출되는 형식 및 메서드 등을 정의하여 DLL형식으로 제공
 *  단독으로는 실행되지 않는다.
 *  1. 배포 및 재사용성이 용이
 *  2. DLL파일 내부의 소스만 변경 및 배포가 가능하므로 유지보수가 용이
 *  3. DLL내부의 소스는 외부 환경에서 확인 할 수 없으므로 보안성이 향상
 */
namespace Services
{

    // Services, Common
    // Services : 실제 프로그램이 실행되는 로직에는 관여하지 않고
    //            도움을 주는 역할의 로직들이 있는 모듈 (Biz)
    // Common   : 서비스 로직이 포함되어 있는 클래스
    public class Commons        //파일명과 달라도 됨 여기 클래스 이름이 제일 중요함
    {
       public const string strCon = "Server = localhost ; Uid = sa ; Pwd = 1234 ; database = AppDev";
    }
}
