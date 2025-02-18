using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] BallController ball;
    public Vector3 offset;

    private void Start()
    {
        transform.position = ball.transform.position + offset;
    }

    // Update is called once per frame
    void Update()
    {
        var oldPos = transform.position;
        transform.position = new Vector3()
        {
            x = ball.transform.position.x + offset.x,
            y = oldPos.y,
            z = ball.transform.position.z + offset.z
        };
    }
}
