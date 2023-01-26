using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using NSubstitute;

namespace MovementTests
{
    public class player_flip : MonoBehaviour
    {

        private IPlayerController GetPlayer(float horizontalInput)
        {
            IPlayerController playerController = Substitute.For<IPlayerController>();
            GameObject parent = new GameObject();
            GameObject body = new GameObject();
            body.transform.SetParent(parent.transform);
            playerController.transform.Returns(parent.transform);
            playerController.InputReader.Returns(Substitute.For<IInputReader>());
            playerController.InputReader.Horizontal.Returns(horizontalInput);

            return playerController;
        }
        [Test]
        [TestCase(1f)]
        [TestCase(-1f)]
        public void player_scale_x_flip_with_one_or_minus_one(float horizontalInput)
        {
            //Arrange
            var playerController = GetPlayer(horizontalInput);
            IFlip flip = new PlayerFlipWithScale(playerController);

            //Act
            for (int i = 0; i < 10; i++)
            {
                flip.FlipAction();
            }

            //Assert
            Assert.AreEqual(horizontalInput, playerController.transform.GetChild(0).localScale.x);
        }


        [Test]
        [TestCase(1f)]
        [TestCase(-1f)]
        public void player_scale_x_flip_when_value_become_zero(float horizontalInput)
        {
            //Arrange
            var playerController = GetPlayer(horizontalInput);
            
            IFlip flip = new PlayerFlipWithScale(playerController);
            float firstInputValue = horizontalInput;
            //Act
            for (int i = 0; i < 10; i++)
            {
                flip.FlipAction();
            }

            horizontalInput = 0f;
            playerController.InputReader.Horizontal.Returns(horizontalInput);

            for (int i = 0; i < 3; i++)
            {
                flip.FlipAction();
            }

            //Assert
            Assert.AreEqual(horizontalInput, playerController.transform.GetChild(0).localScale.x);
        }
    }
}