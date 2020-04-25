using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class followplayer : MonoBehaviour
{
    public Transform player;
    // Start is called before the first frame update
    private Transform tr;

    private float FollowSpeed = 6.0f;

    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tr.position = Vector3.Lerp(this.transform.position, new Vector3(player.transform.position.x , player.transform.position.y , this.transform.position.z), FollowSpeed * Time.deltaTime);
            //new Vector3(player.position.x, player.position.y, -10f);
    }
}

