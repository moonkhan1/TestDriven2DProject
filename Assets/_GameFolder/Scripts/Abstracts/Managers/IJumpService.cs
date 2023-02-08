using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TestDriven.Abstracts.Managers
{
    public interface IJumpService
    {
        void Tick();
        void FixedTick();
    }
}