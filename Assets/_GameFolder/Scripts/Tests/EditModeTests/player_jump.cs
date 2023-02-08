using NSubstitute;
using NUnit.Framework;
using TestDriven.Concretes.Movemenets;
using TestDriven.EditTests.Helpers;
using UnityEngine;

namespace MovementTests
{
    public class player_jump
    {
        [Test]
        public void player_jump_one_time_when_canJump_true()
        {
            var player = EditModeHelper.GetPlayerController();
            player.Stats.JumpForce.Returns(1000f);
            player.transform.gameObject.AddComponent<Rigidbody2D>();
            var playerJump = new PlayerJumpWithForce(player);

            float startForce = playerJump.JumpForce;

            for (int i = 0; i < 50; i++)
            {
                player.InputReader.Jump.Returns(true);
                playerJump.Tick();
                playerJump.FixedTick();
            }
            Assert.Greater(playerJump.JumpForce, startForce);
        }

        [Test]
        public void player_cant_jump_one_time_when_canJump_false()
        {
            var player = EditModeHelper.GetPlayerController();
            player.Stats.JumpForce.Returns(1000f);
            player.transform.gameObject.AddComponent<Rigidbody2D>();
            var playerJump = new PlayerJumpWithForce(player);

            float startForce = playerJump.JumpForce;

            for (int i = 0; i < 50; i++)
            {
                player.InputReader.Jump.Returns(false);
                playerJump.Tick();
                playerJump.FixedTick();
            }
            Assert.AreEqual(startForce, playerJump.JumpForce);
        }
    }
}