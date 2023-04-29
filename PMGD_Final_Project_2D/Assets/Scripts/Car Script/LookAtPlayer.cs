using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    void Update()
    {
        lookAt();
    }

    private void lookAt()
    {
        if (GameManager.GetInstance().activePlayer != null)
        {
            transform.up = GameManager.GetInstance().activePlayer.transform.position - transform.position;
        }
    }
}
