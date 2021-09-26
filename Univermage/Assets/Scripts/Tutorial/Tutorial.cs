using Cinemachine;
using MEC;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[System.Serializable]
public struct TutorialStage
{
    [Multiline]
    public string tutorialText;
    public UnityEvent tutorialEvent;
}

public class Tutorial : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;

    [SerializeField]
    private CinemachineVirtualCamera playerVCam;

    private CinemachineVirtualCamera lastCamera;

    [SerializeField]
    private TextMeshProUGUI textMesh;

    [SerializeField]
    private TutorialStage[] tutorialStages;

    private int currentStage;

    private void Awake()
    {
        lastCamera = playerVCam;
        NextTutorial();
    }

    private void OnEnable()
    {
        inputManager.Controls.Tutorial.Enable();

        inputManager.Controls.Tutorial.NextTutorial.performed += NextTutorial_performed;
    }

    private void OnDisable()
    {
        inputManager.Controls.Tutorial.Disable();

        inputManager.Controls.Tutorial.NextTutorial.performed -= NextTutorial_performed;
    }

    private void NextTutorial_performed(InputAction.CallbackContext obj)
    {
        NextTutorial();
    }

    public void SetVirtualCamera(CinemachineVirtualCamera virtualCamera)
    {
        lastCamera.Priority = 0;
        virtualCamera.Priority = 10;
    }

    public void ResetVirtualCamera()
    {
        SetVirtualCamera(playerVCam);
    }

    public void NextTutorial()
    {
        if (currentStage == tutorialStages.Length)
        {
            currentStage = 0;
            gameObject.SetActive(false);
            return;
        }

        textMesh.text = tutorialStages[currentStage].tutorialText;
        tutorialStages[currentStage].tutorialEvent?.Invoke();

        currentStage++;
    }


    public void DisableObjects(GameObject gameObject, float delay)
    {
        
    }

    public IEnumerator<float> Wait()
    {
        yield return Timing.WaitForSeconds(2);
        Debug.Log("AZAZA");
    }
}