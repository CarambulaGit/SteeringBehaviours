using System.Collections;
using System.Threading.Tasks;
using Project.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Project.Scripts {
    public class PlayerController : CanBeKilledController {
        public override void Die() {
            // StartCoroutine(DeathCoroutine());
            DeathTask();
        }

        private async Task DeathTask() {
            gameObject.SetActive(false);
            await Task.Delay(1000);
            SceneManager.LoadScene("Art/Scenes/Game");
        }
        // private IEnumerator DeathCoroutine() {
        //     gameObject.SetActive(false);
        //     yield return null;
        //     SceneManager.LoadScene("Art/Scenes/Game");
        // }
    }
}