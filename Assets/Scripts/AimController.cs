using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AimController : MonoBehaviour
{
    [SerializeField] private PlayerInputActionMap inputActions;
    [SerializeField] private Camera mainCam;

     private GameObject body;

    private void Awake()
    {
        body = GameObject.Find("Player");
    }
    private void OnEnable()
    {
        inputActions = new PlayerInputActionMap();
        inputActions.Player.Aim.Enable();

    }

    private void OnDisable()
    {
        inputActions.Player.Aim.Disable();
    }
    private void Aim()
    {
        Vector3 mouseInput = inputActions.Player.Aim.ReadValue<Vector2>(); //dau vao

        Vector3 mousePos = mainCam.ScreenToWorldPoint(mouseInput); // vi tri tu cam -> con tro

        Vector3 lookDir = (mousePos - transform.position).normalized; // tim goc

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;// goc -> do
        transform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 localScale = Vector3.one;// xoay sung
        Vector3 localScaleBody = Vector3.one;// xoay sung

        if (angle > 90 || angle < -90)
        {
            localScale.x = -1f;
            localScale.y = -1f;
            localScaleBody.x = -1f;
        }
        else
        {
            localScale.x = 1f;
            localScale.y = 1f;
            localScaleBody.x = 1f;
        }
        transform.localScale = localScale;
        body.transform.localScale = localScaleBody; 

    }

    private void Update()
    {
        Aim();
    }
}
