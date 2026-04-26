using UnityEngine;
using TMPro;

public class TMPInputMaskToggle : MonoBehaviour
{
    public TMP_InputField inputField;

    private string realText = "";
    private bool isHidden = false;
    private bool isUpdating = false;

    void Awake()
    {
        if (inputField == null)
        {
            Debug.LogError("TMP_InputField not assigned.");
            return;
        }

        inputField.onValueChanged.AddListener(OnValueChanged);
    }

    void OnEnable()
    {
        realText = inputField.text;
        isHidden = true;

        ApplyMask(force: true);
    }

    public void ToggleMask()
    {
        isHidden = !isHidden;

        if (isHidden)
            ApplyMask(force: true);
        else
            Reveal();
    }

    private void OnValueChanged(string value)
    {
        if (isUpdating) return;

        realText = value;

        if (isHidden)
        {
            ApplyMask();
        }
    }

    private void ApplyMask(bool force = false)
    {
        isUpdating = true;

        int caret = inputField.caretPosition;

        char[] masked = new char[realText.Length];

        for (int i = 0; i < realText.Length; i++)
        {
            masked[i] = char.IsWhiteSpace(realText[i]) ? ' ' : '*';
        }

        inputField.text = new string(masked);

        // Force UI refresh to avoid last-character glitch
        inputField.ForceLabelUpdate();

        inputField.caretPosition = Mathf.Min(caret, inputField.text.Length);

        isUpdating = false;
    }

    private void Reveal()
    {
        isUpdating = true;

        inputField.text = realText;

        inputField.ForceLabelUpdate();

        inputField.caretPosition = inputField.text.Length;

        isUpdating = false;
    }
}