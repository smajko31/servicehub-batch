using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Logging;

namespace ServiceHub.Batch.Service.Controllers
{
  public abstract class BaseController : Controller
  {
    protected readonly ILogger logger;
    protected readonly IQueueClient queueClient;
    protected abstract void UseReceiver();
    protected abstract void UseSender(Message message);

    protected BaseController(ILoggerFactory loggerFactory, IQueueClient queueClientSingleton)
    {
      logger = loggerFactory.CreateLogger(this.GetType().Name);
      queueClient = queueClientSingleton;
    }

    protected virtual Task ReceiverExceptionHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs) =>
      throw new NotImplementedException();

    protected virtual Task ReceiverMessageProcessAsync(Message message, CancellationToken cancellationToken) =>
      throw new NotImplementedException();
    
    protected virtual Task SenderMessageProcessAsync(Message message) =>
      throw new NotImplementedException();
  }
}
