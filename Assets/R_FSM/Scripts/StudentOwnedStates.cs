using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StudentOwnedStates
{
    public class RestAndSleep : State
    {
        public override void Enter(Student entity)
        {
            // 장소를 집으로 설정하고, 집에오면 스트레스가 0이 된다.
            entity.CurrentLocation = Locations.SweetHome;
            entity.Stress = 0;

            entity.PrintText("집에 들어온다. 행복한 우리집~ 집에오니 스트레스가 사라진다.");
            entity.PrintText("참대에 누워 잠을 잔다.");
        }
        public override void Execute(Student entity)
		{
			entity.PrintText("zzZ~ zz~ zzzzZ~~");

			// 피로가 0이 아니면
			if ( entity.Fatigue > 0 )
			{
				// 피로 10씩 감소
				entity.Fatigue -= 10;
			}
			// 피로가 0이면
			else
			{
				// 도서관에 가서 공부를 하는 "StudyHard" 상태로 변경
				// entity.ChangeState(StudentStates.StudyHard);
			}
		}

		public override void Exit(Student entity)
		{
			entity.PrintText("침대를 정리하고 집 밖으로 나간다.");
		}
    }
}

