using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool hasPowerUp;
    public float speed = 5f;
    public GameObject focalPoint;
    public GameObject poweredUpIndicator;
    private Rigidbody rigidBd;
    private float repelForce = 2f;

    // Start is called before the first frame update
    void Start()
    {
        rigidBd = GetComponent<Rigidbody>();
        poweredUpIndicator.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        rigidBd.AddForce(focalPoint.transform.forward * verticalInput * speed);
        poweredUpIndicator.transform.position = transform.position + new Vector3(0, 1.5f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp")) {
            hasPowerUp = true;
            poweredUpIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerUpDeactivationCoroutine());
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody bod = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            bod.AddForce(awayFromPlayer * repelForce, ForceMode.Impulse);
        }
    }

    IEnumerator PowerUpDeactivationCoroutine()
    {
        yield return new WaitForSeconds(7);
        poweredUpIndicator.SetActive(false);
        hasPowerUp = false;
    }
}
