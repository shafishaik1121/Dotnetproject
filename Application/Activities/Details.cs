using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using System;
using MediatR;
using Persistence;

namespace Application.Activities
{
    // Author Name : Shafi Shaik, Date : 22-Jan-2023
    public class Details
    {
        public class Query : IRequest<Activity>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
              var activity = await _context.Activities.FindAsync(request.Id);

              if(activity == null) throw new Exception("Activity not found");

              return activity;
            }
        }
    }
}