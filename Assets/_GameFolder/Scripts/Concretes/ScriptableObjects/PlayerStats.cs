using System.Collections;
using System.Collections.Generic;
using TestDriven.Abstracts.Stats;
using UnityEngine;


namespace TestDriven.Concretes.Stats
{
    [CreateAssetMenu(fileName = "PlayerStats", menuName = "TestDriven/Stats/PlayerStats")]
    public class PlayerStats : ScriptableObject, IPlayerStats
    {
        [Header("Move Infoes")]
        [SerializeField] float _moveSpeed = 5f;
        public float MoveSpeed => _moveSpeed;
    }
}