using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IPlayerController
{
    public IInputReader InputReader {get;set;}
    IMover _mover;

    void Awake() 
    {
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
