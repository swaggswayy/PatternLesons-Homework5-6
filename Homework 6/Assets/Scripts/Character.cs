using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterStateMachine _stateMachine;
    [SerializeField] private CharacterData _characterConfig;
    [SerializeField] private Transform _workTarget;
    [SerializeField] private Transform _homeTarget;

    public CharacterData CharacterData => _characterConfig;

    private void Awake()
    {
        _stateMachine = new CharacterStateMachine(this, _workTarget, _homeTarget);
    }

    private void Update()
    {
        _stateMachine.Update();
    }
}
