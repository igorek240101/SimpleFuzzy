namespace SimpleFuzzy.Abstract
{
    public interface IMembershipFunction
    {
        double MembershipFunction(object elem);
        Type InputType { get; }
    }
}
