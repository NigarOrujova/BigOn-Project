using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;
using BigOn.Application.Extensions;
using Microsoft.Extensions.Logging;

namespace BigOn.Application.Behaviours
{
    public class ValidateBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        //private readonly IValidator<TRequest> validator;
        private readonly IHttpContextAccessor ctx;
        private readonly ILogger<TRequest> logger;

        public ValidateBehaviour(IHttpContextAccessor ctx, ILogger<TRequest> logger)
        {
            this.ctx = ctx;
            this.logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {

            var validator = ctx.GetService<IValidator<TRequest>>();

            if (validator != null)
            {
                var validationResult = await validator.ValidateAsync(request, cancellationToken);

                if (!validationResult.IsValid)
                {
                    throw new ValidationException(validationResult.Errors);
                }
            }


            //before executing
            var response = await next();
            //after executing

            return response;
        }
    }
}
