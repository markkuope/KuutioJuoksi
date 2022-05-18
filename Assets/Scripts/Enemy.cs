using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);

        // tuhotaan Enemy, kun se menee pois screeniltä, eli kun z < -10
        if (transform.position.z < -10f)
        {
            GameManager.gameManager.ScoreUp();

            Destroy(gameObject);
        }
    }
}
