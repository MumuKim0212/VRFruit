using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public GameObject effect;
    AudioSource audio;

    static int score;
    public Text textScore;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        RaycastHit hit;
        if(Input.GetMouseButton(0) || Input.GetMouseButton(2))
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
