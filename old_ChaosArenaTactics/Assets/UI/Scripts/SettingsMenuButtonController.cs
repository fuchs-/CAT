public class SettingsMenuButtonController : ButtonController
{
    public override void Btn_BackToMainMenu()
    {
        Settings.SaveSettings();
        base.Btn_BackToMainMenu();
    }
}
