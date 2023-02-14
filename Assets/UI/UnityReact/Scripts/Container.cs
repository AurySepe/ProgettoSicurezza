using System.Collections.Generic;
namespace MetaClass.UI.UnityReact.Scripts
{
    public class Container<T> where T : Identifiable
    {
        private Dictionary<int, T> elements;

        private Queue<int> idPool;

        private int lastId;

        public Container()
        {
            this.elements = new Dictionary<int, T>();
            this.idPool = new Queue<int>();
            lastId = 0;
        }

        public void AddElement(T element)
        {
            if (idPool.TryDequeue(out int id))
            {
                element.Id = id;
                elements.Add(id,element);
            }
            else
            {
                element.Id = lastId;
                elements.Add(lastId,element);
                lastId++;
            }
        }

        public void RemoveElement(T element)
        {
            if (elements.Remove(element.Id, out T removedComponent))
            {
                idPool.Enqueue(element.Id);
            }
        }

        public T GetElement(int id)
        {
            return elements[id];
        }
        
    }
}