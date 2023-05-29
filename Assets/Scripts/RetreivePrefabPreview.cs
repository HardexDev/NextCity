using UnityEditor;
using UnityEngine;
using UnityEditor.Experimental.AssetImporters;

public class RetreivePrefabPreview : MonoBehaviour
{
    public GameObject prefabToPreview;
    public string imageName = "prefab_preview";
    public string savePath;


    // Start is called before the first frame update
    void Start()
    {
        savePath = "Assets/UI/Sprites/" + imageName + ".png";
        SavePrefabThumbnail();
    }

    private void SavePrefabThumbnail()
    {
        RenderTexture renderTexture = RenderTexture.GetTemporary(256, 256, 24);
        Camera thumbnailCamera = new GameObject("ThumbnailCamera").AddComponent<Camera>();
        thumbnailCamera.targetTexture = renderTexture;
        thumbnailCamera.clearFlags = CameraClearFlags.Color;
        thumbnailCamera.backgroundColor = Color.white;

        // Set the camera's position and rotation to capture the prefab
        thumbnailCamera.transform.position = prefabToPreview.transform.position - Vector3.forward * 10f;
        thumbnailCamera.transform.LookAt(prefabToPreview.transform);

        // Render the prefab onto the render texture
        thumbnailCamera.Render();

        // Create a texture to hold the rendered thumbnail
        Texture2D thumbnailTexture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGB24, false);
        RenderTexture.active = renderTexture;
        thumbnailTexture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        thumbnailTexture.Apply();

        // Encode the texture as a PNG
        byte[] pngData = thumbnailTexture.EncodeToPNG();

        // Save the PNG image to disk
        System.IO.File.WriteAllBytes(savePath, pngData);

        // Cleanup
        RenderTexture.active = null;
        RenderTexture.ReleaseTemporary(renderTexture);
        Destroy(thumbnailCamera.gameObject);
        Destroy(thumbnailTexture);

        Debug.Log("Prefab thumbnail saved at: " + savePath);
    }
}
