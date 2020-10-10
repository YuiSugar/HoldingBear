using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // bear is hitted by avatar
    bool isHitAvatar = false;
    // avatar object
    GameObject avatar;
    // how many times bear is held
    int heldTimes = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isHitAvatar)
        {
            return;
        }
        UnityEngine.Debug.Log("avatar position: " + avatar.transform.position);
        UnityEngine.Debug.Log("this position: " + this.transform.position);
        float distance = Vector3.Distance(avatar.transform.position, this.transform.position);
        UnityEngine.Debug.Log("distance: " + distance);

        bool isHeld = avatar.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Hold");
        UnityEngine.Debug.Log("isHeld: " + isHeld);
        UnityEngine.Debug.Log("heldTimes: " + heldTimes);

        // if distance from avatar to bear is near than 0.5
        // and bear is held by avatar
        if (distance < 0.5 && isHeld)
        {
            heldTimes++;
            if (heldTimes > 1200) {
                // transport to new location
                this.gameObject.transform.position 
                    = new Vector3(Random.Range(-40.0f, 40.0f), 0.0f, Random.Range(-40.0f, 40.0f));
            }
        }
        else {
            heldTimes = 0;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        UnityEngine.Debug.Log("Hit");
        GameObject hittedObject = collision.gameObject;
        string hittedObjectName = hittedObject.name;
        UnityEngine.Debug.Log("Hit at: " + hittedObjectName);
        if (hittedObjectName.Equals("avatar01_01")) {
            isHitAvatar = true;
            avatar = hittedObject;
        }
    }
}
