using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        //Changes Frame Rate
       // QualitySettings.vSyncCount = 0;
      //  Application.targetFrameRate = 10;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        float horizontal = Input.GetAxis("Horizontal");
       float vertical = Input.GetAxis("Vertical");
        Vector2 position = rigidbody2d.position;
        //Vector2 position = transform.position;
        position.x = position.x +75f* horizontal * Time.deltaTime;
        position.y = position.y + 75f* vertical * Time.deltaTime;
        //transform.position = position;
        rigidbody2d.MovePosition(position);
    }
}
