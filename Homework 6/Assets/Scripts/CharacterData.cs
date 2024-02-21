using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "CharacterConfig")]
public class CharacterData : ScriptableObject
{
    [field: SerializeField, Range(0, 10)] public float Speed { get; private set; }
    [field: SerializeField, Range(0, 10)] public float SleepTime { get; private set; }
    [field: SerializeField, Range(0, 10)] public float WorkTime { get; private set; }
}
