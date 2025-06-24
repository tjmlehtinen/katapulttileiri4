using UnityEngine;

public class CatapultScript : MonoBehaviour
{
    public Transform shootPoint;
    public Rigidbody ammoBody;
    public Vector3 launchDirection = new Vector3(0, 1, 1);
    public float launchForce = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Launch();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetCatapult();
        }
    }

    void Launch()
    {
        ammoBody.isKinematic = false;
        ammoBody.AddForce(launchDirection * launchForce, ForceMode.Impulse);
    }

    void ResetCatapult()
    {
        ammoBody.isKinematic = true;
        ammoBody.transform.position = shootPoint.position;
    }
}
