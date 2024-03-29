﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Dietary.DataAccess;
using Dietary.DataAccess.Extensions;
using Dietary.Helpers;
using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Xml.Linq;
using System.Net;

namespace Dietary.Base
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Create<TModel>(TModel model) where TModel : BaseModel;

        Task<TEntity> Update<TModel>(TModel model) where TModel : BaseModel;

        Task<int> Delete(Guid id);

        Task<TModel> Get<TModel>(Expression<Func<TEntity, bool>> expression = null) where TModel : BaseModel, new();

        List<TModel> GetAll<TModel>(Expression<Func<TEntity, bool>> expression = null) where TModel : BaseModel, new();
    }

    public class BaseService<TEntity>(AppDbContext appDbContext) : IBaseService<TEntity> where TEntity : BaseEntity
    {
        protected readonly AppDbContext _appDbContext = appDbContext;

        public virtual async Task<TEntity> Create<TModel>(TModel model) where TModel : BaseModel
        {
            TEntity entity = model.MapToEntity<TEntity>();
            await _appDbContext.Set<TEntity>().AddAsync(entity);
            await _appDbContext.SaveChangesAsync();
            if (entity.File != null) await FileHelper.UploadFileAsync(entity.GetFileInfo());
            return entity;
        }

        public virtual async Task<TEntity> Update<TModel>(TModel model) where TModel : BaseModel
        {
            TEntity entity = model.MapToEntity<TEntity>();
            TEntity data = await _appDbContext.Set<TEntity>().FindAsync(entity.Id);
            if (data != null)
            {
                foreach (PropertyInfo propertyInfo in data.GetType().GetProperties())
                {
                    Type propertyType = propertyInfo.PropertyType;
                    if (propertyType == typeof(IFormFile)) continue;
                    var source = entity.GetType().GetProperty(propertyInfo.Name).GetValue(entity);
                    var target = propertyInfo.GetValue(data);
                    bool isDefault = propertyType.IsValueType ? source.Equals(Activator.CreateInstance(propertyType)) : source == null;
                    if (source?.ToString() == "none")
                        propertyInfo.SetValue(data, null);
                    else if (!isDefault && !source.Equals(target))
                        propertyInfo.SetValue(data, source);
                }
                _appDbContext.Set<TEntity>().Update(data);
                await _appDbContext.SaveChangesAsync();
                if (entity.File != null) await FileHelper.UploadFileAsync(entity.GetFileInfo());
            }
            return data;
        }

        public virtual async Task<int> Delete(Guid id)
        {
            TEntity data = await _appDbContext.Set<TEntity>().FindAsync(id);
            if (data != null)
                _appDbContext.Set<TEntity>().Remove(data);

            return await _appDbContext.SaveChangesAsync();
        }

        public virtual async Task<TModel> Get<TModel>(Expression<Func<TEntity, bool>> expression = null) where TModel : BaseModel, new()
        {
            TModel model = new();
            TEntity data;
            string[] includedProperty = new TModel().GetIncludedProperty();

            if (expression == null)
            {
                if (includedProperty is null || includedProperty.Length == 0)
                    data = await _appDbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync();
                else
                    data = await _appDbContext.Set<TEntity>().Include(includedProperty).AsNoTracking().FirstOrDefaultAsync();
            }
            else
            {
                if (includedProperty is null || includedProperty.Length == 0)
                    data = await _appDbContext.Set<TEntity>().Where(expression).AsNoTracking().FirstOrDefaultAsync();
                else
                    data = await _appDbContext.Set<TEntity>().Include(includedProperty).Where(expression).AsNoTracking().FirstOrDefaultAsync();
            }
            if (data == null)
            {
                throw new HttpRequestException("ID not found!", null, HttpStatusCode.NotFound);
            }
            model.MapToModel(data);
            return model;
        }

        public virtual List<TModel> GetAll<TModel>(Expression<Func<TEntity, bool>> expression = null) where TModel : BaseModel, new()
        {
            List<TModel> models = [];
            List<TEntity> entities;
            string[] includedProperty = new TModel().GetIncludedProperty();

            if (expression == null)
            {
                if (includedProperty is null || includedProperty.Length == 0)
                    entities = [.. _appDbContext.Set<TEntity>().AsNoTracking()];
                else
                    entities = [.. _appDbContext.Set<TEntity>().Include(includedProperty).AsNoTracking()];
            }
            else
            {
                if (includedProperty is null || includedProperty.Length == 0)
                    entities = [.. _appDbContext.Set<TEntity>().Where(expression).AsNoTracking()];
                else
                    entities = [.. _appDbContext.Set<TEntity>().Include(includedProperty).Where(expression).AsNoTracking()];
            }

            if (entities != null)
                foreach (var entity in entities)
                {
                    TModel model = new();
                    model.MapToModel(entity);
                    models.Add(model);
                }
            return models;
        }
    }
}
