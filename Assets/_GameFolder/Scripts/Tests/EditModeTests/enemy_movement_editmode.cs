using UnityEngine;
using NUnit.Framework;
using NSubstitute;
using TestDriven.Abstracts.Managers;
using TestDriven.Abstracts.Movements;
using TestDriven.Concretes.Managers;

namespace MovementTests
{
    public class enemy_movement_editmode
    {
        private IMovementService GetMovementManager(IEnemyController enemyController, IMoverDal moverDal)
        {
            var moveManager = new EnemyMovementManager(enemyController, moverDal);
            return moveManager;
        }

        [Test]
        [TestCase(1f)]
        [TestCase(-1f)]
        // RIGHT
        public void move_10_meters_right_or_left_different_from_start_position(float horizontalInputValue)
        {
            var enemyController = Substitute.For<IEnemyController>();
            enemyController.Stats.Returns(Substitute.For<IEnemyStats>());
            var moveDal = Substitute.For<IMoverDal>();
            var movementManager = GetMovementManager(enemyController, moveDal);

            enemyController.Stats.MoveSpeed.Returns(5f);
            float inputValue = horizontalInputValue;
            enemyController.IsEnemyDirectedToRight.Returns(horizontalInputValue == 1f);

            inputValue *= Time.deltaTime * enemyController.Stats.MoveSpeed;
            for (int i = 0; i < 10; i++)
            {
                movementManager.Tick();
                movementManager.FixedTick();
            }
            moveDal.Received().MoveAction(inputValue);


        }
    }
}