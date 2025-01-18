using TMPro;
using UnityEngine;

namespace Scenes.PrototypeScenes.InputHandler
{
    public class InputsTest : MonoBehaviour
    {
        [Header("Components")] 
        [SerializeField] private TMP_Text enabledReferenceTxt;
        [SerializeField] private TMP_Text inputVectorText;
        [SerializeField] private TMP_Text isFiringText;
        [SerializeField] private TMP_Text isEnabledText;
    
        [SerializeField] private NoTask.Asteroids.Input.InputHandler inputHandler;
    
        private void Update()
        {
            var currentInputPayload = inputHandler.CurrentInputPayload;
            inputVectorText.SetText($"Input Vector: {currentInputPayload.InputVector}");
            isFiringText.SetText($"Is Firing: {currentInputPayload.IsFiring}");
            isEnabledText.SetText($"Is Enabled: {inputHandler.EnabledInput}");

            var enablingText = inputHandler.EnabledInput ? "disable" : "enable";
            enabledReferenceTxt.SetText($"Press <color=red>F5</color> to {enablingText} input.");
        }
    }
}
