using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AngryFaceAppear : MonoBehaviour {
    [SerializeField]
    private Image _angryFace;

    public async void ShowAngryFace() {
        _angryFace.gameObject.SetActive(true);
        _angryFace.color = Color.white;
        _angryFace.transform.localScale = Vector3.zero;
        
        _angryFace.transform.DOScale(40,1.5f).SetEase(Ease.Flash);
        _angryFace.DOFade(0,1.5f);
        await Task.Delay(1000);
        _angryFace.gameObject.SetActive(false);
    }
}
