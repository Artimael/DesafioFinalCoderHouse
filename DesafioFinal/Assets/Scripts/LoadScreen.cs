using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadScreen : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider loadingBar;
    public Text loadingText;
    public GameObject loadingImage;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadLevelAsync());
    }

    private IEnumerator LoadLevelAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            loadingBar.value = asyncLoad.progress;
            if(asyncLoad.progress >= .9f && !asyncLoad.allowSceneActivation)
            {
                loadingText.text = "Press Any Key to Continue";
                if (Input.anyKeyDown)
                {
                    loadingText.gameObject.SetActive(false);
                    loadingBar.gameObject.SetActive(false);
                    loadingImage.gameObject.SetActive(false);
                    asyncLoad.allowSceneActivation = true;

                }
            }
            yield return null;
        }
    }

}
