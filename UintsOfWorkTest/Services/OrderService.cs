using Microsoft.EntityFrameworkCore;
using UintsOfWorkTest.Data;
using UintsOfWorkTest.Entities;
using UintsOfWorkTest.UnitsOfWork;

namespace UintsOfWorkTest.Services
{
    public class OrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        //todo:creare l'interfaccia factory
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public OrderService(IUnitOfWork unitOfWork, IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWork = unitOfWork;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task CreateOrderAsync(string customerName, string product)
        {
            var customer = new Customer { Name = customerName };
            await _unitOfWork.Customers.AddAsync(customer);
        
            var order = new Order { Product = product, Customer = customer };
            await _unitOfWork.Orders.AddAsync(order);

            await _unitOfWork.CommitAsync(); // Salva tutto in una sola transazione
        }

        public async Task CreateOrderAsync2(string customerName, string product)
        {
            // Usa la factory per creare un'istanza di UnitOfWork
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                // Crea un nuovo cliente
                var customer = new Customer { Name = customerName };
                await unitOfWork.Customers.AddAsync(customer);

                // Crea un nuovo ordine
                var order = new Order { Product = product, Customer = customer };
                await unitOfWork.Orders.AddAsync(order);

                // Esegui il commit delle modifiche (in una transazione unica)
                await unitOfWork.CommitAsync();
            }
        }

    }
}
