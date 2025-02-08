using UnityEngine;
using UnityEngine.XR;
using Unity.VisualScripting;
using System.Collections;

public class Cigarette : MonoBehaviour
{
    public XRNode controllerNode;
    public InputDevice device;
    public GameObject smoke;
    public GameObject whiteLady;
    public ParticleSystem particleSystem;
    public float playDuration = 3f;


    void Start()
    {
        device = InputDevices.GetDeviceAtXRNode(controllerNode);
    }

    void Update()
    {
        if (!device.isValid)
        {
            device = InputDevices.GetDeviceAtXRNode(controllerNode);
        }


    }

    public void Destroyy()
    {
        Smoking();
        Destroy(gameObject);
    }

    public void Smoking()
    {
        if (smoke != null)
        {
            Debug.Log("Smoke");
            smoke.SetActive(true);
            particleSystem.Play();
        }

        if (particleSystem.isPlaying)
        {
            StartCoroutine(StopParticleAfterTime(playDuration));
        }
    }

    IEnumerator StopParticleAfterTime(float time)
    {
        yield return new WaitForSeconds(3f);

        particleSystem.Stop();

        smoke.SetActive(false);
        particleSystem.Stop();
    }


    private void OnTriggerEnter(Collider other)
    {
        // Sprawdź, czy obiekt, który wchodzi w trigger, to gracz
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gracz wszedł w dym!");
            whiteLady.SetActive(false);

            // Sprawdź, czy system cząsteczek nie jest już aktywowany
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play(); // Uruchomienie systemu cząsteczek
                whiteLady.SetActive(false);
            }

            whiteLady.SetActive(false);
        }
    }

    private IEnumerator DeactivateSmokeAfterDelay()
    {
        // Czekaj przez określony czas (3 sekundy)
        yield return new WaitForSeconds(3f);

        // Po upływie 3 sekund, zatrzymaj system cząsteczek
        particleSystem.gameObject.SetActive(false);
        Debug.Log("Dym zniknął.");


    }

}
