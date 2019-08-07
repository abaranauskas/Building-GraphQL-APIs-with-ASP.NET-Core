using CarvedRock.Api.GraphQL.Messaging;
using CarvedRock.Api.GraphQL.Types;
using GraphQL.Resolvers;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarvedRock.Api.GraphQL
{
    public class CarvedRockSubscription : ObjectGraphType
    {
        public CarvedRockSubscription(ReviewMessageService messageService)
        {
            Name = "Subscribtion";
            AddField(new EventStreamFieldType
            {
                Name = "reviewAdded",
                Type = typeof(ReviewAddedMessageType),
                Resolver = new FuncFieldResolver<ReviewAddedMessage>(c =>
                    c.Source as ReviewAddedMessage),
                Subscriber = new EventStreamResolver<ReviewAddedMessage>(c =>
                    messageService.GetMessage())
            });
        }
    }
}
