using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Speed of movement
    public float jumpForce = 5f;
    public bool isGrounded;
    public int enemy = 0;
    private Rigidbody rb; // To apply physics

    public int maxHealth = 100;  // Maximum health
    private int currentHealth;   // Current health
    public Text healthText;
    public GameObject GameOver;
    public int damageAmount = 10; // Amount of damage an enemy deals

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        UpdateHealthUI();
        GameOver.SetActive(false);
        Time.timeScale = 1f;
    }

    public void TakeDamage(int damage)
    {
        // Reduce health
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        UpdateHealthUI();

        // Check if the player is dead
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void UpdateHealthUI()
    {
        // Update the health display
        healthText.text = "Health: " + currentHealth;
    }

    private void Die()
    {
          Time.timeScale = 0f; //To pause the game
          GameOver.SetActive(true);
    }

    void Update()
    {
        float moveForwardBackward = Input.GetAxis("Vertical");  // Vertical movement
        float moveLeftRight = Input.GetAxis("Horizontal");      // Horizontal movement
        Vector3 move = transform.forward * moveForwardBackward + transform.right * moveLeftRight;
        transform.Translate(move * speed * Time.deltaTime, Space.World);

        if (Input.GetButtonDown("Jump") && isGrounded) // Player jump
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the player is touching the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemy++;
            TakeDamage(damageAmount);  // Apply damage when colliding with an enemy

            // Destroy the Enemy
            Destroy(other.gameObject);
        }
    }
}