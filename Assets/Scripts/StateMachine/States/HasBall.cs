using UnityEngine;

namespace ConsoleApp1
{
    public class HasBall : PlayerState
    {
        int passBallProbability = 30;
        int kickBallProbability = 20;

        public override void OnEnter(StateController stateController)
        {
            base.OnEnter(stateController);
            int roll = Random.Range(0, 100);
            if (roll < passBallProbability)
            {
                sc.ChangeState(sc.noBall);
                sc.pass.Invoke();
            }
            else if (roll < passBallProbability + kickBallProbability)
            {
                sc.ChangeState(sc.hitBall);
                sc.kick.Invoke();
            }
            else
            {
                sc.loseBall.Invoke();
            }
        }
    }
}
