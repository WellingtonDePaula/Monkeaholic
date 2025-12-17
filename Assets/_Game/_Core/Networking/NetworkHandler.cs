using System;
using System.Collections.Generic;
using System.Text;
using Unity.Netcode;
using UnityEngine;

namespace Networking {
    public class NetworkHandler : MonoBehaviour {
        private void OnApplicationQuit() {
            if (NetworkManager.Singleton != null) {

                NetworkManager.Singleton.Shutdown();

                Debug.Log("Netcode desligado com sucesso.");
            }
        }

        private void OnDestroy() {
            if (NetworkManager.Singleton != null) {
                NetworkManager.Singleton.Shutdown();
            }
        }
    }
}
