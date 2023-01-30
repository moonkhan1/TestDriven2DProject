using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatsBase : ScriptableObject
{
    [Header("Move Infoes")]
    [SerializeField] protected float _moveSpeed = 5f;

    [Header("Combat Infoes")]
    [SerializeField] protected int _maxHealth = 10;
    [SerializeField] protected int _damage = 1;

    public virtual int MaxHealth => _maxHealth;
    public virtual float MoveSpeed => _moveSpeed;
    public virtual int Damage => _damage;
}
