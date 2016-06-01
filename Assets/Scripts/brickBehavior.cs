using UnityEngine;
using System.Collections;

public class brickBehavior : MonoBehaviour {
    public int score;
    public AudioClip brickbust;
    public GameObject brickParticle;

    void OnCollisionEnter(Collision other)
    {
        Instantiate(brickParticle, transform.position, Quaternion.identity);
        GM.instance.DestroyBrick(score);
        AudioSource.PlayClipAtPoint(brickbust, gameObject.transform.position);
        Destroy(gameObject);
    }
}
