using System;
using UnityEngine;

namespace _Source.Core
{
    public class PlayerData : MonoBehaviour
    {
        [SerializeField] private int coins = 0;
        [SerializeField] private int hp = 0;
        [SerializeField] private int maxHp = 0;
    }
}
