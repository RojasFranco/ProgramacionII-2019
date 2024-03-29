﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralitaHerencia
{
    public class Centralita
    {
        private List<Llamada> listaDeLlamadas;
        protected string razonSocial;


        #region Propiedades

        public float GananciaPorLocal
        {
            get
            {
                return this.CalcularGanancia(Llamada.TipoLlamada.Local);
            }
        }

        public float GananciaPorProvincial
        {
            get
            {
                return this.CalcularGanancia(Llamada.TipoLlamada.Provincial);
            }
        }

        public float GananciaPorTotal
        {
            get
            {
                return (this.GananciaPorLocal + this.GananciaPorProvincial);
            }
        }

        public List<Llamada> Llamadas
        {
            get
            {
                return this.listaDeLlamadas;
            }
        }

        #endregion

        #region Constructores

        public Centralita()
        {
            listaDeLlamadas = new List<Llamada>();
        }

        public Centralita(string nombreEmpresa) :this()
        {
            this.razonSocial = nombreEmpresa;
        }

        #endregion


        #region Metodos

        private float CalcularGanancia(Llamada.TipoLlamada tipo)
        {
            float costoLocal = 0;
            float costoProvincial = 0;            
            
            foreach (Llamada llamada in this.Llamadas)
            {
                if(llamada is Local) // o (llamada.GetType() == typeof(Local)) 
                {
                    costoLocal += llamada.CostoLlamada; //((Local)llamada).CostoLlamada;
                }
                else if(llamada is Provincial)
                {
                    costoProvincial += llamada.CostoLlamada; //((Provincial)llamada).CostoLlamada;
                }
            }    
            switch(tipo)
            {                
                
                case Llamada.TipoLlamada.Local:
                    return costoLocal;
                case Llamada.TipoLlamada.Provincial:
                    return costoProvincial;
                default:
                   return (costoProvincial + costoLocal);                
                 
            }            
        }



        public string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("\n Razon social: {0}\n ", this.razonSocial);
            sb.AppendFormat(" Ganancia total: {0}\n ", this.GananciaPorTotal);
            sb.AppendFormat(" Ganancia Local: {0}\n ", this.GananciaPorLocal);
            sb.AppendFormat(" Ganancia Provincial: {0}\n ", this.GananciaPorProvincial);   
            foreach(Llamada llamada in Llamadas) //Llamadas= this.listaLlamadas
            {
                sb.Append(llamada.ToString());                
                /*
                 * NO HACEN FALTA POR POLIMORFISMO
                 * toString llama a llamadas y al ver el type se dirige a Local o Provincial
                if (llamada is Local)
                {
                    sb.Append((Local)llamada.ToString());
                }
                else if(llamada is Provincial)
                {
                    sb.Append(((Provincial)llamada).ToString());
                }*/                
            }
            return sb.ToString();

        }

        public void OrdenarLlamadas()
        {            
            listaDeLlamadas.Sort(Llamada.OrdenarPorDuracion);// VER            
        }


        private void AgregarLlamada(Llamada nuevaLlamada)
        {
            this.listaDeLlamadas.Add(nuevaLlamada);
        }



        #endregion


        #region Sobrecargas

        public static bool operator ==(Centralita centralita, Llamada llamada)
        {
            foreach (Llamada llamadaEnLista in centralita.Llamadas)
            {
                if(llamadaEnLista==llamada)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Centralita centralita, Llamada llamada)
        {
            return !(centralita == llamada);
        }


        public static Centralita operator +(Centralita centralita, Llamada nuevaLlamada)
        {
            if(centralita != nuevaLlamada)
            {
                centralita.AgregarLlamada(nuevaLlamada);
            }
            return centralita;
        }

        #endregion
    }
}
