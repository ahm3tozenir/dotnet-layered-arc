using Entities.Models;


namespace Business.Abstracts;


public interface IOrderDetailService
{
    OrderDetail? GetById(Guid id);
    Task<OrderDetail?> GetByIdAsync(Guid id);
    IList<OrderDetail> GetAll();
    Task<IList<OrderDetail>> GetAllAsync();
    OrderDetail Add(OrderDetail orderDetail);
    OrderDetail Update(OrderDetail orderDetail);
    void DeleteById(Guid id);
    Task<OrderDetail> AddAsync(OrderDetail orderDetail);
    Task<OrderDetail> UpdateAsync(OrderDetail orderDetail);
    Task DeleteByIdAsync(Guid id);
}