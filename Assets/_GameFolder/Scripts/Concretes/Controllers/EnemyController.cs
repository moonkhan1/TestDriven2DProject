using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IEnemyController
{
    [SerializeField] EnemyStats _stats;
    public IAttacker Attacker {get; set;}
    public IEnemyStats Stats => _stats;

    private void Awake() {
        Attacker = new Attacker(Stats);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent(out IPlayerController playerController))
        {
            playerController.Health.TakeDamage(Attacker);
        }
    }

}
