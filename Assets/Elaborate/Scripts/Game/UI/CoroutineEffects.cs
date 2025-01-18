using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI
{
    public static class CoroutineEffects
    {
        public static IEnumerator FadeEffect(CanvasGroup canvasGroup, float targetAlpha, float duration, Action onComplete = null)
        {
            var startAlpha = canvasGroup.alpha;
            var time = 0f;
            
            while (time < duration)
            {
                canvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
                time += Time.deltaTime;
                yield return null;
            }
            
            canvasGroup.alpha = targetAlpha;
            onComplete?.Invoke();
        }
        
        public static IEnumerator BlinkEffect(SpriteRenderer spriteRenderer, float blinkDuration, int repetitions, Action onComplete = null)
        {
            var timePerBlink = blinkDuration / 2f;
            var currentRepetition = 0;
            
            var secondsWaiter = new WaitForSeconds(timePerBlink);

            while (currentRepetition < repetitions)
            {
                var color = spriteRenderer.color;
                color.a = 0f;
                spriteRenderer.color = color;
                
                yield return secondsWaiter;
                
                color.a = 1f;
                spriteRenderer.color = color;

                currentRepetition++;
            }

            onComplete?.Invoke();
        }
    }
}