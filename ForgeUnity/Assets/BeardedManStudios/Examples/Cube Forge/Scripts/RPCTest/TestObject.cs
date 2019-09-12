using System.Collections.Generic;
using BeardedManStudios.Forge.Networking;
using BeardedManStudios.Forge.Networking.Generated;
using UnityEngine;

namespace BeardedManStudios.Examples.Cube_Forge.Scripts.RPCTest
{
	public class TestObject : TestBehavior
	{
		public Dictionary<NetworkingPlayer, int> TestRPCCount { get; private set; } =
			new Dictionary<NetworkingPlayer, int>();

		public override void FuncBlank(RpcArgs args)
		{
			TestRPCCount[args.Info.SendingPlayer] = TestRPCCount.ContainsKey(args.Info.SendingPlayer)
				? TestRPCCount[args.Info.SendingPlayer] + 1
				: 1;
		}

		public override void FuncByte(RpcArgs args)
		{
			throw new System.NotImplementedException();
		}

		public override void FuncChar(RpcArgs args)
		{
			throw new System.NotImplementedException();
		}

		public override void FuncShort(RpcArgs args)
		{
			throw new System.NotImplementedException();
		}

		public override void FuncUShort(RpcArgs args)
		{
			throw new System.NotImplementedException();
		}

		public override void FuncBool(RpcArgs args)
		{
			throw new System.NotImplementedException();
		}

		public override void FuncInt(RpcArgs args)
		{
			throw new System.NotImplementedException();
		}

		public override void FuncUInt(RpcArgs args)
		{
			throw new System.NotImplementedException();
		}

		public override void FuncFloat(RpcArgs args)
		{
			throw new System.NotImplementedException();
		}

		public override void FuncLong(RpcArgs args)
		{
			throw new System.NotImplementedException();
		}

		public override void FuncULong(RpcArgs args)
		{
			throw new System.NotImplementedException();
		}

		public override void FuncDouble(RpcArgs args)
		{
			throw new System.NotImplementedException();
		}

		public override void FuncString(RpcArgs args)
		{
			throw new System.NotImplementedException();
		}

		public override void FuncByteArray(RpcArgs args)
		{
			throw new System.NotImplementedException();
		}

		public override void FuncAll(RpcArgs args)
		{
			throw new System.NotImplementedException();
		}
	}
}
