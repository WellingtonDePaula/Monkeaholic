using UnityEditor;
using Unity.Netcode;
using UnityEngine;

[InitializeOnLoad]
public static class NetcodeFixer {
    static NetcodeFixer() {
        // Esse evento roda toda vez que você clica no botão de Play/Stop
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
    }

    private static void OnPlayModeStateChanged(PlayModeStateChange state) {
        // Quando você clica para PARAR o jogo
        if (state == PlayModeStateChange.ExitingPlayMode) {
            if (NetworkManager.Singleton != null) {
                Debug.Log("Forçando encerramento do Netcode via Editor...");
                NetworkManager.Singleton.Shutdown();

                // Pequena gambiarra: destrói o objeto para garantir que o socket feche
                Object.DestroyImmediate(NetworkManager.Singleton.gameObject);
            }
        }
    }
}