using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : IAttacker
{
    readonly IStats _stats;
    public Attacker(IStats stats)
    {
        _stats = stats;
    }
    public int Damage => _stats.Damage;

    
}
