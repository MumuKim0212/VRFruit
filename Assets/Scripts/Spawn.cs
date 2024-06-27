using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] prefab;
    public Transform[] pos;

    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        InvokeRepeating("Create", 2, 2); 
    }

    void Create()
    {
        int randomPos = Random.Range(0, pos.Length);

        for (int i = 0; i < 3; i++)
        {
            if (i == randomPos) continue;
            int randomPrefab = Random.Range(0, prefab.Length);

            GameObject obj = Instantiate(prefab[randomPrefab], pos[i].position,
                                    Quaternion.identity);
            Vector3 targetPosition = new Vector3(transform.position.x, obj.transform.position.y, transform.position.z);
            obj.transform.LookAt(targetPosition);
            Destroy(obj, 5f);

            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * Random.Range(3f, 5f),
                        ForceMode.VelocityChange);
        }
        audio.Play();
    }
}
