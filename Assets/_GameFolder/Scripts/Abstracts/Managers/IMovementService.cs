using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestDriven.Abstracts.Managers
{
    public interface IMovementService
    {
        void Tick();
        void FixedTick();
    }
}