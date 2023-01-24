using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerController : IEntityController
{
    IInputReader InputReader {get; set;}
}
