using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Cam : MonoBehaviour {
 
    public GameObject target;
 
    public float offsetX;
    public float offsetY;
    public float offsetZ;
 
    public float DelayTime;
 
    // Update is called once per frame
    void Update () {
        var position = target.transform.position;
        Vector3 FixedPos =
            new Vector3(
                position.x + offsetX,
                position.y + offsetY,
                position.z + offsetZ);
        transform.position = Vector3.Lerp(transform.position, FixedPos, Time.deltaTime * DelayTime);
    }
}