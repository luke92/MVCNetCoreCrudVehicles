using MVCNetCoreCrudVehicles.Business.Modules.Base.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVCNetCoreCrudVehicles.Business.Modules.Base
{
    public interface IBaseModule<M>
        where M : IBaseModel
    {
        Task<M> Get(Guid Id);

        Task<ICollection<M>> GetAll();

        Task<ResultModel<M>> Create(M model);

        Task<ResultModel<M>> Update(M model);

        Task<ResultModel<M>> Delete(Guid Id);

        IEnumerable<ErrorModel> CheckCreateValidations(M model);

        IEnumerable<ErrorModel> CheckUpdateValidations(M model);
    }
}
