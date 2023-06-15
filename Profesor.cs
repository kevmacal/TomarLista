using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomarLista
{
    public class Profesor
    {
        String id;
        String apellidos;
        String nombres;

        public Profesor()
        {
            this.id = "0";
            this.apellidos = "null";
            this.nombres = "null";
        }

        public Profesor(String id, String apellidos, String nombres)
        {
            this.id = id;
            this.apellidos = apellidos;
            this.nombres = nombres;
        }

        /*Getter and Setter*/
        public String Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Apellidos
        {
            get { return apellidos; }
            set { apellidos = value; }
        }

        public String Nombres
        {
            get { return nombres; }
            set { nombres = value; }
        }
    }
}
