using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler  {

    [SerializeField] private Image bgImg;
    [SerializeField] private Image joystickImg;

    private Vector3 direction;

    public Vector3 Direction
    {
        get { return direction; }
    }

    void start()
    {
        bgImg = GetComponent<Image>();
        joystickImg = transform.GetChild(0).GetComponent<Image>();
        direction = Vector3.zero;
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;

        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform,ped.position, ped.pressEventCamera, out pos))
        {
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

            float x = (bgImg.rectTransform.pivot.x == 1f) ? pos.x * 2 + 1 : pos.x * 2 - 1;
            float y = (bgImg.rectTransform.pivot.y == 1f) ? pos.y * 2 + 1 : pos.y * 2 - 1;

            direction = new Vector3(x, 0f, y);

            direction = direction.magnitude > 1 ? direction.normalized : direction;
            joystickImg.rectTransform.anchoredPosition = new Vector3(direction.x * (bgImg.rectTransform.sizeDelta.x / 3), direction.z * (bgImg.rectTransform.sizeDelta.y / 3));
        }


    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        direction = Vector3.zero;
        joystickImg.rectTransform.anchoredPosition = Vector3.zero;
    }
}
