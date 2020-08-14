using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float _speed = 4.0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(Random.Range(-9.4f, 9.4f), 6f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _direction = Vector3.down;
        transform.Translate(_direction * _speed * Time.deltaTime);
        if(transform.position.y <= -6f)
        {
            transform.position = new Vector3(Random.Range(-9f, 9f), 6f, 0);
        }
        //-//
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Player player = other.transform.GetComponent<Player>();
            if(player != null)
            {
                player.Damage();
                Destroy(this.gameObject);
            }
        }
        if(other.gameObject.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

}
