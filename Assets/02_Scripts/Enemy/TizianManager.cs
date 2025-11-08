using UnityEngine;
using UnityEngine.UIElements;

public class TizianManager : MonoBehaviour
{
    [SerializeField] private UIDocument _uiDoc;
    private VisualElement _root;

    [SerializeField] Texture2D _picture1;
    [SerializeField] Texture2D _picture2;
    [SerializeField] Texture2D _picture3;

    private VisualElement _picture1VisualElement;
    private VisualElement _picture2VisualElement;
    private VisualElement _picture3VisualElement;

    private void Awake()
    {
        _root = _uiDoc.rootVisualElement;
    }

    private void Start()
    {
        _picture1VisualElement = _root.Q<VisualElement>("Picture1");
        _picture2VisualElement = _root.Q<VisualElement>("Picture2");
        _picture3VisualElement = _root.Q<VisualElement>("Picture3");
    }

    public void SwitchPictureTo(int number)
    {
        switch(number)
        {

            case 1:
                _picture1VisualElement.style.backgroundImage = _picture1;
                break;
            case 2:
                _picture1VisualElement.style.backgroundImage = _picture2;
                break;
            case 3:
                _picture1VisualElement.style.backgroundImage = _picture3;
                break;
            default:
                break;
        }
    }

    void LateUpdate()
    {
        Camera cam = Camera.main;
        if (cam == null)
        {
            return;
        }

        transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward, cam.transform.rotation * Vector3.up);
    }


}
