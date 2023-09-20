using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Timemanager;

namespace Timemanager
{
    public class ARCADEMODEDITOR : MonoBehaviour
    {
        public static bool IsGameStart = false;
        public GameObject StartMenu;
        // Start is called before the first frame update
        void Start()
        {
            Pause();
        }

        // Update is called once per frame
        void Update()
        {
            if (IsGameStart == false)
            {
                Time.timeScale = 0;
            }
            else
            {
                StartMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
        public void Pause()
        {

            IsGameStart = false;
        }
        public void Resume()
        {
            IsGameStart = true;


        }
    }
}
