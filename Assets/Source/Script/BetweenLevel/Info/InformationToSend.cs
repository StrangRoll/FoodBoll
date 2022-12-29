public class InformationToSend
{
    public FoodInformation[] FoodInfo { get; private set; }
    public PlayerInformation PlayerInfo { get; private set; }

    public InformationToSend(FoodInformation[] foodInfo, PlayerInformation playerInfo)
    {
        FoodInfo = foodInfo;
        PlayerInfo = playerInfo;
    }
}
