using IqraCommerce.API.Data;
using IqraCommerce.API.Entities;
using IqraService.DB;
using IqraService.Search;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IqraCommerce.Services
{
    public class QueryBase : INameService
    {
        public virtual Dictionary<string, bool> ExcludedProperties
        {
            get
            {
                return new Dictionary<string, bool>()
                {
                    { "ChangeLog",true }
                };
            }
        }
        public virtual string GetName(string name)
        {
            switch (name.ToLower())
            {
                case "id":
                    name = "[itm].[Id]";
                    break;
                case "name":
                    name = "[itm].[Name]";
                    break;
                case "createdat":
                    name = "[itm].[CreatedAt]";
                    break;
                case "createdby":
                    name = "ctr.[Name]";
                    break;
                case "updatedat":
                    name = "[itm].[UpdatedAt]";
                    break;
                case "updatedby":
                    name = "[updtr].[Name]";
                    break;
                case "isdeleted":
                    name = "[itm].[IsDeleted]";
                    break;
                case "description":
                    name = "[itm].[Description]";
                    break;
            }
            return name;
        }
        public async Task<ResponseJson> CallBackAsync(ResponseJson response, Action<ResponseJson> calBack)
        {
            await Task.Run(() =>
            {
                try
                {
                    calBack(response);
                }
                catch (Exception ex)
                {
                    response.Msg = "Internal server Error.";
                    response.IsError = true;
                    response.Id = -6;
                    response.Data = ex.Message;
                }
            });
            return response;
        }
        public ResponseJson CallBack(ResponseJson response, Action<ResponseJson> calBack)
        {
            try
            {
                calBack(response);
            }
            catch (Exception ex)
            {
                response.Msg = "Internal server Error.";
                response.IsError = true;
                response.Id = -6;
                response.Data = ex.Message;
            }
            return response;
        }
        public ResponseJson CallBack(Action<ResponseJson> calBack)
        {
            ResponseJson response = new IqraService.Search.ResponseJson();
            return CallBack(response, calBack);
        }
        public async Task<ResponseJson> CallBackAsync(Action<ResponseJson> calBack)
        {
            ResponseJson response = new IqraService.Search.ResponseJson();
            return await CallBackAsync(response, calBack);
        }
        public ResponseJson CallBack(bool isValid, Action<ResponseJson> calBack)
        {
            var result = CallBack(response =>
            {
                if (isValid)
                {
                    calBack(response);
                }
                else
                {
                    response.Msg = "Validation Errors.";
                    response.IsError = true;
                    response.Id = -5;
                }
            });
            return result;
        }
        public ResponseJson CallBack(ResponseJson response, bool isValid, Action<ResponseJson> calBack)
        {
            var result = CallBack(response, res =>
            {
                if (isValid)
                {
                    calBack(res);
                }
                else
                {
                    res.Msg = "Validation Errors.";
                    res.IsError = true;
                    res.Id = -5;
                }
            });
            return result;
        }
    }
    public class AppContext<T> : QueryBase, IDisposable where T : class
    {
        public DbSet<T> Entity { get; set; }
        public DbContext context;
        public AppContext()
        {
            context = new DataContext();
            Entity = context.Set<T>();
        }
        public AppContext(DbContext ctx)
        {
            context = ctx;
            Entity = context.Set<T>();
        }
        public virtual DbSet<ENTITY> GetEntity<ENTITY>() where ENTITY : class
        {
            return context.Set<ENTITY>();
        }
        public virtual T Insert(T model)
        {
            Entity.Add(model);
            return model;
        }
        public virtual IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Expression<Func<T, object>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = Entity;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return query.OrderBy(orderBy);
            }
            else
            {
                return query;
            }
        }
        public virtual T GetById(object id)
        {
            return Entity.Find(id);
        }
        public virtual DbSet<T> GetEntity()
        {
            return Entity;
        }
        public virtual void DeActivate(object id)
        {
            T entityToDelete = SetChangeLog(id);
        }
        public virtual void Delete(object id)
        {
            Entity.Remove(Entity.Find(id));
            SaveChange();
        }
        public virtual T SetChangeLog(object Id)
        {
            var model = Entity.Find(Id);
            return model;
        }
        public virtual void SaveChange()
        {
            context.SaveChanges();
        }
        public virtual void Dispose()
        {
            if (context != null)
                context.Dispose();
        }
    }
