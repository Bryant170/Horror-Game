using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public GameObject doorClosed, doorOpened, intText;
    public AudioSource open, close;
    public bool isOpen = false;

    // Start is called before the first frame update
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if(isOpen == false)
            {
                intText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    doorClosed.SetActive(false);
                    doorOpened.SetActive(true);
                    intText.SetActive(false);
                    StartCoroutine(repeat());
                    isOpen = true;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            intText.SetActive(false);
        }
    }

    IEnumerator repeat()
    {
        yield return new WaitForSeconds(4.0f);
        isOpen = false;
        doorClosed.SetActive(true);
        doorOpened.SetActive(false);
    }
    // Update is called once per frame

}
