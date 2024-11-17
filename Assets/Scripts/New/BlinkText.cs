using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlinkText : MonoBehaviour
{
    private Text textComponent;
    private bool isSceneLoading = false;

    [Tooltip("Controls the blink speed. Higher values result in faster blinking.")]
    [SerializeField] private float blinkSpeed = 2.0f;

    private void Awake()
    {
        textComponent = GetComponent<Text>();
        if (textComponent == null)
        {
            Debug.LogError("Text component not found. Please attach this script to an object with a Text (Legacy) component!");
        }
    }

    private void Start()
    {
        if (textComponent != null)
        {
            StartCoroutine(BlinkEffect());
        }
    }

    private void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Z) && !isSceneLoading)
        // {
        //     isSceneLoading = true;
        //     StopAllCoroutines();
        //     StartCoroutine(LoadSceneWithDelay("Old_Title", 0.2f));
        // }
    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    private IEnumerator BlinkEffect()
    {
        while (true)
        {
            for (float alpha = 0; alpha <= 1; alpha += Time.deltaTime * blinkSpeed)
            {
                SetTextAlpha(alpha);
                yield return null;
            }
            for (float alpha = 1; alpha >= 0; alpha -= Time.deltaTime * blinkSpeed)
            {
                SetTextAlpha(alpha);
                yield return null;
            }
        }
    }

    private void SetTextAlpha(float alpha)
    {
        if (textComponent != null)
        {
            Color color = textComponent.color;
            color.a = alpha;
            textComponent.color = color;
        }
    }
}