using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyController : IEntityController
{
    IAttacker Attacker {get; set;}
    IEnemyStats Stats {get;}
    IHealth Health {get;}
}
