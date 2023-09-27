namespace ConsoleApp1
{

    public abstract class PlayerState
    {
        public StateController sc;
        public virtual void OnEnter(StateController stateController)
        {
            sc = stateController;
        }
        public virtual void OnUpdate()
        {
        }
        public virtual void OnExit()
        {
        }
    }
}
