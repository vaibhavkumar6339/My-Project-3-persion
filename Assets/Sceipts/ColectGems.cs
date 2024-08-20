using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemCollector : MonoBehaviour
{
    public int gemCount = 0;
    public Text gemScoreText;

    private void Start()
    {
        // the score text
        gemScoreText.text = "Gems Collected: " + gemCount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            gemCount++;
            gemScoreText.text = "Gems Collected: " +gemCount;
            // Destroy the gem object
            Destroy(other.gameObject);
        }
    }
}
