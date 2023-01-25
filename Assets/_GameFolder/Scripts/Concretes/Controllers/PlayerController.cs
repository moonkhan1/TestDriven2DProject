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

    IMover _mover;

    void Awake() 
    {
        InputReader = new InputReader();
        _mover = new MoveWithTransform(this);
        
    }
     void Update() 
    {
        _mover.TakeInputAction();
    }

    // Update is called once per frame
    void FixedUpdate() {
        _mover.MoveAction();
    }
}
