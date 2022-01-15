using System.Collections;
using System.Collections.Generic;
using Game.hmm.ScriptableObjects;
using UnityEngine;
using UnityEngine.Events;

namespace Game.hmm.Unit
{
    public class UnitComponent : MonoBehaviour
    {
        [Header("Data")]
        public int playerIdx;
        public int health { get; private set; }

        [SerializeField] private int _Count;
        public int Count
        {
            get => _Count;
            set
            {
                _Count = value;

                onCountChanged.Invoke();
            }
        }

        [Header("Stats")]
        public UnitBaseStats baseStats;

        [Header("Events")]
        public UnityEvent onCountChanged;
        public UnityEvent onDead;

        public void Damage(int amount)
        {
            health -= amount;
            if (health <= 0)
            {
                onDead.Invoke();

                return;
            }

            Count = health / baseStats.health;
        }
    }
}