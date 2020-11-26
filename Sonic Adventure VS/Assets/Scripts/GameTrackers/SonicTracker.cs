using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public class SonicTracker : MonoBehaviour
    {
        private int _ringCount;
        public int ringCount{
            get{
                return _ringCount;
            }
            set{
                _ringCount += 1;
                if (_ringCount >= 100)
                {
                    _lifeCount ++;
                }
            }
        }
        private int _lifeCount;
    }
}
