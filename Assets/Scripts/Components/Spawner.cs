using System.Collections.Generic;
using UnityEngine;

namespace Project.Components
{

    public class Spawner : MonoBehaviour
    {
        [SerializeField]
        private MoveableComponent _moveableComponent;

        public static Spawner _instance;
        public List<GameObject> _listTank = new List<GameObject>();
        [SerializeField]
        private int _amountPool = 3;
        [SerializeField] private GameObject _tankPrefab;
        private void OnDisable()
        {
            //add implementation
        }

        private void OnEnable()
        {
            //add implementation
            _moveableComponent = _tankPrefab.GetComponent<MoveableComponent>();
            for (int i = 0; i < _amountPool; i++)
            {
                GameObject tank = Instantiate(_tankPrefab);
                tank.SetActive(false);
                _listTank.Add(tank);
            }
            HandleOnSpawnTriggered();
        }
        public GameObject GetPooledObject()
        {
            for (int i = 0; i < _listTank.Count; i++)
            {
                if (!_listTank[i].activeInHierarchy)
                {
                    return _listTank[i];
                }
            }
            return null;
        }
        private void Update()
        {

        }

        public void Setup(ICanTriggerSpawn spawnTrigger)
        {
            //add implementation
        }

        public void EnableScript()
        {
            //remember to enable script from context if needed
            enabled = true;
        }

        public void HandleOnSpawnTriggered()
        {
            //add implementation
            InvokeRepeating("SpawnMoveableObject", 0, 1.5f);

        }

        private void SpawnMoveableObject()
        {
            //add implementation
            GameObject tank = GetPooledObject();
            if (tank != null)
            {
                tank.transform.position = new Vector3(-2, -2, 0);
                tank.SetActive(true);
            }
            if (_moveableComponent != null)
            {
                _moveableComponent.SetDestination(new Vector3(4.5f, -2, 0));
            }
        }
    }
}