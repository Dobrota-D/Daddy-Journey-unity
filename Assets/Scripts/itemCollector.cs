using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{
    private int milks = 0;

    [SerializeField] private Text milksText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("milk"))
        {
            Destroy(collision.gameObject);
            milks++;
            milksText.text = "milks: " + milks + " /4";
        }
    }
  
}
