using System.Collections;
using System.Collections.Generic;
using TestDriven.Abstracts.Managers;
using TestDriven.Abstracts.Movements;
using UnityEngine;

namespace TestDriven.Concretes.Managers
{
    public class PlayerMoveManager : IMovementService
    {
        readonly IPlayerController _playerController;
        readonly IMoverDal _moverDal;
        float _inputValue;
        public PlayerMoveManager(IPlayerController playerController, IMoverDal moverDal)
        {
            _playerController = playerController;
            _moverDal = moverDal;
        }
        public void Tick()
        {
            _inputValue = _playerController.InputReader.Horizontal * _playerController.Stats.MoveSpeed * Time.deltaTime;
        }
        public void FixedTick()
        {
            if(_inputValue == 0f) return;
            
            _moverDal.MoveAction(_inputValue);
        }
    }
}