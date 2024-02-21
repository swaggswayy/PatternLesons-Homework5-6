using UnityEngine;

public class GoToHomeState : IState
{
    private Character _character;
    private float _characterSpeed;
    private Transform _homeTarget;
    private IStateSwitcher _stateSwitcher;

    public GoToHomeState(IStateSwitcher stateSwitcher, Character character, Transform homeTarget)
    {
        _stateSwitcher = stateSwitcher;
        _character = character;
        _characterSpeed = character.CharacterData.Speed;
        _homeTarget = homeTarget;
    }

    public void Enter()
    {
        Debug.Log("Go To Home");
    }
    public void Update()
    {
        _character.transform.position = Vector3.Slerp(_character.transform.position, _homeTarget.position, _characterSpeed * Time.deltaTime);
        if (_character.transform.position == _homeTarget.position)
        {
            _stateSwitcher.StateSwitch<SleepState>();
        }
    }

    public void Exit()
    {
        Debug.Log("I came to home");
    }
}
