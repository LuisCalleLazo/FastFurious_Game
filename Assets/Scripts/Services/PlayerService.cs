using System;
using System.Collections;
using System.Collections.Generic;
using FastFurios_Game.Dtos;
using FastFurios_Game.Provider;
using Newtonsoft.Json;
using UnityEngine;

namespace FastFurios_Game.Services
{
    public class PlayerService : MonoBehaviour
    {
        public static void GetDataPlayer(int idPlayer, Action<PlayerDto> callback, Action<List<string>> errorMessage)
        {

            Dictionary<string, string> formData = new Dictionary<string, string>();

            ApiProvider.Instance.StartCoroutine(ApiProvider.Instance.GetRequest($"/player/info-game?id{idPlayer}",
            (responseJson) =>
            {
                var player = JsonConvert.DeserializeObject<PlayerDto>(responseJson);
                Debug.Log(player.Id);
                callback(player);
            },
            (error) =>
            {
                errorMessage(error);
            }));
        }
    }
}