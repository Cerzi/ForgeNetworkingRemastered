using System;
using System.Linq;
using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using BeardedManStudios.Forge.Networking.Unity;
using NUnit.Framework.Internal;
using UnityEngine;

namespace BeardedManStudios.Examples.Cube_Forge.Scripts.RPCTest
{
	public class RPCTester : MonoBehaviour
	{
		private TestObject _myObject;
		private TestObject _theirObject;

		[Tooltip("If true, tests sending reliable RPCs instead of unreliable")]
		public bool testReliable;

		private NetworkingPlayer _me;
		private int _ownedCount;
		private int _unownedCount;

		private void Start()
		{
			// Create a test object
			_myObject = (TestObject) NetworkManager.Instance.InstantiateTest();

			_me = NetworkManager.Instance.Networker.Me;
		}

		private void FixedUpdate()
		{
			if (_theirObject == null)
				_theirObject = TryGetTheirObject();

			if (_myObject == null || _theirObject == null) return;

			if (testReliable)
			{
				_myObject.networkObject.SendRpc(TestBehavior.RPC_FUNC_BLANK, Receivers.All);
				_theirObject.networkObject.SendRpc(TestBehavior.RPC_FUNC_BLANK, Receivers.All);
			}
			else
			{
				_myObject.networkObject.SendRpcUnreliable(TestBehavior.RPC_FUNC_BLANK, Receivers.All);
				_theirObject.networkObject.SendRpcUnreliable(TestBehavior.RPC_FUNC_BLANK, Receivers.All);
			}
		}

		/// <summary>
		/// Return the first TestObject found in the scene that isn't ours.
		/// </summary>
		/// <returns></returns>
		private TestObject TryGetTheirObject()
		{
			var objects = FindObjectsOfType<TestObject>();
			return objects.FirstOrDefault(obj => obj != _myObject);
		}

		private void Update()
		{
			if (_myObject == null || _theirObject == null) return;

			_ownedCount = _myObject.TestRPCCount.ContainsKey(_me)
				? _myObject.TestRPCCount[_me]
				: 0;
			_unownedCount = _theirObject.TestRPCCount.ContainsKey(_me)
				? _myObject.TestRPCCount[_me]
				: 0;
		}

		private void OnGUI()
		{
			int w = Screen.width, h = Screen.height;
			GUIStyle style = new GUIStyle();

			Rect rect = new Rect(0, 0, w, h * 2 / 100f);
			style.alignment = TextAnchor.UpperRight;
			style.fontSize = h * 2 / 100;
			style.normal.textColor = Color.white;
			string text;
			if (_myObject == null || _theirObject == null)
				text = "Waiting for second player...";
			else
			{
				text = $"RPC count on OWNED object: {_ownedCount}\r\n";
				text += $"RPC count on UNOWNED object: {_unownedCount}";
			}

			GUI.Label(rect, text, style);
		}
	}
}
