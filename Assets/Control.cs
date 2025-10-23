using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Control:MonoBehaviour
    {
        public void Restart()
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
}