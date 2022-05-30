using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscaPerro.Domain.Interfaces.Repository
{
    public interface IGenericRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<int> DeleteRow(int id);
        Task<T> Get(int id);
        Task<int> InsertRange(IEnumerable<T> list);
        Task<int> Update(T t);
        Task<int> Insert(T t);

        Task<IEnumerable<T>> SearchByFields<Fields>(Fields modelFields) where Fields : class;
        Task<IEnumerable<T>> SearchByFieldsDictionary(Dictionary<string, object> modelFields);
        Task<IEnumerable<T>> GetRange(IEnumerable<int> ids);
        Task<IEnumerable<TE>> Query<TE>(string consult, object modelFields = null);
        Task<int> UpdateDictionary(Dictionary<string, object> updateParams);
    }
}
