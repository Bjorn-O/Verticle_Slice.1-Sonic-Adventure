using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManager
{
    public class CheckPoint : LevelObject_BASE
    {
        private LevelTracker _levelTracker;
        private bool _isCheckPointActive;

        void Start()
        {
            _levelTracker = FindObjectOfType<LevelTracker>();
        }

        protected override void OnPlayerInteraction(GameObject player)
        {
            base.OnPlayerInteraction(player);
            if (!_isCheckPointActive)
            {
                SetCheckPoint();
                _isCheckPointActive = true;
            }
        }

        void SetCheckPoint()
        {
            _levelTracker.lastCheckPoint = this;
        }
    }
}
