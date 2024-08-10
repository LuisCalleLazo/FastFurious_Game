using System.Collections;
using System.Collections.Generic;
using FastFurios_Game.Connections;
using UnityEngine;



namespace FastFurios_Game.UI
{

    public class FadeoutSprite : MonoBehaviour
    {
        public float fadeOutDuration = 1.0f;
        public float spriteLifeTime = 3.0f;
        public ManageErrors manageErrors;
        
        public IEnumerator FadeOutAndRemove(GameObject sprite)
        {
            CanvasGroup canvasGroup = sprite.GetComponent<CanvasGroup>();
            
            if (canvasGroup == null) canvasGroup = sprite.AddComponent<CanvasGroup>();

            yield return new WaitForSeconds(spriteLifeTime);

            float elapsed = 0f;
            while (elapsed < fadeOutDuration)
            {
                elapsed += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(1, 0, elapsed / fadeOutDuration);
                yield return null;
            }

            Destroy(sprite);
        }
        
        public IEnumerator FadeOutAndRemoveListErros(GameObject sprite)
        {
            CanvasGroup canvasGroup = sprite.GetComponent<CanvasGroup>();
            
            if (canvasGroup == null) canvasGroup = sprite.AddComponent<CanvasGroup>();

            yield return new WaitForSeconds(spriteLifeTime);

            float elapsed = 0f;
            while (elapsed < fadeOutDuration)
            {
                elapsed += Time.deltaTime;
                canvasGroup.alpha = Mathf.Lerp(1, 0, elapsed / fadeOutDuration);
                yield return null;
            }
            manageErrors.activeMessages.Remove(sprite);
            Destroy(sprite);
        }
    }

    
}
