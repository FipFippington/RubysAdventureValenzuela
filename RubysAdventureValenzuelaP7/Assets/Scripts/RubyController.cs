using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // speed
    public float speed = 3.0f;

    // Health Values
    public int maxHealth = 5;
    public int Health { get { return currentHealth; } }
    public int currentHealth;

    //I frames
    bool isInvincible;
    float invincibleTimer;
    public float timeInvincible = 2.0f;

    // colission
    Rigidbody2D rigidbody2d;

    // movement
    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        // sets colission 
        rigidbody2d = GetComponent<Rigidbody2D>();

        // sets health to max
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
                isInvincible = false;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;

        //Colission
        rigidbody2d.MovePosition(position);
    }
    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);


        if (amount < 0)
        {
            if (isInvincible)
                return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
