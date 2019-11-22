﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IFiles<T>
    {
        void Guardar(string nombrearchivo, T objeto);
        void Guardar(string nombrearchivo, T objeto, Encoding encoding);
        bool Leer(string nombrearchivo, out T objeto);
        bool Leer(string nombrearchivo, out T objeto, Encoding encoding);
    }
}
