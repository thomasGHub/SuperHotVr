using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputAction playerInputAction;
    public GameObject laser;
    public GameObject menu;
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
        playerInputAction.Player.Menu.Enable();
        playerInputAction.Player.Menu.performed += MenuActive;
    }

    private void OnDisable()
    {
        playerInputAction.Player.Newaction.Disable();
        playerInputAction.Player.Menu.Disable();

    }

    void laserStart(InputAction.CallbackContext context)
    {
        float dist = Vector3.Distance(rightHand.position, transform.position);
        Debug.Log(dist);
        if (dist < distanceLaser)
        {
            var projectile = Instantiate(laser, transform.position + new Vector3(0, -0.2f, 0), Quaternion.identity);
            projectile.GetComponent<Rigidbody>().velocity = transform.forward * shootSpeed;
            Destroy(projectile.gameObject, 1f);
        }
    }

    void MenuActive(InputAction.CallbackContext context)
    {
        var menuVar = Instantiate(menu);
        Destroy(menuVar, 2f);
    }
}
