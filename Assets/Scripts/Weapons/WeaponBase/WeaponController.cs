using System;
using UniRx;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
	[Header("Weapon ScriptableObject")]
	public WeaponScriptableObject WeaponData;

	private float _currentCooldown;
	private CompositeDisposable _disposable;
	protected PlayerMovement PlayerMovement;

	protected virtual void Start()
	{
		PlayerMovement = FindObjectOfType<PlayerMovement>();
		_currentCooldown = WeaponData.CooldownDuration;

		Observable.Timer(TimeSpan.FromSeconds(_currentCooldown))
			.Repeat()
			.Subscribe(_ =>
			{
				{
					Attack();
				}
			}).AddTo(_disposable);
	}

	private void OnEnable()
	{
		_disposable = new CompositeDisposable();
	}

	private void OnDisable()
	{
		_disposable?.Clear();
	}

	protected virtual void Attack()
	{
	}
}