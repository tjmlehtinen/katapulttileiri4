using UnityEngine;

public class BoxScript : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody myBody;
    private bool hasScored = false;
    public int boxScore = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        myBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ResetBox();
        }
        CheckScore();
    }

    void ResetBox()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
        myBody.linearVelocity = Vector3.zero;
        myBody.angularVelocity = Vector3.zero;
    }

    void CheckScore()
    {
        if (!hasScored && Vector3.Distance(startPosition, transform.position) > 1)
        {
            hasScored = true;
            ScoreManager.Instance.AddScore(boxScore);
        }
    }
}
