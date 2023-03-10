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
        int _currentJumpCount = 0;
        int _maxJumpCount = 1;
        public PlayerJumpManager(IPlayerController playerController, IJumpDal jumpDal)
        {
            _playerController = playerController;
            _jumpDal = jumpDal;
        }
        public void Tick()
        {
            if (_playerController.InputReader.Jump && _currentJumpCount < _maxJumpCount)
            {
                _currentJumpCount++;
                _canJump = true;
            }

        }
        public void FixedTick()
        {
            if (_canJump)
            {
                _jumpDal.JumpProcess(_playerController.Stats.JumpForce);
            }
            _canJump = false;
        }
        public void ReserJumpCounter()
        {
            _currentJumpCount = 0;
        }
    }
}