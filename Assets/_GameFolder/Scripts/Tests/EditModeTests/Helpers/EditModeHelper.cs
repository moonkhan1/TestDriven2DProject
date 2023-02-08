using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using TestDriven.Abstracts.Stats;
using UnityEngine;


namespace TestDriven.EditTests.Helpers
{
    public class EditModeHelper
    {
        public static IPlayerController GetPlayerController()
        {
            IPlayerController playerController = Substitute.For<IPlayerController>();
            GameObject gameObject = new GameObject();
            playerController.transform.Returns(gameObject.transform);
            playerController.InputReader = Substitute.For<IInputReader>();
            playerController.Stats.Returns(Substitute.For<IPlayerStats>());

            return playerController;
        }
    }
}