using UnityEngine;
using System.Collections;

public static class CursorStateManager{
	static bool locked = false;

	public static void HideCursor()
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		locked = true;
	}

	public static void ShowCursor()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
		locked = false;
	}

	public static bool IsLocked()
	{
		return locked;
	}
}
