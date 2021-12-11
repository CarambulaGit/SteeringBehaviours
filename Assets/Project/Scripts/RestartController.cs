using System;
using System.Collections;
using Project.Classes;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts
{
    public class RestartController : MonoBehaviour
    {
        private bool isRestarting;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
            
            if (isRestarting)
            {
                return;
            }
            if ((FindObjectsOfType<Animal>().Length == 0) || Input.GetKeyDown(KeyCode.F5))
            {
                StartCoroutine(RestartCoroutine());
            }
            
        }

        private IEnumerator RestartCoroutine()
        {
            isRestarting = true;
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(Consts.GAME_SCENE_PATH);
        }
    }
}