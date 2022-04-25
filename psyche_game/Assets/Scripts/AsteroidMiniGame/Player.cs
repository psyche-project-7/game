using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 15f;
    public float mapWidth = 20f;
    public string nextScene;
    private Rigidbody2D rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed ;

        Vector2 newPosition = rb.position + Vector2.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);

        rb.MovePosition(newPosition);
    }

    void onCollisionEnter2d ()
    {
        FindObjectOfType<GameManager>().EndGame();

    }

    private void switchScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
