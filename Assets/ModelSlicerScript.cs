using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelSlicerScript : MonoBehaviour
{
    public int sliceNumber = 10;
    public int near = 8;
    public int far = 12;

    public void SliceModel()
    {
        Camera mainCamera = Camera.main;
        RenderTexture rt = mainCamera.targetTexture;
        RenderTexture.active = rt;

        float step = (float)(far - near) / sliceNumber;
        for(int i = 0; i < sliceNumber; i++)
        {
            mainCamera.nearClipPlane = near + step * i;
            mainCamera.farClipPlane = near + step * (i+1);
            Debug.LogFormat("near:{0}, far:{1}", mainCamera.nearClipPlane, mainCamera.farClipPlane);
            mainCamera.Render();

            Texture2D screenShot = new Texture2D(rt.width, rt.height, TextureFormat.RGB24, false);
            screenShot.ReadPixels(new Rect(0, 0, screenShot.width, screenShot.height), 0, 0);

            byte[] bytes = screenShot.EncodeToPNG();
            string path = "Slices/slice" + i + ".png";
            System.IO.File.WriteAllBytes(path, bytes);
        }
    }
}
