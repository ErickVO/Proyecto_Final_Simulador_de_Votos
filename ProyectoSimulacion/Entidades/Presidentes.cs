﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoSimulacion.Entidades
{
    public class Presidentes
    {
        [Key]
        public int Id { get; set; }
        public double Presidente { get; set; }
        public string Nombre { get; set; }
       

        public Presidentes()
        {
            Presidente = 0;
            Nombre = "";
            
        }
    }
}
