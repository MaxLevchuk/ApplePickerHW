using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{
    public Text scoreGT;
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    private GameObject scoreGO;
    public string NextScene;

    void Start()
    {
        scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();

        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
        }
    }

    public void AppleDestroyed()
    {
        int currentScore = int.Parse(scoreGT.text);
        PlayerPrefs.SetInt("PlayerScore", currentScore);

        scoreGT.text = "0"; // Reset score or handle appropriately

        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject go in appleArray)
        {
            Destroy(go);
        }

        GameObject[] basketArray = GameObject.FindGameObjectsWithTag("Basket");
        if (basketArray.Length > 0)
        {
            Destroy(basketArray[basketArray.Length - 1]);
        }

        
        SceneManager.LoadScene(NextScene);
    }
}
