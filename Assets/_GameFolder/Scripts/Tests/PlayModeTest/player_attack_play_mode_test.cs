using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using NSubstitute;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;


namespace CombatTests
{

    public class player_attack_play_mode_test
    {
        IPlayerController _player;
        IEnemyController _enemy;

        [UnitySetUp]
        public IEnumerator SetUps()
        {
            yield return SceneManager.LoadSceneAsync("CombatTest");
            _enemy = GameObject.FindObjectOfType<EnemyController>();
            _player = GameObject.FindObjectOfType<PlayerController>();
        }

        [UnityTest]
        public IEnumerator player_attack_one_time()
        {
            //Arrange
            
            int enemyStartHealth = _enemy.Health.CurrnetHealth;
            //Act
            Vector3 enemyPosition = _enemy.transform.position + Vector3.up;
            _player.transform.position = enemyPosition;
            //Assert
            yield return new WaitForSeconds(1f);
            Assert.AreNotEqual(enemyStartHealth, _enemy.Health.CurrnetHealth);

        }

        [UnityTest]
        [TestCase(-1f, 0f, ExpectedResult = (IEnumerator)null)]
        [TestCase(1f, 0f, ExpectedResult = (IEnumerator)null)]
        [TestCase(0f, -1f, ExpectedResult = (IEnumerator)null)]
        public IEnumerator player_attack_can_not_attack_from_left_down_right_sides(float x, float y)
        {
            //Arrange
            
            int enemyStartHealth = _enemy.Health.CurrnetHealth;
            //Act
            Vector3 direction = new Vector3(x, y ,0f);
            Vector3 enemyPosition = _enemy.transform.position + (direction / 2f);
            _player.transform.position = enemyPosition;
            //Assert
            yield return new WaitForSeconds(1f);
            Assert.AreEqual(enemyStartHealth, _enemy.Health.CurrnetHealth);

        }
    }
}
