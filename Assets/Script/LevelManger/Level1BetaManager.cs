using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1BetaManager : MonoBehaviour
{
    public GameObject StartTarget;
    private bool IsStart = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(IsStart == true)
        {

        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("StartTargetTag"))
        {
            StartTarget.SetActive(false);
            IsStart = true;
        }
    }
}
