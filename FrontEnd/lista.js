document.addEventListener("DOMContentLoaded", async () => {
    const tableBody = document.getElementById("productTableBody");
  
    if (!tableBody) {
      console.error("Elemento 'productTableBody' no encontrado en el DOM.");
      return;
    }
  
    // Función para obtener productos y mostrarlos en la tabla
    async function fetchProducts() {
      try {
        const response = await fetch("https://localhost:7124/api/producto/listaProductos");
  
        if (!response.ok) {
          throw new Error(`Error en la petición: ${response.status} - ${response.statusText}`);
        }
  
        const products = await response.json();
  
        // Limpiar la tabla antes de agregar nuevos productos
        tableBody.innerHTML = "";
  
        products.forEach(product => {
          const row = document.createElement("tr");
          row.innerHTML = `
            <td>${product.nombre}</td>
            <td>$${product.precio ? product.precio.toFixed(2) : "0.00"}</td>
            <td>${product.fechaCreacion ?product.fechaCreacion : "sin fecha de creacion"}</td>
          `;
          tableBody.appendChild(row);
        });
  
      } catch (error) {
        console.error("Error al obtener los productos:", error);
        alert("Error al obtener los productos. Verifica que el servidor esté en ejecución.");
      }
    }
  
    // Llamar la función al cargar la página
    fetchProducts();
  });
  