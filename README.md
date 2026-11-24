# E-commerce · TPC Equipo 2

Trabajo Práctico Cuatrimestral: una tienda online donde los clientes pueden ver productos, armar un carrito y realizar compras, y los administradores pueden gestionar el catálogo, las ventas y la configuración de la tienda.

---

## Funcionalidades

### Clientes
- Registro con mail y activación de la cuenta mediante un link enviado por correo.
- Inicio y cierre de sesión.
- Catálogo de productos con filtro por categoría y buscador.
- Carrito de compras, disponible también sin iniciar sesión (los productos se conservan al ingresar).
- Compra con elección de forma de pago (efectivo o débito) y forma de entrega (retiro en el local, envío o punto de encuentro).
- Mail de confirmación al realizar un pedido.
- Historial de pedidos con el detalle de cada uno.
- Sección **Mi cuenta** para administrar direcciones, tarjetas y contraseña.

### Administradores
- Alta, modificación y baja de productos, con imágenes y stock.
- Gestión de categorías.
- Configuración de formas de pago y de entrega.
- Listado de ventas y actualización de su estado (pendiente, pagado, en preparación, etc.).
- Alta y baja de otros administradores.

---

## Tecnologías

- **C#** con **ASP.NET Web Forms** (.NET Framework 4.8)
- **SQL Server** como base de datos
- **Bootstrap** y **Bootstrap Icons** para el diseño
- **Mailtrap** para probar el envío de mails sin que lleguen a casillas reales

El proyecto está organizado en tres capas:

| Carpeta | Contenido |
|---|---|
| `dominio` | Clases que representan los elementos de la tienda: Producto, Cliente, Venta, Carrito, etc. |
| `negocio` | Lógica de la aplicación y consultas a la base de datos |
| `TPC_Equipo2` | Páginas web que ve el usuario |

---

## Cómo ejecutar el proyecto

### Requisitos
- **Visual Studio** con la carga de trabajo de desarrollo web ASP.NET
- **SQL Server Express** y **SQL Server Management Studio**
- Una cuenta gratuita en **[Mailtrap](https://mailtrap.io)**, para probar los mails

### 1. Crear la base de datos
En SQL Server Management Studio, ejecutar los siguientes archivos en este orden:
1. `EcommerceDB.sql`: crea la base de datos y las tablas.
2. `Datos-prueba-DB.sql`: carga productos, usuarios y otros datos de prueba.

> El proyecto se conecta al servidor `.\SQLEXPRESS`. Si el nombre de tu servidor es otro, modificalo en `negocio/AccesoDatos.cs`.

### 2. Configurar Mailtrap
Los mails de activación de cuenta y de confirmación de compra se envían a través de Mailtrap:
1. En Mailtrap, ingresar a **Sandboxes**, abrir el sandbox y, en la pestaña **Integration**, seleccionar **SMTP**.
2. Copiar el **Username** y el **Password**. El username no es la dirección de mail, sino un código generado por Mailtrap.
3. Completarlos en `negocio/Credenciales.cs`. Si el archivo no existe, crearlo a partir de `negocio/Credenciales.ejemplo.txt`.

> `Credenciales.cs` no se sube al repositorio: cada integrante usa sus propias credenciales.

Los mails no llegan a casillas reales, sino a la bandeja del sandbox de Mailtrap. Por eso es posible registrarse con cualquier dirección de prueba.

### 3. Ejecutar
Abrir `TPC_Equipo2.slnx` en Visual Studio y presionar **F5**. El sitio se abre automáticamente en el navegador.

---

## Usuarios de prueba

Incluidos en `Datos-prueba-DB.sql`:

| Rol | Usuario | Contraseña |
|---|---|---|
| Administrador | `luucasarieel@hotmail.com` | `asd123` |
| Cliente | `florenciagutierrez@gmail.com` | `abc123` |

También se puede registrar un usuario nuevo para probar el circuito completo, incluida la activación por mail.

---

## Mejoras pendientes

- Las contraseñas se guardan sin encriptar en la base de datos. En un entorno real deberían almacenarse encriptadas.
- Cuando la cuenta todavía no fue activada, el inicio de sesión muestra "usuario o contraseña incorrecta" en lugar de indicar que falta verificar el mail.

---

## Integrantes

- **Maximiliano Bianchi** – [@maxibian](https://github.com/maxibian)
- **Federico Gauna** – [@Fgauna-0](https://github.com/Fgauna-0)
- **Lucas Jakovcevic** – [@uJakoLucas](https://github.com/JakoLucas)
