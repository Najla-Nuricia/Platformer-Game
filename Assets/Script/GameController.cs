using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{
    int progressAmount;
    public Slider progressSlider;

    public GameObject player;
    public GameObject LoadCanvas;
    public List<GameObject> levels;
    private int currentlevelIndex = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       progressAmount = 0;
       progressSlider.value = 0;
       Gem.OnGemCollect += IncreaseProgressAmount;
       HoldToLoadLevel.onHoldComplete += LoadNextlevel;
       LoadCanvas.SetActive(false);
    }

    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        progressSlider.value = progressAmount; 
        if(progressAmount >= 100)
        {
            LoadCanvas.SetActive(true);
            Debug.Log("level complete");
        }
    }

    void LoadNextlevel()
    {
        int nextLevelIndex = (currentlevelIndex == levels.Count -1 ? 0 : currentlevelIndex + 1);
        LoadCanvas.SetActive(false);

        levels[currentlevelIndex].gameObject.SetActive(false);
        levels[nextLevelIndex].gameObject.SetActive(true);

        player.transform.position = new Vector3(0,0,0);

        currentlevelIndex = nextLevelIndex;
        progressAmount = 0;
        progressSlider.value = 0;
    }
}
