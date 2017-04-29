using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploAni : MonoBehaviour
{

    // Use this for initialization
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }



    private IEnumerator RandomWait()
    {
        while (true)
        {
            ExploAni explo = new ExploAni();
            explo.Start();
            yield return new WaitForSeconds(Random.Range(3, 100));
        }
    }
}
