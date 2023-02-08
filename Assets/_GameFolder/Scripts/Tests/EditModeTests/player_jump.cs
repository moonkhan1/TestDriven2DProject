using NSubstitute;
using NUnit.Framework;
using TestDriven.Abstracts.Movements;
using TestDriven.Concretes.Managers;
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
            IJumpDal jumpDal = Substitute.For<IJumpDal>();
            var playerJumpManager = new PlayerJumpManager(player, jumpDal);

            player.InputReader.Jump.Returns(true);
            player.JumpManager.Tick();
            player.JumpManager.FixedTick(); 
            jumpDal.Received().JumpProcess();
        }

        [Test]
        public void player_cant_jump_one_time_when_canJump_false()
        {
            var player = EditModeHelper.GetPlayerController();
            IJumpDal jumpDal = Substitute.For<IJumpDal>();
            var playerJumpManager = new PlayerJumpManager(player, jumpDal);

            player.InputReader.Jump.Returns(false);
            player.JumpManager.Tick();
            player.JumpManager.FixedTick(); 
            jumpDal.DidNotReceive().JumpProcess();
        }
    }
}