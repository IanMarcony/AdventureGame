using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private TargetJoint2D targetJoint2D;

    private BoxCollider2D boxCollider2D;

    public float fallingTime;

    // Start is called before the first frame update
    void Start()
    {
        targetJoint2D = GetComponent<TargetJoint2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator fallPlatform(){
        yield return new WaitForSeconds(fallingTime);
        targetJoint2D.enabled=false;
        boxCollider2D.isTrigger=true;
        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag.Equals("Player")){
            StartCoroutine(fallPlatform());
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.layer == 6){
            Destroy(gameObject);
        }
    }

}
