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

    }
}