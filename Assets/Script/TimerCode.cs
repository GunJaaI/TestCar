using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

 namespace Timemanager { 
public class TimerCode : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TimeText;
    [SerializeField] public float remainingTime;
        // Start is called before the first frame update
        [SerializeField] public GameObject GameOverUI;
    void Start()
    {
            GameOverUI.SetActive(false);
       // elapsedTime += Time.deltaTime;
      //  TimeText.text = elapsedTime.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int second = Mathf.FloorToInt(remainingTime % 60);
        TimeText.text = string.Format("{0:00}:{1:00}", minutes, second);

        if (remainingTime <= 0)
        {
            TimeText.text = string.Format("{0:00}:{1:00}", 0, 0);
                GameOverUI.SetActive(true);
            Pause();
           
        }
      
    }  
    void Pause()
        {
            Time.timeScale = 0;

        }
}
}