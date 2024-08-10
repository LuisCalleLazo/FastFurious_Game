using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FastFurios_Game.Utils
{
    public enum InitValuesGame
    {
        TimeGame = 120, // Seconds
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
}
