using UnityEngine;

namespace ConsoleApp1
{
    public class NoBall : PlayerState
    {
        int takeBallProbability = 30;
        public override void OnUpdate()
        {
            base.OnUpdate();
            int roll = Random.Range(0, 100);
            if(roll < takeBallProbability)
            {
                sc.gotBall.Invoke();
                sc.ChangeState(sc.hasBall);
            }
        }
    }
}
