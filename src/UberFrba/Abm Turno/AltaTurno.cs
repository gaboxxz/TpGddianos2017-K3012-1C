﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UberFrba.Model;
using UberFrba.CapaDAO;

namespace UberFrba.Abm_Turno
{
    public partial class AltaTurno : FormBase
    {
        public AltaTurno()
        {
            InitializeComponent();
        }

        private void AltaTurno_Load(object sender, EventArgs e)
        {

        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool validaciones()
        {
            if (String.IsNullOrEmpty(TextBoxDescripcion.Text) || (TextBoxDescripcion.Text == null)) { Mensaje_Error("Descripcion vacía"); return false; }
            if (String.IsNullOrEmpty(TextBoxHoraInicio.Text) ||(TextBoxHoraInicio.Text == "")) { Mensaje_Error("Hora de inicio vacía"); return false; }
            if (String.IsNullOrEmpty(TextBoxHoraFin.Text) ||(TextBoxHoraFin.Text == "") ) { Mensaje_Error("Hora de fin vacía"); return false; }
            if (String.IsNullOrEmpty(TextBoxValorKM.Text) ||(TextBoxValorKM.Text == "") ) { Mensaje_Error("Valor del kilometro vacío"); return false; }
            if (String.IsNullOrEmpty(TextBoxPrecioBase.Text) || (TextBoxPrecioBase.Text == "")) { Mensaje_Error("Precio base vacío"); return false; }
            try
            {
                if ((Convert.ToDouble(TextBoxValorKM.Text) == 0)) { Mensaje_Error("El valor base es 0"); }
                if ((Convert.ToDouble(TextBoxPrecioBase.Text) == 0)) { Mensaje_Error("El precio base es 0"); }
                if ((Convert.ToDouble(TextBoxHoraInicio.Text) >= 0) && !(Convert.ToDouble(TextBoxHoraInicio.Text) <= 24)) { Mensaje_Error("Hora de inicio fuera del rango de 24hs"); return false; }
                if ((Convert.ToDouble(TextBoxHoraFin.Text) >= 0) && !(Convert.ToDouble(TextBoxHoraFin.Text) <= 24)) { Mensaje_Error("Hora de fin fuera del rango de 24hs"); return false; }
                if (! ((Convert.ToDouble(TextBoxHoraFin.Text)) > (Convert.ToDouble(TextBoxHoraInicio.Text))) ) { Mensaje_Error("La Hora Fin no debe ser menonr que la Hora Inicio"); return false; }
            }
            catch
            {
                Mensaje_Error("Los horarios, el precio base y el valor por kilometro, deben ser números");
                return false;
            }
            return true;
        }


        private void Alta_Click(object sender, EventArgs e)
        {
            if ((validaciones()))
            {
                string descripcion = TextBoxDescripcion.Text;
                double hi = Convert.ToDouble(TextBoxHoraInicio.Text);
                double hf = Convert.ToDouble(TextBoxHoraFin.Text);
                double valor = Convert.ToDouble(TextBoxValorKM.Text);
                double pb = Convert.ToDouble(TextBoxPrecioBase.Text);
                int finalizo = DAOTurno.altaTurno(descripcion, hi, hf, valor, pb);
                if (finalizo == 1)
                {
                    Mensaje_OK("El turno ha sido dada de alta");
                    Close();
                }
                else
                {
                    Mensaje_Error("Los horarios del turno de alta está superpuesto a algun/os turno/s");
                }
            }
        }

        private void TextBoxValorKM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBoxPrecioBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

    }
}
