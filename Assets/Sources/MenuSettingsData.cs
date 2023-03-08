[System.Serializable]
public class MenuSettingsData
{
    public float LightLevel;

    public float AmbienceLevel;
    public float SFXLevel;

    public MenuSettingsData(float LightLevel, float AmbienceLevel, float SFXLevel)
    {
       this.LightLevel = LightLevel;
       this.AmbienceLevel = AmbienceLevel;
       this.SFXLevel = SFXLevel;
    }

    public MenuSettingsData(MenuSettingsData menuData)
    {
        this.LightLevel = menuData.LightLevel;
        this.AmbienceLevel = menuData.AmbienceLevel;
        this.SFXLevel = menuData.SFXLevel;
    }
}
