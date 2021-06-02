using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMissingCheckpoints : MonoBehaviour
{
    public bool checkPointMissedWarning = false;
    [SerializeField] public GameObject missingCHTxt;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if ( player.GetComponent<CheckPointsManager>().is_missing_checkpoint == true)
        {
            StartCoroutine(ShowMissingChWarningText("You have missed a Checkpoint"));
            checkPointMissedWarning = true;
            player.GetComponent<CheckPointsManager>().is_missing_checkpoint = false;
        }
    }
    public IEnumerator ShowMissingChWarningText(string message)
    {
        missingCHTxt.GetComponent<Text>().text = message;
        missingCHTxt.SetActive(true);
        yield return new WaitForSeconds(2);
        missingCHTxt.SetActive(false);
    }
    
}
