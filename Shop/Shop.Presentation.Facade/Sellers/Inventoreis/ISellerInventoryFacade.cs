using Common.Application;
using Shop.Application.Sellers.AddInvertory;
using Shop.Application.Sellers.EditInvertory;
using Shop.Query.Sellers.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Presentation.Facade.Sellers.Inventoreis
{
    public interface ISellerInventoryFacade
    {
        Task<OperationResult> AddInventory(AddInvertoryCommand command);
        Task<OperationResult> EditInventory(EditInvertoryCommand command);


        Task<InventoryDto?> GetById(long inventoryId);
        Task<List<InventoryDto>> GetList(long sellerId);
    }
}
