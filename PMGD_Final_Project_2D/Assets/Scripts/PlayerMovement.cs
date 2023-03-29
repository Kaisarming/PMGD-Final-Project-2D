using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Kecepatan karakter
    private Rigidbody2D rb2d; // Variabel untuk Rigidbody2D

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // Mendapatkan komponen Rigidbody2D dari karakter
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Mendapatkan input horizontal (A/D atau kiri/kanan)
        float moveVertical = Input.GetAxis("Vertical"); // Mendapatkan input vertikal (W/S atau atas/bawah)

        Vector2 movement = new Vector2(moveHorizontal, moveVertical); // Menggabungkan input horizontal dan vertikal menjadi satu vektor

        rb2d.AddForce(movement * speed); // Menambahkan gaya pada karakter berdasarkan input yang diterima
    }
}
