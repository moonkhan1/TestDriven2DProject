using NUnit.Framework;
using UnityEngine;
using NSubstitute;
using UnityEngine.TestTools;
using System.Collections;
using UnityEngine.SceneManagement;

namespace MovementTests
{

    public class player_movement_playmodetest
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
        public IEnumerator player_move_right_or_left_different_from_start_position(float inputValue)
        {
            // Arrange

            // Method 1
            // GameObject playerObject = new GameObject("Player");
            // var playerController = playerObject.AddComponent<PlayerController>();

            //Method 2
            // yield return LoadPlayerModeTestScene();
           
            Vector3 startPosition = _playerController.transform.position;

            // Act
            _playerController.InputReader.Horizontal.Returns(inputValue);
            yield return new WaitForSeconds(3f);
            // Assert
            Assert.AreNotEqual(startPosition, _playerController.transform.position);
        }

        [UnityTest]
        public IEnumerator player_move_right_greater_than_start_position()
        {
            // Arrange
            Vector3 startPosition = _playerController.transform.position;

            //Act
            _playerController.InputReader.Horizontal.Returns(1f);
            yield return new WaitForSeconds(3f);

            //Assert
            Assert.Greater(_playerController.transform.position.x, startPosition.x);
        }

         [UnityTest]
        public IEnumerator player_move_left_greater_than_start_position()
        {
            // Arrange
            Vector3 startPosition = _playerController.transform.position;

            //Act
            _playerController.InputReader.Horizontal.Returns(-1f);
            yield return new WaitForSeconds(3f);

            //Assert
            Assert.Less(_playerController.transform.position.x, startPosition.x);
        }
    }
}