using Project.Components;
using System;
using UnityEngine;

namespace Project.Hometown
{
    public class HouseController : IController, IUpgradeable , ICanTriggerSpawn
    {
        public event Action<LevelupEventData> OnLevelUp;
        public event Action TriggerSpawn;

        private HometownContext _hometownContext;
        private string _itemName;
        private UpgradeableData _upgradeableData;
        private UpgradeableRepository _upgradeableRepository;

        public static HouseController _houseCo;
        public int _level;
        public int _maxLevel;
        public void OnContextDispose()
        {
            //add implementation
        }

        public HouseController(HometownContext hometownContext , string upgradeableItemName , InputManager inputManager)
        {
            _hometownContext = hometownContext;
            _itemName = upgradeableItemName;

            //add implementation
            //hometownContext._level = _upgradeableData.Level;
            //hometownContext._maxLevel = _upgradeableData.MaxLevel;
            inputManager.OnInputTouch += HandleOnInputTouch;

            //_hometownContext._maxLevel = _upgradeableData.MaxLevel;
            Upgrade();
        }

        //public HouseController()
        //{
        //    Upgrade();
        //}

        public void Upgrade()
        {
            Debug.Log($"Handle Upgrade {_itemName}");
            //add implementation
            //_level = _upgradeableData.Level;
            //_maxLevel = _upgradeableData.MaxLevel;
            _upgradeableRepository.GetUpgradeableData(up =>_upgradeableData.LevelUp());
            //Debug.Log(_upgradeableData.MaxLevel);
        }

        public void HandleOnInputTouch()
        {
            //add implementation
            //_upgradeableData.LevelUp();
            //OnLevelUp(_upgradeableData.Level);
            if (_upgradeableData.Level < _upgradeableData.MaxLevel)
            {
                _hometownContext.UpdateLevel();
            }

        }
    }
}
