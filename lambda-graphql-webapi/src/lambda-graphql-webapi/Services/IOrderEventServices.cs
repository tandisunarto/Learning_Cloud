using System;
using System.Collections.Concurrent;
using lambda_graphql_webapi.Models;

namespace lambda_graphql_webapi.Services
{
    public interface IOrderEventService
    {
        ConcurrentStack<OrderEvent> AllEvents { get; }
        void AddError(Exception exception);
        OrderEvent AddEvent(OrderEvent orderEvent);
        IObservable<OrderEvent> EventStream();
    }
}