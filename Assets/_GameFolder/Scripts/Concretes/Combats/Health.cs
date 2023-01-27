using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : IHealth
{
    int _currentHealth = 0;

    public event Action OnTakeDamage;
    public event Action OnDead;

    public int CurrnetHealth => _currentHealth;

    public Health(int maxHealth)
    {
        _currentHealth = maxHealth;
        
    }

    public void TakeDamage(IAttacker attacker)
    {
        _currentHealth -= attacker.Damage; 
        _currentHealth = Mathf.Max(_currentHealth, 0);
        OnTakeDamage?.Invoke();
        OnDead?.Invoke();
    }
}
