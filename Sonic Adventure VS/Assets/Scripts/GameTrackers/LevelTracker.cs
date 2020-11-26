using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public class LevelTracker : MonoBehaviour
    {
        [SerializeField] CheckPoint _lastCheckPoint;
        public CheckPoint lastCheckPoint
        {
            get {
                return _lastCheckPoint;
            }
            set {
                _lastCheckPoint = value;
            }
        }
        
        [SerializeField] GameObject _playerCharacter;

        
        public string timeText;
        float _time;

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
            // Debug.Log(fraction);
            fraction = fraction % 1000;
            // Debug.Log(fraction);
            timeText = string.Format ("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
        }
    }
}
