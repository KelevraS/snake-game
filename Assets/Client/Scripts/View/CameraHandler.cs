using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Client.Scripts.MainGame;

namespace Assets.Client.Scripts.View
{
    public class CameraHandler : MonoBehaviour
    {
        [SerializeField]
        private Camera cam;

        public void SetCameraPosition(MainGame.Grid grid)
        {
            var dimensionLength = Mathf.Min(grid.Row, grid.Col);
            transform.position = new Vector3((dimensionLength - 1f) / 2, (dimensionLength - 1f) / 2, 1);
            transform.localEulerAngles = new Vector3(0, 180f, 0);
            cam.orthographic = true;
            cam.orthographicSize = dimensionLength / 2;
            cam.clearFlags = CameraClearFlags.Color;
            cam.backgroundColor = Color.black;
        }
    }
}