using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestDriven.Abstracts.Movements
{
    public interface IJump
    {
        void Tick();
        void FixedTick();
    }
}