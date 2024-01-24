using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverSprite : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject projectile; 
    public float projectileSpeed = 4.0f; 
    private float lastShotTime; 
    private float xMin = -750f;
    private float xMax = 750f;
    private float yMin = -380f;
    private float yMax = 380f;

    
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);

        Vector3 newPosition = transform.position + movement * speed * Time.deltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);
        newPosition.y = Mathf.Clamp(newPosition.y, yMin, yMax);
        transform.position = newPosition;

        if (Input.GetKeyDown(KeyCode.Z) && Time.time - lastShotTime >= 1.0f)
        {
            GameObject shot = Instantiate(projectile, transform.position, Quaternion.identity);
            shot.GetComponent<Rigidbody>().velocity = Vector3.right * projectileSpeed;

            Destroy(shot, 3.0f);

            lastShotTime = Time.time;
        }
    }

    void Start()
    {
        lastShotTime = -0.5f;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}