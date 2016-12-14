using System;

namespace AssemblyCSharp
{
	public class GentlemansSingleton
	{
		private static PlayerController activePlayer;
		private static int sceneNum;

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

		public void SetSceneNum(int num){
			sceneNum = num;
		}
		public int GetSceneNum(){
			return sceneNum;
		}
	}
}

