using System;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance;


    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        ProcessFire();
        MoveCrosshair();
        MoveTagertPoint();
        LaserAim();
    }

    private void LaserAim()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 laserDirection = targetPoint.position - transform.position;
            Quaternion laserRotation = Quaternion.LookRotation(laserDirection);
            laser.transform.rotation = laserRotation;
        }
    }

    private void MoveTagertPoint()
    {
        Vector3 targetPointPosition = new Vector3(Mouse.current.position.x.value, Mouse.current.position.y.value, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    private void MoveCrosshair()
    {
        crosshair.position = Mouse.current.position.ReadValue();
    }

    void OnAttack(InputValue inputValue)
    {
        isFiring = inputValue.isPressed;
    }

    void ProcessFire()
    {
        foreach (GameObject laser in lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isFiring;
            
        }
    }
}
