using System.Collections;
using System.Collections.Generic;
using TestDriven.Abstracts.Stats;
using UnityEngine;


namespace TestDriven.Concretes.Stats
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "TestDriven/Stats/PlayerStats")]
    public class PlayerStats : StatsBase, IPlayerStats
    {
        [SerializeField] float _jumpForce = 15000f;
        public float JumpForce => _jumpForce;

    }
}