using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;



namespace examen_final
{
    internal class Proveedor : Item
    {
        public int ID;
        public string RUC;
        public string RazonSocial;
        public string Direccion;
        public string Ciudad;
        public string Telefono;

        public Proveedor(Consola _consola, BaseDatos _objBD) : base(_consola, _objBD, "000", "Proveedor", "RUC")
        {
        }

        public Proveedor(Consola _consola, BaseDatos _objBD, int ID, String _Codigo, String RUC, String RazonSocial, String Direccion, String Ciudad, String Telefono) : base(_consola, _objBD, _Codigo, "Proveedor", "RUC")
        {
            this.ID = ID;
            this.RUC = RUC;
            this.RazonSocial = RazonSocial;
            this.Direccion = Direccion;
            this.Ciudad = Ciudad;
            this.Telefono = Telefono;
        }

        public override Item creatItem(Consola _consola, BaseDatos _objBD)
        {
            return new Proveedor(_consola, _objBD);
        }

        public override Item creatItem(Consola _consola, BaseDatos _objBD, DataRow _registro)
        {
            return new Proveedor(_consola, _objBD, int.Parse(_registro["ID"].ToString()),
                _registro["RUC"].ToString(), _registro["RUC"].ToString(), _registro["RazonSocial"].ToString(),
                _registro["Direccion"].ToString(), _registro["Ciudad"].ToString(), _registro["Telefono"].ToString());
        }

        public override void mostrarMembreteTabla()
        {
            consola.Escribir(40, 2, ConsoleColor.Yellow, "LISTA DE PROVEEDORES");
            consola.Escribir(5, 5, ConsoleColor.Blue, "N°"); consola.Escribir(10, 5, ConsoleColor.Blue, "RUC");
            consola.Escribir(25, 5, ConsoleColor.Blue, "Razón Social"); consola.Escribir(45, 5, ConsoleColor.Blue, "Dirección");
            consola.Escribir(65, 5, ConsoleColor.Blue, "Ciudad"); consola.Escribir(80, 5, ConsoleColor.Blue, "Telefono");
            consola.Marco(3, 4, 95, 15);
        }

        public override void mostrarInfoComoFila(int Num, int fila)
        {
            consola.Escribir(5, fila, ConsoleColor.White, Num.ToString());
            consola.Escribir(10, fila, ConsoleColor.White, RUC);
            consola.Escribir(25, fila, ConsoleColor.White, RazonSocial);
            consola.Escribir(45, fila, ConsoleColor.White, Direccion);
            consola.Escribir(65, fila, ConsoleColor.White, Ciudad);
            consola.Escribir(80, fila, ConsoleColor.White, Telefono);

        }


        public override void mostrarInfo()
        {

            consola.Escribir(30, 2, ConsoleColor.Red, "INFORMACIÓN DEL PROVEEDOR");
            consola.Marco(10, 3, 65, 11);
            consola.Escribir(20, 5, ConsoleColor.Yellow, "RUC: "); consola.Escribir(35, 5, ConsoleColor.White, RUC);
            consola.Escribir(20, 6, ConsoleColor.Yellow, "Razón Social: "); consola.Escribir(35, 6, ConsoleColor.White, RazonSocial);
            consola.Escribir(20, 7, ConsoleColor.Yellow, "Dirección: "); consola.Escribir(35, 7, ConsoleColor.White, Direccion);
            consola.Escribir(20, 8, ConsoleColor.Yellow, "Ciudad: "); consola.Escribir(35, 8, ConsoleColor.White, Ciudad);
            consola.Escribir(20, 9, ConsoleColor.Yellow, "Teléfono: "); consola.Escribir(35, 9, ConsoleColor.White, Telefono);
        }

        public override void leerInfo()
        {

            consola.Escribir(30, 2, ConsoleColor.Red, "NUEVO PROVEEDOR");
            consola.Marco(10, 3, 65, 11);
            consola.Escribir(20, 5, ConsoleColor.Yellow, "RUC: ");
            consola.Escribir(20, 6, ConsoleColor.Yellow, "Razón Social: ");
            consola.Escribir(20, 7, ConsoleColor.Yellow, "Dirección: ");
            consola.Escribir(20, 8, ConsoleColor.Yellow, "Ciudad: ");
            consola.Escribir(20, 9, ConsoleColor.Yellow, "Teléfono: ");

            RUC = consola.leerCadena(35, 5);
            RazonSocial = consola.leerCadena(35, 6);
            Direccion = consola.leerCadena(35, 7);
            Ciudad = consola.leerCadena(35, 8);
            Telefono = consola.leerCadena(35, 9);

        }

        public override String getSQL(String TipoSQL, String CodigoABuscar = "")
        {
            String SQL = "";
            switch (TipoSQL)
            {
                case "Insert":
                    SQL = "Insert into TbProveedores (RUC, RazonSocial,Direccion,Ciudad,Telefono) values('"
                          + RUC + "','" + RazonSocial + "','" + Direccion + "','" + Ciudad + "','" + Telefono + "');";
                    break;
                case "Delete":
                    SQL = "Delete from TbProveedores where RUC='" + CodigoABuscar + "'";
                    break;
                case "Select":
                    if (CodigoABuscar != "")
                    {
                        SQL = "Select * from TbProveedores where RUC='" + CodigoABuscar + "'";
                    }
                    else
                    {
                        SQL = "Select * from TbProveedores order by RUC";
                    }
                    break;
            }

            return SQL;
        }
    }
}

    

