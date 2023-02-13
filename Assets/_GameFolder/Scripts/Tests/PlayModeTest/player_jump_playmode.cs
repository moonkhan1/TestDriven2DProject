using NSubstitute;
using NUnit.Framework;
using UnityEngine.TestTools;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TestDriven.PlayTests.Helpers;

namespace MovementTests
{
    public class player_jump_playmode
    {
        [UnityTest]
        public IEnumerator player_jump_one_time()
        {
            yield return SceneManager.LoadSceneAsync("PlayerMovementTests");
            var player = GameObject.FindObjectOfType<PlayerController>();
            player.InputReader = Substitute.For<IInputReader>();

            yield return null;
            float ystartPosition = player.transform.position.y;
            player.InputReader.Jump.Returns(true);
            yield return null;
            player.InputReader.Jump.Returns(false);

            yield return new WaitForSeconds(0.5f);
            Assert.Greater(player.transform.position.y, ystartPosition);
        }

        // [UnityTest]
        // public IEnumerator player_jump_one_time_despite_input_taken_many_times()
        // {
        //     yield return SceneManager.LoadSceneAsync("PlayerMovementTests");
        //     var player = GameObject.FindObjectOfType<PlayerController>();
        //     player.InputReader = Substitute.For<IInputReader>();
        //     GroundDisableHelper groundDisableHelper = GameObject.FindObjectOfType<GroundDisableHelper>();

        //     yield return null;
        //     float ystartPosition = player.transform.position.y;
        //     player.InputReader.Jump.Returns(true);
        //     yield return null;
        //     groundDisableHelper.SetDisableCollider();
            
        //     yield return new WaitForSeconds(1.5f);
        //     Assert.Less(player.transform.position.y, ystartPosition);
        // }


        [UnityTest]
        public IEnumerator player_jump_one_time_wait_before_jump_again()
        {
            yield return SceneManager.LoadSceneAsync("PlayerMovementTests");
            var player = GameObject.FindObjectOfType<PlayerController>();
            player.InputReader = Substitute.For<IInputReader>();

            yield return null;
            float ystartPosition = player.transform.position.y;
            player.InputReader.Jump.Returns(true);
            yield return null;
            player.InputReader.Jump.Returns(false);
            
            yield return new WaitForSeconds(2f);

            player.InputReader.Jump.Returns(true);
            yield return null;
            player.InputReader.Jump.Returns(false);
            
            yield return new WaitForSeconds(0.5f);
            
            Assert.Greater(player.transform.position.y, ystartPosition);
        }
    }
}