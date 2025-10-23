using Unity.VisualScripting;
using UnityEngine;

namespace CharacterMovement
{
    public class Win:MonoBehaviour
    {
        public GameObject player;
        public GameObject ui;
        public GameObject Camera;
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("OnTriggerEnter2D");
            if (other.CompareTag("Player"))
            {
                player.SetActive(false);
                ui.SetActive(true);
                Debug.Log("YouWin!");
            }
        }
    }
}