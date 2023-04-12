// LocomotionSimpleAgent.cs
using System;
using UnityEngine;
using UnityEngine.AI;

public class CharacterLocomotion : MonoBehaviour
{
    //public bool bersenjata;
    Animator anim;
    Rigidbody rigidbody;
    float m_TurnAmount;
    float m_ForwardAmount;
    [HideInInspector] public Vector3 rotationVector;
    [HideInInspector] public Vector3 upperBodyRotationEulers;

    //[Header("Player")]
    //public float MoveSpeed = 2.0f;
    //public float SprintSpeed = 5.0f;
    //[Range(0.0f, 0.3f)]
    //public float RotationSmoothTime = 0.12f;
    //public float SpeedChangeRate = 10.0f;
    //public float Sensitivity = 1f;
    //public AudioClip LandingAudioClip;
    //public AudioClip[] FootstepAudioClips;
    //[Range(0, 1)] public float FootstepAudioVolume = 0.5f;
    //public float JumpHeight = 1.2f;
    //public float Gravity = -15.0f;
    //public float JumpTimeout = 0.50f;
    //public float FallTimeout = 0.15f;

    //[Header("Player Grounded")]
    //public bool Grounded = true;
    //public float GroundedOffset = -0.14f;
    //public float GroundedRadius = 0.28f;
    //public LayerMask GroundLayers;

    //// player
    //private float _speed;
    //private float _animationBlend;
    //private float _targetRotation = 0.0f;
    //private float _rotationVelocity;
    //private float _verticalVelocity;
    //private float _terminalVelocity = 53.0f;

    //// timeout deltatime
    //private float _jumpTimeoutDelta;
    //private float _fallTimeoutDelta;

    //// animation IDs
    //private int _animIDSpeed;
    //private int _animIDGrounded;
    //private int _animIDJump;
    //private int _animIDFreeFall;
    //private int _animIDMotionSpeed;
    //private bool _hasAnimator;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    public void OnAnimatorMove()
    {
        // we implement this function to override the default root motion.
        // this allows us to modify the positional speed before it's applied.
        Vector3 v = anim.deltaPosition / Time.deltaTime;
        Vector3 newRot = new Vector3(
            transform.eulerAngles.x + rotationVector.x + anim.deltaRotation.eulerAngles.x,
             transform.eulerAngles.y + rotationVector.y + anim.deltaRotation.eulerAngles.y,
              transform.eulerAngles.z + rotationVector.z + anim.deltaRotation.eulerAngles.z
            );
        rigidbody.MoveRotation(Quaternion.Euler(newRot));
        v.y = rigidbody.velocity.y;
        rigidbody.velocity = v;
    }
    private void OnAnimatorIK()
    {
        //   upperBodyRotationEulers.y = 30;
        Quaternion chestRot = Quaternion.Euler(upperBodyRotationEulers);
        anim.SetBoneLocalRotation(HumanBodyBones.Chest, chestRot);
    }

    private RaycastHit PickOneBasedOnHeight(RaycastHit rightHitOne, RaycastHit rightHitTwo)
    {
        if (rightHitOne.point.y >= rightHitTwo.point.y)
            return rightHitOne;
        else
            return rightHitTwo;
    }

    public void Move(Vector3 move)
    {
        //if (bersenjata == true)
        //{
            if (move.magnitude > 1f) move.Normalize();
            move = transform.InverseTransformDirection(move);
            move = Vector3.ProjectOnPlane(move, Vector3.up);
            m_TurnAmount = Mathf.Atan2(move.x, move.z);
            m_ForwardAmount = move.z;
            ApplyExtraTurnRotation();
            anim.SetFloat("Turn", m_TurnAmount, 0.1f, Time.deltaTime);
            anim.SetFloat("Forward", m_ForwardAmount, 0.1f, Time.deltaTime);
        //}
    }
    public void MoveAiming(Vector3 move)
    {
        //if (bersenjata == true)
        //{
            if (move.magnitude > 1f) move.Normalize();
            anim.SetFloat("Speed X", move.x, 0.1f, Time.deltaTime);
            anim.SetFloat("Speed Z", move.z, 0.1f, Time.deltaTime);
        //}
    }
    void ApplyExtraTurnRotation()
    {
        // help the character turn faster (this is in addition to root rotation in the animation)
        float turnSpeed = Mathf.Lerp(360, 180, m_ForwardAmount);
        transform.Rotate(0, m_TurnAmount * turnSpeed * Time.deltaTime, 0);
    }
    public void UpdateAnimatorAimingState(bool aiming)
    {
        //if (bersenjata == true)
        //{
            anim.SetBool("Aiming", aiming);
        //}
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.tag == "Senjata")
    //    {
    //        bersenjata = true;
    //    }
    //}
}