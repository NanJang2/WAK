using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Ang());
    }

    IEnumerator Ang()
    {
        while (true)
        {
            this.transform.position += new Vector3(Random.Range(-1.00f, 1.00f), Random.Range(-1.00f, 1.00f), 0);
            yield return new WaitForSeconds(0.001f);
            this.transform.position = Vector3.zero;
        }
    }
}
