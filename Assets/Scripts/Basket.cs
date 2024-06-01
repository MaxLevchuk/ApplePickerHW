using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;

    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        if (scoreGO != null)
        {
            scoreGT = scoreGO.GetComponent<Text>();
            if (scoreGT != null)
            {
                scoreGT.text = "0";
            }
            else
            {
                Debug.LogError("Text component not found on ScoreCounter object.");
            }
        }
        else
        {
            Debug.LogError("ScoreCounter object not found.");
        }
    }

    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();
        }
    }
}
