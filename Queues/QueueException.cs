using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queues
{
    /// <summary>        
    /// исключение возникает при нарушении контракта
    /// Класс содержит два конструктора
    /// </summary>
    public class QueueException : Exception
    {
        // Конструкторы, имеющиеся в базовом классе
        /// <summary>        
        /// конструктор без параметра 
        /// </summary>
        public QueueException() : base() { }
        /// <summary>        
        /// конструктор с параметром 
        /// </summary>
        public QueueException(String msg) : base(msg) { }
    }
}
