using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [Header("Menu")]
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject settingsMenu;

    [Header("Buttons")]
    [SerializeField] private Button firstSelected;
    [SerializeField] private Button settingsButton;

    private Manette manette;
    private GameObject player;

    private void Awake()
    {
        manette = new Manette();
        manette.UI.Pause.Enable();
        manette.UI.Restart.Enable();

        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnEnable()
    {
        manette.UI.Pause.performed += PauseMenu;
        manette.UI.Restart.performed += Restart;
    }

    private void OnDisable()
    {
        manette.UI.Pause.performed -= PauseMenu;
        manette.UI.Restart.performed -= Restart;
    }

    public void PauseMenu(InputAction.CallbackContext obj)
    {
        if (pauseMenu.activeSelf)
        {
            pauseMenu.SetActive(false);
            EnablePlayerCommands(true);
            Time.timeScale = 1;
        }
        else if (settingsMenu.activeSelf)
        {
            settingsMenu.SetActive(false);
            pauseMenu.SetActive(true);
            settingsButton.Select();
        }
        else
        {
            pauseMenu.SetActive(true);
            firstSelected.Select();
            EnablePlayerCommands(false);
            Time.timeScale = 0;
        }
    }

    public void Restart(InputAction.CallbackContext obj)
    {
        player.GetComponent<FallDeath>().Die();
    }

    private void EnablePlayerCommands(bool active)
    {
        player.GetComponent<HorizontalMovement>().EnableCommands(active);
        player.GetComponent<Jump>().EnableCommands(active);
    }
}
