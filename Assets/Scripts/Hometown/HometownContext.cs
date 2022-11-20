using Project.Components;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Hometown
{
    [RequireComponent(typeof(InputManager) , typeof(Spawner))]
    public class HometownContext : MonoBehaviour
    {
        [SerializeField]
        private InputManager _inputManager;
        [SerializeField]
        private Spawner _spawner;

        public HouseController HouseController { get; private set; }
        
        [SerializeField]
        private int _level, _maxLevel = 5;
        string _item;
        bool _oneTime;
        private void Awake()
        {
            if(_inputManager == null)
            {
                _inputManager = GetComponent<InputManager>();
            }

            if (_spawner == null)
            {
                _spawner =  GetComponent<Spawner>();
            }

            //add implementation
            //if (HouseController != null)
            //{
            //    HouseController.OnLevelUp += HouseController_OnLevelUp;
            //}
        }

        //private void HouseController_OnLevelUp(LevelupEventData obj)
        //{
        //    _level++;
        //}
        private void Update()
        {

        }
        public void LevelMax()
        {
            if (_level < _maxLevel)
            {
                _level++;
                HouseView.Instance.OnTouch();
            }
            else
            {
                _spawner.EnableScript();
            }
        }

        private void OnDestroy()
        {
            //add implementation
        }
        [ContextMenu("Update Level")]
        public void UpdateLevel()
        {
            HouseController = new HouseController(this, _item, _inputManager);
            
        }
    }
}