using System;
using UnityEngine;

namespace Project.Hometown
{
    public class HouseView : MonoBehaviour
    {
        private HouseController _houseController;
        
        public GameObject _houseSprite;
        private Vector3 _scaleChange;
        private void OnDisable()
        {
            //add implementation
        }

        private void OnEnable()
        {
            //add implementation
        }

        public HouseView Setup(HouseController houseController)
        {
            _houseController= houseController;
            return this;
        }

        public void EnableScript()
        {
            //remember to enable script from context if needed
            enabled = true;
        }

        public void HandleOnHouseLevelUp(LevelupEventData data)
        {
            //add implementation
            //_scaleChange = new Vector3(0.2f, 0.1f, 0);
            //_houseSprite.transform.localScale += _scaleChange;
        }
        public void OnTouch()
        {
            _scaleChange = new Vector3(0.2f, 0.1f, 0);
            _houseSprite.transform.localScale += _scaleChange;
        }
        #region Singleton
        public static HouseView Instance
        {
            get
            {
                if (instance == null)
                    instance = FindObjectOfType(typeof(HouseView)) as HouseView;

                return instance;
            }
            set
            {
                instance = value;
            }
        }
        private static HouseView instance;
        #endregion
    }
}