using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        gameObject.GetComponent<PlayerMovement>().enabled = true;
        gameObject.GetComponent<PlayerJump>().enabled = true;
    }
    private void OnDisable()
    {
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<PlayerJump>().enabled = false;
    }

}
