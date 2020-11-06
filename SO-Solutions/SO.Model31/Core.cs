using System;
using System.Collections.Generic;
using System.Text;

namespace SO.Model31
{
    public abstract class Core<T> : ICore<T>
    {
        public T ID { get; set; }
    }
}
