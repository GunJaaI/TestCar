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
    
    public float elapsedTime;
    [SerializeField] TextMeshProUGUI Pt;
    public float Point;
    [SerializeField] float SecondSpawner = 1f;


    [SerializeField] float minTras;
    [SerializeField] float maxTras;
   
    [SerializeField] float minUTras; 
    [SerializeField] float maxUTras;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        Pt.text = string.Format("0",Point);
       

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("StartTargetTag"))
        {     
            StartObj.SetActive(false);
            StartCoroutine(TargetSpawner());
        }
        if (collision.collider.CompareTag("TargetTag"))
        {


            Point++;
            Pt.text = Point.ToString();
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
            var wanted2 = Random.Range(minUTras, maxUTras);
            var position = new Vector3(wanted, 1,wanted2);
            GameObject gameObject = Instantiate(Target, position, Quaternion.identity);
            yield return new WaitForSeconds(SecondSpawner);
        }

    }
}
