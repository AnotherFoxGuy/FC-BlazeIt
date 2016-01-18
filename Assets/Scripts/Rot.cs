using UnityEngine;
using System.Collections;

public class Rot : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var o = gameObject.transform.eulerAngles;
        gameObject.transform.eulerAngles = new Vector3(o.x+0.1f, o.y+ 0.1f, o.z+ 0.1f);
    }
}