using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
	[SerializeField]
	private Image _visualJoystick;

	[SerializeField]
	private Image _stick;

	private Vector3 Value { get; set; }

	public void OnDrag(PointerEventData eventData)
	{
		Vector2 position;

		RectTransformUtility.ScreenPointToLocalPointInRectangle
			(_visualJoystick.rectTransform, eventData.position, eventData.pressEventCamera, out position);

		var sizeDelta = _visualJoystick.rectTransform.sizeDelta;
		position.x = (position.x / sizeDelta.x);
		position.y = (position.y / sizeDelta.y);

		var x = (_visualJoystick.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2 - 1;
		var y = (_visualJoystick.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2 - 1;

		Value = new Vector3(x, y, 0);
		Value = (Value.magnitude > 1) ? Value.normalized : Value;

		var delta = _visualJoystick.rectTransform.sizeDelta;

		_stick.rectTransform.anchoredPosition = new Vector3(Value.x * (delta.x / 3)
			, Value.y * (delta.y) / 3);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		OnDrag(eventData);
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		Value = Vector3.zero;
		_stick.rectTransform.anchoredPosition = Vector3.zero;
	}
}