using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupPosition : MonoBehaviour
{
    public GameObject spawn_point;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = this.spawn_point.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
