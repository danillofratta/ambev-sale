using MediatR;
using FluentValidation;
using AutoMapper;
using Ambev.Sale.Core.Domain.Repository;

namespace Ambev.Sale.Core.Application.SaleItem.Cancel
{
    public class CancelSaleItemHandler : IRequestHandler<CancelSaleItemCommand, CancelSaleItemResult>
    {
        private readonly ISaleRepository _repositorysale;
        private readonly ISaleItemRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly SaleRecalculationService _recalculationService;

        public CancelSaleItemHandler(ISaleRepository repositorysale, SaleRecalculationService recalculationService, IMediator mediator, ISaleItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _mediator = mediator;
            _recalculationService = recalculationService;
            _repositorysale = repositorysale;
        }

        public async Task<CancelSaleItemResult> Handle(CancelSaleItemCommand command, CancellationToken cancellationToken)
        {
            var validator = new CancelSaleItemCommandValidator(_repository);
            var validationResult = await validator.ValidateAsync(command, cancellationToken);            
            if (validationResult != null && !validationResult.IsValid)                
                throw new ValidationException(validationResult.Errors);
            
            var record = await _repository.GetByIdAsync(command.id);            
            record.Status = Ambev.Sale.Core.Domain.Enum.SaleItemStatus.Cancelled;

            var update = await _repository.UpdateAsync(record);
            
            //after cancel item, recalculate itens of sale and total of sale
            var sale = await _repositorysale.GetByIdAsync(record.SaleId);
            _recalculationService.RecalculateSale(sale);
            //save sale with new total
            await _repositorysale.UpdateAsync(sale);

            //publich event 
            await _mediator.Publish(new CancelSaleItemResult
            {
                id = update.Id
            });

            await Task.FromResult("Sale Item Canceled");

            return _mapper.Map<CancelSaleItemResult>(update); ;            
        }
    }
}
