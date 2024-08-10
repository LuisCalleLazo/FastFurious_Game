using System;
using System.Collections.Generic;
using FastFurios_Game.Dtos;
using FastFurios_Game.Provider;
using Newtonsoft.Json;
using UnityEngine;

namespace FastFurios_Game.Services
{
    public class AuthService : MonoBehaviour
    {
        public static void LoginPlayer(string name, string password, Action<AuthResponseDto> callback, Action<List<string>> errorMessage)
        {

            Dictionary<string, string> formData = new Dictionary<string, string>();
                formData.Add("NameOrGmail", name);
                formData.Add("Password", password);

            ApiProvider.Instance.StartCoroutine(ApiProvider.Instance.PostRequest("/auth/login", formData,
            (responseJson) =>
            {
                var dataUser = JsonConvert.DeserializeObject<AuthResponseDto>(responseJson);
                Debug.Log(dataUser.Player.Id);
                PlayerPrefs.SetString("NamePlayer", dataUser.Player.Name);
                PlayerPrefs.SetString("IdPlayer", dataUser.Player.Id.ToString());
                callback(dataUser);
            },
            (error) =>
            {
                errorMessage(error);
            }));

        }

    }
}
