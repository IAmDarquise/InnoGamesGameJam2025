using UnityEngine;
using UnityEngine.UIElements;

public class RollingTizianManager : MonoBehaviour
{
    [SerializeField] private UIDocument _uiDoc;
    private VisualElement _root;

    [SerializeField] Texture2D _picture1;
    [SerializeField] Texture2D _picture2;
    [SerializeField] Texture2D _picture3;
    [SerializeField] Texture2D _picture4;

    private VisualElement _picture1VisualElement;


    private void Awake()
    {
        _root = _uiDoc.rootVisualElement;
    }

    private void Start()
    {
        _picture1VisualElement = _root.Q<VisualElement>("Picture1");
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
            case 4:
                _picture1VisualElement.style.backgroundImage = _picture4;
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
