namespace TP1;

public class Cadete
{
    public int Id { get; }
    public string Nombre { get; }
    public string Direccion { get; }
    public string Telefono { get; }

    public Cadete(int id, string nombre, string direccion, string telefono)
    {
        Id = id;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
    }

    public string ObtenerNombre()
    {
        return Nombre;
    }

    public string ObtenerDireccion()
    {
        return Direccion;
    }

    public string ObtenerTelefono()
    {
        return Telefono;
    }
}