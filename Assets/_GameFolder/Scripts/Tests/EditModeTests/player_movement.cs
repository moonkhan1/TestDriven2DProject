using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;
using TestDriven.Abstracts.Stats;
using TestDriven.EditTests.Helpers;
using TestDriven.Concretes.Managers;
using TestDriven.Abstracts.Movements;
using TestDriven.Abstracts.Managers;

namespace MovementTests
{
    public class player_movement
    {
        private IPlayerController GetPlayer()
        {
           var playerController =  EditModeHelper.GetPlayerController();
            playerController.Stats.MoveSpeed.Returns(5f);

            return playerController;
        }

        private IMovementService GetMovementManager(IPlayerController playerController, IMoverDal moverDal)
        {
            var moveManager = new PlayerMoveManager(playerController, moverDal );
            return moveManager;
        }


        [Test]
        [TestCase(1f)]
        [TestCase(-1f)]
        // RIGHT
        public void move_10_meters_right_or_left_different_from_start_position(float horizontalInputValue)
        {
            // Arrange
            var playerController = GetPlayer();
            var moveDal = Substitute.For<IMoverDal>();
            var movementManager = GetMovementManager(playerController,moveDal);
            // Act
            playerController.InputReader.Horizontal.Returns(horizontalInputValue);
            playerController.Stats.MoveSpeed.Returns(5f);
            float inputValue =  playerController.InputReader.Horizontal * playerController.Stats.MoveSpeed * Time.deltaTime;
            for (int i = 0; i <= 10; i++)
            {
                movementManager.Tick();//input
                movementManager.FixedTick(); //action
            }
            // Assert
            moveDal.Received().MoveAction(inputValue);
        }
        [Test]

        // RIGHT
        public void move_10_meters_right_greater_than_start_position()
        {
            // Arrange
            var playerController = GetPlayer();
            var moveDal = Substitute.For<IMoverDal>();
            var movementManager = GetMovementManager(playerController,moveDal);
            // Act
            playerController.InputReader.Horizontal.Returns(1f);
            playerController.Stats.MoveSpeed.Returns(5f);
            float inputValue =  playerController.InputReader.Horizontal * playerController.Stats.MoveSpeed * Time.deltaTime;
            for (int i = 0; i <= 10; i++)
            {
                movementManager.Tick();//input
                movementManager.FixedTick(); //action
            }

            // Assert
            moveDal.Received().MoveAction(inputValue);
        }


        [Test]
        // Left
        public void move_10_meters_left_greater_than_start_position()
        {
            // Arrange
            var playerController = GetPlayer();
            var moveDal = Substitute.For<IMoverDal>();
            var movementManager = GetMovementManager(playerController,moveDal);
            // Act
            playerController.InputReader.Horizontal.Returns(-1f);
            playerController.Stats.MoveSpeed.Returns(5f);
            float inputValue =  playerController.InputReader.Horizontal * playerController.Stats.MoveSpeed * Time.deltaTime;
            for (int i = 0; i <= 10; i++)
            {
               movementManager.Tick();//input
                movementManager.FixedTick(); //action
            }

            // Assert
            moveDal.Received().MoveAction(inputValue);
        }

        [Test]
        public void dont_move_when_input_value_equal_zero()
        {
            // Arrange
            var playerController = GetPlayer();
            var moveDal = Substitute.For<IMoverDal>();
            var movementManager = GetMovementManager(playerController,moveDal);
            // Act
            playerController.InputReader.Horizontal.Returns(0f);
            playerController.Stats.MoveSpeed.Returns(5f);
            float inputValue =  playerController.InputReader.Horizontal * playerController.Stats.MoveSpeed * Time.deltaTime;
            for (int i = 0; i <= 10; i++)
            {
               movementManager.Tick();//input
                movementManager.FixedTick(); //action
            }

            // Assert
            moveDal.DidNotReceive().MoveAction(inputValue);
        }
    }
}
