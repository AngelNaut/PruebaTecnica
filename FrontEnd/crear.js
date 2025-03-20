document.addEventListener("DOMContentLoaded", () => {
    const form = document.getElementById("productForm");
  
    if (!form) {
      console.error("Elemento 'productForm' no encontrado en el DOM.");
      return;
    }
  
    // Evento para enviar el formulario
    form.addEventListener("submit", async (e) => {
      e.preventDefault(); // Evita el envío del formulario de forma tradicional
  
      // Obtener los valores del formulario
      const nombre = document.getElementById("nombre")?.value.trim();
      const precio = parseFloat(document.getElementById("precio")?.value) || 0;
      
  
      if (!nombre || precio <= 0 ) {
        alert("Todos los campos son obligatorios y el precio debe ser mayor a 0.");
        return;
      }
  
      // Construir el objeto producto con los nombres exactos del modelo
      const product = {
        Nombre: nombre,
        Precio: precio,
       
      };
  
      try {
        const response = await fetch("https://localhost:7124/api/Producto/crear", {
          method: "POST",
          headers: {
            "Content-Type": "application/json"
          },
          body: JSON.stringify(product)
        });
  
        if (!response.ok) {
          throw new Error(`Error en la petición: ${response.status} - ${response.statusText}`);
        }
  
        const data = await response.json();
        console.log("Producto creado:", data);
        alert("Producto creado exitosamente");
  
        // Reiniciar el formulario
        form.reset();
  
        // Volver a cargar la lista de productos después de agregar uno nuevo
        setTimeout(() => {
          location.reload(); // Recarga la página para actualizar la tabla
        }, 500);
  
      } catch (error) {
        console.error("Error al crear el producto:", error);
        alert("Error al crear el producto. Verifica que el servidor esté en ejecución.");
      }
    });
  });
  