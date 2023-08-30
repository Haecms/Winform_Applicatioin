using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    /* 인터페이스
     *  - 클래스와 비슷하게 메서드, 필드, 등의 멤버를 갖지만
     *    직접 구현하지 않고 정의만 갖는다. (추상적)
     *  - 다른 클래스가 해당 인터페이스를 상속하는 경우
     *    인터페이스의 모든 멤버에 대한 구현을 해야한다.
     *    
     *  - 상속받는 클래스가 구현해야 할 기본 멤버를 정의하여 기준 틀을 설정하기 위해 사용
     *    . 여러 개발자가 개발을 동시에 할 경우 표준 네이밍 규칙을 정할 수 있다.
     *  - 상속받은 클래스가 해당 인터페이스로 업 캐스팅 될 경우 - 추상화를 통한 캡슐화로 상속받은 
     *                                                            클래스의 메서드 정보를 숨길 수 있다.
     */
    public interface IChildCommand
    {
        void DoInquire();   // 조회

        void DoNew();       // 추가

        void DoSave();      // 저장

        void DoDelete();    // 삭제

    }
}
