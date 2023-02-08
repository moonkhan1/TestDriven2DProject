using System.Collections;
using System.Collections.Generic;
using TestDriven.Abstracts.Movements;
using UnityEngine;

namespace TestDriven.Concretes.Movemenets
{
public class PlayerJumpWithForce : IJump
{
    readonly IPlayerController _playerController;
    readonly Rigidbody2D _rb2D;
    bool _canJump;
    public float JumpForce { get; private set; }
    public PlayerJumpWithForce(IPlayerController playerController)
    {
        _playerController = playerController;
        _rb2D = _playerController.transform.GetComponent<Rigidbody2D>();
    }

    public void Tick()
    {
        if(_playerController.InputReader.Jump)
        {
            _canJump = true;
        }

    }
    public void FixedTick()
    {
        if(_canJump)
        {
            JumpForce = _playerController.Stats.JumpForce * Time.deltaTime;
            _rb2D.AddForce(Vector3.up * JumpForce);
        }
        else
        {
            JumpForce = 0f;
        }
        _canJump = false;
    }

    

    
}
}