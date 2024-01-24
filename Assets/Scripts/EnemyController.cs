using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyController : MonoBehaviour
{
    public float speed = 500.0f;
    private Vector3 direction;
    public Text scoreText; 
    private int score = 0; 


    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }


    void Update()
    {
   
        transform.position = transform.position + direction * speed * Time.deltaTime;

  
        if (transform.position.x <= -1045)
        {
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Projectile")
        {
            Destroy(gameObject);
            score++;
            int currentScore = int.Parse(scoreText.text);
            currentScore++;
            scoreText.text = currentScore.ToString();
        }
    }
}