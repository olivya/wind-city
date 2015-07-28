using UnityEngine;
using System.Collections;

public class GUIstyles : MonoBehaviour 
{
	//GUI & HUD:
	public GUIStyle HPStyleBack;
	public GUIStyle HPStyleFront;
	public GUIStyle EnemyHPStyleBack;
	public GUIStyle EnemyHPStyleFront;
	public GUIStyle LifeStyle;
	public GUIStyle GearCountStyle;
	public GUIStyle ScrollStyle;
	public GUIStyle ScrollTextStyle;
	public GUIStyle MessageStyle;

	public GUIStyle TutorialStyle;
	public GUIStyle TutorialStyle2;
	public GUIStyle TutorialStyle3;


	//Menus:
	public GUIStyle StartMenuStyle;
	public GUIStyle SettingsMenuStyle;
	public GUIStyle Settings2MenuStyle;
	public GUIStyle QuitMenuStyle;
	public GUIStyle QuitMenu2Style;

	public GUIStyle PauseResumeStyle;
	public GUIStyle PauseMainMenuStyle;

	public GUIStyle EscStyle;
	public GUIStyle MapStyle;
	public GUIStyle MapViewStyle;

	public GUIStyle CityStyle;
	public GUIStyle AirshipStyle;
	public GUIStyle MechDistrictStyle;
	public GUIStyle CoreStyle;

	public GUIStyle City2Style;
	public GUIStyle Airship2Style;
	public GUIStyle MechDistrict2Style;
	public GUIStyle Core2Style;

	public GUIStyle PauseScreenStyle;
	public GUIStyle StartBlkScreenStyle;

	public GUIStyle BackStyle;
	
	private static GUIstyles instance;
	
	void Awake()
	{
		instance = this;
	}
	
	public static GUIStyle GetHPStyleBack()
	{
		return instance.HPStyleBack;
	}

	public static GUIStyle GetHPStyleFront()
	{
		return instance.HPStyleFront;
	}

	public static GUIStyle GetEnemyHPStyleBack()
	{
		return instance.EnemyHPStyleBack;
	}

	public static GUIStyle GetEnemyHPStyleFront()
	{
		return instance.EnemyHPStyleFront;
	}

	public static GUIStyle GetLifeStyle()
	{
		return instance.LifeStyle;
	}

	public static GUIStyle GetGearCountStyle()
	{
		return instance.GearCountStyle;
	}

	public static GUIStyle GetScrollStyle()
	{
		return instance.ScrollStyle;
	}

	public static GUIStyle GetScrollTextStyle()
	{
		return instance.ScrollTextStyle;
	}

	public static GUIStyle GetTutorialStyle()
	{
		return instance.TutorialStyle;
	}

	public static GUIStyle GetTutorialStyle2()
	{
		return instance.TutorialStyle2;
	}

	public static GUIStyle GetTutorialStyle3()
	{
		return instance.TutorialStyle3;
	}

	public static GUIStyle GetMessageStyle()
	{
		return instance.MessageStyle;
	}

	public static GUIStyle GetStartMenuStyle()
	{
		return instance.StartMenuStyle;
	}

	public static GUIStyle GetSettingsMenuStyle()
	{
		return instance.SettingsMenuStyle;
	}

	public static GUIStyle GetSettings2MenuStyle()
	{
		return instance.Settings2MenuStyle;
	}

	public static GUIStyle GetQuitMenuStyle()
	{
		return instance.QuitMenuStyle;
	}

	public static GUIStyle GetQuitMenu2Style()
	{
		return instance.QuitMenu2Style;
	}

	public static GUIStyle GetPauseResumeStyle()
	{
		return instance.PauseResumeStyle;
	}

	public static GUIStyle GetPauseMainMenuStyle()
	{
		return instance.PauseMainMenuStyle;
	}

	public static GUIStyle GetCityStyle()
	{
		return instance.CityStyle;
	}

	public static GUIStyle GetAirshipStyle()
	{
		return instance.AirshipStyle;
	}

	public static GUIStyle GetMechDistrictStyle()
	{
		return instance.MechDistrictStyle;
	}

	public static GUIStyle GetCoreStyle()
	{
		return instance.CoreStyle;
	}



	public static GUIStyle GetCity2Style()
	{
		return instance.City2Style;
	}
	
	public static GUIStyle GetAirship2Style()
	{
		return instance.Airship2Style;
	}
	
	public static GUIStyle GetMechDistrict2Style()
	{
		return instance.MechDistrict2Style;
	}
	
	public static GUIStyle GetCore2Style()
	{
		return instance.Core2Style;
	}



	public static GUIStyle GetPauseScreenStyle()
	{
		return instance.PauseScreenStyle;
	}

	public static GUIStyle GetStartBlkScreenStyle()
	{
		return instance.StartBlkScreenStyle;
	}

	public static GUIStyle GetBackStyle()
	{
		return instance.BackStyle;
	}

	public static GUIStyle GetEscStyle()
	{
		return instance.EscStyle;
	}

	public static GUIStyle GetMapStyle()
	{
		return instance.MapStyle;
	}

	public static GUIStyle GetMapViewStyle()
	{
		return instance.MapViewStyle;
	}
}