using UnityEngine;

public class Level2Exit : MonoBehaviour
{
    public GameObject escapeText;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Level 2 Complete!");

            escapeText.SetActive(true);
        }
    }
}