using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBoxHide : MonoBehaviour
{
    [SerializeField] GameObject ToActivate;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>())
        {
            if (ToActivate.activeSelf)
            {
                Debug.Log("caché");
                ToActivate.SetActive(false);
            }
            else
            {
               
            }
            gameObject.SetActive(false);
        }
    }
}
