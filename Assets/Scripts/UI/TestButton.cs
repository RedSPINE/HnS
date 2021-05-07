using UnityEngine;

public class TestButton : MonoBehaviour
{
    public GameObject go;
    private Transform goTransform;

    private void Update() {
        goTransform = go.transform;
    }

    public void OnClick()
    {
        Debug.Log(goTransform.position);
    }
}
