using NUnit.Framework;
using UnityEngine;
using NSubstitute;
using UnityEngine.TestTools;
using System.Collections;
using UnityEngine.SceneManagement;

namespace MovementTests
{

    public class enemy_movement_playmodetest 
    {
        
        IEnemyController _enemyController;
        private IEnumerator LoadEnemyModeTestScene()
        {
            yield return SceneManager.LoadSceneAsync("EnemyMovementTests");
        }

        [UnitySetUp] // Setup, bu script daxilindeki her test ise duserken, 1 defe ise dus demekdir
        IEnumerator Setup()
        {
             yield return LoadEnemyModeTestScene();
            _enemyController = GameObject.FindObjectOfType<EnemyController>();
        }

        [UnityTest]
        [TestCase(1f, ExpectedResult = (IEnumerator)null)]
        [TestCase(-1f, ExpectedResult = (IEnumerator)null)]
        public IEnumerator enemy_move_right_or_left_different_from_start_position(float inputValue)
        {
           //Arrange

            float startPositionX = _enemyController.transform.position.x;
            
            // Act
            _enemyController.IsEnemyDirectedToRight = inputValue == 1f;
            
            yield return new WaitForSeconds(1f);

            Vector3 startPosition = new Vector3(startPositionX, _enemyController.transform.position.y, 
            _enemyController.transform.position.z);
            _enemyController.transform.position = startPosition;
            
            yield return new WaitForSeconds(3f);
            // Assert
            if(inputValue < 0)
                Assert.Less(_enemyController.transform.position.x, startPositionX);
            else if(inputValue > 0)
                Assert.Greater(_enemyController.transform.position.x, startPositionX);
        }
    }
}