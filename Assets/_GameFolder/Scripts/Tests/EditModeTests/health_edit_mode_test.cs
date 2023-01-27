using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using NSubstitute;

namespace CombatTests
{
    public class health_edit_mode_test
    {
        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        public void take_damage_not_equal_to_max_health(int damageValue)
        {
            // Arragne
            int maxHealth = 1;
            Health health = new Health(maxHealth);
            IAttacker attacker = Substitute.For<IAttacker>();

            // Act
            attacker.Damage.Returns(damageValue);
            health.TakeDamage(attacker);
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
            Health health = new Health(maxHealth);
            IAttacker attacker = Substitute.For<IAttacker>();

            // Act
            attacker.Damage.Returns(damageValue);
            health.TakeDamage(attacker);
            // Assert
            Assert.GreaterOrEqual(health.CurrnetHealth, 0);
        }

        [Test]
        public void trigger_event_when_take_damage_one_time()
        {
            // Arrange
            IHealth health = new Health(5);
            IAttacker attacker = Substitute.For<IAttacker>();
            
            //Act
            attacker.Damage.Returns(1);
            string message = string.Empty;
            health.OnTakeDamage += () => message = "On Took Damage Event Triggered";
            health.TakeDamage(attacker);

            //Assert
            Assert.AreNotEqual(string.Empty, message);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        public void trigger_event_when_take_damage_many_time(int loopValue)
        {
            // Arrange
            IHealth health = new Health(100);
            IAttacker attacker = Substitute.For<IAttacker>();
            int damageLoop = loopValue;

            //Act
            attacker.Damage.Returns(1);
            int damageCounter = loopValue;
            health.OnTakeDamage += () => damageCounter++;
            for (int i = 0; i < damageLoop; i++)
            {
                
            health.TakeDamage(attacker);
            }

            //Assert
            Assert.AreEqual(damageCounter, damageCounter);
        }

        [Test]
        public void trigger_event_when_fatally_damaged()
        {
            // Arrange
            int maxHealth = 100;
            IHealth health = new Health(maxHealth);
            IAttacker attacker = Substitute.For<IAttacker>();
            
            //Act
            attacker.Damage.Returns(maxHealth + 1);
            string message = string.Empty;
            health.OnTakeDamage += () => message = "On Dead Event Triggered";
            health.TakeDamage(attacker);

            //Assert
            Assert.AreNotEqual(string.Empty, message);
        }
    }
}