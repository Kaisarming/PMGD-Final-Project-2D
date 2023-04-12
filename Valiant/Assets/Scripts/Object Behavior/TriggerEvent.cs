using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]

public class TriggerEvent : MonoBehaviour
{
    public string targetTag;

    public UnityEvent OnTrigger;
    public UnityEvent<GameObject> OnTriggerWithGameobject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == targetTag)
        {
            OnTrigger?.Invoke();
            OnTriggerWithGameobject?.Invoke(other.gameObject);
        }
    }
}
