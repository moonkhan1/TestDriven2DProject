using System.Collections;
using System.Collections.Generic;
using TestDriven.Abstracts.Managers;
using TestDriven.Abstracts.Movements;
using UnityEngine;
namespace TestDriven.Concretes.Managers
{
    public class EnemyMovementManager : IMovementService
    {
        readonly IEnemyController _enemyController;
        readonly IMoverDal _moverDal;
        float _inputValue = 0f;

        public EnemyMovementManager(IEnemyController enemyController, IMoverDal moverDal)
        {
            _enemyController = enemyController;
            _moverDal = moverDal;
        }
        public void Tick()
        {
            _inputValue = _enemyController.IsEnemyDirectedToRight ? 1f : -1f;
            _inputValue *= Time.deltaTime * _enemyController.Stats.MoveSpeed;
        }
        public void FixedTick()
        {
             _moverDal.MoveAction(_inputValue);
        }
    }
}