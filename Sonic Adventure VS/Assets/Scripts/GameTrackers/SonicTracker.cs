using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public class SonicTracker : MonoBehaviour
    {
        [SerializeField] AudioSource[] _soundEffects;
        [SerializeField] GameObject _droppedRing;
        [SerializeField] private int _ringCount;
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
                print(value);
                _ringsToExtraLife = value;
            }
        }
        private int _lifeCount;
        public int lifeCount{
            get{
                return _lifeCount;
            }
            set{
                _lifeCount = value;
            }
        }
        private float _angle;
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DropRings(ringCount);
            }
        }
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
            print(value);
        }
        void SetLife(int value)
        {
            print("I'm setting life");
            if (value > 0)
            {
                print("I'm gonna play a jingle");
                _soundEffects[0].Play();
            }
            lifeCount += value;
            if (lifeCount < 0)
            {
                //Initiate Game-over
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
