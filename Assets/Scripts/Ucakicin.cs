using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ucakicin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.8f*Time.deltaTime, 0.15f*Time.deltaTime, 0);
    }
}
