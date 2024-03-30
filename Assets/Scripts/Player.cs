using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public UnityEvent JumpEvent = new UnityEvent();
    public UnityEvent DeathEvent = new UnityEvent();

    private Animator _animator;
    private bool _isJumping;
    private bool _isActivePlayer = true;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isActivePlayer == false)
            return;

        if (_isJumping == true)
            return;

        if (Input.GetKeyDown(KeyCode.W))
        {
            Move(Vector3.forward);
            Rotate(Vector3.forward);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Move(Vector3.back);
            Rotate(Vector3.back);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(Vector3.left);
            Rotate(Vector3.left);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Move(Vector3.right);
            Rotate(Vector3.right);
        }

    }

    private void Move(Vector3 direction)
    {
        if (CanInMove(direction) == false)
            return;


        _isJumping = true;
        _animator.SetTrigger("Jump");
        transform.Translate(direction);

        JumpEvent?.Invoke();
    }

    private void Rotate(Vector3 direction)
    {
        if (direction == Vector3.forward)
            transform.GetChild(0).eulerAngles = Vector3.up * 0;
        else if (direction == Vector3.back)
            transform.GetChild(0).eulerAngles = Vector3.up * 180;
        else if (direction == Vector3.left)
            transform.GetChild(0).eulerAngles = Vector3.up * -90;
        else if (direction == Vector3.right)
            transform.GetChild(0).eulerAngles = Vector3.up * 90;
    }

    private void EndJump()
    {
        _isJumping = false;
    }

    private bool CanInMove(Vector3 direction)
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position + Vector3.up * 0.5f, direction);

        if (Physics.Raycast(ray, out hit, 1))
        {
            if (hit.collider.tag == "Obstacle")
                return false;
            else
                return true;
        }
        else
            return true;
    }

    private void Death()
    {
        if (_isActivePlayer == false)
            return;

        _isActivePlayer = false;
        _animator.SetTrigger("Death");
        DeathEvent?.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car")
            Death();
    }
}
