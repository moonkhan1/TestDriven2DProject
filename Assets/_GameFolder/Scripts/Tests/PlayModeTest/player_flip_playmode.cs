using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using NSubstitute;
using UnityEngine.TestTools;
using System.Collections;
using UnityEngine.SceneManagement;
namespace MovementTests
{
    public class player_flip_playmode
    {
        IPlayerController _playerController;
        private IEnumerator LoadPlayerModeTestScene()
        {
            yield return SceneManager.LoadSceneAsync("PlayerMovementTests");
        }

        [UnitySetUp] // Setup, bu script daxilindeki her test ise duserken, 1 defe ise dus demekdir
        IEnumerator Setup()
        {
            yield return LoadPlayerModeTestScene();
            _playerController = GameObject.FindObjectOfType<PlayerController>();
            _playerController.InputReader = Substitute.For<IInputReader>();
        }

        [UnityTest]
        [TestCase(1f, ExpectedResult = (IEnumerator)null)]
        [TestCase(-1f, ExpectedResult = (IEnumerator)null)]
        public IEnumerator player_scale_x_flip_with_one_or_minus_one(float horizontalInput)
        {
            //Act
            _playerController.InputReader.Horizontal.Returns(horizontalInput);
            yield return new WaitForSeconds(3f);

            //Assert
            Assert.AreEqual(horizontalInput, _playerController.transform.GetChild(0).localScale.x);
        }

        [UnityTest]
        [TestCase(1f, ExpectedResult = (IEnumerator)null)]
        [TestCase(-1f, ExpectedResult = (IEnumerator)null)]
        public IEnumerator player_scale_x_flip_when_value_become_zero(float horizontalInput)
        {
            
            //Arrange
            float firstInputValue = horizontalInput;
            //Act
            _playerController.InputReader.Horizontal.Returns(horizontalInput);
            yield return new WaitForSeconds(3f);

            horizontalInput = 0f;
            _playerController.InputReader.Horizontal.Returns(horizontalInput);

            yield return new WaitForSeconds(3f);

            //Assert
            Assert.AreEqual(firstInputValue, _playerController.transform.GetChild(0).transform.localScale.x);
        }
    }
}