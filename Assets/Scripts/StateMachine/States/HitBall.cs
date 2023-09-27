using UnityEngine;

namespace ConsoleApp1
{
    public class HitBall : PlayerState
    {
        int scoreBallProbability = 10;
        int golkiperSaveProbability = 10;

        public override void OnEnter(StateController stateController)
        {
            base.OnEnter(stateController);
            int roll = Random.Range(0, 100);
            if (roll < scoreBallProbability)
            {
                sc.ChangeState(sc.noBall);
                sc.score.Invoke();
            }
            else if (roll < scoreBallProbability + golkiperSaveProbability)
            {
                sc.ChangeState(sc.noBall);
                sc.save.Invoke();
            }
            else
            {
                sc.miss.Invoke();
            }
        }
    }
}
