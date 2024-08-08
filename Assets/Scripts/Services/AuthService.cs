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
        public static void LoginPlayer(string name, string password, Action<AuthResponseDto> callback)
        {

            Dictionary<string, string> formData = new Dictionary<string, string>();
                formData.Add("Name", name);
                formData.Add("Password", password);

            ApiProvider.Instance.StartCoroutine(ApiProvider.Instance.PostRequest("/auth", formData,
            (responseJson) =>
            {
                var dataUser = JsonConvert.DeserializeObject<AuthResponseDto>(responseJson);
                Debug.Log(dataUser.player.id);
                PlayerPrefs.SetString("NamePlayer", dataUser.player.name);
                PlayerPrefs.SetString("IdPlayer", dataUser.player.id);
                callback(dataUser);
            },
            (error) =>
            {
                Debug.Log("Hubo un gran error");
                callback( new AuthResponseDto{ok = false, player = null});
            }));

        }

    }
}
