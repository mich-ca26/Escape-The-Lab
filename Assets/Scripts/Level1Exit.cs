using System.Diagnostics;
using UnityEngine;

public class Level1Exit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Level 1 Complete!");
        }
    }
}