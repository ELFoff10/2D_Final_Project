using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
	[SerializeField]
	private Image m_VisualJoystick;

	[SerializeField]
	private Image m_Stick;

	public Vector3 Value { get; private set; }

	public void OnDrag(PointerEventData eventData)
	{
		var position = Vector2.zero;

		RectTransformUtility.ScreenPointToLocalPointInRectangle
			(m_VisualJoystick.rectTransform, eventData.position, eventData.pressEventCamera, out position);

		var sizeDelta = m_VisualJoystick.rectTransform.sizeDelta;
		position.x = (position.x / sizeDelta.x);
		position.y = (position.y / sizeDelta.y);

		var x = (m_VisualJoystick.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
		var y = (m_VisualJoystick.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

		Value = new Vector3(x, y, 0);
		Value = (Value.magnitude > 1) ? Value.normalized : Value;

		var delta = m_VisualJoystick.rectTransform.sizeDelta;

		m_Stick.rectTransform.anchoredPosition = new Vector3(Value.x * (delta.x / 3)
			, Value.y * (delta.y) / 3);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		OnDrag(eventData);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		Value = Vector3.zero;
		m_Stick.rectTransform.anchoredPosition = Vector3.zero;
	}
}