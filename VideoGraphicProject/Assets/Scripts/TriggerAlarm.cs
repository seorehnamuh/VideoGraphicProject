

using UnityEngine;
using UnityEngine.UI;
// Se usi TextMeshPro: using TMPro;

public class TriggerAlarm : MonoBehaviour
{
    [SerializeField] AudioSource alarmSound;
    [SerializeField] Light[] redLights;
    [SerializeField] float blinkSpeed = 1f;

    [SerializeField] GameObject alarmTextUI;

    private bool alarmTriggered = false;
    private float blinkTimer = 0f;

    private void Start()
    {
        foreach (Light light in redLights)
        {
            light.enabled = false;
        }

        if (alarmTextUI != null)
        {
            alarmTextUI.SetActive(false);
        }
    }

    private void Update()
    {
        if (alarmTriggered)
        {
            BlinkLights();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!alarmTriggered && other.CompareTag("Player"))
        {
            alarmTriggered = true;

            if (alarmSound != null && !alarmSound.isPlaying)
            {
                alarmSound.loop = true;
                alarmSound.Play();
            }

            if (alarmTextUI != null)
            {
                alarmTextUI.SetActive(true);
                StartCoroutine(HideAlarmTextAfterDelay(5f));
            }
        }
    }

    private void BlinkLights()
    {
        blinkTimer += Time.deltaTime * blinkSpeed;
        bool isOn = Mathf.FloorToInt(blinkTimer) % 2 == 0;

        foreach (Light light in redLights)
        {
            light.enabled = isOn;
        }
    }

    private System.Collections.IEnumerator HideAlarmTextAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (alarmTextUI != null)
        {
            alarmTextUI.SetActive(false);
        }
    }
}
