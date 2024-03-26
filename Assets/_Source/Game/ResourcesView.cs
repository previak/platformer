using System;
using System.Collections;
using System.Collections.Generic;
using _Source.Core;
using TMPro;
using UnityEngine;

namespace _Source.Game
{
    public class ResourcesView : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        [SerializeField] private GameObject stat;
        private TMP_Text _tmpText;

        private void Start()
        {
            _tmpText = GetComponent<TMP_Text>();
        }

        public void Update()
        {
            if (stat.CompareTag("Coin"))
            {
                _tmpText.text = playerData.GetCoins().ToString();
            }
            if (stat.CompareTag("Heart"))
            {
                _tmpText.text = playerData.GetHealthPoints().ToString();
            }
        }
    }
}

