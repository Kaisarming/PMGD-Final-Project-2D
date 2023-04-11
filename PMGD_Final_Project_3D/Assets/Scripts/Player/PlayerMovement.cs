using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	CharacterController character;
	public Animator playerAnim;
	public Rigidbody playerRigid;
    public float w_speed, wb_speed, olw_speed, rn_speed, ro_speed, bd_speed;
    public bool walking;
    public Transform playerTrans;
	public GameObject cam;
	float rotX, rotY;
	public float sensitivity = 30.0f;
	public bool webGLRightClickRotation = true;
	public bool mbidik;
	public GameObject pistol;

	private void Start()
    {
		//pistol.SetActive(false);
		character = GetComponent<CharacterController>();
		if (Application.isEditor)
		{
			webGLRightClickRotation = false;
			sensitivity = sensitivity * 1.5f;
		}
	}

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            playerRigid.velocity = transform.forward * w_speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerRigid.velocity = -transform.forward * wb_speed * Time.deltaTime;
        }
    }

    private void Update()
    {
		rotX = Input.GetAxis("Mouse X") * sensitivity;
		rotY = Input.GetAxis("Mouse Y") * sensitivity;

		if (webGLRightClickRotation)
		{
			if (Input.GetKey(KeyCode.Mouse0))
			{
				CameraRotation(cam, rotX, rotY);
			}
		}
		else if (!webGLRightClickRotation)
		{
			CameraRotation(cam, rotX, rotY);
		}
		if (Input.GetKeyDown(KeyCode.W))
		{
			playerAnim.SetTrigger("walk");
			playerAnim.ResetTrigger("idle");
			walking = true;
		}
		if (Input.GetKeyUp(KeyCode.W))
		{
			playerAnim.ResetTrigger("walk");
			playerAnim.SetTrigger("idle");
			walking = false;
		}
		if (Input.GetKeyDown(KeyCode.S))
		{
			playerAnim.SetTrigger("walkback");
			playerAnim.ResetTrigger("idle");
		}
		if (Input.GetKeyUp(KeyCode.S))
		{
			playerAnim.ResetTrigger("walkback");
			playerAnim.SetTrigger("idle");
		}
		if (Input.GetKey(KeyCode.A))
		{
			playerTrans.Rotate(0, -ro_speed * Time.deltaTime, 0);
		}
		if (Input.GetKey(KeyCode.D))
		{
			playerTrans.Rotate(0, ro_speed * Time.deltaTime, 0);
		}
		if (walking == true)
		{
			if (Input.GetKeyDown(KeyCode.LeftShift))
			{
				w_speed = w_speed + rn_speed;
				playerAnim.SetTrigger("run");
				playerAnim.ResetTrigger("walk");
			}
			if (Input.GetKeyUp(KeyCode.LeftShift))
			{
				w_speed = olw_speed;
				playerAnim.ResetTrigger("run");
				playerAnim.SetTrigger("walk");
			}
		}
		if (pistol == true)
        {
			if (Input.GetKeyDown(KeyCode.Mouse1))
			{
				playerAnim.SetTrigger("pistolidle");
				playerAnim.ResetTrigger("idle");
				mbidik = true;
			}
			if (Input.GetKeyUp(KeyCode.Mouse1))
			{
				playerAnim.ResetTrigger("pistolidle");
				playerAnim.SetTrigger("idle");
				mbidik = false;
			}
			if (mbidik == true)
			{
				if (Input.GetKeyDown(KeyCode.LeftControl))
				{
					playerAnim.SetTrigger("pistolcrouch");
					playerAnim.ResetTrigger("pistolidle");
				}
				if (Input.GetKeyUp(KeyCode.LeftControl))
				{
					playerAnim.ResetTrigger("pistolcrouch");
					playerAnim.SetTrigger("pistolidle");
				}
				if (Input.GetKeyDown(KeyCode.W))
				{
					w_speed = w_speed + bd_speed;
					playerAnim.SetTrigger("pistolwalk");
					playerAnim.ResetTrigger("pistolidle");
				}
				if (Input.GetKeyUp(KeyCode.W))
				{
					w_speed = olw_speed;
					playerAnim.ResetTrigger("pistolwalk");
					playerAnim.SetTrigger("pistolidle");
				}
				if (Input.GetKeyDown(KeyCode.S))
				{
					w_speed = w_speed + bd_speed;
					playerAnim.SetTrigger("pistolwalkback");
					playerAnim.ResetTrigger("pistolidle");
				}
				if (Input.GetKeyUp(KeyCode.S))
				{
					w_speed = olw_speed;
					playerAnim.ResetTrigger("pistolwalkback");
					playerAnim.SetTrigger("pistolidle");
				}
				//if (Input.GetKeyDown(KeyCode.A))
				//{
				//	playerAnim.SetTrigger("pistolleft");
				//	playerAnim.ResetTrigger("pistolidle");
				//	//playerRigid.velocity = -transform.forward * w_speed * Time.deltaTime;
				//}
				//if (Input.GetKeyUp(KeyCode.A))
				//{
				//	playerAnim.ResetTrigger("pistolleft");
				//	playerAnim.SetTrigger("pistolidle");
				//}
				//if (Input.GetKeyDown(KeyCode.D))
				//{
				//	playerAnim.SetTrigger("pistolright");
				//	playerAnim.ResetTrigger("pistolidle");
				//	//playerRigid.velocity = transform.forward * w_speed * Time.deltaTime;
				//}
				//if (Input.GetKeyUp(KeyCode.D))
				//{
				//	playerAnim.ResetTrigger("pistolright");
				//	playerAnim.SetTrigger("pistolidle");
				//}
			}
		}
	}
	void CameraRotation(GameObject cam, float rotX, float rotY)
	{
		transform.Rotate(0, rotX * Time.deltaTime, 0);
		cam.transform.Rotate(-rotY * Time.deltaTime, 0, 0);
	}
}