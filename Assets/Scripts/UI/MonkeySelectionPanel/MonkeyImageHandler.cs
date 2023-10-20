using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ServiceLocator.UI
{
    public class MonkeyImageHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IPointerDownHandler
    {
        private Image monkeyImage;
        private MonkeyCellController owner;
        private Sprite spriteToSet;
        private RectTransform monkeyImageRectTransform;
        private Vector3 initialPosition;
        private Vector3 initialAnchoredPosition;

        public void ConfigureImageHandler(Sprite spriteToSet, MonkeyCellController owner)
        {
            this.spriteToSet = spriteToSet;
            this.owner = owner;
        }

        private void Awake()
        {
            monkeyImage = GetComponent<Image>();
            monkeyImage.sprite = spriteToSet;
            monkeyImageRectTransform = GetComponent<RectTransform>();
            initialPosition = monkeyImageRectTransform.anchoredPosition;
            initialAnchoredPosition = monkeyImageRectTransform.anchoredPosition;

        }
        public void OnDrag(PointerEventData eventData)
        {
            monkeyImageRectTransform.position = eventData.position;

            owner.MonkeyDraggedAt(eventData.position);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            ResetMonkeyPosition();
            owner.MonkeyDroppedAt(eventData.position);
        }

        private void ResetMonkeyPosition()
        {
            monkeyImage.color = new Color(1, 1, 1, 1f);
            monkeyImageRectTransform.position = initialPosition;
            monkeyImageRectTransform.anchoredPosition = initialAnchoredPosition;
            GetComponent<LayoutElement>().enabled = false;
            GetComponent<LayoutElement>().enabled = true;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            monkeyImage.color = new Color(1, 1, 1, 0.6f);
        }
    }
}