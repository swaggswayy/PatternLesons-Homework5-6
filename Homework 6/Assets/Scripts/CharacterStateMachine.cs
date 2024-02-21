using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CharacterStateMachine : IStateSwitcher
{
    private List<IState> _states;
    private IState _currentState;

    public CharacterStateMachine(Character character, Transform workTarget, Transform homeTarget)
    {
        _states = new List<IState>()
        {
            new SleepState(this, character.CharacterData),
            new WorkState(this, character.CharacterData),
            new GoToHomeState(this, character, homeTarget),
            new GoToWorkState(this, character, workTarget)
        };

        _currentState = _states.FirstOrDefault();
        _currentState.Enter();
    }

    public void Update()
    {
        _currentState.Update();
    }

    public void StateSwitch<State>() where State : IState
    {
        IState state = _states.FirstOrDefault(state => state is State);

        _currentState.Exit();
        _currentState = state;
        _currentState.Enter();
    }
}
