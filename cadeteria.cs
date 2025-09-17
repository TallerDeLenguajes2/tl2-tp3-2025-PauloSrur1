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

    public bool AsignarCadeteAPedido(int idCadete, int idPedido)
    {
        Pedido? pedido = null;
        Cadete? cadete = null;
        foreach (var p in pedidos)
            if (p.Id == idPedido) pedido = p;
        foreach (var c in cadetes)
            if (c.Id == idCadete) cadete = c;
        if (pedido != null && cadete != null)
        {
            pedido.CadeteAsignado = cadete;
            return true;
        }
        return false;
    }

    public double JornalACobrar(int idCadete)
    {
        const double montoPorPedido = 500;
        int entregados = 0;
        foreach (var p in pedidos)
            if (p.CadeteAsignado != null && p.CadeteAsignado.Id == idCadete && p.Estado == EstadoPedido.Entregado)
                entregados++;
        return entregados * montoPorPedido;
    }

    public List<(int IdCadete, string NombreCadete, int CantidadPedidos, double MontoGanado)> ObtenerInformeCadetes()
    {
        var informe = new List<(int, string, int, double)>();
        foreach (var cadete in cadetes)
        {
            int cantidadPedidos = 0;
            foreach (var pedido in pedidos)
            {
                if (pedido.CadeteAsignado != null &&
                    pedido.CadeteAsignado.Id == cadete.Id &&
                    pedido.Estado == EstadoPedido.Entregado)
                {
                    cantidadPedidos++;
                }
            }
            double montoGanado = cantidadPedidos * 500.0;
            informe.Add((cadete.Id, cadete.Nombre, cantidadPedidos, montoGanado));
        }
        return informe;
    }

    public string ObtenerNombreCadeteria()
    {
        return nombre;
    }

    public string ObtenerTelefonoCadeteria()
    {
        return telefono;
    }
}