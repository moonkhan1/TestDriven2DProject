using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using NSubstitute;

namespace CombatTests
{
    public class health_edit_mode_test
    {
        IAttacker _attacker;

        [SetUp]  // Setup, bu script daxilindeki her test ise duserken, 1 defe ise dus demekdir
        public void Setup()
        {
            _attacker = Substitute.For<IAttacker>();
        }
        private IHealth GetHealth(int maxHealth)
        {
            Health health = new Health(maxHealth);
            return health;
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        public void take_damage_not_equal_to_max_health(int damageValue)
        {
            // Arragne
            int maxHealth = 1;
            var health = GetHealth(maxHealth);

            // Act
            _attacker.Damage.Returns(damageValue);
            health.TakeDamage(_attacker);
            // Assert
            Assert.AreNotEqual(maxHealth, health.CurrnetHealth);
        }


        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        public void take_damage_current_health_not_less_than_0(int damageValue)
        {
            // Arragne
            int maxHealth = 1;
            var health = GetHealth(maxHealth);

            // Act
            _attacker.Damage.Returns(damageValue);
            health.TakeDamage(_attacker);
            // Assert
            Assert.GreaterOrEqual(health.CurrnetHealth, 0);
        }

        [Test]
        public void trigger_event_when_take_damage_one_time()
        {
            // Arrange
            var health = GetHealth(5);
            
            //Act
            _attacker.Damage.Returns(1);
            string message = string.Empty;
            health.OnTakeDamage += () => message = "On Took Damage Event Triggered";
            health.TakeDamage(_attacker);

            //Assert
            Assert.AreNotEqual(string.Empty, message);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        public void trigger_event_when_damage_taken_many_time(int loopValue)
        {
            // Arrange
            int maxHealth = 100;
            var health = GetHealth(maxHealth);
            int damageLoop = loopValue;

            //Act
            _attacker.Damage.Returns(1);
            int damageCounter = loopValue;
            health.OnTakeDamage += () => damageCounter++;
            for (int i = 0; i < damageLoop; i++)
            {
                
            health.TakeDamage(_attacker);
            }

            //Assert
            Assert.AreEqual(damageCounter, damageCounter);
        }

        [Test]
        public void trigger_event_when_fatally_damaged()
        {
            // Arrange
            int maxHealth = 100;
            var health = GetHealth(maxHealth);
            
            //Act
            _attacker.Damage.Returns(maxHealth + 1);
            string message = string.Empty;
            health.OnDead += () => message = "On Dead Event Triggered";
            health.TakeDamage(_attacker);

            //Assert
            Assert.AreNotEqual(string.Empty, message);
        }

        [Test]
        public void take_damage_without_triggering_dead_event()
        {
            // Arrange
            int maxHealth = 100;
            var health = GetHealth(maxHealth);
            
            //Act
            _attacker.Damage.Returns(maxHealth / 2);
            string expectedMessage = "Dead Event Not Triggered";
            string message = expectedMessage;
            health.OnDead += () => message = "On Dead Event Triggered";
            health.TakeDamage(_attacker);

            //Assert
            Assert.AreEqual(expectedMessage, message);
        }

        [Test]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        public void trigger_take_damage_event_one_time_despite_fatal_damage_taken_many_times(int loopValue)
        {
            // Arrange
            int maxHealth = 100;
            var health = GetHealth(maxHealth);
            
            int damageLoop = loopValue;

            //Act
            _attacker.Damage.Returns(maxHealth + 1);
            int damageCounter = 0;
            health.OnTakeDamage += () => damageCounter++;
            for (int i = 0; i < damageLoop; i++)
            {
                health.TakeDamage(_attacker);
            }

            //Assert
            Assert.AreEqual(1, damageCounter);
        }
    }
}