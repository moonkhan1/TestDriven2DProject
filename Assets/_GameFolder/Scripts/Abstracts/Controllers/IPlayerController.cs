using System.Collections;
using System.Collections.Generic;
using TestDriven.Abstracts.Stats;
using UnityEngine;

public interface IPlayerController : IEntityController
{
    IInputReader InputReader {get; set;}
    IPlayerStats Stats {get;}
    IHealth Health { get; }
}
