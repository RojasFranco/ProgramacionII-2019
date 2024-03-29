﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Provincial : Llamada
    {

        protected Franja franjaHoraria;


        #region Propiedades

        public float CostoLlamada
        {
            get
            {
                return CalcularCosto();
            }
        }

        #endregion


        #region Constructores

        public Provincial(Franja miFranja, Llamada llamada) : base(llamada.Duracion, llamada.NroDestino, llamada.NroOrigen)
        {
            this.franjaHoraria = miFranja;
        }

        public Provincial(string origen, Franja miFranja, float duracion, string destino) : this(miFranja, new Llamada(duracion, destino, origen))
        {            
        }

        #endregion


        #region Metodos

        private float CalcularCosto()
        {
            if(this.franjaHoraria == Franja.Franja_1)
            {
                return this.Duracion * 0.99f;
            }
            else if(this.franjaHoraria == Franja.Franja_2)
            {
                return this.Duracion * 1.25f;
            }
            return this.Duracion * 0.66f;

        }

        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n-------------Llamada provincial-------------");
            sb.Append(base.Mostrar());
            sb.AppendFormat("\n Costo llamada : {0} ", this.CostoLlamada);
            sb.AppendFormat("\n Franja horaria: {0} ", this.franjaHoraria);
            return sb.ToString();
        }

        #endregion


        public enum Franja
        {
            Franja_1,
            Franja_2,
            Franja_3
        }
    }
}
