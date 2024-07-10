using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    public RectTransform transform_cursor;

    private void Start()
    {
        Init_Cursor();
    }
    private void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward,
                           out hit, 5))
        {
            Vector3 mousePos = Input.mousePosition;
            transform_cursor.position = new Vector3(transform.position.x, transform.position.y, 2.5f);

            string message = mousePos.ToString();
            Debug.Log(message);
        }
    }

    private void Init_Cursor()
    {
        //transform_cursor.pivot = Vector2.up;

        if (transform_cursor.GetComponent<Graphic>())
            transform_cursor.GetComponent<Graphic>().raycastTarget = false;
    }
}
