using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform playerTarget;
    Vector3 distanceFromPlayer = new Vector3(0, 6, -8);

    void Start()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        var newPos = new Vector3(
            playerTarget.position.x,
            distanceFromPlayer.y,
            playerTarget.position.z + distanceFromPlayer.z
            );
        transform.position = newPos;
    }
}
