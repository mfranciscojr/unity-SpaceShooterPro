using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float _speed = 8.0f; //Laser fire speed

    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        // Laser Behavior
        Vector3 _laserSpeed = Vector3.up * _speed * Time.deltaTime;
        transform.Translate(_laserSpeed);
        //-//

        if(transform.position.y >= 8)
        {
            Destroy(this.gameObject);
        }
    }
}
