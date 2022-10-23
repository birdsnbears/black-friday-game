using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levitating : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int cureentIndex = 0;
    [SerializeField] private float speed;
    
    

    // Update is called once per frame
    void Update()
    {
        speed = Random.Range(1, 10);

        if(Vector3.Distance(waypoints[cureentIndex].transform.position,transform.position) < .1f)
        {
            cureentIndex++;
            if(cureentIndex >= waypoints.Length)
            {
                cureentIndex = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position,waypoints[cureentIndex].transform.position,Time.deltaTime*speed);
    }
}
