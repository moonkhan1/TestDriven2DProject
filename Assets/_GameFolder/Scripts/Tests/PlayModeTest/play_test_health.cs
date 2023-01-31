using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using NSubstitute;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

namespace CombatTests
{
    public class play_test_health
    {
        IPlayerController _player;
        IEnemyController _enemy;
        IStats _enemyStats;

        [UnitySetUp]
        public IEnumerator Setup()
        {
            yield return SceneManager.LoadSceneAsync("CombatTest");

            _player = GameObject.FindObjectOfType<PlayerController>();
            _enemy = GameObject.FindObjectOfType<EnemyController>();
            _enemyStats = Substitute.For<IStats>();
        }


        [UnityTest]
        [TestCase(1, ExpectedResult = (IEnumerator)null)]
        [TestCase(2, ExpectedResult = (IEnumerator)null)]
        [TestCase(5, ExpectedResult = (IEnumerator)null)]
        [TestCase(10, ExpectedResult = (IEnumerator)null)]

        public IEnumerator player_take_one_damage_in_one_time(int damageValue)
        {
            
            _enemyStats.Damage.Returns(damageValue);
            _enemy.Attacker = new Attacker(_enemyStats);
            int maxHealth = _player.Health.CurrnetHealth;
            Vector3 playerPosition = _player.transform.position;
            _enemy.transform.position = playerPosition;

            yield return new WaitForSeconds(1f);

            Assert.AreEqual(maxHealth - damageValue, _player.Health.CurrnetHealth);

        }

        [UnityTest]
        [TestCase(0f, 1f, ExpectedResult = (IEnumerator)null)] // up
        [TestCase(1f, 0f, ExpectedResult = (IEnumerator)null)] // right
        [TestCase(-1f, 0f, ExpectedResult = (IEnumerator)null)] // left 

        public IEnumerator player_take_one_damage_from_left_up_right_sides(float x, float y)
        {
            
            Vector3 attackPosition = new Vector3(x, y, 0f);
            int damageValue = 1;
            _enemyStats.Damage.Returns(damageValue);
            int maxHealth = _player.Health.CurrnetHealth;
            Vector3 playerNearestPosition = _player.transform.position + (attackPosition / 2f);
            _enemy.transform.position = playerNearestPosition;

            yield return new WaitForSeconds(1f);

            Assert.AreEqual(maxHealth - damageValue, _player.Health.CurrnetHealth);

        }


        [UnityTest] // Player asagi terefden damage almamalidir
        public IEnumerator player_take_no_damage_from_down_side()
        {
            
            _enemyStats.Damage.Returns(1);
            int maxHealth = _player.Health.CurrnetHealth;
            Vector3 playerNearestPosition = _player.transform.position + (Vector3.down / 2f);
            _enemy.transform.position = playerNearestPosition;

            yield return new WaitForSeconds(1f);

            Assert.AreEqual(maxHealth, _player.Health.CurrnetHealth);

        }

    }
}