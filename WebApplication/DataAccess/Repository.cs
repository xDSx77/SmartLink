using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.DataAccess
{
    public class Repository<DBEntity, ModelEntity> : IRepository<DBEntity, ModelEntity>
        where DBEntity : class, new()
        where ModelEntity : class, Dbo.IObjectWithId, new()
    {
        private DbSet<DBEntity> _set;
        protected EfModels.SmartLinkContext _context;
        protected ILogger _logger;
        public Repository(EfModels.SmartLinkContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
            _set = _context.Set<DBEntity>();
        }

        public virtual async Task<ModelEntity> Create(ModelEntity entity)
        {
            DBEntity dbEntity = AutomapperProfiles.Mapper.Map<DBEntity>(entity);
            _set.Add(dbEntity);
            try
            {
                await _context.SaveChangesAsync();
                ModelEntity newEntity = AutomapperProfiles.Mapper.Map<ModelEntity>(dbEntity);
                return newEntity;
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot create new entry in this table", ex);
                return null;
            }
        }

        public virtual async Task<IEnumerable<ModelEntity>> Read(string includeTables = "")
        {
            try
            {
                List<DBEntity> query = null;
                if (String.IsNullOrEmpty(includeTables))
                {
                    query = await _set.AsNoTracking().ToListAsync();
                }
                else
                {
                    query = await _set.Include(includeTables).AsNoTracking().ToListAsync();
                }
                return AutomapperProfiles.Mapper.Map<ModelEntity[]>(query);
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot read this table", ex);
                return null;
            }
        }

        public virtual async Task<ModelEntity> Update(ModelEntity entity)
        {
            DBEntity dbEntity = _set.Find(entity.Id);

            if (dbEntity == null)
            {
                return null;
            }
            AutomapperProfiles.Mapper.Map(entity, dbEntity);
            if (!_context.ChangeTracker.HasChanges())
            {
                return entity;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot update this table", ex);
                return null;
            }
            return AutomapperProfiles.Mapper.Map<ModelEntity>(dbEntity);
        }

        public virtual async Task<bool> Delete(long idEntity)
        {
            DBEntity dbEntity = _set.Find(idEntity);

            if (dbEntity == null)
            {
                return false;
            }
            _set.Remove(dbEntity);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("Cannot delete this entry in the table", ex);
                return false;
            }
        }
    }
}
