using UnityEngine;

namespace TicToe
{
    //простой MonoBehaviour в котором будут ссылки на камеру(и другие элементы сцены)
    public class SceneData : MonoBehaviour
    {
        public Transform CameraTransform;
        public Camera Camera;
    }
}