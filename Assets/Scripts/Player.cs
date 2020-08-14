using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5.0f; // player movement speed
    [SerializeField]
    private GameObject laserPrefab; //laser prefab
    [SerializeField]
    private float _firerate = 0.5f;
    [SerializeField]
    private float _canFire = 0.15f;
    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;


// Start is called before the first frame update
void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        //_spawnManager = GameObject.Find.tag("Spawn_Manager").GetComponent<SpawnManager>();
        _spawnManager = GameObject.FindGameObjectWithTag("Spawn_Manager").GetComponent<SpawnManager>();
        if(_spawnManager == null)
        {
            Debug.LogError("The Spawn Manager is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }

    }

    void CalculateMovement()
    {
        // Player Movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);
        transform.Translate(direction * _speed * Time.deltaTime);
        //--//

        // Player Bounds
        transform.position = (new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0));
        
        if (transform.position.x > 10.25f)
        {
            transform.position = new Vector3(-10.25f, transform.position.y, 0);
        }
        else if (transform.position.x < -10.25f)
        {
            transform.position = new Vector3(10.25f, transform.position.y, 0);
        }
        //-//
    }
    void FireLaser()
    {
        // Laser fire when space key is pressed
        {
            _canFire = Time.time + _firerate;
            Instantiate(laserPrefab, new Vector3(transform.position.x, transform.position.y + 1.05f, 0), Quaternion.identity);
        }
        //-//

    }

    public void Damage()
    {
        _lives--;
        if (_lives < 1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
            
    }

}
