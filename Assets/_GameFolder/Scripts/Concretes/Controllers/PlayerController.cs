using System.Collections;
using System.Collections.Generic;
using TestDriven.Abstracts.Managers;
using TestDriven.Abstracts.Stats;
using TestDriven.Concretes.Managers;
using TestDriven.Concretes.Movemenets;
using TestDriven.Concretes.Stats;
using TestDriven.Inputs;
using UnityEngine;


public class PlayerController : MonoBehaviour, IPlayerController
{
    [SerializeField] PlayerStats _playerStats;
    public IInputReader InputReader {get;set;}

    public IPlayerStats Stats => _playerStats;

    public IHealth Health { get; private set; }
    public IAttacker Attacker { get; private set; }

    public IJumpService JumpManager {get; private set;}
    IMover _mover;
    IFlip _flip;
    void Awake() 
    {
        InputReader = new InputReader();
        _mover = new MoveWithTransform(this);
        _flip = new PlayerFlipWithScale(this);
        Health = new Health(Stats);
        Attacker = new Attacker(Stats);
        JumpManager = new PlayerJumpManager(this, new PlayerJumpWithForce(this));
    }
     void Update() 
    {
        _mover.TakeInputAction();
        _flip.FlipAction();
        JumpManager.Tick();
    }

    // Update is called once per frame
    void FixedUpdate() {

        _mover.MoveAction();
        JumpManager.FixedTick();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        JumpManager.ReserJumpCounter();
        if(other.collider.TryGetComponent(out IEnemyController enemyController))
        {  
            if(other.contacts[0].normal.y != 1f) return;

            enemyController.Health.TakeDamage(Attacker);
        }
    }
}
