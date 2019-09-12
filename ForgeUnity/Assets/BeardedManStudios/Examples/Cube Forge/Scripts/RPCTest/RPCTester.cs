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

		[Tooltip("If true, tests sending reliable RPCs instead of unreliable")]
		public bool testReliable;

		private int _ownedCount;

		private void Start()
		{
			// Create a test object
			_myObject = (TestObject) NetworkManager.Instance.InstantiateTest();

		}

		private void FixedUpdate()
		{
			if (NetworkManager.Instance.IsServer) return; // We are only testing RPCs from client

			if (_myObject == null) return;

			if (testReliable)
			{
				_myObject.networkObject.SendRpc(TestBehavior.RPC_FUNC_BLANK, Receivers.All);
			}
			else
			{
				_myObject.networkObject.SendRpcUnreliable(TestBehavior.RPC_FUNC_BLANK, Receivers.All);
			}
		}

		private void Update()
		{
			if (_myObject == null) return;

			_ownedCount = _myObject.Count;
		}

		private void OnGUI()
		{
			int w = Screen.width, h = Screen.height;
			GUIStyle style = new GUIStyle();

			Rect rect = new Rect(0, 0, w, h * 2 / 100f);
			style.alignment = TextAnchor.UpperRight;
			style.fontSize = h * 2 / 100;
			style.normal.textColor = Color.white;
			var text = $"RPC count on OWNED object: {_ownedCount}\r\n";

				GUI.Label(rect, text, style);
		}
	}
}
