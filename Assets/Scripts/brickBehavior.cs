using UnityEngine;
using System.Collections;

public class brickBehavior : MonoBehaviour {
    public int score;

    public GameObject brickParticle;

    void OnCollisionEnter(Collision other)
    {
        Instantiate(brickParticle, transform.position, Quaternion.identity);
        GM.instance.DestroyBrick(score);
        Destroy(gameObject);
    }
}
