using System.IO;

namespace TP1;

public static class CargaDeDatos
{
    public static List<Cliente> LeerClientes(string archivo)
    {
        var clientes = new List<Cliente>();
        var lineas = File.ReadAllLines(archivo);

        for (int i = 1; i < lineas.Length; i++)
        {
            var datos = lineas[i].Split(',');
            if (datos.Length < 4) continue;
            int id = int.Parse(datos[0]);
            string nombre = datos[1];
            string direccion = datos[2];
            string telefono = datos[3];

            clientes.Add(new Cliente(id, nombre, direccion, telefono));
        }

        return clientes;
    }

    public static List<Cadete> LeerCadetes(string archivo)
    {
        var cadetes = new List<Cadete>();
        var lineas = File.ReadAllLines(archivo);

        for (int i = 1; i < lineas.Length; i++)
        {
            var datos = lineas[i].Split(',');
            if (datos.Length < 4) continue;
            int id = int.Parse(datos[0]);
            string nombre = datos[1];
            string direccion = datos[2];
            string telefono = datos[3];

            cadetes.Add(new Cadete(id, nombre, direccion, telefono));
        }

        return cadetes;
    }
}