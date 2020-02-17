using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{
    [SerializeField] private AudioClip brickBreak;
    [SerializeField] private AudioClip coinGet;
    [SerializeField] private GameObject GameManager;
    [SerializeField] private GameObject Brick;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)){
                if (hit.collider.gameObject.tag == "Brick") {
                    gameObject.GetComponent<AudioSource>().PlayOneShot(brickBreak);
                    GameManager.GetComponent<UICounters>().addScore(50);
                    Destroy(hit.collider.gameObject);
                }

                if (hit.collider.gameObject.tag == "CoinBlock") {
                    gameObject.GetComponent<AudioSource>().PlayOneShot(coinGet);
                    GameManager.GetComponent<UICounters>().addScore(200);
                    GameManager.GetComponent<UICounters>().addCoin(1);
                }
            }
        }
                
    }
}
