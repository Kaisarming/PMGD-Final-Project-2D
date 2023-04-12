using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Life : MonoBehaviour
{
    [HideInInspector] public int life;
    [HideInInspector] public int maxLife;

    [HideInInspector] public ScriptableInteger lifeScriptable;
    [HideInInspector] public ScriptableInteger maxLifeScriptable;

    [HideInInspector] public bool useScriptable;

    public UnityEvent OnLifeReachZero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onHit()
    {
        if (useScriptable)
        {
            lifeScriptable.value = lifeScriptable.value - 1 < 0 ? 0 : lifeScriptable.value - 1;
            if (lifeScriptable.value <= 0)
            {
                //call event hp reach zero
                OnLifeReachZero?.Invoke();
            }
        }
        else
        {
            life = life - 1 < 0 ? 0 : life - 1;
            if (life <= 0)
            {
                //call event hp reach zero
                OnLifeReachZero?.Invoke();
            }
        }
    }

    public void onGain()
    {
        if (useScriptable)
        {
            lifeScriptable.value = lifeScriptable.value + 1 > maxLifeScriptable.value ? maxLifeScriptable.value : lifeScriptable.value + 1;
        }
        else
        {
            life = life + 1 > maxLife ? maxLife : life + 1;
        }
    }
}
