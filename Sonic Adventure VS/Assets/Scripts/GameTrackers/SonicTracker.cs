using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public class SonicTracker : MonoBehaviour
    {
        [SerializeField] AudioSource[] _soundEffects;
        [SerializeField] GameObject _droppedRing;
        private int _ringCount;
        public int ringCount{
            get{
                return _ringCount;
            }
            set{
                if (value < 0)
                {
                    DropRings(_ringCount);
                }
                _ringCount += value;
                _ringsToExtraLife += value;
            }
        }
        private int _ringsToExtraLife{
            get{
                return _ringsToExtraLife;
            }
            set{
                _ringsToExtraLife += value;
                if (_ringsToExtraLife >= 100)
                {
                    lifeCount++;
                    _ringsToExtraLife -= 100;
                } else if (_ringsToExtraLife < 0)
                {
                    _ringsToExtraLife = 0;
                }
            }
        }
        private int _lifeCount;
        public int lifeCount{
            get{
                return _lifeCount;
            }
            set{
                switch (value)
                {
                    case 1:
                        _lifeCount += value;
                        _soundEffects[0].Play();
                        break;
                    case -1:
                        if (_lifeCount == 0)
                        {
                            // Call onto LevelTracker.GameOver();
                        }
                        _lifeCount += value;
                        break;
                    default:
                    break;
                }
            }
        }

        void GetHurt()
        {
            if (ringCount > 0)
            {
                DropRings(ringCount);
            }
            else
            {
                PlayerDeath();
            }
        }

        void DropRings(int ringsDropped)
        {
            // Check if the amount of rings is above 20
            // If not, calculate 360/ringcount to get the angle of firing in a circle.
            // Instantiate the amount of rings each in their own direction
            // Note to self, how do I instantly instantiate each ring in a different direction with force? Maybe put force in the awake function but that won't help the direction.
        }

        void PlayerDeath()
        {
            // Call onto LevelTracker.Respawn
        }
    }
}
