
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCNetCoreCrudVehicles.Business.Modules.Base.Models;
using MVCNetCoreCrudVehicles.Business.Modules.Vehicle.Models;
using MVCNetCoreCrudVehicles.Data;

namespace MVCNetCoreCrudVehicles.Business.Modules.Vehicle
{
    public class VehicleModule : IVehicleModule
    {
        private readonly VehicleContext _context;

        public VehicleModule(VehicleContext context)
        {
            _context = context;
        }

        public Data.Entities.Vehicle ToEntity(VehicleModel model)
        {
            var entity = new Data.Entities.Vehicle();
            if (!model.Id.Equals(Guid.Empty) && model.Id != null)
            {
                entity.Id = model.Id;
            }

            SetData(entity, model);

            return entity;
        }

        public VehicleModel ToModel(Data.Entities.Vehicle entity)
        {
            return new VehicleModel
            {
                Id = entity.Id,
                Model = entity.Model,
                Brand = entity.Brand,
                NumberOfDoors = entity.NumberOfDoors,
                Owner = entity.Owner,
                Patent = entity.Patent
            };
        }

        public void SetData(Data.Entities.Vehicle entity, VehicleModel model)
        {
            entity.Brand = model.Brand;
            entity.Patent = model.Patent;
            entity.Owner = model.Owner;
            entity.NumberOfDoors = model.NumberOfDoors;
            entity.Model = model.Model;
            entity.SetModification();
        }

        public async Task<ResultModel<VehicleModel>> Create(VehicleModel model)
        {
            try
            {
                var validationErrors = CheckCreateValidations(model);
                if (validationErrors.Any())
                {
                    return new ErrorResultModel<VehicleModel>(validationErrors);
                }
                var entity = ToEntity(model);

                await _context.Vehicles.AddAsync(entity);
                var rowsAffected = await _context.SaveChangesAsync();

                if (rowsAffected > 0)
                {
                    model.Id = entity.Id;
                    return new SuccessResultModel<VehicleModel>(model);
                }
                else
                {
                    return new ErrorResultModel<VehicleModel>("No se pudo guardar el vehiculo");
                }
            }
            catch (Exception e)
            {
                return new ErrorResultModel<VehicleModel>(e.Message);
            }
        }

        public async Task<ResultModel<VehicleModel>> Delete(Guid Id)
        {
            try
            {
                var entity = Load(Id);
                if(entity != null)
                {
                    entity.Delete();
                    var result = await _context.SaveChangesAsync();
                    if(result > 0)
                    {
                        return new SuccessResultModel<VehicleModel>(ToModel(entity));
                    }
                    else
                    {
                        return new ErrorResultModel<VehicleModel>("No se ha borrado ningun vehiculo");
                    }
                }
                else
                {
                    return new ErrorResultModel<VehicleModel>("No se encontró el vehiculo para borrar");
                }

            }
            catch(Exception e)
            {
                return new ErrorResultModel<VehicleModel>(e.Message);
            }
        }

        public async Task<VehicleModel> Get(Guid Id)
        {
            var entity = _context.Vehicles.FirstOrDefault(x => x.Id.Equals(Id));
            if(entity != null)
            {
                return ToModel(entity);
            }
            return null;            

        }

        public Data.Entities.Vehicle Load(Guid Id)
        {
            return _context.Vehicles.FirstOrDefault(x => x.Id.Equals(Id));
        }

        public async Task<ICollection<VehicleModel>> GetAll()
        {
            var list = new List<VehicleModel>();
            try
            {
                var entities = _context.Vehicles.Where(x => !x.Deleted).ToList();
                foreach(var entity in entities)
                {
                    list.Add(ToModel(entity));
                }
            }
            catch
            {
                //TODO 
            }                            

            return list;

        }

        public async Task<ResultModel<VehicleModel>> Update(VehicleModel model)
        {
            try
            {
                var validationErrors = CheckUpdateValidations(model);
                if (validationErrors.Any())
                {
                    return new ErrorResultModel<VehicleModel>(validationErrors);
                }
                var entity = Load(model.Id);

                if(entity != null)
                {
                    SetData(entity, model);
                    var result = await _context.SaveChangesAsync();
                    if(result > 0)
                    {
                        return new SuccessResultModel<VehicleModel>(ToModel(entity));
                    }
                    else
                    {
                        return new ErrorResultModel<VehicleModel>("No se ha actualizado ningun vehiculo");
                    }
                }
                else
                {
                    return new ErrorResultModel<VehicleModel>("No se encontró el vehiculo para actualizar");
                }

            }
            catch(Exception e)
            {
                return new ErrorResultModel<VehicleModel>(e.Message);
            }
        }

        public IEnumerable<ErrorModel> CheckCreateValidations(VehicleModel model)
        {
            if (model.NumberOfDoors < 0)
            {
                yield return new ErrorModel("NumberOfDoors", "El valor debe ser mayor o igual a 0");
            }

            if (string.IsNullOrEmpty(model.Model.Trim()))
            {
                yield return new ErrorModel("Model", "El modelo no puede estar vacío");
            }

            if (string.IsNullOrEmpty(model.Owner.Trim()))
            {
                yield return new ErrorModel("Owner", "El vehiculo debe tener un propietario");
            }

            if (string.IsNullOrEmpty(model.Brand.Trim()))
            {
                yield return new ErrorModel("Brand", "El vehiculo debe tener una marca");
            }

            if (string.IsNullOrEmpty(model.Patent.Trim()))
            {
                yield return new ErrorModel("Patent", "El vehiculo debe tener una patente");
            }
        }


        public IEnumerable<ErrorModel> CheckUpdateValidations(VehicleModel model)
        {
            return CheckCreateValidations(model);
        }
    }
}
