using System.Collections;
using System.Collections.Generic;
using TestDriven.Abstracts.Stats;
using TestDriven.Concretes.Stats;
using TestDriven.Inputs;
using UnityEngine;


public class PlayerController : MonoBehaviour, IPlayerController
{
    [SerializeField] PlayerStats _playerStats;
    public IInputReader InputReader {get;set;}

    public IPlayerStats Stats => _playerStats;

    public IHealth Health { get; private set; }

    IMover _mover;
    IFlip _flip;
    void Awake() 
    {
        InputReader = new InputReader();
        _mover = new MoveWithTransform(this);
        _flip = new PlayerFlipWithScale(this);
        Health = new Health(Stats);
    }
     void Update() 
    {
        _mover.TakeInputAction();
        _flip.FlipAction();
    }

    // Update is called once per frame
    void FixedUpdate() {
        _mover.MoveAction();
    }

    
}
