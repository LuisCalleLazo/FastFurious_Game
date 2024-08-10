using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using FastFurios_Game.Utils;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace FastFurios_Game.Provider
{
  public class ApiProvider : MonoBehaviour
  {
    private static ApiProvider instance;
    private static string baseUrl;
    public static ApiProvider Instance
    {
      get
      {
        if (instance == null)
        {
          instance = FindObjectOfType<ApiProvider>();
          if (instance == null)
          {
            GameObject apiProviderObject = new GameObject("ApiProvider");
            instance = apiProviderObject.AddComponent<ApiProvider>();
            baseUrl = ConfigManager.GetApiUrl();
          }
        }
        return instance;
      }
    }

    public IEnumerator PostRequest( string endpoint, Dictionary<string, string> formData, Action<string> onSuccess, Action<List<string>> onError)
    {
      string apiUrl = baseUrl + endpoint;

      WWWForm form = new WWWForm();
      foreach (var kvp in formData)
      {
        form.AddField(kvp.Key, kvp.Value);
      }
      using (UnityWebRequest www = UnityWebRequest.Post(apiUrl, form))
      {
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
          string response = www.downloadHandler.text;
          onSuccess?.Invoke(response);
        }
        else
        {
            try
            {
                // Intenta deserializar la respuesta de error en un ErrorDto
                var errorDto = JsonConvert.DeserializeObject<List<string>>(www.downloadHandler.text);
                if (errorDto != null && errorDto != null)
                    onError?.Invoke(errorDto);
                else
                    // Si no se puede deserializar, invoca el error con el mensaje general
                    onError?.Invoke(new List<string> { $"Fallo al conectar: {www.error}" });
            }
            catch (Exception ex)
            {
                onError?.Invoke(new List<string> { $"Fallo al conectar: {www.error}", $"Error: {ex.Message}" });
            }
        }
      }
    }
    
    public IEnumerator GetRequest(string endpoint, Action<string> onSuccess, Action<string> onError)
    {
      string apiUrl = baseUrl + endpoint;

      using (UnityWebRequest www = UnityWebRequest.Get(apiUrl))
      {
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
          string response = www.downloadHandler.text;
          onSuccess?.Invoke(response);
        }
        else
        {
          onError?.Invoke($"Fallo al conectar {www.error}");
        }
      }
    }
    
    public IEnumerator DeleteRequest(string endpoint, Action<string> onSuccess, Action<string> onError)
    {
      string apiUrl = baseUrl + endpoint;
      
      using (UnityWebRequest www = UnityWebRequest.Delete(apiUrl))
      {
        yield return www.SendWebRequest();

        if (www.result == UnityWebRequest.Result.Success)
        {
          string response = www.downloadHandler.text;
          onSuccess?.Invoke(response);
        }
        else
        {
          onError?.Invoke($"Fallo al conectar {www.error}");
        }
      }
    }
  }
}
