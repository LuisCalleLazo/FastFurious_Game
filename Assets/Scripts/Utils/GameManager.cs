using System;
using System.IO;
using UnityEngine;


namespace FastFurios_Game.Utils
{

    [Serializable]
    public class GameSettings
    {
        public string urlApi;
        public string webSocket;
        public static GameSettings CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<GameSettings>(jsonString);
        }
    }

    public static class ConfigManager
    {
        public static GameSettings currentSettings;

        public static string GetJsonSettings()
        {
            string jsonPath = Path.GetFullPath(Path.Combine(Application.dataPath, "appSettings.json"));

            if (!File.Exists(jsonPath))
            {
                Debug.LogError("El archivo gameSettings.json no se encontro en la ruta especificada.");
            }

            string json = File.ReadAllText(jsonPath);

            return json;
        }

        public static string GetApiUrl()
        {
            currentSettings = GameSettings.CreateFromJSON(GetJsonSettings());
            return currentSettings.urlApi;
        }
        public static string GetWebSocket()
        {
            currentSettings = GameSettings.CreateFromJSON(GetJsonSettings());
            return currentSettings.webSocket;
        }
    }
}