﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using AutoMapper;
using Ambev.Sale.Core.Application.Sales.Create;
using Ambev.Sale.Core.Domain.Repository;

namespace Ambev.Sale.Core.Application.Sales.Modify
{
    public class ModifySaleHandler : IRequestHandler<ModifySaleCommand, ModifySaleResult>
    {
        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ModifySaleHandler(IMediator mediator, ISaleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ModifySaleResult> Handle(ModifySaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new ModifySaleCommandValidator(_repository);
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (validationResult != null && !validationResult.IsValid)                
                throw new ValidationException(validationResult.Errors);

            var record = _mapper.Map< Ambev.Sale.Core.Domain.Entities.Sale >(command);
            
            var update = await _repository.UpdateAsync(record);
            var result = _mapper.Map<ModifySaleResult>(update);


            //publich event 
            await _mediator.Publish(new ModifySaleResult
            {
                Id = result.Id,
                Number = result.Number
            });
            await Task.FromResult("Sale Modified");

            return result;            
        }
    }
}
