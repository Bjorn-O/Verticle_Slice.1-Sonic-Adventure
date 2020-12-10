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
                _ringCount = value;
            }
        }
        private int _ringsToExtraLife;
        public int ringsToExtraLife{
            get{
                return _ringsToExtraLife;
            }
            set{
                _ringsToExtraLife = value;
            }
        }
        private int _lifeCount = 4;
        public int lifeCount{
            get{
                return _lifeCount;
            }
            set{
                _lifeCount = value;
            }
        }
        private float _angle;
        public void setRings(int value)
        {
            ringCount += value;
            ringsToExtraLife += value;
            print(ringsToExtraLife);
            if (ringsToExtraLife >= 100)
            {
                ringsToExtraLife -= 100;
                SetLife(1);
            } else if (ringsToExtraLife < 0)
            {
                ringsToExtraLife = 0;
            }
        }
        void SetLife(int value)
        {
            if (value > 0)
            {
                _soundEffects[0].Play();
            }
            lifeCount += value;
            if (lifeCount < 0)
            {
                //Initiate Game-over
            }
        }
        public void GetHurt()
        {
            if (ringCount > 0)
            {
                DropRings(ringCount);
            }
            else
            {
                SetLife(-1);
                //Initiate Respawn
            }
        }
        void DropRings(int ringsDropped)
        {
            if (ringsDropped > 20)
            {
                ringsDropped = 20;
            }
            setRings(-ringCount);
            float launchAngle = 360 / ringsDropped;
            for (int i = 0; i < ringsDropped; i++)
            {
                Instantiate(_droppedRing, transform.position, Quaternion.Euler(0,_angle,0));
                _angle += launchAngle;
            }
        }
    }
}
