using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FastFurios_Game.Utils
{
    public enum InitValuesGame
    {
        TimeGame = 120, // Seconds
    }

    public static class LocalDataEnv
    {
        public static string LoadNextScene() => "LoadNextScene";
    }

    public enum ManageNumberEscene
    {
        Auth = 0,
        LoadToLobby = 1,
        LoadToNextScene = 2,
        Lobby = 3,
        GameOffline = 4
    }

    public static class AxesControls
    {
        public static string ControlHorizontal() => "Horizontal";
        public static string ControlVertical() => "Vertical";
    }

    public static class OptionsOfCar
    {
        public static List<string> GetColorsCars() => 
            new List<string>
            {
                "Rojo",
                "Verde",
                "Azul",
                "Amarrillo",
                "Negro",
                "Blanco"
            };

            
        public static List<string> GetTypeCars() => 
            new List<string>
            {
                "Honda",
                "Toyota",
                "Tesla",
                "Susiki",
                "Monster",
                "Camioneta"
            };
    }
}
