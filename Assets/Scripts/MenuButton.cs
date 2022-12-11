using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {
    [SerializeField]
    private GameObject _anrgy;

    [SerializeField]
    private GameObject _peace;

    [SerializeField]
    private Material _angryMaterial;

    [SerializeField]
    private Material _peaceMaterial;

    public void OnPointerEnter(PointerEventData eventData) {
        _anrgy.SetActive(true);
        _peace.SetActive(false);
        RenderSettings.skybox = _angryMaterial;
    }

    public void OnPointerExit(PointerEventData eventData) {
        _anrgy.SetActive(false);
        _peace.SetActive(true);
        RenderSettings.skybox = _peaceMaterial;
    }
}
