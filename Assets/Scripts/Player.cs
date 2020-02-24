using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private AudioClip brickBreak;
    [SerializeField] private AudioClip coinGet;
    [SerializeField] private GameObject GameManager;
    [SerializeField] private GameObject Brick;
    [SerializeField] private int pointsForBrick;
    [SerializeField] private int pointsForCoin;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter(Collision collider) {
        if (collider.gameObject.tag == "Brick" &&
                collider.gameObject.transform.position.y > gameObject.transform.position.y) {
            gameObject.GetComponent<AudioSource>().PlayOneShot(brickBreak);
            GameManager.GetComponent<UICounters>().addScore(pointsForBrick);
            Destroy(collider.gameObject);
        }

        if (collider.gameObject.tag == "CoinBlock" && 
                collider.gameObject.transform.position.y > gameObject.transform.position.y) {
            gameObject.GetComponent<AudioSource>().PlayOneShot(coinGet);
            GameManager.GetComponent<UICounters>().addScore(pointsForCoin);
            GameManager.GetComponent<UICounters>().addCoin(1);
        }

        if (collider.gameObject.tag == "Spike") {
            GameManager.GetComponent<GameManager>().gameOver(false);
        }

        if (collider.gameObject.tag == "Goal") {
            GameManager.GetComponent<GameManager>().gameOver(true);
        }
    }
}
