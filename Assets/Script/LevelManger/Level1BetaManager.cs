using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Level1BetaManager : MonoBehaviour
{
  
    public GameObject StartTarget,UIElement;
    private bool IsStart = false;
    [SerializeField] public GameObject SucessUI;

    [SerializeField] TextMeshProUGUI RemainingDrop;
    private float Dropped = 10;

    // Start is called before the first frame update
    void Start()
    {
        SucessUI.SetActive(false);
         
    }

    // Update is called once per frame
    void Update()
    {
        RemainingDrop.text = string.Format("{0}",Dropped);
        if(IsStart == true)
        {
            UIElement.SetActive(true);
           
        }
        else
        {
            UIElement.SetActive(false);

        }
        if (Dropped < 2) 
        {
            SucessUI.SetActive(true);
            Pause();
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("StartTargetTag"))
        {
            StartTarget.SetActive(false);
            IsStart = true;
        }
        if (collision.collider.CompareTag("TargetTag"))
        {
            Dropped--;
            RemainingDrop.text = Dropped.ToString();
        }
    }
    public void Rastart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Pause()
    {
        Time.timeScale = 0;

    }
}
