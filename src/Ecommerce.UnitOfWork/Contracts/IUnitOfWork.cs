using System;
using System.Data;
using Ecommerce.Entity;
using Ecommerce.Repository;

namespace Ecommerce.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> ProductRepository { get; }
        IRepository<Order> OrderRepository { get; }
        void SaveChanges();
    }
}