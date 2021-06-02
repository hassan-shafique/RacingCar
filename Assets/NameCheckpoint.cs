using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameCheckpoint : MonoBehaviour
{
    Transform[] children;
    int number = 0;
    // Start is called before the first frame update
    void Start()
    {
        children = gameObject.GetComponentsInChildren<Transform>();
        foreach(Transform child in children)
        {
            if(child.gameObject!=this.gameObject)

            {
                child.transform.gameObject.name = "" + number;
                number++;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
