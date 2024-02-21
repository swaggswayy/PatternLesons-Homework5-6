using UnityEngine;

public class GoToWorkState : IState
{
    private Character _character;
    private float _characterSpeed;
    private Transform _workTarget;
    private IStateSwitcher _stateSwitcher;

    public GoToWorkState(IStateSwitcher stateSwitcher, Character character, Transform workTarget)
    {
        _stateSwitcher = stateSwitcher;
        _character = character;
        _characterSpeed = character.CharacterData.Speed;
        _workTarget = workTarget;
    }

    public void Enter()
    {
        Debug.Log("Go To Work");
    }
    public void Update()
    {
        _character.transform.position = Vector3.Slerp(_character.transform.position, _workTarget.position, _characterSpeed * Time.deltaTime);
        if (_character.transform.position == _workTarget.position)
        {
            _stateSwitcher.StateSwitch<WorkState>();
        }
    }

    public void Exit()
    {
        Debug.Log("I came to work");
    }
}
