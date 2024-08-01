namespace SimpleFuzzy.Abstract
{
    public interface IMembershipFunction : IModulable
    {
        double MembershipFunction(object elem);
        Type InputType { get; }
    }
}