//     public class AppBaseService<T> : AppContext<T>, IService<T> where T : BaseEntity
//     {
//         public AppBaseService() : base()
//         {
//         }
//         public AppBaseService(DbContext ctx) : base(ctx)
//         {
//         }
//         public virtual string GetQuery(Page page, DBService db)
//         {
//             return db.GetQuery<T>(page, "[itm]", ExcludedProperties);
//         }
//         public virtual async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page)
//         {
//             using (var db = new DBService(this))
//             {
//                 return await db.GetPages(page, GetQuery(page, db));
//             }
//         }
//         public virtual async Task<ResponseList<Pagger<Dictionary<string, object>>>> Get(Page page, long QueryId)
//         {
//             using (var db = new DBService(this))
//             {
//                 return await db.GetPages(page, QueryId);
//             }
//         }
//         public virtual async Task<ResponseList<Dictionary<string, object>>> Details(long QueryId, string condition)
//         {
//             using (var db = new DBService(this))
//             {
//                 return await db.FirstOrDefault(QueryId, condition);
//             }
//         }
//         public virtual async Task<ResponseJson> GetDetails(object id)
//         {
//             ResponseJson response = new ResponseJson();
//             await Task.Run(() => {
//                 CallBack(response, res =>
//                 {
//                     res.Data = GetById(id);
//                 });
//             });
//             return response;
//         }

//         // public virtual T Insert(AppBaseDTO model, Guid userId)
//         // {
//         //     var entity = (T)Activator.CreateInstance(typeof(T));
//         //     model.CopyProperties(entity);
//         //     entity.CreatedAt = DateTime.Now;
//         //     entity.UpdatedAt = DateTime.Now;
//         //     entity.CreatedBy = entity.UpdatedBy = userId;

//         //     Entity.Add(entity);
//         //     return entity;
//         // }
//         // public virtual T5 Insert<T5>(DbSet<T5> TEntity, AppBaseDTO model, Guid userId) where T5 : AppBaseEntity
//         // {
//         //     var entity = (T5)Activator.CreateInstance(typeof(T5));
//         //     model.CopyProperties(entity);
//         //     entity.CreatedAt = DateTime.Now;
//         //     entity.UpdatedAt = DateTime.Now;
//         //     entity.CreatedBy = entity.UpdatedBy = userId;

//         //     TEntity.Add(entity);
//         //     return entity;
//         // }
//         // public virtual ResponseJson OnCreate(AppBaseDTO model, Guid userId, bool isValid)
//         // {
//         //     var result = CallBack(isValid, response =>
//         //     {
//         //         var entity = Insert(model, userId);
//         //         SaveChange();
//         //         response.Id = entity.Id;
//         //     });
//         //     return result;
//         // }
//         // public virtual Guid InsertSave(AppBaseDTO model, Guid userId)
//         // {
//         //     var entity = Insert(model, userId);
//         //     SaveChange();
//         //     return entity.Id;
//         // }
//         // public virtual ResponseJson Update(AppBaseDTO model, Guid userId)
//         // {
//         //     ResponseJson response = new ResponseJson();
//         //     T dbModel = GetById(model.Id);

//         //     model.CreatedAt = dbModel.CreatedAt;
//         //     model.CreatedBy = dbModel.CreatedBy;
//         //     model.CopyProperties(dbModel);
//         //     dbModel.UpdatedAt = DateTime.Now;
//         //     dbModel.UpdatedBy = userId;
//         //     SaveChange();
//         //     return response;
//         // }
//         public virtual async Task<ResponseList<Pagger<Dictionary<string, object>>>> GetWithSummary(Page page)
//         {
//             return await NoneImplementedAsync<ResponseList<Pagger<Dictionary<string, object>>>>();
//         }
//         public virtual async Task<ResponseList<Pagger<Dictionary<string, object>>>> Daily(Page page, bool isDaily)
//         {
//             using (var db = new DBService())
//             {
//                 var query = db.GetWhereClause(page.filter);

