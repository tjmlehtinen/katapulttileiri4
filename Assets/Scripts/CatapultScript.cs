using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CatapultScript : MonoBehaviour
{
    public Transform turret;
    public Transform shootPoint;
    public Rigidbody ammoBody;
    public TextMeshProUGUI forceText;
    public Slider forceSlider;
    public TextMeshProUGUI angleText;
    public Slider angleSlider;
    public Vector3 launchDirection = new Vector3(0, 1, 1);
    public float launchForce = 10f;
    public float rotationSpeed = 100f;
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
        HandleRotation();
        HandleUI();
    }

    void Launch()
    {
        ammoBody.isKinematic = false;
        ammoBody.transform.parent = null;
        ammoBody.AddForce(launchDirection.normalized * launchForce, ForceMode.Impulse);
    }

    void ResetCatapult()
    {
        ammoBody.isKinematic = true;
        ammoBody.transform.parent = shootPoint;
        ammoBody.transform.position = shootPoint.position;
    }

    void HandleRotation()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        turret.Rotate(Vector3.up * rotationInput * rotationSpeed * Time.deltaTime);
    }

    void HandleUI()
    {
        launchForce = 50 * forceSlider.value;
        forceText.text = "Voima: " + Mathf.RoundToInt(launchForce);
        float launchAngle = (Mathf.PI / 2) * angleSlider.value;
        launchDirection = turret.forward * Mathf.Cos(launchAngle) + Vector3.up * Mathf.Sin(launchAngle);
        angleText.text = "Kulma: " + Mathf.RoundToInt(90 * angleSlider.value);
    }
}