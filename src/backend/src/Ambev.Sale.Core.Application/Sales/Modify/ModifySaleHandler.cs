using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Ambev.Sale.Core.Domain.Repository;
using AutoMapper;
using Ambev.Sale.Core.Application.Sales.Create;

namespace Ambev.Sale.Core.Application.Sales.Modify
{
    public class ModifySaleHandler : IRequestHandler<ModifySaleCommand, ModifySaleResult>
    {
        private readonly SaleRepository _repository;
        private readonly IMapper _mapper;

        public ModifySaleHandler(SaleRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ModifySaleResult> Handle(ModifySaleCommand command, CancellationToken cancellationToken)
        {
            var validator = new ModifySaleCommandValidator(_repository);
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (validationResult != null && !validationResult.IsValid)                
                throw new ValidationException(validationResult.Errors);

            var record = _mapper.Map<Ambev.Sale.Infrastructure.ORN.Entities.Sale>(command);
            
            var update = await _repository.UpdateAsync(record);
            var result = _mapper.Map<ModifySaleResult>(update);
            return result;            
        }
    }
}
