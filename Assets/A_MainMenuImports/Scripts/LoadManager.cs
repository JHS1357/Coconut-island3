using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public string sceneName = "combineScene";
    public Slider prograssBar;
    private AsyncOperation operation;

    //private SaveAndLoad saveAndLoad;

    public static LoadManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        //else { Destroy(gameObject); }
    }

    private void Start()
    {
        StartCoroutine(Loading());
    }

    private IEnumerator Loading()
    {
        operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        float timer = 0.0f;
        while (!operation.isDone)
        {
            yield return null;

            timer += Time.deltaTime;
            if (operation.progress < 0.9f)
            {
                prograssBar.value = Mathf.Lerp(operation.progress, 1.0f, timer);
                if (prograssBar.value >= operation.progress) timer = 0.0f;
            }
            else
            {
                prograssBar.value = Mathf.Lerp(prograssBar.value, 1f, timer);
                if (prograssBar.value >= 0.99f)
                    operation.allowSceneActivation = true;
            }
        }

        /* ���̺�� �ڷ� �ε� */

        gameObject.SetActive(false);
    }
}
