using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputAction playerInputAction;
    public Rigidbody laser;
    public float shootSpeed = 300;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            laserStart();
            Debug.Log("oui");
        }
    }

    void laserStart()
    {
        var projectile = Instantiate(laser, transform.position, Quaternion.Euler(90f, 0f, 0f));
        projectile.velocity = transform.forward * shootSpeed;
        Destroy(projectile.gameObject, 1f);
    }




}
