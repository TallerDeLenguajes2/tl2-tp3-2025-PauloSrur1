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
            clientes.Add(new Cliente(
                int.Parse(datos[0]),
                datos[1],
                datos[2],
                datos[3]
            ));
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
            cadetes.Add(new Cadete(
                int.Parse(datos[0]),
                datos[1],
                datos[2],
                datos[3]
            ));
        }

        return cadetes;
    }
}