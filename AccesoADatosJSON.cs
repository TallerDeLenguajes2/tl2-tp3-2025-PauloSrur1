using System.Text.Json;

namespace TP1;

public class AccesoADatosJSON : IAccesoADatos
{
    private string archivoClientes;
    private string archivoCadetes;

    public AccesoADatosJSON(string archivoClientes, string archivoCadetes)
    {
        this.archivoClientes = archivoClientes;
        this.archivoCadetes = archivoCadetes;
    }

    public List<Cliente> LeerClientes()
    {
        if (!File.Exists(archivoClientes)) return new List<Cliente>();
        var json = File.ReadAllText(archivoClientes);
        return JsonSerializer.Deserialize<List<Cliente>>(json) ?? new List<Cliente>();
    }

    public List<Cadete> LeerCadetes()
    {
        if (!File.Exists(archivoCadetes)) return new List<Cadete>();
        var json = File.ReadAllText(archivoCadetes);
        return JsonSerializer.Deserialize<List<Cadete>>(json) ?? new List<Cadete>();
    }

    public void GuardarClientes(List<Cliente> clientes)
    {
        var json = JsonSerializer.Serialize(clientes);
        File.WriteAllText(archivoClientes, json);
    }

    public void GuardarCadetes(List<Cadete> cadetes)
    {
        var json = JsonSerializer.Serialize(cadetes);
        File.WriteAllText(archivoCadetes, json);
    }
}