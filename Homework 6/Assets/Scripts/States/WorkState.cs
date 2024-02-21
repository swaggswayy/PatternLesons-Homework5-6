using UnityEngine;

public class WorkState : IState
{
    private float _workingTime;
    private float _currentWotkingTime;
    private IStateSwitcher _stateSwitcher;

    public WorkState(IStateSwitcher stateSwitcher, CharacterData characterData)
    {
        _stateSwitcher = stateSwitcher;
        _workingTime = characterData.WorkTime;
    }

    public void Enter()
    {
        Debug.Log("Working");
        _currentWotkingTime = _workingTime;
    }

    public void Update()
    {
        _currentWotkingTime -= Time.deltaTime;
        if (_currentWotkingTime <= 0)
        {
            _stateSwitcher.StateSwitch<GoToHomeState>();
        }
    }

    public void Exit()
    {
        Debug.Log("Finished working");
    }
}
