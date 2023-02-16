using System.Collections;
using System.Collections.Generic;
using TestDriven.Abstracts.Managers;
using TestDriven.Abstracts.Movements;
using UnityEngine;

public interface IEnemyController : IEntityController
{
    IAttacker Attacker {get; set;}
    IEnemyStats Stats {get;}
    IHealth Health {get;}
    IMovementService MoveManager{get;}
    bool IsEnemyDirectedToRight {get; set;}
}
