using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    //Configuration Paramaters
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float paddlePosMin = 1f;
    [SerializeField] float paddlePosMax = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosInUnits = Input.mousePosition.x / Screen.width * screenWidthInUnits;
        Vector2 paddlePos = new Vector2(mousePosInUnits, transform.position.y);
        paddlePos.x = Mathf.Clamp(paddlePos.x, paddlePosMin, paddlePosMax);
        transform.position = paddlePos;
    }

   

}
