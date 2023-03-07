using Common.Application;
using MediatR;
using Shop.Application.Sellers.AddInvertory;
using Shop.Application.Sellers.EditInvertory;
using Shop.Query.Sellers.DTOs;
using Shop.Query.Sellers.Invertories.GetById;
using Shop.Query.Sellers.Invertories.GetList;

namespace Shop.Presentation.Facade.Sellers.Inventoreis
{
    internal class SellerInventoryFacade: ISellerInventoryFacade
    {
        private readonly IMediator _mediator;

        public SellerInventoryFacade(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult> AddInventory(AddInvertoryCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> EditInventory(EditInvertoryCommand command)
        {
            return await _mediator.Send(command);
        }
        public async Task<InventoryDto?> GetById(long inventoryId)
        {
            return await _mediator.Send(new GetSellerInventoryByIdQuery(inventoryId));
        }

        public async Task<List<InventoryDto>> GetList(long sellerId)
        {
            return await _mediator.Send(new GetInventoriesQuery(sellerId));
        }
    }
}
