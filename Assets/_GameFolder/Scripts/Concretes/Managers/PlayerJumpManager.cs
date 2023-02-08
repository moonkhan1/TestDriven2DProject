using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestDriven.Abstracts.Movements;
using TestDriven.Abstracts.Managers;

namespace TestDriven.Concretes.Managers
{
    public class PlayerJumpManager : IJumpService
    {
        readonly IPlayerController _playerController;
        readonly IJumpDal _jumpDal;
        bool _canJump;
        public PlayerJumpManager(IPlayerController playerController, IJumpDal jumpDal)
        {
            _playerController = playerController;
            _jumpDal = jumpDal;
        }
        public void Tick()
        {
            if (_playerController.InputReader.Jump)
            {
                _canJump = true;
            }

        }
        public void FixedTick()
        {
            if (_canJump)
            {
                _jumpDal.JumpProcess();
            }
            _canJump = false;
        }

    }
}