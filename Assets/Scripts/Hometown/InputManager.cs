using System;
using UnityEngine;
using Project.Components;

namespace Project.Hometown
{
    public class InputManager : MonoBehaviour
    {
        public event Action OnInputTouch;

        public void ClickUpgrade()
        {
            OnInputTouch?.Invoke();
            _home.LevelMax();
        }

        public HometownContext _home;
        private void Awake()
        {
            if (_home == null)
            {
                _home = GetComponent<HometownContext>();
            }
        }
    }
}