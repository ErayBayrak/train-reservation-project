using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class TrainManager : ITrainService
    {
        ITrainDal _trainDal;

        public TrainManager(ITrainDal trainDal)
        {
            _trainDal = trainDal;
        }

        public void Add(Train entity)
        {
            _trainDal.Add(entity);
        }

        public void Delete(Train entity)
        {
            _trainDal.Delete(entity);
        }

        public Train Get(Expression<Func<Train, bool>> filter)
        {
            var train = _trainDal.Get(filter);
            return train;
        }

        public List<Train> GetAll(Expression<Func<Train, bool>> filter = null)
        {
            var trains = _trainDal.GetAll(filter);
            return trains;
        }

        public void Update(Train entity)
        {
            _trainDal.Update(entity);
        }
    }
}
