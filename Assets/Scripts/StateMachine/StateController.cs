using UnityEngine.Events;

namespace ConsoleApp1
{
    public class StateController
    {
        PlayerState currentState;
        public HasBall hasBall = new HasBall();
        public HitBall hitBall = new HitBall();
        public NoBall noBall = new NoBall();

        public UnityEvent gotBall = new UnityEvent();
        public UnityEvent score = new UnityEvent();
        public UnityEvent save = new UnityEvent();
        public UnityEvent kick = new UnityEvent();
        public UnityEvent pass = new UnityEvent();
        public UnityEvent miss = new UnityEvent();
        public UnityEvent loseBall = new UnityEvent();


        public void Start()
        {
            ChangeState(noBall);
        }

        public void Update()
        {
            if (currentState != null)
            {
                currentState.OnUpdate();
            }
        }

        public void ChangeState(PlayerState newState)
        {
            if (currentState != null)
            {
                currentState.OnExit();
            }
            currentState = newState;
            currentState.OnEnter(this);
        }
    }

}
