using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public class LevelTracker : MonoBehaviour
    {
        [SerializeField] CheckPoint _lastCheckPoint;
        [SerializeField] GameObject _playerCharacter;
        [SerializeField] Transform _startLocation;
        public CheckPoint lastCheckPoint
        {
            get {
                return _lastCheckPoint;
            }
            set {
                _lastCheckPoint = value;
                _checkPointTime = _time;
                //Make the _checkPointTime flash in the UI
            }
        }
        
        private string _timeText;
        public string timeText{
            get{
                return _timeText;
            }
        }
        float _time;
        float _checkPointTime;

        void Start()
        {
            _playerCharacter = Instantiate(_playerCharacter, _startLocation.position, Quaternion.identity);
            //Transition screen
            //Give player control of Sonic

        }
        void Update()
        {
            _time += Time.deltaTime;
            TimeFormatter(_time);            
        }

        void Respawn()
        {
            // Take control away from _playerCharacter
            // Transition screen to black
            // Turn off the timer
            // Set the time to _checkPointTime
            // Fade the screen back in
            // Give player Control of _playerCharacter
            // Start the timer
        }

        void TimeFormatter(float fTime)
        {
            int intTime = (int)fTime;
            int minutes = intTime / 60;
            int seconds = intTime % 60;
            float fraction = fTime * 1000;
            fraction = fraction % 1000;
            _timeText = string.Format ("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction);
        }
    }
}
