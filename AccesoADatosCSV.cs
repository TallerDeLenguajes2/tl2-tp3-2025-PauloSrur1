using System.IO;

namespace TP1;

public class AccesoADatosCSV : IAccesoADatos
{
    private string archivoClientes;
    private string archivoCadetes;

    public AccesoADatosCSV(string archivoClientes, string archivoCadetes)
    {
        this.archivoClientes = archivoClientes;
        this.archivoCadetes = archivoCadetes;
    }

    public List<Cliente> LeerClientes()
    {
        var clientes = new List<Cliente>();
        var lineas = File.ReadAllLines(archivoClientes);

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

    public List<Cadete> LeerCadetes()
    {
        var cadetes = new List<Cadete>();
        var lineas = File.ReadAllLines(archivoCadetes);

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

    public void GuardarClientes(List<Cliente> clientes)
    {
        var lineas = new List<string> { "Id,Nombre,Direccion,Telefono" };
        foreach (var c in clientes)
            lineas.Add($"{c.Id},{c.Nombre},{c.Direccion},{c.Telefono}");
        File.WriteAllLines(archivoClientes, lineas);
    }

    public void GuardarCadetes(List<Cadete> cadetes)
    {
        var lineas = new List<string> { "Id,Nombre,Direccion,Telefono" };
        foreach (var c in cadetes)
            lineas.Add($"{c.Id},{c.Nombre},{c.Direccion},{c.Telefono}");
        File.WriteAllLines(archivoCadetes, lineas);
    }
}