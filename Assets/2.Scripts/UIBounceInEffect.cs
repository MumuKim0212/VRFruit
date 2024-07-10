using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;
using Sequence = DG.Tweening.Sequence;

public class UIBounceInEffect : MonoBehaviour
{
    public float duration = 0.5f;
    public float startScale = 0.3f;
    public float overshootScale = 1.2f;
    public Ease easeType = Ease.OutBack;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void PlayBounceInAnimation()
    {
        // �ʱ� ũ�� ����
        rectTransform.localScale = Vector3.one * startScale;

        // �ִϸ��̼� ������ ����
        Sequence bounceSequence = DOTween.Sequence();

        // ũ�� ���� �ִϸ��̼�
        bounceSequence.Append(rectTransform.DOScale(Vector3.one * overshootScale, duration * 0.6f).SetEase(easeType));

        // ���� ũ��� ���ƿ��� �ִϸ��̼�
        bounceSequence.Append(rectTransform.DOScale(Vector3.one, duration * 0.4f).SetEase(Ease.InOutSine));

        // �ִϸ��̼� ����
        bounceSequence.Play();
    }

    public void PlayBounceOutAnimation(TweenCallback onComplete = null)
    {
        // �ִϸ��̼� ������ ����
        Sequence bounceOutSequence = DOTween.Sequence();

        // �ణ Ŀ���� �ִϸ��̼�
        bounceOutSequence.Append(rectTransform.DOScale(Vector3.one * overshootScale, duration * 0.3f).SetEase(Ease.OutSine));

        // �۾����鼭 ������� �ִϸ��̼�
        bounceOutSequence.Append(rectTransform.DOScale(Vector3.one * startScale, duration * 0.7f).SetEase(Ease.InBack));

        // �ִϸ��̼� �Ϸ� �� �ݹ� ����
        if (onComplete != null)
        {
            bounceOutSequence.OnComplete(onComplete);
        }

        // �ִϸ��̼� ����
        bounceOutSequence.Play();
    }
}