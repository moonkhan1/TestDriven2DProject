using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : IHealth
{
    int _currentHealth = 0;
    int _maxHealth = 0;
    public event Action OnTakeDamage;
    public event Action OnDead;

    public int CurrnetHealth => _currentHealth;
    bool IsDead => _currentHealth <= 0;
    public Health(IStats stats)
    {
        _maxHealth = stats.MaxHealth;
        _currentHealth = _maxHealth;
        
    }

    public void TakeDamage(IAttacker attacker)
    {
        if (IsDead) return;
        
        _currentHealth -= attacker.Damage; 
        _currentHealth = Mathf.Max(_currentHealth, 0);
        OnTakeDamage?.Invoke();
        if(IsDead)
        {
            OnDead?.Invoke();
        }
    }
}
