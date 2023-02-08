using System.Collections;
using System.Collections.Generic;
using TestDriven.Abstracts.Movements;
using UnityEngine;

namespace TestDriven.Concretes.Movemenets
{
    public class PlayerJumpWithForce : IJumpDal
    {
        readonly IPlayerController _playerController;
        readonly Rigidbody2D _rb2D;
        public PlayerJumpWithForce(IPlayerController playerController)
        {
            _playerController = playerController;
            _rb2D = _playerController.transform.GetComponent<Rigidbody2D>();
        }

        public void JumpProcess()
        {
            float JumpForce = _playerController.Stats.JumpForce * Time.deltaTime;
            _rb2D.AddForce(Vector3.up * JumpForce);
        }
       


    }
}