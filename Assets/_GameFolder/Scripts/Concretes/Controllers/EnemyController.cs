using System.Collections;
using System.Collections.Generic;
using TestDriven.Abstracts.Managers;
using TestDriven.Abstracts.Movements;
using TestDriven.Concretes.Managers;
using UnityEngine;

public class EnemyController : MonoBehaviour, IEnemyController
{
    [SerializeField] EnemyStats _stats;
    public IAttacker Attacker {get; set;}
    public IEnemyStats Stats => _stats;
    public IHealth Health {get; private set;}
    public IMovementService MoveManager {get; private set;}
    public bool IsEnemyDirectedToRight {get; set;}

    private void Awake() {
        Attacker = new Attacker(Stats);
        Health = new Health(Stats);
        MoveManager = new EnemyMovementManager(this, new MoveWithTransformDal(transform));
    }
    void Update()
    {
        MoveManager.Tick();
    }
    void FixedUpdate() 
    {
        MoveManager.FixedTick();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.TryGetComponent(out IPlayerController playerController))
        {
            if(other.contacts[0].normal.y < 0f) return; // Player-in y-i 0 ve (-1) arasinda, yeni asagi hissesinden damage almamalidir

            playerController.Health.TakeDamage(Attacker);
        }
    }

}
