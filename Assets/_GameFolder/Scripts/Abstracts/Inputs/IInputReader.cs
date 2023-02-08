using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputReader
{
    float Horizontal {get;}
    bool Jump { get; }
}