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
  }
}
