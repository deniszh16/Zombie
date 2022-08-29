﻿using UnityEngine;
using UnityEngine.UI;
using Cubra.Helpers;

namespace Cubra
{
    public class ZombieStats : MonoBehaviour
    {
        [Header("Количество игр")]
        [SerializeField] private Text _played;

        [Header("Количество поражений")]
        [SerializeField] private Text _loss;

        // Объект для работы со статистикой по персонажу
        public ZombieHelper ZombieHelper { get; private set; } = new ZombieHelper();

        private void Awake()
        {
            var number = gameObject.GetComponent<Zombie>().Number;
            ZombieHelper = JsonUtility.FromJson<ZombieHelper>(PlayerPrefs.GetString("character-" + number));
        }

        /// <summary>
        /// Обновление статистики по персонажу
        /// </summary>
        public void UpdateStatistics()
        {
            _played.gameObject.SetActive(true);
            _played.GetComponent<TextTranslation>().TranslateText();
            _played.text += " " + ZombieHelper.Played;

            _loss.gameObject.SetActive(true);
            _loss.GetComponent<TextTranslation>().TranslateText();
            _loss.text += " " + ZombieHelper.Deaths;
        }
    }
}