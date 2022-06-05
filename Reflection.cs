using System;
using System.Collections;
using System.Reflection;

namespace _7_1
{
    public class Reflection
    {
        public static IEnumerable ConstructEnumerator(object obj)
        {
            Queue queue = new Queue();
            queue.Enqueue(obj);
            while (queue.Count > 0)
            {
                object n_obj = queue.Dequeue();
                Type type = n_obj.GetType();
                
                PropertyInfo pInfo = type.GetProperty("Name", typeof(string));
                
                if (pInfo != null && pInfo.GetGetMethod() != null && pInfo.GetSetMethod() != null)
                {
                    
                    yield return n_obj;
                }
                else if (IsList(n_obj)) 
                {
                    

                    foreach (var VAR in (IEnumerable)n_obj)
                    {
                       
                        queue.Enqueue(VAR);
                    }
                }
            }
        }

        //Полиморфизм говна
        public static IEnumerable ConstructEnumerator(object obj,int a)
        {
          Type type = obj.GetType();

          PropertyInfo pInfo = type.GetProperty("Name", typeof(string));
          if (pInfo != null && pInfo.GetGetMethod() != null && pInfo.GetSetMethod() != null)
          {
            yield return obj;
          }
          else if (IsList(obj))
          {
              foreach (var VAR in (IEnumerable)obj)
              {
                  foreach (var n_obj in ConstructEnumerator(VAR, 0))
                  {
                      yield return n_obj;
                  }
              }
          }
        }

        public static bool IsList(object obj)
        {
            return (obj is IList);
        }

        public static bool IsGenericList(object obj)
        {
            return (obj is IList && obj.GetType().IsGenericType);
        }
    }
}
