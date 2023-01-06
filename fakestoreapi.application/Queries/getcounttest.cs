using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace fakestoreapi.application.Queries
{
    public class SomeEvent : INotification
    {
        public SomeEvent(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }

    public class Handler1 : INotificationHandler<SomeEvent>
    {
        private readonly ILogger<Handler1> _logger;

        public Handler1(ILogger<Handler1> logger)
        {
            _logger = logger;
        }
        public void Handle(SomeEvent notification)
        {
            _logger.LogWarning($"Handled: {notification.Message}");
        }

        public Task Handle(SomeEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

    }
    public class HomeController : Controller
    {

        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        public async Task<IActionResult> Index()
        {
            await _mediator.Publish(new SomeEvent("Hello World"));
            return View();
        }
        // more code omitted
    }
}
