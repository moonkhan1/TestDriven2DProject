using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    int CurrnetHealth { get; }
    void TakeDamage(IAttacker attacker);
    event System.Action OnTakeDamage;
    event System.Action OnDead;
}
