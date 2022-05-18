using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //v�istelynopeus
    [SerializeField] float dodgeSpeed;

    //muuttuja, jolla rajoitetaan pelaajan liike arvoon maxX
    [SerializeField] float maxX;

    //muuttuja liikkumiseen vasempaan tai oikeaan, x- akselilla
    float xInput;

    void Update()
    {
        //liikutetaan pelaajaa nuolin�pp�imi� painamalla...
        xInput = Input.GetAxis("Horizontal");

        //...tai liikutetaan pelaajaa koskettamalla k�nnyk�n n�ytt��
        TouchInput();

        transform.Translate(xInput * dodgeSpeed * Time.deltaTime, 0, 0);

        //rajoitetaan pelaajan liike v�lille -maxX, maxX
        float limitedX = Mathf.Clamp(transform.position.x, -maxX, maxX);

        transform.position = new Vector3(limitedX, transform.position.y, transform.position.z);

    }

    void TouchInput()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = Input.mousePosition;

            float middle = Screen.width / 2;

            if (touchPos.x < middle)
            {
                xInput = -1;
            }
            else
            {
                xInput = 1;
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        GameManager.gameManager.Restart();
    }


}
