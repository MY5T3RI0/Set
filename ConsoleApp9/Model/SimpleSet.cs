using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Set.Model
{
    /// <summary>
    /// Множество.
    /// </summary>
    /// <typeparam name="T">Тип элемента множества.</typeparam>
    class SimpleSet<T> : IEnumerable
    {
        /// <summary>
        /// Список элементов.
        /// </summary>
        private List<T> Items = new List<T>();

        /// <summary>
        /// Размер.
        /// </summary>
        private int Count => Items.Count;

        /// <summary>
        /// Создать пустое множество.
        /// </summary>
        public SimpleSet()
        {

        }

        /// <summary>
        /// Создать новое множество.
        /// </summary>
        /// <param name="data">Новый элемент.</param>
        public SimpleSet(T data)
        {
            if (data.Equals(default(T)))
            {
                throw new ArgumentNullException(nameof(data), "Элемент не может быть нулевым");
            }

            Items.Add(data);
        }

        /// <summary>
        /// Создать множетво элементов.
        /// </summary>
        /// <param name="items">Перечисление элементов.</param>
        public SimpleSet(IEnumerable<T> items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items), "Множетсво не может быть null");
            }

            Items = items.ToList();
        }

        /// <summary>
        /// Добавить элемент.
        /// </summary>
        /// <param name="data">Элемент.</param>
        public void Add(T data)
        {
            if (data.Equals(default(T)))
            {
                throw new ArgumentNullException(nameof(data), "Элемент не может быть нулевым");
            }

            if (Items.Contains(data))
            {
                return;
            }
            
            Items.Add(data);
        }

        /// <summary>
        /// Удалить элемент.
        /// </summary>
        /// <param name="data">Элемент.</param>
        public void Remove(T data)
        {
            if (data.Equals(default(T)))
            {
                throw new ArgumentNullException(nameof(data), "Элемент не может быть нулевым");
            }

            Items.Remove(data);
        }

        /// <summary>
        /// Выполнить объединение множеств.
        /// </summary>
        /// <param name="set">Добавляемое множетсво.</param>
        /// <returns>Объединение множеств.</returns>
        public SimpleSet<T> Union(SimpleSet<T> set)
        {
            if (set is null)
            {
                throw new ArgumentNullException(nameof(set), "Множество не может быть нулевым");
            }

            var result = new SimpleSet<T>();

            foreach(T item in Items)
            {
                result.Add(item);
            }
            foreach (T item in set.Items)
            {
                result.Add(item);
            }

            return result;
        }

        /// <summary>
        /// Поиск общих элементов во множествах.
        /// </summary>
        /// <param name="set">Сравниваемое множество.</param>
        /// <returns>Множество общих элементов.</returns>
        public SimpleSet<T> Intersect(SimpleSet<T> set)
        {
            if (set is null)
            {
                throw new ArgumentNullException(nameof(set), "Множество не может быть нулевым");
            }

            var result = new SimpleSet<T>();

            var big = set;
            var small = this;
            if (Count > set.Count)
            {
                big = this;
                small = set;
            }

            for (int i = 0; i < small.Count; i++)
            {
                for (int j = 0; j < big.Count; j++)
                {
                    if (big.Items[j].Equals(small.Items[i]))
                    {
                        result.Add(small.Items[i]);
                        break;
                    }
                }
            }
            
            return result;
        }

        /// <summary>
        /// Выполнить разность множеств.
        /// </summary>
        /// <param name="set">Вычитаемое множество.</param>
        /// <returns>Итоговое множество.</returns>
        public SimpleSet<T> Difference(SimpleSet<T> set)
        {
            if (set is null)
            {
                throw new ArgumentNullException(nameof(set), "Множество не может быть нулевым");
            }

            //var result = new SimpleSet<T>();

            //for (int i = 0; i < Count; i++)
            //{
            //    bool isEqual = false;
            //    for (int j = 0; j < set.Count; j++)
            //    {
            //        if (set.Items[j].Equals(Items[i]))
            //        {
            //            isEqual = true;
            //            break;
            //        }
            //    }

            //    if (!isEqual)
            //    {
            //        result.Add(Items[i]);
            //    }

            //}

            var result = new SimpleSet<T>(Items);

            foreach(T item in set.Items)
            {
                result.Remove(item);
            }

            return result;
        }

        /// <summary>
        /// Проверка на вхождение во множество.
        /// </summary>
        /// <param name="set">Большее множество.</param>
        /// <returns>Результат проверки.</returns>
        public bool Subset(SimpleSet<T> set)
        {
            if (set is null)
            {
                throw new ArgumentNullException(nameof(set), "Множество не может быть нулевым");
            }

            foreach (T item1 in Items)
            {
                bool isEqual = false;
                foreach (T item2 in set.Items)
                {
                    if (item1.Equals(item2))
                    {
                        isEqual = true;
                        break;
                    }
                }
                if (!isEqual)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Операция исключающая или между множествами.
        /// </summary>
        /// <param name="set">Входное множетсво.</param>
        /// <returns>Итоговое множество</returns>
        public SimpleSet<T> SymmetricDifference(SimpleSet<T> set)
        {
            if (set is null)
            {
                throw new ArgumentNullException(nameof(set), "Множество не может быть нулевым");
            }

            var result = new SimpleSet<T>();

            for (int i = 0; i < Count; i++)
            {
                bool isEqual = false;
                for (int j = 0; j < set.Count; j++)
                {
                    if (set.Items[j].Equals(Items[i]))
                    {
                        isEqual = true;
                        break;
                    }
                }

                if (!isEqual)
                {
                    result.Add(Items[i]);
                }

            }

            for (int i = 0; i < set.Count; i++)
            {
                bool isEqual = false;
                for (int j = 0; j < Count; j++)
                {
                    if (Items[j].Equals(set.Items[i]))
                    {
                        isEqual = true;
                        break;
                    }
                }

                if (!isEqual)
                {
                    result.Add(set.Items[i]);
                }

            }

            return result;
        }
        public IEnumerator GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}
