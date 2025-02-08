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
        smoke.SetActive(true);

        if (particleSystem.isPlaying)
        {
            // Jeśli system cząsteczek jest odtwarzany, zaczynamy licznik czasu
            StartCoroutine(StopParticleAfterTime(playDuration));
        }
    }

    IEnumerator StopParticleAfterTime(float time)
    {
        // Czekaj przez określoną ilość czasu
        yield return new WaitForSeconds(time);

        // Zatrzymanie systemu cząsteczek
        particleSystem.Stop();

        // Ukrycie obiektu, jeśli chcesz, aby system cząsteczek zniknął
        smoke.SetActive(false);
    }


    private void OnTriggerEnter(Collider other)
    {
        // Sprawdź, czy obiekt, który wchodzi w trigger, to gracz
        if (other.CompareTag("Player"))
        {
            Debug.Log("Gracz wszedł w dym!");

            // Sprawdź, czy system cząsteczek nie jest już aktywowany
            if (!particleSystem.isPlaying)
            {
                particleSystem.Play(); // Uruchomienie systemu cząsteczek
            }

            // Uruchomienie korutyny, która poczeka 3 sekundy, a potem dezaktywuje dym
            StartCoroutine(DeactivateSmokeAfterDelay());
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
