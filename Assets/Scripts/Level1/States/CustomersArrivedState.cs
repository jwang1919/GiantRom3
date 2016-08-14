using UnityEngine;
using System.Collections;

public class CustomersArrivedState : MonoBehaviour {

    public GameObject[] customers;
    public AudioClip clip;
    public int startTime = 0;

    void Start()
    {
        if (customers == null || customers.Length == 0)
        {
            throw new System.Exception("At least one customer must be defined!");
        }
    }

    void Update()
    {
        // not used
    }

    public void Run(Timeline timeline, AudioSource audioSource)
    {
        if (timeline.GetCurrentTime() > startTime)
        {
            foreach (GameObject customer in customers)
            {
                customer.SetActive(true);
            }

            audioSource.Stop();
            audioSource.clip = clip;
            audioSource.Play();

            timeline.AddOrder();
        }

    }
}
