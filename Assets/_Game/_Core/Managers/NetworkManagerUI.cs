using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

namespace Managers {
    public class NetworkManagerUI : MonoBehaviour {
        [SerializeField] Button startHostButton;
        [SerializeField] Button startClientButton;

        private void Awake() {
            startHostButton.onClick.AddListener(() => {
                NetworkManager.Singleton.StartHost();
                Clicked();
            });
            startClientButton.onClick.AddListener(() => {
                NetworkManager.Singleton.StartClient();
                Clicked();
            });
        }

        private void Clicked() {
            gameObject.SetActive(false);
        }
    }
}