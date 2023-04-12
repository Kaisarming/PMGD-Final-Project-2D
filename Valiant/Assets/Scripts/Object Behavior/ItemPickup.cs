using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StarterAssets
{
    public class ItemPickup : MonoBehaviour
    {
        public GameObject movement;
        public GameObject characterController;
        Animator animator;
        public bool bersenjata;
        public GameObject senjata;
        public GameObject pistol;
        public KeyCode pickupKey = KeyCode.E;

        private bool canPickup = false;


        private void Start()
        {
            animator = GetComponent<Animator>();
            senjata.SetActive(false);
        }

        void OnTriggerEnter(Collider other)
        {
            // Jika game object yang masuk ke trigger adalah player
            if (other.CompareTag("Player"))
            {
                canPickup = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            // Jika game object yang keluar dari trigger adalah player
            if (other.CompareTag("Player"))
            {
                canPickup = false;
            }
        }

        void Update()
        {
            // Mencari game object yang ditunjuk oleh mouse
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Jika game object yang ditunjuk adalah game object yang memiliki script ItemPickup
                if (hit.collider.gameObject == gameObject)
                {
                    canPickup = true;
                }
                else
                {
                    canPickup = false;
                }
            }

            // Jika player menekan tombol pickupKey dan dapat mengambil item
            if (Input.GetKeyDown(pickupKey) && canPickup)
            {
                senjata.SetActive(true);
                characterController.GetComponent<CharacterController>().enabled = false;
                movement.GetComponent<ThirdPersonController>().enabled = false;
                animator.SetBool("Bersenjata", true);
                bersenjata = true;

                // Menghapus game object yang menampung item
                Destroy(pistol);
            }
        }
    }
}
