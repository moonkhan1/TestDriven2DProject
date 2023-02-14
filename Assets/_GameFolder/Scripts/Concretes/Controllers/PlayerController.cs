using System.Collections;
using System.Collections.Generic;
using TestDriven.Abstracts.Managers;
using TestDriven.Abstracts.Stats;
using TestDriven.Concretes.Managers;
using TestDriven.Concretes.Movemenets;
using TestDriven.Concretes.Stats;
using TestDriven.Inputs;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour, IPlayerController
{
    [SerializeField] PlayerStats _playerStats;
    [SerializeField] Rigidbody2D _rigidBody2D;
    private Transform _transform;
    public IInputReader InputReader {get;set;}

    public IPlayerStats Stats => _playerStats;

    public IHealth Health { get; private set; }
    public IAttacker Attacker { get; private set; }

    public IJumpService JumpManager {get; private set;}

    public IMovementService MovementManager {get; private set;}

    IFlip _flip;
    void Awake() 
    {
        GetReference();
        _transform = GetComponent<Transform>();
        InputReader = new InputReader();
        _flip = new PlayerFlipWithScale(this);
        Health = new Health(Stats);
        Attacker = new Attacker(Stats);
        JumpManager = new PlayerJumpManager(this, new JumpWithForce(_rigidBody2D));
        MovementManager = new PlayerMoveManager(this, new MoveWithTransformDal(_transform));
    }

    void OnValidate() 
    {
        GetReference();
    }
     void Update() 
    {
        _flip.FlipAction();
        MovementManager.Tick();
        JumpManager.Tick();
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        MovementManager.FixedTick();
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

    private void GetReference()
    {
        if(_rigidBody2D == null)
            _rigidBody2D = GetComponent<Rigidbody2D>();
    }
}
