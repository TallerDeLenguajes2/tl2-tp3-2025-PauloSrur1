namespace TP1;

public enum EstadoPedido { Pendiente, Entregado, Cancelado }

public class Pedido
{
    public int Id { get; }
    public EstadoPedido Estado { get; set; }
    public Cliente Cliente { get; }
    public Cadete? CadeteAsignado { get; set; }

    public Pedido(int id, Cliente cliente)
    {
        Id = id;
        Cliente = cliente;
        Estado = EstadoPedido.Pendiente;
        CadeteAsignado = null;
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