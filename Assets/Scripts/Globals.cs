using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    public static bool isGrabbingTrash = false;

	public static int ItemsRecycled = 4;

	public static bool isGameOver = false;
	public static void ResetGlobals()
	{
		ItemsRecycled = 4;
		isGameOver = false;
	}
}
