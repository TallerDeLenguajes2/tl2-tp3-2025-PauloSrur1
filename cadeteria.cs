using System.Linq;

namespace TP1;

public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> cadetes;
    private List<Pedido> pedidos = new List<Pedido>();

    public string Nombre => nombre;
    public string Telefono => telefono;
    public List<Cadete> Cadetes => cadetes;
    public List<Pedido> Pedidos => pedidos;

    public Cadeteria(string nombre, string telefono, List<Cadete> cadetes)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        this.cadetes = cadetes;
    }

    public void AgregarPedido(Pedido pedido)
    {
        pedidos.Add(pedido);
    }

    // Asigna un cadete a un pedido
    public bool AsignarCadeteAPedido(int idCadete, int idPedido)
    {
        var pedido = pedidos.FirstOrDefault(p => p.Id == idPedido);
        var cadete = cadetes.FirstOrDefault(c => c.Id == idCadete);
        if (pedido != null && cadete != null)
        {
            pedido.CadeteAsignado = cadete;
            return true;
        }
        return false;
    }

    // Calcula el jornal a cobrar por un cadete
    public double JornalACobrar(int idCadete)
    {
        const double montoPorPedido = 500;
        int entregados = pedidos.Count(p => p.CadeteAsignado?.Id == idCadete && p.Estado == EstadoPedido.Entregado);
        return entregados * montoPorPedido;
    }
}