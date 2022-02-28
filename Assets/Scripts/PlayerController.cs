using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputAction playerInputAction;
    public Rigidbody laser;
    public float shootSpeed = 300;
    public Transform rightHand;
    public float distanceLaser = 1f;
    private void Awake()
    {
        playerInputAction = new PlayerInputAction();

    }

    private void OnEnable()
    {
        playerInputAction.Player.Newaction.Enable();
        playerInputAction.Player.Newaction.performed += laserStart;
    }

    private void OnDisable()
    {
        playerInputAction.Player.Newaction.Disable();
    }

    void laserStart(InputAction.CallbackContext context)
    {
        float dist = Vector3.Distance(rightHand.position, transform.position);
        if (dist < distanceLaser)
        {
            var projectile = Instantiate(laser, transform.position + new Vector3(0, -0.2f, 0), Quaternion.identity);
            projectile.velocity = transform.forward * shootSpeed;
            Destroy(projectile.gameObject, 1f);
        }
    }
}
