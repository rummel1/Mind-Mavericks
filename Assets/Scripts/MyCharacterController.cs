using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class MyCharacterController : MonoBehaviour
{
    private static MyCharacterController instance;

    private Vector2 _input;
    private CharacterController _characterController;
    private Vector3 _direction;

    [SerializeField] private float smoothTime;
    private float _currentVelocity;

    private float _gravity = -9.81f;
    //[SerializeField] private float gravityMultiplier = 3.0f;
    private float _velocity;
    
    [SerializeField] private float speed;

    [SerializeField] private float jumpPower;
    private int _numberOfJumps;
    [SerializeField] private int maxNumberOfJumps = 2;
    
    
    public static float originalGravityMultiplier = 1.0f;
    public static float temporaryGravityMultiplier = 100.0f;
    public static bool isGravityIncreased = false;

    
    
    private void Awake()
    {
       _characterController= GetComponent<CharacterController>();
       instance = this;
    }

    private void Update()
    {
        ApplyRotation();
        ApplyMovement();
        ApplyGravity();
        
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

    private void ApplyMovement()
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