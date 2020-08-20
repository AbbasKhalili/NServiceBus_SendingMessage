using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;

public class SendMessageController :
    Controller
{
    IMessageSession messageSession;

    #region MessageSessionInjection
    public SendMessageController(IMessageSession messageSession)
    {
        this.messageSession = messageSession;
    }
    #endregion


    #region MessageSessionUsage
    [HttpGet]
    public async Task<string> Get()
    {
        var message = new MyMessage()
        {
            Id = new Random(10000).Next(),
            Name = new Random(233).Next(23,1593697452).ToString("X2")
        };
        await messageSession.Send(message)
            .ConfigureAwait(false);
        return "Message sent to endpoint";
    }
    #endregion
}