//                 page.filter = new List<FilterModel>();
//                 return await GetDailyResult(page, db, query, isDaily);
//             }
//         }
//         public virtual async Task<ResponseList<Pagger<Dictionary<string, object>>>> GetDailyResult(Page page, DBService db, string condition, bool isDaily)
//         {
//             var model = GetDailyResultGuery(page, db, condition, isDaily, GetDailyColumns(page, db, condition, isDaily));
//             return await db.GetPages(page, model.Query, model.Sum);
//         }
//         public virtual DailyResultQueryModel GetDailyResultGuery(Page page, DBService db, string condition, bool isDaily, QueryColumnModel columnModel)
//         {
//             var alias = columnModel.Alias == null ? "" : columnModel.Alias + ".";
//             columnModel.DateField = columnModel.DateField ?? "CreatedAt";
//             columnModel.Table = columnModel.Table ?? "[dbo].[" + (typeof(T)).Name + "] ";
//             string param = isDaily ? "" : "(7)";
//             if (string.IsNullOrEmpty(condition))
//             {
//                 condition = " Where " + alias + "[IsDeleted]=0 ";
//             }
//             else
//             {
//                 condition = " Where " + condition + " and " + alias + "[IsDeleted]=0 ";
//             }
//             var model = new DailyResultQueryModel();
//             string query = "", sumQuery = "";
//             foreach (var col in columnModel.Columns)
//             {
//                 if (query != "")
//                 {
//                     query += ",";
//                     sumQuery += ",";
//                 }
//                 query += " Sum([" + col + "]) [" + col + "]";
//                 sumQuery += alias + "[" + col + "]";
//             }
//             model.Sum = query;
//             query += ", [" + columnModel.DateField + "]";
//             sumQuery += ",CONVERT(varchar" + param + @", " + alias + "[" + columnModel.DateField + "], 111) [" + columnModel.DateField + "]";

//             query = @"
// *  from (
// Select " + query + @"
//               from (
// select " + sumQuery +
// " FROM " + columnModel.Table + (columnModel.Alias ?? "") +
// condition + @" ) data group by [" + columnModel.DateField + "] ) itm ";
//             model.Query = query;
//             return model;
//         }
//         public virtual QueryColumnModel GetDailyColumns(Page page, DBService db, string query, bool isDaily)
//         {
//             var data = GetQueryColumnModel(typeof(T));
//             //var alias = data.Alias == null ? "" : data.Alias + ".";
//             page.SortBy = page.SortBy ?? "[" + data.DateField + "] Desc";
//             return data;
//         }
//         public static async Task<R> NoneImplementedAsync<R>()
//         {
//             await Task.Run(() =>
//             {

//             });
//             throw new NotImplementedException();
//         }
//     }
    // public class DropDownBaseService<T> : AppBaseService<T>, IDropDownService<T> where T : DropDownBaseEntity
    // {
    //     public DropDownBaseService() : base()
    //     {
    //     }
    //     public DropDownBaseService(DbContext ctx) : base(ctx)
    //     {
    //     }
    //     public virtual ResponseJson DropDownData(Expression<Func<T, bool>> filter = null)
    //     {
    //         return new ResponseJson
    //         {
    //             Data = Get(filter, p => p.Name).Select(p => new { text = p.Name, value = p.Id })
    //         };
    //     }
    //     public virtual ResponseJson AutoCompleteData(Expression<Func<T, bool>> filter = null)
    //     {
    //         return new ResponseJson
    //         {
    //             Data = Get(filter, p => p.Name).Select(p => new { text = p.Name, value = p.Id })
    //         };
    //     }
    // }
    public class DailyResultQueryModel
    {
        public DailyResultQueryModel()
        {
            Query = "";
        }
        public string Query { get; set; }
        public string Sum { get; set; }
    }
}
