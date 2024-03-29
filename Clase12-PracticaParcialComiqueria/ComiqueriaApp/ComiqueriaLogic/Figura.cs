﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComiqueriaLogic
{
    public class Figura : Producto
    {
        private double altura;

        #region Metodos

        public Figura(int stock, double precio, double altura) : this("Figura "+ altura+" cm", stock, precio, altura)
        {
        }

        public Figura(string descripcion, int stock, double precio, double altura) : base(descripcion, stock, precio)
        {
            this.altura = altura;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.AppendFormat("\n Altura: {0}", this.altura);

            return sb.ToString();
        }
        #endregion
    }
}
