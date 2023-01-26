using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlipWithScale : IFlip
{

    IPlayerController _playerController;
    Transform _transform;

    public PlayerFlipWithScale(IPlayerController playerController)
    {
        _playerController = playerController;
        _transform = _playerController.transform.GetChild(0).transform;
    }
    public void FlipAction()
    {
        float horizontalInput = _playerController.InputReader.Horizontal;
        if(horizontalInput == 0f) return;
       _transform.localScale = new Vector3(horizontalInput,1f,1f);
    }

    
}
