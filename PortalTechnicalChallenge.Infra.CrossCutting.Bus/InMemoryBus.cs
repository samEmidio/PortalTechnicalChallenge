using MediatR;
using PortalTechnicalChallenge.Domain.Core.Bus;
using PortalTechnicalChallenge.Domain.Core.Commands;
using PortalTechnicalChallenge.Domain.Core.Events;

namespace PortalTechnicalChallenge.Infra.CrossCutting.Bus
{

    /// <summary>
    /// mediator handler  - events
    /// </summary>

    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            return _mediator.Publish(@event);
        }
    }
}