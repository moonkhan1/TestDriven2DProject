using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using NSubstitute;

public class player_movement
{
   [Test]
   // RIGHT
    public void move_10_meters_right_different_from_start_position()
    {
        // Arrange
        IPlayerController playerController = Substitute.For<IPlayerController>();
        GameObject gameObject = new GameObject();
        playerController.transform.Returns(gameObject.transform);
        playerController.InputReader = Substitute.For<IInputReader>();
        IMover mover = new MoveWithTransform(playerController);
        Vector3 startPosition = playerController.transform.position;
        // Act
        playerController.InputReader.Horizontal.Returns(1f);
        for (int i = 0; i <= 10; i++)
        {
            mover.TakeInputAction();
            mover.MoveAction();
        }
        Debug.Log("Player Start Position => " + startPosition);
        Debug.Log("Player End Position => " + playerController.transform.position);
        // Assert
        Assert.AreNotEqual(startPosition, playerController.transform.position);
    }
    [Test]
   // RIGHT
    public void move_10_meters_right_greater_than_start_position()
    {
        // Arrange
        IPlayerController playerController = Substitute.For<IPlayerController>();
        GameObject gameObject = new GameObject();
        playerController.transform.Returns(gameObject.transform);
        playerController.InputReader = Substitute.For<IInputReader>();
        IMover mover = new MoveWithTransform(playerController);
        Vector3 startPosition = playerController.transform.position;
        // Act
        playerController.InputReader.Horizontal.Returns(1f);
        for (int i = 0; i <= 10; i++)
        {
            mover.TakeInputAction();
            mover.MoveAction();
        }
        Debug.Log("Player Start Position => " + startPosition);
        Debug.Log("Player End Position => " + playerController.transform.position);
        // Assert
        Assert.Greater( playerController.transform.position.x, startPosition.x);
    }

    [Test]
   // Left
    public void move_10_meters_left_different_from_start_position()
    {
        // Arrange
        IPlayerController playerController = Substitute.For<IPlayerController>();
        GameObject gameObject = new GameObject();
        playerController.transform.Returns(gameObject.transform);
        playerController.InputReader = Substitute.For<IInputReader>();
        IMover mover = new MoveWithTransform(playerController);
        Vector3 startPosition = playerController.transform.position;
        // Act
        playerController.InputReader.Horizontal.Returns(-1f);
        for (int i = 0; i <= 10; i++)
        {
            mover.TakeInputAction();
            mover.MoveAction();
        }
        Debug.Log("Player Start Position => " + startPosition);
        Debug.Log("Player End Position => " + playerController.transform.position);
        // Assert
        Assert.AreNotEqual(startPosition, playerController.transform.position);
    }

    [Test]
   // Left
    public void move_10_meters_left_greater_than_start_position()
    {
        // Arrange
        IPlayerController playerController = Substitute.For<IPlayerController>();
        GameObject gameObject = new GameObject();
        playerController.transform.Returns(gameObject.transform);
        playerController.InputReader = Substitute.For<IInputReader>();
        IMover mover = new MoveWithTransform(playerController);
        Vector3 startPosition = playerController.transform.position;
        // Act
        playerController.InputReader.Horizontal.Returns(-1f);
        for (int i = 0; i <= 10; i++)
        {
            mover.TakeInputAction();
            mover.MoveAction();
        }
        Debug.Log("Player Start Position => " + startPosition);
        Debug.Log("Player End Position => " + playerController.transform.position);
        // Assert
        Assert.Less(playerController.transform.position.x, startPosition.x);
    }
}
