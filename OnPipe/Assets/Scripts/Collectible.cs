using UnityEngine;

public class Collectible : MonoBehaviour
{
    Rigidbody rbd;

    void Start()
    {
        rbd = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            rbd.AddRelativeForce(new Vector3(0,-3,0),ForceMode.Impulse);
            transform.rotation = Random.rotation;
            rbd.useGravity = true;
            FindObjectOfType<ScoreController>().AddScore(1);
        }

        if(other.tag == "Plane")
        {
            Destroy(gameObject);
        }
    }
}
