using UnityEngine;

public class SleepState : IState
{
    private float _timeBeforeWakingUp;
    private float _currentTimeBeforeWakingUp;
    private IStateSwitcher _stateSwitcher;

    public SleepState(IStateSwitcher stateSwitcher, CharacterData characterData)
    {
        _stateSwitcher = stateSwitcher;
        _timeBeforeWakingUp = characterData.SleepTime;
    }

    public void Enter()
    {
        Debug.Log("Sleeping");
        _currentTimeBeforeWakingUp = _timeBeforeWakingUp;
    }

    public void Update()
    {
        _currentTimeBeforeWakingUp -= Time.deltaTime;
        if (_currentTimeBeforeWakingUp <= 0)
        {
            _stateSwitcher.StateSwitch<GoToWorkState>();
        }
    }

    public void Exit()
    {
        Debug.Log("Wake Up");
    }
}
