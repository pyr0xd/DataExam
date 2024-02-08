using ConsoleApp1.Entities;

public class CustomerService
{
    private Repo<CustomerEntity> _customerRepo;

    public CustomerService(Repo<CustomerEntity> customerRepo)
    {
        _customerRepo = customerRepo;
    }

    public async Task<IEnumerable<CustomerEntity>> GetAllCustomersAsync()
    {
        return await _customerRepo.GetAllAsync();
    }

    public async Task<CustomerEntity> GetCustomerByIdAsync(int id)
    {
        return await _customerRepo.GetByIdAsync(id);
    }

    public async Task<CustomerEntity> CreateCustomerAsync(CustomerEntity customer)
    {
        await _customerRepo.AddAsync(customer);
        return customer;
    }

    public async Task UpdateCustomerAsync(CustomerEntity customer)
    {
        await _customerRepo.UpdateAsync(customer);
    }

    public async Task DeleteCustomerAsync(int id)
    {
        await _customerRepo.DeleteAsync(id);
    }
}
