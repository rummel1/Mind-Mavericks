using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class MyCharacterController : MonoBehaviour
{
    private static MyCharacterController instance;

    private Animator animator;
    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;

    [SerializeField] private float smoothTime;
    private float _currentVelocity;

    private float _gravity = -9.81f;
    //[SerializeField] private float gravityMultiplier = 3.0f;
    private float _velocity;
    
     public static float speed=6;

    [SerializeField] private float jumpPower;
    private int _numberOfJumps;
    [SerializeField] private int maxNumberOfJumps = 2;
    
    
    public static float originalGravityMultiplier = 1.0f;
    public static float temporaryGravityMultiplier = 100.0f;
    public static bool isGravityIncreased = false;
    
    private Vector3 previousPosition;

    
    
    private void Awake()
    {
       _characterController= GetComponent<CharacterController>();
       instance = this;
       animator = GetComponent<Animator>();
       previousPosition = transform.position;
    }

     void FixedUpdate()
    {
        ApplyRotation();
        ApplyMovement();
        ApplyGravity();
        
        Vector3 currentPosition = transform.position;
        Vector3 displacement = currentPosition - previousPosition;

        if (displacement.magnitude > 0)
        {
            // Karakter hareket ediyor
            animator.SetFloat("Speed", 0.9f);
        }
        else
        {
            // Karakter hareket etmiyor
            animator.SetFloat("Speed", 0f);
        }

        previousPosition = currentPosition;
        
        
    }

    private void ApplyGravity()
    {
        if (IsGrounded() && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            float gravityMultiplier = originalGravityMultiplier;

            if (isGravityIncreased)
            {
                gravityMultiplier = temporaryGravityMultiplier;
            }

            _velocity += _gravity * gravityMultiplier * Time.deltaTime;
        }

        _direction.y = _velocity;
    }
    public static IEnumerator IncreaseGravityForDuration(float duration)
    {
        isGravityIncreased = true;

        yield return new WaitForSeconds(duration);

        isGravityIncreased = false;
    }
    private void ApplyRotation()
    {
        if(_input.sqrMagnitude==0)return;
        var targetAngle = Mathf.Atan2(_direction.x,_direction.z)*Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime);
        transform.rotation= Quaternion.Euler(0.0f,angle,0.0f);
    }

    public void ApplyMovement()
    {
        _characterController.Move(_direction * (speed * Time.deltaTime));
    }
    
    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<Vector2>();
        _direction = new Vector3(_input.x, 0.0f, _input.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if(!context.started) return;
        if(!IsGrounded() && _numberOfJumps>=maxNumberOfJumps) return;
        if (_numberOfJumps == 0) StartCoroutine((WaitForLamding()));
        
        _numberOfJumps++;
        _velocity += jumpPower;
    }

    private IEnumerator WaitForLamding()
    {
        yield return new WaitUntil(() => !IsGrounded());
        yield return new WaitUntil(IsGrounded);
        _numberOfJumps = 0;
    }

    private bool IsGrounded() => _characterController.isGrounded;
}