using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class Restarter : MonoBehaviour
    {
        private GameOverHandeler rGame;

        void Awake() {
            rGame = GameObject.Find("GameHandler").GetComponent<GameOverHandeler>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                rGame.gameOver();
            }
        }
    }
}
