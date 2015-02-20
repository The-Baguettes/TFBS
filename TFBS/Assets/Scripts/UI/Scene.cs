using UnityEngine;

public class Scene
{
	// UI
	public static readonly Scene MainMenu = new Scene("MainMenu");
	public static readonly Scene SettingsMenu = new Scene("SettingsMenu");

	// Game Levels
	public static readonly Scene Environment = new Scene("Environment");
	public static readonly Scene Thing = new Scene("Thing");
	
	// Shortcuts
	public static readonly Scene GameBeginning = Thing;
	
	public readonly string Name;
	
	Scene(string name)
	{
		Name = name;
	}
	
	public void Activate()
	{
		Application.LoadLevel(Name);
	}
}
