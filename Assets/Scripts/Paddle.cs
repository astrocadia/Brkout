using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public float paddleSpeed = 1f;
    public AudioClip ping;
    private Vector3 playerPos = new Vector3 (0, -9.5f, 0);

    // Update is called once per frame
    void OnCollisionEnter(Collision other)
    { AudioSource.PlayClipAtPoint(ping, playerPos);
    }


    void Update () {
        float xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
        playerPos = new Vector3(Mathf.Clamp(xPos, -13f, 13f), -9.5f, 0f);
        transform.position = playerPos;
	}
}
