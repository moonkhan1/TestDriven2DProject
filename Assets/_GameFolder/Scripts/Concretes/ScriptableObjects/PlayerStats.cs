using System.Collections;
using System.Collections.Generic;
using TestDriven.Abstracts.Stats;
using UnityEngine;


namespace TestDriven.Concretes.Stats
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "TestDriven/Stats/PlayerStats")]
    public class PlayerStats : StatsBase, IPlayerStats
    {
        public float JumpForce {get;}

    }
}