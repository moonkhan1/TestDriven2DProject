using System.Collections;
using System.Collections.Generic;
using TestDriven.Inputs;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayerController
{
    public IInputReader InputReader {get;set;}
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
