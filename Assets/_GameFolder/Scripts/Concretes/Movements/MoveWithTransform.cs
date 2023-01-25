using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithTransform : IMover
{
    readonly IPlayerController _playerController;
    readonly Transform _transform;
    float _horizontalInput = 0f;
    float _moveSpeed = 1f;
    public MoveWithTransform(IPlayerController playerController)
    {
        _playerController = playerController;
        _transform = playerController.transform;
    }
    public void MoveAction()
    {
        _horizontalInput = _playerController.InputReader.Horizontal;
    }

    public void TakeInputAction()
    {
        _transform.Translate(Vector3.right *_horizontalInput * (_moveSpeed * Time.deltaTime));
    }
}
