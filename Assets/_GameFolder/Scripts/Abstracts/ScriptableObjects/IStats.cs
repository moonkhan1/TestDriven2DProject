using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStats
{
    float MoveSpeed { get; }
    int MaxHealth { get; }
    int Damage { get; }
}
