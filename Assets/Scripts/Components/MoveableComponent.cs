using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Components
{
    public class MoveableComponent : MonoBehaviour
    {
        private Vector3 _destination;
        public void SetDestination(Vector3 destination)
        {
            //add implementation to move this object to destination
            //and destroy it when it reach the destination
            //desination must be some vector3 where y and z coordinate not change from current coordinate
            //only x coordinate change and to positive direction (to the right)
            _destination = destination;
            if (transform.position == destination)
            {
                gameObject.SetActive(false);
            }
            transform.position = Vector3.MoveTowards(transform.position, destination, 2f * Time.deltaTime);
        }
        private void Update()
        {
            SetDestination(new Vector3(4.5f, -2, 0));
        }

    }
}