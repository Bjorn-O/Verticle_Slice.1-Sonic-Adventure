using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public class LevelTracker : MonoBehaviour
    {
        [SerializeField] public GameObject _playerCharacter;

        private string _timeText;
        public string timeText{
            set{
                _timeText = timeText;
            }
            get{
                return _timeText;
            }
        }
        float _time;
        float _checkPointTime;

        void Start()
        {
            _playerCharacter = GameObject.FindGameObjectWithTag("Sonic");
        }
        void Update()
        {
            _time += Time.deltaTime;
            TimeFormatter(_time);            
        }

        void TimeFormatter(float fTime)
        {
            int intTime = (int)fTime;
            int minutes = intTime / 60;
            int seconds = intTime % 60;
            float fraction = fTime * 1000;
            fraction = fraction % 1000;
            _timeText = string.Format ("{0:00} : {1:00} : {2:00}", minutes, seconds, fraction/10);
        }
    }
}
