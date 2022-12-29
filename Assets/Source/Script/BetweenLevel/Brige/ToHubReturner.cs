using IJunior.TypedScenes;

public class ToHubReturner : LevelChanger
{
    protected override void LoadLevel(InformationToSend information)
    {
        Hub.Load(information);
    }
}
