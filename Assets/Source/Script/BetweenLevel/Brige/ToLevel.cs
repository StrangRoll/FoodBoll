public class ToLevel : LevelChanger
{
    protected override void LoadLevel(InformationToSend information)
    {
        IJunior.TypedScenes.Level.Load(information);
    }
}
