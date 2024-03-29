﻿using CarvedRock.Api.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace CarvedRock.Api.GraphQL.Messaging
{
    public class ReviewMessageService
    {
        private readonly ISubject<ReviewAddedMessage> _messageStream =
            new ReplaySubject<ReviewAddedMessage>(1);

        public ReviewAddedMessage AddReviewAddedMessage(ProductReview review)
        {
            var message = new ReviewAddedMessage
            {
                ProductId = review.ProductId,
                Title = review.Title
            };
            _messageStream.OnNext(message);
            return message;
        }

        public IObservable<ReviewAddedMessage> GetMessage()
        {
            return _messageStream.AsObservable();
        }
        
    }
}
