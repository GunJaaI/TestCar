using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShotiingMechaniic : MonoBehaviour
{
    public Transform gunBarrel;
    public GameObject bullet;
    
     void Start()
    {
      
    }
    public void Shoot()
    {
       
    }
    public void Shooting()
    {
        Shoot();
    }

     void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("shooted");
            
        }
    }

}
