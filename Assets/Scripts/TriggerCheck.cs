using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider col)
    {
        //if object collides with ball, invoke FallDown
        if (col.gameObject.tag == "Ball")
        {
            Invoke("FallDown", 0.5f);
        }
    }

    void FallDown()
    {
        //enable gravity, no kinematic, destroy object after falling
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject, 1.5f);
    }
}
