using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class VentaNegocio
    {
        public List<Venta> listarVentas()
        {
            AccesoDatos datos = new AccesoDatos();

            List<Venta> lista = new List<Venta>();
            try
            {
                datos.setearConsulta("SELECT V.IdVenta, V.IdCliente, C.Nombre AS NombreCliente, C.Apellido AS ApellidoCliente, V.Fecha, V.VentaTotal, V.IdFormaPago, FP.Nombre AS NombreFormaPago, V.IdFormaEntrega, FE.Nombre AS NombreFormaEntrega, V.IdDireccion, V.IdEstadoVenta, EV.Nombre AS NombreEstado, V.Observaciones, V.CodigoSeguimiento FROM VENTA V INNER JOIN CLIENTE C ON V.IdCliente = C.IdCliente INNER JOIN FORMAPAGO FP ON V.IdFormaPago = FP.IdFormaPago INNER JOIN FORMAENTREGA FE ON V.IdFormaEntrega = FE.IdFormaEntrega INNER JOIN ESTADOVENTA EV  ON V.IdEstadoVenta = EV.IdEstadoVenta ORDER BY V.Fecha DESC, V.IdVenta DESC");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Venta aux = new Venta();
                    aux.IdVenta = (int)datos.Lector["IdVenta"];
                    aux.Cliente = new Cliente();
                    aux.Cliente.IdCliente = (int)datos.Lector["IdCliente"];
                    aux.Cliente.Nombre = (string)datos.Lector["NombreCliente"];
                    aux.Cliente.Apellido = (string)datos.Lector["ApellidoCliente"];
                    aux.Fecha = (DateTime)datos.Lector["Fecha"];
                    aux.VentaTotal = (decimal)datos.Lector["VentaTotal"];
                    aux.FormaPago = new FormaPago();
                    aux.FormaPago.IdFormaPago = (int)datos.Lector["IdFormaPago"];
                    aux.FormaPago.Nombre = (string)datos.Lector["NombreFormaPago"];
                    aux.FormaEntrega = new FormaEntrega();
                    aux.FormaEntrega.IdFormaEntrega = (int)datos.Lector["IdFormaEntrega"];
                    aux.FormaEntrega.Nombre = (string)datos.Lector["NombreFormaEntrega"];

                    if (datos.Lector["IdDireccion"] != DBNull.Value)
                    {
                        aux.Direccion = new Direccion();
                        aux.Direccion.IdDireccion = (int)datos.Lector["IdDireccion"];
                    }

                    aux.EstadoVenta = new EstadoVenta();
                    aux.EstadoVenta.IdEstadoVenta = (int)datos.Lector["IdEstadoVenta"];
                    aux.EstadoVenta.Nombre = (string)datos.Lector["NombreEstado"];

                    if (datos.Lector["Observaciones"] != DBNull.Value)
                    {
                        aux.Observaciones = (string)datos.Lector["Observaciones"];
                    }

                    if (datos.Lector["CodigoSeguimiento"] != DBNull.Value)
                    {
                        aux.CodigoSeguimiento =
                            (string)datos.Lector["CodigoSeguimiento"];
                    }

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public Venta obtenerVenta(int idVenta)
        {
            AccesoDatos datos = new AccesoDatos();
            Venta venta = null;

            try
            {
                datos.setearConsulta("SELECT V.IdVenta, V.IdCliente, C.Nombre AS NombreCliente, C.Apellido AS ApellidoCliente, C.Email AS EmailCliente, V.Fecha, V.VentaTotal, V.IdFormaPago, FP.Nombre AS NombreFormaPago, V.IdFormaEntrega, FE.Nombre AS NombreFormaEntrega, V.IdDireccion, V.IdEstadoVenta, EV.Nombre AS NombreEstado, V.Observaciones, V.CodigoSeguimiento FROM VENTA V INNER JOIN CLIENTE C ON V.IdCliente = C.IdCliente INNER JOIN FORMAPAGO FP ON V.IdFormaPago = FP.IdFormaPago INNER JOIN FORMAENTREGA FE ON V.IdFormaEntrega = FE.IdFormaEntrega INNER JOIN ESTADOVENTA EV  ON V.IdEstadoVenta = EV.IdEstadoVenta WHERE V.IdVenta = @id");
                datos.setearParametro("@id", idVenta);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    venta = new Venta();

                    venta.IdVenta = (int)datos.Lector["IdVenta"];
                    venta.Cliente = new Cliente();
                    venta.Cliente.IdCliente = (int)datos.Lector["IdCliente"];
                    venta.Cliente.Nombre = (string)datos.Lector["NombreCliente"];
                    venta.Cliente.Apellido = (string)datos.Lector["ApellidoCliente"];
                    venta.Cliente.Email = (string)datos.Lector["EmailCliente"];
                    venta.Fecha = (DateTime)datos.Lector["Fecha"];
                    venta.VentaTotal = (decimal)datos.Lector["VentaTotal"];
                    venta.FormaPago = new FormaPago();
                    venta.FormaPago.IdFormaPago = (int)datos.Lector["IdFormaPago"];
                    venta.FormaPago.Nombre = (string)datos.Lector["NombreFormaPago"];
                    venta.FormaEntrega = new FormaEntrega();
                    venta.FormaEntrega.IdFormaEntrega = (int)datos.Lector["IdFormaEntrega"];
                    venta.FormaEntrega.Nombre = (string)datos.Lector["NombreFormaEntrega"];

                    if (datos.Lector["IdDireccion"] != DBNull.Value)
                    {
                        venta.Direccion = new Direccion();
                        venta.Direccion.IdDireccion = (int)datos.Lector["IdDireccion"];
                    }

                    venta.EstadoVenta = new EstadoVenta();
                    venta.EstadoVenta.IdEstadoVenta = (int)datos.Lector["IdEstadoVenta"];
                    venta.EstadoVenta.Nombre = (string)datos.Lector["NombreEstado"];

                    if (datos.Lector["Observaciones"] != DBNull.Value)
                    {
                        venta.Observaciones = (string)datos.Lector["Observaciones"];
                    }

                    if (datos.Lector["CodigoSeguimiento"] != DBNull.Value)
                    {
                        venta.CodigoSeguimiento =
                            (string)datos.Lector["CodigoSeguimiento"];
                    }

                }

                return venta;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<DetalleVenta> listarDetallesPorVenta(int idVenta)
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT D.IdDetalleVenta, D.IdVenta, D.IdProducto, P.Nombre AS NombreProducto, D.Cantidad, D.PrecioUnitario FROM DETALLEVENTA D INNER JOIN PRODUCTO P ON P.IdProducto = D.IdProducto WHERE D.IdVenta = @idVenta");
                datos.setearParametro("@idVenta", idVenta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    DetalleVenta aux = new DetalleVenta();

                    aux.IdDetalleVenta = (int)datos.Lector["IdDetalleVenta"];
                    aux.IdVenta = (int)datos.Lector["IdVenta"];

                    aux.Producto = new Producto();
                    aux.Producto.IdProducto = (int)datos.Lector["IdProducto"];
                    aux.Producto.Nombre = (string)datos.Lector["NombreProducto"];

                    aux.Cantidad = (int)datos.Lector["Cantidad"];
                    aux.PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"];

                    lista.Add(aux);
                }

                return lista;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregar(Venta venta)
        {
            AccesoDatos datos = new AccesoDatos();

            if (venta == null)
            {
                throw new ArgumentNullException(nameof(venta));
            }

            if (venta.Detalles == null || venta.Detalles.Count == 0)
            {
                throw new ArgumentException(
                    "La venta debe contener al menos un producto."
                );
            }

            if (venta.Cliente == null || venta.Cliente.IdCliente <= 0)
            {
                throw new ArgumentException(
                    "La venta debe tener un cliente válido."
                );
            }

            if (venta.FormaEntrega == null || venta.FormaEntrega.IdFormaEntrega <= 0)
            {
                throw new ArgumentException(
                    "La venta debe tener una forma de entrega válida."
                );
            }

            if (venta.FormaPago == null || venta.FormaPago.IdFormaPago <= 0)
            {
                throw new ArgumentException(
                    "La venta debe tener una forma de pago válida."
                );
            }

            if (venta.EstadoVenta == null || venta.EstadoVenta.IdEstadoVenta <= 0)
            {
                throw new ArgumentException(
                    "La venta debe tener un estado válido."
                );
            }

            List<int> productosRevisados = new List<int>();

            foreach (DetalleVenta detalle in venta.Detalles)
            {
                if (detalle == null || detalle.Producto == null || detalle.Producto.IdProducto <= 0 || detalle.Cantidad <= 0)
                {
                    throw new ArgumentException(
                        "La venta contiene un detalle inválido."
                    );
                }

                int idProducto = detalle.Producto.IdProducto;

                if (productosRevisados.Contains(idProducto))
                {
                    throw new ArgumentException(
                        "La venta contiene un producto repetido."
                    );
                }

                productosRevisados.Add(idProducto);
            }


            decimal total = 0;

            foreach (DetalleVenta detalle in venta.Detalles)
            {
                AccesoDatos datosProducto = new AccesoDatos();

                try
                {
                    datosProducto.setearConsulta("SELECT Precio, Stock FROM PRODUCTO WHERE IdProducto = @IdProducto AND Estado = 1");

                    datosProducto.setearParametro("@IdProducto", detalle.Producto.IdProducto);

                    datosProducto.ejecutarLectura();

                    if (!datosProducto.Lector.Read())
                    {
                        throw new ArgumentException(
                            "El producto seleccionado no existe o está inactivo."
                        );
                    }

                    decimal precioActual = (decimal)datosProducto.Lector["Precio"];
                    int stockDisponible = (int)datosProducto.Lector["Stock"];

                    if (detalle.Cantidad > stockDisponible)
                    {
                        throw new ArgumentException(
                            "No hay stock suficiente para el producto."
                        );
                    }

                    detalle.PrecioUnitario = precioActual;
                    total += precioActual * detalle.Cantidad;
                }
                finally
                {
                    datosProducto.cerrarConexion();
                }
            }

            venta.VentaTotal = total;

            datos.setearConsulta("INSERT INTO VENTA(IdCliente, VentaTotal, IdFormaPago, IdFormaEntrega, IdDireccion, IdEstadoVenta, Observaciones) VALUES (@IdCliente, @VentaTotal, @IdFormaPago, @IdFormaEntrega, @IdDireccion, @IdEstadoVenta, @Observaciones);SELECT CAST(SCOPE_IDENTITY() AS INT)");
            datos.setearParametro("@IdCliente", venta.Cliente.IdCliente);
            datos.setearParametro("@VentaTotal", venta.VentaTotal);
            datos.setearParametro("@IdFormaPago", venta.FormaPago.IdFormaPago);
            datos.setearParametro("@IdFormaEntrega", venta.FormaEntrega.IdFormaEntrega);

            if (venta.Direccion != null)
            {
                datos.setearParametro("@IdDireccion", venta.Direccion.IdDireccion);
            }
            else
            {
                datos.setearParametro("@IdDireccion", DBNull.Value);
            }

            datos.setearParametro("@IdEstadoVenta", venta.EstadoVenta.IdEstadoVenta);

            datos.setearParametro("@Observaciones", venta.Observaciones);

            int idGenerado = datos.ejecutarEscalar();

            venta.IdVenta = idGenerado;


            foreach (DetalleVenta detalle in venta.Detalles)
            {
                AccesoDatos datosDetalle = new AccesoDatos();

                try
                {
                    datosDetalle.setearConsulta("INSERT INTO DETALLEVENTA(IdVenta, IdProducto, Cantidad, PrecioUnitario) VALUES (@IdVenta, @IdProducto, @Cantidad, @PrecioUnitario)");

                    datosDetalle.setearParametro("@IdVenta", venta.IdVenta);

                    datosDetalle.setearParametro("@IdProducto", detalle.Producto.IdProducto);

                    datosDetalle.setearParametro("@Cantidad", detalle.Cantidad);

                    datosDetalle.setearParametro("@PrecioUnitario", detalle.PrecioUnitario);

                    datosDetalle.ejecutarAccion();

                }
                finally
                {
                    datosDetalle.cerrarConexion();
                }
            }

            foreach (DetalleVenta detalle in venta.Detalles)
            {
                AccesoDatos datosStock = new AccesoDatos();

                try
                {
                    datosStock.setearConsulta("UPDATE PRODUCTO SET Stock = Stock - @Cantidad WHERE IdProducto = @IdProducto AND Stock >= @Cantidad AND Estado = 1; SELECT @@ROWCOUNT;");

                    datosStock.setearParametro("@Cantidad", detalle.Cantidad);

                    datosStock.setearParametro("@IdProducto", detalle.Producto.IdProducto);

                    int filasActualizadas = datosStock.ejecutarEscalar();

                    if (filasActualizadas == 0)
                    {
                        throw new InvalidOperationException(
                            "No se pudo descontar el stock del producto."
                        );
                    }
                }
                finally
                {
                    datosStock.cerrarConexion();
                }
            }

        }


        public void cambiarEstado(int idVenta, int idEstadoVenta)
        {
            AccesoDatos datos = new AccesoDatos();

            Venta ventaActual = obtenerVenta(idVenta);

            if (ventaActual == null)
            {
                throw new ArgumentException(
                    "La venta seleccionada no existe."
                );
            }

            EstadoVentaNegocio negocioEstados = new EstadoVentaNegocio();

            List<EstadoVenta> estados = negocioEstados.listar();

            EstadoVenta estadoNuevo = null;

            foreach (EstadoVenta estado in estados)
            {
                if (estado.IdEstadoVenta == idEstadoVenta)
                {
                    estadoNuevo = estado;
                    break;
                }
            }

            if (estadoNuevo == null)
            {
                throw new ArgumentException(
                    "El estado seleccionado no existe."
                );
            }

            if (!transicionValida(ventaActual.EstadoVenta.Nombre, estadoNuevo.Nombre))
            {
                throw new InvalidOperationException(
                    "No se permite realizar ese cambio de estado."
                );
            }

            try
            {
                datos.setearConsulta("UPDATE VENTA SET IdEstadoVenta = @IdEstadoVenta WHERE IdVenta = @IdVenta");

                datos.setearParametro("@IdEstadoVenta", idEstadoVenta);
                datos.setearParametro("@IdVenta", idVenta);

                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void actualizarObservaciones(int idVenta, string observaciones)
        {
            AccesoDatos datos = new AccesoDatos();

            if (idVenta <= 0)
            {
                throw new ArgumentException(
                    "El identificador de la venta no es válido."
                );
            }

            if (observaciones != null && observaciones.Length > 500)
            {
                throw new ArgumentException(
                    "Las observaciones no pueden superar los 500 caracteres."
                );
            }

            try
            {
                datos.setearConsulta("UPDATE VENTA SET Observaciones = @Observaciones WHERE IdVenta = @IdVenta");

                datos.setearParametro("@Observaciones", observaciones);
                datos.setearParametro("@IdVenta", idVenta);

                datos.ejecutarAccion();
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        private bool transicionValida(string estadoActual, string estadoSeleccionado)
        {
            estadoActual = estadoActual.Trim().ToLower();
            estadoSeleccionado = estadoSeleccionado.Trim().ToLower();

            switch (estadoActual)
            {
                case "pendiente":
                    return estadoSeleccionado == "pagado";

                case "pagado":
                    return estadoSeleccionado == "en preparación";

                case "en preparación":
                    return estadoSeleccionado == "enviado";

                case "enviado":
                    return estadoSeleccionado == "entregado";

                default:
                    return false;
            }
        }

        public List<EstadoVenta> listarEstadosDisponibles(Venta venta)
        {
            EstadoVentaNegocio negocioEstados = new EstadoVentaNegocio();

            List<EstadoVenta> estados = negocioEstados.listar();
            List<EstadoVenta> disponibles = new List<EstadoVenta>();

            foreach (EstadoVenta estado in estados)
            {
                if (estado.IdEstadoVenta == venta.EstadoVenta.IdEstadoVenta ||
                    transicionValida(venta.EstadoVenta.Nombre, estado.Nombre))
                {
                    disponibles.Add(estado);
                }
            }

            return disponibles;
        }

        public List<Venta> listarVentasPorCliente(int usuario)
        {
            List<Venta> ventas = new List<Venta>();


            if (usuario <= 0)
            {
                throw new ArgumentException("El identificador del cliente no es válido.");
            }

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT V.IdVenta, V.IdCliente, C.Nombre AS NombreCliente, C.Apellido AS ApellidoCliente, V.Fecha, V.VentaTotal, V.IdFormaPago, FP.Nombre AS NombreFormaPago, V.IdFormaEntrega, FE.Nombre AS NombreFormaEntrega, V.IdDireccion, V.IdEstadoVenta, EV.Nombre AS NombreEstado, V.Observaciones FROM VENTA V INNER JOIN CLIENTE C ON V.IdCliente = C.IdCliente INNER JOIN USUARIO U ON U.IdUsuario = C.IdCliente INNER JOIN FORMAPAGO FP ON V.IdFormaPago = FP.IdFormaPago INNER JOIN FORMAENTREGA FE ON V.IdFormaEntrega = FE.IdFormaEntrega INNER JOIN ESTADOVENTA EV  ON V.IdEstadoVenta = EV.IdEstadoVenta WHERE C.IdUsuario = @IdUsuario ORDER BY V.Fecha DESC, V.IdVenta DESC");
                datos.setearParametro("@IdUsuario", usuario);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Venta venta = new Venta();

                    venta.IdVenta = (int)datos.Lector["IdVenta"];
                    venta.Fecha = (DateTime)datos.Lector["Fecha"];
                    venta.VentaTotal = (decimal)datos.Lector["VentaTotal"];

                    venta.Cliente = new Cliente();

                    venta.Cliente.IdCliente = (int)datos.Lector["IdCliente"];
                    venta.Cliente.Nombre = (string)datos.Lector["NombreCliente"];
                    venta.Cliente.Apellido = (string)datos.Lector["ApellidoCliente"];

                    venta.EstadoVenta = new EstadoVenta();

                    venta.EstadoVenta.IdEstadoVenta = (int)datos.Lector["IdEstadoVenta"];

                    venta.EstadoVenta.Nombre = (string)datos.Lector["NombreEstado"];

                    venta.FormaPago = new FormaPago();
                    venta.FormaPago.IdFormaPago = (int)datos.Lector["IdFormaPago"];
                    venta.FormaPago.Nombre = (string)datos.Lector["NombreFormaPago"];
                    venta.FormaEntrega = new FormaEntrega();
                    venta.FormaEntrega.IdFormaEntrega = (int)datos.Lector["IdFormaEntrega"];
                    venta.FormaEntrega.Nombre = (string)datos.Lector["NombreFormaEntrega"];

                    if (datos.Lector["IdDireccion"] != DBNull.Value)
                    {
                        venta.Direccion = new Direccion();
                        venta.Direccion.IdDireccion = (int)datos.Lector["IdDireccion"];
                    }

                    if (datos.Lector["Observaciones"] != DBNull.Value)
                    {
                        venta.Observaciones = (string)datos.Lector["Observaciones"];
                    }

                    ventas.Add(venta);
                }

                return ventas;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void actualizarCodigoSeguimiento(int idVenta, string codigoSeguimiento)
        {
            if (idVenta <= 0)
            {
                throw new ArgumentException(
                    "El identificador de la venta no es válido.");
            }

            if (string.IsNullOrWhiteSpace(codigoSeguimiento))
            {
                throw new ArgumentException(
                    "El código de seguimiento es obligatorio.");
            }

            codigoSeguimiento = codigoSeguimiento.Trim();

            if (codigoSeguimiento.Length > 100)
            {
                throw new ArgumentException(
                    "El código de seguimiento no puede superar los 100 caracteres.");
            }

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE VENTA SET CodigoSeguimiento = @CodigoSeguimiento WHERE IdVenta = @IdVenta; SELECT @@ROWCOUNT");

                datos.setearParametro("@CodigoSeguimiento", codigoSeguimiento);
                datos.setearParametro("@IdVenta", idVenta);

                int filasActualizadas = datos.ejecutarEscalar();

                if (filasActualizadas == 0)
                {
                    throw new ArgumentException(
                        "No se encontró la venta seleccionada.");
                }
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }
}
