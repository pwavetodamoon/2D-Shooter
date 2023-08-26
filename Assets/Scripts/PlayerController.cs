using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;




public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private float _Speed;
    [SerializeField] private float _blood;
    [SerializeField] private float _maxBlood;


    [SerializeField] private Animator _anim;
    [SerializeField] private Animator _animAim;
    [SerializeField] private Transform _BulletSpawner;
    [SerializeField] private GameObject _Bullet;

    private PlayerInputActionMap _inputActions;
    public bool _stillAlive;

    private void Awake()
    {
        _stillAlive = true;
        _blood = _maxBlood;
    }
    private void OnEnable()
    {
        _inputActions = new PlayerInputActionMap();
        _inputActions.Player.Move.Enable();
        _inputActions.Player.Shoot.Enable();
        _inputActions.Player.Shoot.performed += Shooting; 
       

    }

    private void Shooting(InputAction.CallbackContext context)
    {
        if(context.performed) 
        {
            Instantiate(_Bullet, _BulletSpawner.position, _BulletSpawner.rotation);
           
        }
        _animAim.SetTrigger("shoot");
    }


    private void OnDisable()
    {
        _inputActions.Disable();
        _inputActions.Player.Move.Disable();
        _inputActions.Player.Shoot.Disable();

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.CompareTag("enemy"))
        //{
        //    TakeDamage(5);
        //    if (_blood == 0)
        //    {
        //        Destroy(gameObject);
        //        _stillAlive = false;
        //    }
        //}
    }
    //private void TakeDamage(int mount)
    //{
    //    _blood -= mount;
    //}

    public void Movement()
    {
        Vector2 inputValue = _inputActions.Player.Move.ReadValue<Vector2>();

        if(inputValue != Vector2.zero) 
        {
            _rb.velocity = new Vector2 (inputValue.x, inputValue.y) *_Speed;
            _anim.SetTrigger("run");
        }
        
        else
        {
            _rb.velocity = Vector2.zero;
            _anim.SetTrigger("idle");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movement();
        
    }
}
