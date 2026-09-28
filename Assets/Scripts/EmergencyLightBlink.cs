using UnityEngine;

public class EmergencyLightBlink : MonoBehaviour
{
    private Light emergencyLight;

    public float blinkSpeed = 0.5f;

    void Start()
    {
        emergencyLight = GetComponent<Light>();
    }

    void Update()
    {
        emergencyLight.enabled =
            Mathf.Sin(Time.time * Mathf.PI * 2f * blinkSpeed) > 0;
    }
}