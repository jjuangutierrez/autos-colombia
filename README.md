# Sistema de Información - Parqueadero "Autos Colombia"
### Electiva I: Diseño de Sistemas de Información
**Iteración 1: Gestión de Entrada y Salida de Vehículos**

---

## Descripción del Proyecto
Este proyecto corresponde a la **Iteración 1** del sistema de información para el parqueadero **"Autos Colombia"**. En esta fase se implementa el núcleo transaccional básico del estacionamiento, cubriendo el flujo operativo completo:
- Registro de entrada de automotores y asignación automática de celda.
- Validación de aforo y prevención de placas duplicadas en el parqueadero.
- Visualización en tiempo real de celdas libres vs. celdas ocupadas.
- Registro de salida de vehículos y liberación inmediata de espacios.

---

## Arquitectura de la Solución (.NET en 4 Capas)
La solución sigue estrictamente el diseño de paquetes y arquitectura por capas modelada en StarUML:

1. **`AutosColombia.Models`**: Contiene las entidades del dominio (`Vehiculo`, `Celda`, `Usuario`, `RegistroAcceso`).
2. **`AutosColombia.Data`**: Capa de persistencia con el repositorio de datos y control de celdas.
3. **`AutosColombia.BusinessLogic`**: Lógica transaccional (`AccesoService`) con las reglas de negocio de entrada y salida.
4. **`AutosColombia.UI`**: Aplicación web construida con ASP.NET Core y Bootstrap 5, replicando fielmente los mockups diseñados en Figma.

---

## Requisitos e Instrucciones de Ejecución

### Requisitos previos:
- SDK de **.NET 8.0** o superior instalado en el equipo.
- Navegador web moderno (Google Chrome, Microsoft Edge, Firefox).

---

### Opción A: Ejecución desde la Terminal / Consola (Recomendada)
1. Abrir una terminal (PowerShell o CMD) en la carpeta raíz del proyecto.
2. Navegar al proyecto de interfaz de usuario:
   ```bash
   cd AutosColombia.UI
