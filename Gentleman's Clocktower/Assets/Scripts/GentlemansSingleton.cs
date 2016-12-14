using System;

namespace AssemblyCSharp
{
	public class GentlemansSingleton
	{
		private static PlayerController activePlayer;
		public GentlemansSingleton ()
		{
			activePlayer = null;
		}

		public static void SetPlayer(PlayerController player)
		{
			activePlayer = player;
		}

		public static PlayerController GetPlayer()
		{
			return activePlayer;
		}

	}
}

