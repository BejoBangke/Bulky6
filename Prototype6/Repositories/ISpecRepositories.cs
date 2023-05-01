using Prototype6.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface ISpecRepository
{
    Task<IEnumerable<Spec>> GetAll();
    Task<Spec> GetById(int id);
    Task<int> Create(Spec spec);
    Task<int> Update(Spec spec);
    Task<int> Delete(int id);
}
