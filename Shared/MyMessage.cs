using NServiceBus;

public class MyMessage :
    IMessage
{
    public long Id { get; set; }
    public string Name { get; set; }
}