using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class restart : MonoBehaviour{
    private bool canRestart = true;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && canRestart)
        {
            canRestart = false;
            Restart();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            Application.Quit();
        }

    }
    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}