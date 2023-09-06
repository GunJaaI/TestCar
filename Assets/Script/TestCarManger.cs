using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestCarManger : MonoBehaviour
{
    public GameObject StartObj;
    public int StartTarget;
    public Collider Player;
    public GameObject PlayerObj;
    public GameObject Target;
    public string StartTargetTag = "StartTargetTag";
    public string TargetTag = "TargetTag";
    [SerializeField] TextMeshProUGUI TimeText;
    public float elapsedTime;
    [SerializeField] float SecondSpawner = 1f;

    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    // Start is called before the first frame update
    void Start()
    {
        elapsedTime += Time.deltaTime;
        TimeText.text = elapsedTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int second = Mathf.FloorToInt(elapsedTime % 60);
        TimeText.text = string.Format("{0:00}:{1:00}",minutes,second);
       

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("StartTargetTag"))
        {

                 
            StartObj.SetActive(false);
            //StartCoroutine(TargetSpawner());
        }
       
    }
    private void StartTimer()
    {

    }
    IEnumerator TargetSpawner()
    {

        while (true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, 1);
            GameObject gameObject = Instantiate(Target, position, Quaternion.identity);
            yield return new WaitForSeconds(SecondSpawner);
        }

    }
}
