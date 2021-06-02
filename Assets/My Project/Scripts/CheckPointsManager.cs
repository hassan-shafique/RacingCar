using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPointsManager : MonoBehaviour
{
    [HideInInspector]
    public int lap = 0;
    [HideInInspector]
    public int checkPoint = -1;
    int checkPointCount;
    int nextCheckPoint = 0;
    Dictionary<int, bool> visited = new Dictionary<int, bool>();
    [SerializeField]
    private Text laptxt;
    public bool is_missing_checkpoint = false;
    
    [SerializeField]
    GameObject PrevCheckpoint;

    GameObject uiSuccessMessage;                    // To show succes message
    // Start is called before the first frame update
    void Start()
    {
        uiSuccessMessage =  GameObject.Find("scriptsUIMissingCheckPoints");
        //uiSuccessMessage.GetComponent("scriptsUIMissingCheckPoints");
        GameObject[] checkPoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        checkPointCount = checkPoints.Length;
        foreach(GameObject checkpoint in checkPoints)
        {
            if (checkpoint.name == "0")
            {
                PrevCheckpoint = checkpoint;
                break;
            }
        }
        foreach (GameObject cp in checkPoints)
        {
            Int32.TryParse(cp.name, out int intcpname);
            visited.Add(intcpname, false);
        }
    }
    private void Update()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider col)
    {
        Debug.Log("Collision");
        
        if(col.gameObject.tag.Equals("Checkpoint"))
        {
            int checkPointCurrent;
            checkPointCurrent = int.Parse(col.gameObject.name);
            
            if (checkPointCurrent == nextCheckPoint)
            {
                PrevCheckpoint = col.gameObject;
                visited[checkPointCurrent] = true;
                checkPoint = checkPointCurrent;
                if (gameObject.tag == "Player")
                {

                    GameObject.Find("ScriptUICanvas").GetComponent<UICanvas>().inc_CheckpointCurrent();
                }
//                CHtxt.text = "CH: " + checkPoint.ToString();
                if (checkPoint == 0 && gameObject.tag == "Player")
                {
                    lap++;
                    laptxt.text = "Lap: " + lap;
                }
                nextCheckPoint++;
                if (nextCheckPoint >= checkPointCount)
                {
                    var keys = new List<int>(visited.Keys);
                    foreach (var k in keys)
                    {
                        visited[k] = false;
                    }
                    nextCheckPoint = 0;
                }
                if( uiSuccessMessage.GetComponent<UIMissingCheckpoints>().checkPointMissedWarning)
                {
                    uiSuccessMessage.GetComponent<UIMissingCheckpoints>().missingCHTxt.GetComponent<Text>().color = Color.green;
                    StartCoroutine(uiSuccessMessage.GetComponent<UIMissingCheckpoints>().ShowMissingChWarningText("CheckPoint Collected"));
                    //uiSuccessMessage.GetComponent<UIMissingCheckpoints>().missingCHTxt.GetComponent<Text>().color = new Color(241,113,0);
                    uiSuccessMessage.GetComponent<UIMissingCheckpoints>().checkPointMissedWarning = false;
                }
            }
            else if( visited[checkPointCurrent] == false )
            {
                is_missing_checkpoint = true;
            }
        }
        
    }
}
