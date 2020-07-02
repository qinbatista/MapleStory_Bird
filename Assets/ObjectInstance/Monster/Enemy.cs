using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject _cloudParticlePrefab;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D other) {
        NormalBird bird = other.collider.GetComponent<NormalBird>();
        if (bird!= null)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
        Enemy enemy = other.collider.GetComponent<Enemy>();
        if(enemy!=null)
        {
            return;
        }
        if (other.contacts[0].normal.y < -0.5)
        {
            Instantiate(_cloudParticlePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
