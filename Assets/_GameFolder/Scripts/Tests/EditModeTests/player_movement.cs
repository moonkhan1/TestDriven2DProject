using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;
using TestDriven.Abstracts.Stats;

namespace MovementTests
{
    public class player_movement
    {
        private IPlayerController GetPlayer()
        {
            IPlayerController playerController = Substitute.For<IPlayerController>();
            GameObject gameObject = new GameObject();
            playerController.transform.Returns(gameObject.transform);
            playerController.InputReader = Substitute.For<IInputReader>();
            playerController.Stats.Returns(Substitute.For<IPlayerStats>());
            playerController.Stats.MoveSpeed.Returns(5f);

            return playerController;
        }

        private IMover GetMoveWithTransform(IPlayerController playerController)
        {
            IMover mover = new MoveWithTransform(playerController);
            return mover;
        }


        [Test]
        [TestCase(1f)]
        [TestCase(-1f)]
        // RIGHT
        public void move_10_meters_right_or_left_different_from_start_position(float horizontalInputValue)
        {
            // Arrange
            var playerController = GetPlayer();
            var mover = GetMoveWithTransform(playerController);
            Vector3 startPosition = playerController.transform.position;
            // Act
            playerController.InputReader.Horizontal.Returns(horizontalInputValue);
            for (int i = 0; i <= 10; i++)
            {
                mover.TakeInputAction();
                mover.MoveAction();
            }
            Debug.Log("Player Start Position => " + startPosition);
            Debug.Log("Player End Position => " + playerController.transform.position);
            // Assert
            Assert.AreNotEqual(startPosition, playerController.transform.position);
        }
        [Test]

        // RIGHT
        public void move_10_meters_right_greater_than_start_position()
        {
            // Arrange
            var playerController = GetPlayer();
            var mover = GetMoveWithTransform(playerController);
            Vector3 startPosition = playerController.transform.position;
            // Act
            playerController.InputReader.Horizontal.Returns(1f);
            for (int i = 0; i <= 10; i++)
            {
                mover.TakeInputAction();
                mover.MoveAction();
            }
            Debug.Log("Player Start Position => " + startPosition);
            Debug.Log("Player End Position => " + playerController.transform.position);
            // Assert
            Assert.Greater(playerController.transform.position.x, startPosition.x);
        }


        [Test]
        // Left
        public void move_10_meters_left_greater_than_start_position()
        {
            // Arrange
            var playerController = GetPlayer();
            var mover = GetMoveWithTransform(playerController);
            Vector3 startPosition = playerController.transform.position;
            // Act
            playerController.InputReader.Horizontal.Returns(-1f);
            for (int i = 0; i <= 10; i++)
            {
                mover.TakeInputAction();
                mover.MoveAction();
            }
            Debug.Log("Player Start Position => " + startPosition);
            Debug.Log("Player End Position => " + playerController.transform.position);
            // Assert
            Assert.Less(playerController.transform.position.x, startPosition.x);
        }
    }
}
