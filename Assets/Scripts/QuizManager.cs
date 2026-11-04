using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    private static readonly string[] OptionPrefixes = { "A) ", "B) ", "C) ", "D) " };

    [Header("Configuración de la Pregunta")]
    [TextArea(2, 4)]
    public string questionPrompt;

    [TextArea(2, 4)]
    public string[] options = new string[4];

    [Range(0, 3)]
    public int correctOptionIndex = 0;

    public int nextSceneBuildIndex = 1;

    [Header("Referencias UI")]
    public TextMeshProUGUI questionText;
    public Button[] optionButtons = new Button[4];
    public Image[] optionBackgrounds = new Image[4];
    public TextMeshProUGUI[] optionLabels = new TextMeshProUGUI[4];
    public TextMeshProUGUI feedbackText;
    public Button lobbyButton;

    [Header("Colores Estilo Millonario")]
    public Color normalColor = new Color32(15, 23, 42, 245);    // #0F172A
    public Color selectedColor = new Color32(245, 158, 11, 255); // #F59E0B (Ámbar/Naranja)
    public Color correctColor = new Color32(16, 185, 129, 255);  // #10B981 (Verde)
    public Color wrongColor = new Color32(239, 68, 68, 255);     // #EF4444 (Rojo)

    [Header("Audio Opcional")]
    public AudioSource audioSource;
    public AudioClip selectClip;
    public AudioClip correctClip;
    public AudioClip wrongClip;

    private bool _isEvaluating;
    private Coroutine _evaluationCoroutine;

    private void Awake()
    {
        EnsureInteractiveState();
        BindListeners();
    }

    private void Start()
    {
        EnsureInteractiveState();
        RefreshUI();
    }

    private void OnValidate()
    {
        if (!Application.isPlaying)
        {
            RefreshUI();
        }
    }

    private void OnDestroy()
    {
        UnbindListeners();
    }

    private static void EnsureInteractiveState()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void BindListeners()
    {
        if (optionButtons != null)
        {
            for (int i = 0; i < optionButtons.Length; i++)
            {
                int index = i;
                Button btn = optionButtons[i];
                if (btn != null)
                {
                    btn.onClick.RemoveAllListeners();
                    btn.onClick.AddListener(() => OnOptionClicked(index));
                }
            }
        }

        if (lobbyButton != null)
        {
            lobbyButton.onClick.RemoveAllListeners();
            lobbyButton.onClick.AddListener(ReturnToLobby);
        }
    }

    private void UnbindListeners()
    {
        if (optionButtons != null)
        {
            for (int i = 0; i < optionButtons.Length; i++)
            {
                if (optionButtons[i] != null)
                {
                    optionButtons[i].onClick.RemoveAllListeners();
                }
            }
        }

        if (lobbyButton != null)
        {
            lobbyButton.onClick.RemoveAllListeners();
        }
    }

    public void RefreshUI()
    {
        if (questionText != null)
        {
            questionText.text = questionPrompt ?? string.Empty;
        }

        for (int i = 0; i < 4; i++)
        {
            if (optionLabels != null && i < optionLabels.Length && optionLabels[i] != null)
            {
                string rawText = (options != null && i < options.Length && options[i] != null)
                    ? options[i].Trim()
                    : string.Empty;

                string prefix = OptionPrefixes[i];
                if (!string.IsNullOrEmpty(rawText) && !rawText.StartsWith(prefix))
                {
                    optionLabels[i].text = prefix + rawText;
                }
                else
                {
                    optionLabels[i].text = rawText;
                }
            }

            if (optionBackgrounds != null && i < optionBackgrounds.Length && optionBackgrounds[i] != null)
            {
                optionBackgrounds[i].color = normalColor;
            }
        }

        if (feedbackText != null)
        {
            feedbackText.text = "Selecciona la respuesta correcta:";
            feedbackText.color = new Color32(226, 232, 240, 255);
        }

        SetButtonsInteractable(true);
        _isEvaluating = false;
    }

    public void OnOptionClicked(int optionIndex)
    {
        if (_isEvaluating)
        {
            return;
        }

        if (_evaluationCoroutine != null)
        {
            StopCoroutine(_evaluationCoroutine);
        }

        _evaluationCoroutine = StartCoroutine(EvaluateOptionRoutine(optionIndex));
    }

    private IEnumerator EvaluateOptionRoutine(int selectedIndex)
    {
        _isEvaluating = true;
        EnsureInteractiveState();
        SetButtonsInteractable(false);

        // Fase 1: Selección en Ámbar/Naranja (#F59E0B) durante 0.5s
        SetOptionColor(selectedIndex, selectedColor);
        if (feedbackText != null)
        {
            feedbackText.text = "Verificando respuesta...";
            feedbackText.color = selectedColor;
        }
        PlaySound(selectClip);

        yield return new WaitForSecondsRealtime(0.5f);

        // Fase 2: Evaluación
        bool isCorrect = selectedIndex == correctOptionIndex;
        if (isCorrect)
        {
            SetOptionColor(selectedIndex, correctColor);
            if (feedbackText != null)
            {
                feedbackText.text = "¡Respuesta Correcta!";
                feedbackText.color = correctColor;
            }
            PlaySound(correctClip);

            yield return new WaitForSecondsRealtime(1.0f);
            SceneTransitionManager.LoadScene(nextSceneBuildIndex);
        }
        else
        {
            SetOptionColor(selectedIndex, wrongColor);
            if (feedbackText != null)
            {
                feedbackText.text = "Respuesta incorrecta, analiza la definición e inténtalo de nuevo";
                feedbackText.color = wrongColor;
            }
            PlaySound(wrongClip);

            yield return new WaitForSecondsRealtime(0.9f);

            // Restaurar estado para reintento inmediato
            SetOptionColor(selectedIndex, normalColor);
            if (feedbackText != null)
            {
                feedbackText.text = "Selecciona la respuesta correcta:";
                feedbackText.color = new Color32(226, 232, 240, 255);
            }
            SetButtonsInteractable(true);
            _isEvaluating = false;
        }
    }

    private void SetOptionColor(int index, Color color)
    {
        if (optionBackgrounds != null && index >= 0 && index < optionBackgrounds.Length && optionBackgrounds[index] != null)
        {
            optionBackgrounds[index].color = color;
        }
    }

    private void SetButtonsInteractable(bool interactable)
    {
        if (optionButtons == null)
        {
            return;
        }

        for (int i = 0; i < optionButtons.Length; i++)
        {
            if (optionButtons[i] != null)
            {
                optionButtons[i].interactable = interactable;
            }
        }
    }

    private void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void ReturnToLobby()
    {
        EnsureInteractiveState();
        SceneTransitionManager.ReturnToLobby();
    }
}

