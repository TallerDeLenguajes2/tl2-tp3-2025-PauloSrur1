namespace TP1;

public enum EstadoPedido { Pendiente, Entregado, Cancelado }

public class Pedido
{
    public int Id { get; }
    public string Observacion { get; set; }
    public EstadoPedido Estado { get; set; }
    public Cliente Cliente { get; }
    public Cadete? CadeteAsignado { get; set; }

    public Pedido(int id, string observacion, Cliente cliente)
    {
        Id = id;
        Observacion = observacion;
        Cliente = cliente;
        Estado = EstadoPedido.Pendiente;
        CadeteAsignado = null;
    }

    public string ObtenerObservacion()
    {
        return Observacion;
    }

    public EstadoPedido ObtenerEstado()
    {
        return Estado;
    }

    public string ObtenerNombreCliente()
    {
        return Cliente.Nombre;
    }

    public int? ObtenerIdCadeteAsignado()
    {
        return CadeteAsignado?.Id;
    }
}