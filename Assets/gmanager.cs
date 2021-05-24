using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gmanager : MonoBehaviour
{
    public List<GameObject> targets;
    float rate = 1.0f;
    int score = 0;
    public TextMeshProUGUI stext;
    public TextMeshProUGUI gtext;
    public Button button;
    public bool isplay = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnObject());
        stext.text = "Score: " + score;
        isplay = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator spawnObject()
    {
        while (isplay)
        {
            yield return new WaitForSeconds(rate);
            int ind = Random.Range(0, targets.Count);
            Instantiate(targets[ind]);
        }
    }

    public void updateScore(int point)
    {
        score += point;
        stext.text = "Score: " + score;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameover()
    {
        gtext.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
        isplay = false;
    }
}
