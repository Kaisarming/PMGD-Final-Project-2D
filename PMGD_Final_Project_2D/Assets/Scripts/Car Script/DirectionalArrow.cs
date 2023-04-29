using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionalArrow : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        lookAt();
    }

    private void lookAt()
    {
        transform.up = target.transform.position - transform.position;
    }
}
