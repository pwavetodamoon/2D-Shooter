using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] protected GameObject _playerTarget;
    [SerializeField] protected float _blood;
    [SerializeField] protected float _maxBlood;
    [SerializeField] protected float _speed;

    protected Animator _animEnemy;




    private void Awake()
    {
        _playerTarget = GameObject.FindWithTag("Player");

        _animEnemy = GetComponentInChildren<Animator>();

        _blood = _maxBlood;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("bullet"))
        {
            Debug.Log("Touched");
            _animEnemy.SetTrigger("gotShoot");
            TakeDamage(5);
            if (_blood == 0)
            {
                Destroy(gameObject);
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Touched");
        }
    }

    private void TakeDamage(int mount)
    {
        _blood -= mount;
    }
    public void Move()
    {
      
           Vector2  dir = (_playerTarget.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, _playerTarget.transform.position, _speed * Time.deltaTime);

            Vector3 localScale = transform.localScale;

            if (transform.position.x < _playerTarget.transform.position.x)
            {
                localScale.x = 1f;

            }
            else
            {
                localScale.x = -1f;

            }
            transform.localScale = localScale;
        

      

          
     

        

    }



}

