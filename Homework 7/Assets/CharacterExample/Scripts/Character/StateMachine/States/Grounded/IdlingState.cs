public class IdlingState : GroundedState
{
    public IdlingState(IStateSwitcher stateSwitcher, StateMachineData data, Character character) : base(stateSwitcher, data, character)
    {
    }

    public override void Enter()
    {
        base.Enter();

        View.StartIdling();
    }

    public override void Exit()
    {
        base.Exit();

        View.StopIdling();
    }

    public override void Update()
    {
        base.Update();

        if (IsHorizontalInputZero())
            return;

        if (IsCrouchInput())
            StateSwitcher.SwitchState<WalkingState>();
        else if(IsSprintInput())
            StateSwitcher.SwitchState<FastRunningState>();
        else
            StateSwitcher.SwitchState<RunningState>();
    }
}
