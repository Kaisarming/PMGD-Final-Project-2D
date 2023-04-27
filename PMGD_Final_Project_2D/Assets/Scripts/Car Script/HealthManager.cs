using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    // Defines a public static variable called instance of type "HealthManager", this variable can be accessed anywhere in the code just by calling "HealthManager.instance"
    public static HealthManager instance;
    public int currentHealth;
    public int maxHealth;
    public GameObject explosion;
    public DeadCount dead;

    private int lifeInt;
    private string lifeString;
    HealthManager lifeFromHealthManager;
    public GameObject txtFromUnity;

    // AudioSource represent audio sources on 3d
    public AudioSource carExplosion;

    public LifeCount life;

    private void Awake()
    {
        // The Awake method (is called when the object it placed in the scene) it is checking if there is already an instance for "HealthManager" in the variable "instance", if there isn't any then it assigns itself to "instance"
        instance = this;
    }

    private void Start()
    {
        // currentHealth will be equal to maxHealth at the start of the scene
        currentHealth = maxHealth;
    }

    public void DamagePlayer()
    {
        // -1 currentHealth
        currentHealth--;
        LifeFunction();

        // If currentHealth is less than or equal to 0
        if (currentHealth <= 0)
        {
            // "Instantiate" means clones the object original and returns the clone(public static Object Instantiate(Object original, Vector3 position, Quaternion rotation);)
            Instantiate(explosion, transform.position, transform.rotation);
            //Uncheck the checklist on the top left of the game object in Unity
            gameObject.SetActive(false);
            // Play Audio carExplosion
            carExplosion.Play();

            // Call "KillPlayer()" from GameManager scripts
            GameManager.instance.KillPlayer();
        }
    }

    public void Respawn()
    {
        // Make car appear on the screen again
        gameObject.SetActive(true);
        dead.DeathCount();
        // Make the car health to full health
        currentHealth = maxHealth;
    }

    public void LifeFunction()
    {
        lifeInt = currentHealth;
        lifeString = lifeInt.ToString();
        txtFromUnity.GetComponent<Text>().text = lifeString;
    }
}
