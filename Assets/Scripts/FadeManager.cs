using UnityEngine;
using System.Collections.Generic;

public class FadeManager : MonoBehaviour
{
    [SerializeField] private List<FadeController> objectsToFade = new List<FadeController>();
    [SerializeField] private float fadeDuration = 2f;

    private bool isFading = false;
    private bool hasFadedOut = false;
    private float timer = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) && !isFading && !hasFadedOut)
        {
            StartFade();
        }

        if (isFading)
        {
            timer += Time.deltaTime;
            float progress = Mathf.Clamp01(timer / fadeDuration);
            float opacity = 1f - progress;

            foreach (FadeController fader in objectsToFade)
            {
                if (fader != null)
                {
                    fader.SetMaterialsToTransparent();
                    fader.SetOpacity(opacity);
                }
            }

            // Stop fading when the timer completes
            if (timer >= fadeDuration)
            {
                isFading = false;
                hasFadedOut = true;
            }
        }
    }

    public void StartFade()
    {
        timer = 0f;
        isFading = true;
    }
}
