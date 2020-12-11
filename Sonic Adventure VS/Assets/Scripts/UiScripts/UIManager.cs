using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameManager
    {
    public class UIManager : MonoBehaviour
    {
        public LevelTracker _tracker;
        [SerializeField] private Text _displayTimeText;
        [SerializeField] private Text _displayRingText;
        [SerializeField] private Text _displayLifeText;

        void Update()
        {
            _displayLifeText.text = FormatLives(_tracker._playerCharacter.GetComponent<SonicTracker>().lifeCount);
            _displayRingText.text = FormatRings(_tracker._playerCharacter.GetComponent<SonicTracker>().ringCount);
            _displayTimeText.text = _tracker.timeText;
        }
        private string FormatRings(int rings)
        {
            return string.Format("{0:000}", rings);
        }
        private string FormatLives(int lives)
        {
            return string.Format("{0:00}", lives);
        }
    }
}
