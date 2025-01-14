using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morango : MonoBehaviour
{

    private SpriteRenderer sr;
    private CircleCollider2D circle;

    public GameObject collected;
    public int Score;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        circle = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player"){

            sr.enabled = false;
            circle.enabled = false;
            collected.SetActive(true);

            GameController.instance.totalScore += Score;
            GameController.instance.updateScoreTxt();   

            Destroy(gameObject,0.3f);
        }
    }

}


