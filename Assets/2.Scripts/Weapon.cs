using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public GameObject effect;
    AudioSource audio;

    public static int score;
    public Text textScore;
    AudioSource audioSource;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        Fire();

    }
    public void Fire()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward,
                           out hit, 5))
        {
            Destroy(hit.transform.gameObject);
            Instantiate(effect, hit.point, Quaternion.LookRotation(hit.normal));
            audio.Play();

            score += 10;
            textScore.text = "Score : " + score;
        }
    }
}
