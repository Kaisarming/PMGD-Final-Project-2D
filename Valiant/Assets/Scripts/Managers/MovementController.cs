using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StarterAssets
{
    public class MovementController : MonoBehaviour
    {
        public GameObject movement;
        public GameObject characterController;
        Animator animator;
        public bool bersenjata;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Senjata")
            {
                characterController.GetComponent<CharacterController>().enabled = false;
                movement.GetComponent<ThirdPersonController>().enabled = false;
                animator.SetBool("Bersenjata", true);
                bersenjata = true;
            }
        }
    }
}