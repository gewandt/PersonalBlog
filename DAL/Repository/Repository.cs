﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interface.Interfaces;
using DAL.Interface.Repository;

namespace DAL.Repository
{
    public class Repository<TEntity, TDal> : IRepository<TDal> 
        where TEntity : class 
        where TDal : IDalEntity
    {
        private readonly DbContext _context;
        private readonly IMapper<TEntity, TDal> _mapper;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context, IMapper<TEntity, TDal> mapper)
        {
            //if (context == null) throw new ArgumentNullException("context");
            //if (mapper == null) throw new ArgumentNullException("mapper");
            _context = context;
            _mapper = mapper;
            _dbSet = _context.Set<TEntity>();
        } 
        public void Create(TDal item)
        {
            //var user = _mapper.ToEntity(item);
            //_context.Set<TEntity>().Add(user);
            _dbSet.Add(_mapper.ToEntity(item));
        }

        public void Delete(TDal item)
        {
            _dbSet.Remove(_mapper.ToEntity(item));
        }

        public void Update(TDal item)
        {
            var itemToUpdate = _dbSet.Find(item.Id);
            _mapper.CopyFields(item, itemToUpdate);
        }

        public IEnumerable<TDal> GetAll()
        {
            return _dbSet.AsEnumerable().Select(c => _mapper.ToDal(c));
        }

        public TDal GetById(int id)
        {
            return _mapper.ToDal(_dbSet.Find(id));
        }
    }
}
