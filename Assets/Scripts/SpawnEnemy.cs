using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemySpawner;
    [SerializeField] private GameObject _Enemy1;
    [SerializeField] private GameObject _Enemy2;

    [SerializeField] private float _timeSpawn ;
    private PlayerController _playerController;
    // Start is called before the first frame update
    private void Start()
    {
        //if(_playerController._stillAlive == true)
        //{
        //    StartCoroutine(spawnEnemy(_timeSpawn, _Enemy1));
        //    StartCoroutine(spawnEnemy(_timeSpawn, _Enemy2));

        //}
        Spawn();

    }

    private void Spawn()
    {
        StartCoroutine(spawnEnemy(_timeSpawn, _Enemy1));
        StartCoroutine(spawnEnemy(_timeSpawn, _Enemy2));
    }

    /* IEnumerator là một interface được sử dụng để tạo các coroutine
     Coroutine là một loại hàm đặc biệt trong Unity,
     cho phép bạn tạm dừng thực thi một hàm tại một thời điểm bất kỳ,
     sau đó tiếp tục thực thi hàm đó ở một thời điểm khác. */

    private IEnumerator spawnEnemy(float _time, GameObject _enemy) // tạo Coroutine ( spawnEnemy)
    {
        // Từ khóa "yield" được sử dụng trong coroutine để tạm dừng thực thi 
        yield

        //  trả về một giá trị cho đoạn code gọi coroutine( spawnEnemy ).
        return new WaitForSeconds(_time);
        Instantiate(_enemy, new Vector3(Random.Range(-15, 15),Random.Range(-10,10),0),Quaternion.identity);
        StartCoroutine(spawnEnemy(_time, _enemy));


    }


}
