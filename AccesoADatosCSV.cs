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
            clientes.Add(new Cliente(
                int.Parse(datos[0]),
                datos[1],
                datos[2],
                datos[3]
            ));
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
            cadetes.Add(new Cadete(
                int.Parse(datos[0]),
                datos[1],
                datos[2],
                datos[3]
            ));
        }
        return cadetes;
    }

    public void GuardarClientes(List<Cliente> clientes)
    {
        // Implementación de guardado si es necesario
    }

    public void GuardarCadetes(List<Cadete> cadetes)
    {
        // Implementación de guardado si es necesario
    }
}