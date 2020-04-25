using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followplayer : MonoBehaviour
{
    public Transform player;

    private float FollowSpeed = 5.0f;
    // Start is called before the first frame update

    private Transform tr;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tr.position = Vector3.Lerp(this.transform.position, new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z), FollowSpeed * Time.deltaTime);
    }
}
