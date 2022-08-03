using UnityEngine;

namespace HuntroxGames.Utils
{
	[System.Serializable]
	public struct FloatRange 
	{

		public float _MinValue;
		public float _MaxValue;

		public FloatRange(float minValue, float maxValue)
		{
			this._MinValue = minValue;
			this._MaxValue = maxValue;
		}

		/// <summary>
		/// returns a Random value between Min and Max Value
		/// </summary>
		public float Random => UnityEngine.Random.Range(MinValue, MaxValue);

		public float MinValue
		{
			get => _MinValue;
			set => _MinValue = Mathf.Clamp(value, float.MinValue, MaxValue);
		}
		public float MaxValue
		{
			get => _MaxValue;

			set => _MaxValue = Mathf.Clamp(value, _MinValue, float.MaxValue);
		}

		public static FloatRange ZeroOne => new FloatRange(0, 1);
		public static FloatRange ZeroTen => new FloatRange(0, 10);
	}
}