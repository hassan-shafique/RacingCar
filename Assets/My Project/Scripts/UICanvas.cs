using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour
{
    [SerializeField]
    private Text speedtxt;
    [SerializeField]
    private Text CHTXT;
    private Rigidbody vehicle;
    private static int checkPointCurrent = 0;
    // Start is called before the first frame update
    void Start()
    {
        vehicle = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        speedtxt.text = "Speed: " + ((int)(vehicle.velocity.magnitude * 3.6f)).ToString() + " m/s";
        CHTXT.text = "Ch: " + checkPointCurrent;
    }
    public void inc_CheckpointCurrent()
    {
        checkPointCurrent++;
        if (checkPointCurrent > 16) checkPointCurrent = 0;
    }
}
