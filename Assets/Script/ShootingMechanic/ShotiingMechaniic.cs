using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ShootMechanic
{
    public class ShotiingMechaniic : MonoBehaviour
    {
        private GunControlled gun;
        #region Datamembers

        #region Editor Settings

        [SerializeField] private LayerMask groundMask;

        #endregion
        #region Private Fields

        private Camera mainCamera;

        #endregion

        #endregion


        #region Methods

        #region Unity Callbacks

        private void Start()
        {
            // Cache the camera, Camera.main is an expensive operation.
            mainCamera = Camera.main;
            gun = GetComponent<GunControlled>();
        }

        private void Update()
        {
            Aim();
            if (Input.GetMouseButtonDown(0))
            {
                Shot();
            }
        }

        #endregion

        private void Aim()
        {
            var (success, position) = GetMousePosition();
            if (success)
            {
                // Calculate the direction
                var direction = position - transform.position;

                // You might want to delete this line.
                // Ignore the height difference.
                direction.y = 0;

                // Make the transform look in the direction.
                transform.forward = direction;
            }
        }

        private (bool success, Vector3 position) GetMousePosition()
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
            {
                // The Raycast hit something, return with the position.
                return (success: true, position: hitInfo.point);
            }
            else
            {
                // The Raycast did not hit anything.
                return (success: false, position: Vector3.zero);
            }
        }
        public void Shot()
        {

        }
        #endregion
    }
    public class GunControlled : MonoBehaviour
    {
        public float damage = 10f;
        public float fireRate = 1f;
        public Transform firePoint;
    }
}

