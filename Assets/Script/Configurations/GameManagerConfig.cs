﻿using PoketZone;
using UnityEngine;

namespace Script.Configurations
{
    [CreateAssetMenu(fileName = "GameManagerConfig", menuName = "Configurations/GameManagerConfig")]
    public class GameManagerConfig: ScriptableObject
    {
        [SerializeField] private Enemy _tamplate;
        [SerializeField] private float _delay;
        [SerializeField] private float _delayForRespawn;
        [SerializeField] int _count;

        public Enemy Tamplate => _tamplate;
        public float Delay => _delay;
        public float DelayForRespawn => _delayForRespawn;
        public int Count => _count;
        public Transform[] SpawnPoint { get; set; } 
    }
}
