using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField]
    private Image _progerssBar;
    private void Start()
    {
        StartCoroutine(LoadLevelAsync());
    }

    IEnumerator LoadLevelAsync()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Main");

        while (!asyncOperation.isDone)
        {
            _progerssBar.fillAmount = asyncOperation.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
