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
            float startPositionX = _playerController.transform.position.x;
            yield return new WaitForSeconds(3f);

            Vector3 startPosition = new Vector3(startPositionX, _playerController.transform.position.y, 
            _playerController.transform.position.z);
            _playerController.transform.position = startPosition;
            // Act
            _playerController.InputReader.Horizontal.Returns(inputValue);
            yield return new WaitForSeconds(3f);
            // Assert
            Assert.AreNotEqual(startPositionX, _playerController.transform.position.x);
        }

        [UnityTest]
        public IEnumerator player_move_right_greater_than_start_position()
        {
            // Arrange
            float startPositionX = _playerController.transform.position.x;
            yield return new WaitForSeconds(3f);

            Vector3 startPosition = new Vector3(startPositionX, _playerController.transform.position.y, 
            _playerController.transform.position.z);
            _playerController.transform.position = startPosition;

            //Act
            _playerController.InputReader.Horizontal.Returns(1f);
            yield return new WaitForSeconds(3f);

            //Assert
            Assert.Greater(_playerController.transform.position.x, startPositionX);
        }

         [UnityTest]
        public IEnumerator player_move_left_greater_than_start_position()
        {
            // Arrange
            float startPositionX = _playerController.transform.position.x;
            yield return new WaitForSeconds(3f);

            Vector3 startPosition = new Vector3(startPositionX, _playerController.transform.position.y, 
            _playerController.transform.position.z);
            _playerController.transform.position = startPosition;

            //Act
            _playerController.InputReader.Horizontal.Returns(-1f);
            yield return new WaitForSeconds(3f);

            //Assert
            Assert.Less(_playerController.transform.position.x, startPositionX);
        }
    }
}