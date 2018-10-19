//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;

//namespace ServiceLayer.Repositories
//{
//    public interface IGlobalRepository
//    {
        
//        // Will Add the given entity
       
//        object Add<T>(T itemToAdd) where T : class;

//        // Will Add the given list of entities
       
//        object AddRange<T>(List<T> itemsToAdd) where T : class;

//        // Will simply update any Model without any effort
        
//        object SimpleUpdate<T>(T itemToUpdate) where T : class;

//        // Will update any Model without replacing data with null or foreign keys with 0 in case the user didn't add them
        
//        object SmartUpdate(BaseEntity itemToUpdate);

//        // will SoftDelete the indicated object
        
//        object SoftDelete(BaseEntity itemToDelete);

//        // Restore the soft deleted elements ! this method will not update the DeletedAt property
        
//        object Restore(BaseEntity itemToRestore);

//       // This method will return an IQueryable object containing all the data that match the specified model and the condition expression with the indicated includes
        
//        IQueryable<T> Get<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class;

//        // Will ignore the global query filters! can be used to get data that will be restored
        
//        IQueryable<T> ForceGet<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class;
//    }
//}
