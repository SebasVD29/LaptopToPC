// Función para renderizar los productos en el carrito
function renderCart() {
  const cartItemsContainer = document.getElementById("cartItems");
  const cartSummary = document.getElementById("cartSummary");
  const totalAmountElement = document.getElementById("totalAmount");

  // Leer los productos del carrito desde el localStorage
  let cart = JSON.parse(localStorage.getItem("cart")) || [];

  cartItemsContainer.innerHTML = "";  // Limpiar los productos
  cartSummary.innerHTML = "";         // Limpiar el resumen

  if (cart.length === 0) {
    // Si el carrito está vacío, mostrar un mensaje
    cartItemsContainer.innerHTML = `<p class="empty-cart-message">Tu carrito está vacío. ¡Explora nuestro catálogo y añade productos!</p>`;
    totalAmountElement.textContent = "₡ 0.00";  // Establecer el total a 0
    return;
  }
  // Limpiar el resumen
  let total = 0;  // Para calcular el total

  cart.forEach(item => {
    const cartItem = document.createElement("div");
    cartItem.classList.add("item");

    const formattedPrice = item.price.toLocaleString('es-CR');

    cartItem.innerHTML = `
  <img src="${item.imageUrl}" class="product-image" alt="${item.name}">
  <div class="details">
    <h2>${item.name}</h2>
    <p class="category">Categoría: ${item.category}</p>
    <p class="price">Precio: ₡ <span>${formattedPrice}</span></p>
    <label for="quantity${item.productId}">Cantidad:</label>
    <input type="number" id="quantity${item.productId}" class="quantity-control" value="${item.quantity}" min="1">
    <button class="delete" data-id="${item.productId}">🗑️</button>
  </div>
`;


    // Escuchar el cambio en la cantidad
    const quantityInput = cartItem.querySelector(`#quantity${item.productId}`);
    quantityInput.addEventListener("input", (e) => updateQuantity(item.productId, e.target.value));

    // Calcular el total por producto
    total += item.price.toFixed(2) * item.quantity;

    // Agregar el producto al resumen
    const cartSummaryItem = document.createElement("li");

    // Calcular el total del producto con la cantidad y redondear a 2 decimales
    const itemTotal = (item.price * item.quantity).toFixed(2);  // Hacer la multiplicación primero y luego aplicar toFixed

    cartSummaryItem.textContent = `${item.name} x${item.quantity} - ₡ ${itemTotal}`;  // Mostrar el total con 2 decimales

    cartSummary.appendChild(cartSummaryItem);


    // Botón de eliminar
    const deleteButton = cartItem.querySelector(".delete");
    deleteButton.addEventListener("click", () => removeFromCart(item.productId));

    cartItemsContainer.appendChild(cartItem);
  });

  // Mostrar el total
  totalAmountElement.textContent = "₡ " + total.toFixed(2);
}

// Función para actualizar la cantidad del producto en el carrito
function updateQuantity(productId, newQuantity) {
  if (newQuantity < 1) {
    return; // No permitir cantidades menores a 1
  }

  // Leer el carrito desde el localStorage
  let cart = JSON.parse(localStorage.getItem("cart")) || [];

  // Encontrar el producto en el carrito
  const product = cart.find(item => item.productId === productId);

  if (product) {
    // Actualizar la cantidad
    product.quantity = parseInt(newQuantity);

    // Guardar el carrito actualizado en el localStorage
    localStorage.setItem("cart", JSON.stringify(cart));

    // Volver a renderizar el carrito
    renderCart();

    // Actualizar el ícono del carrito
    updateCartButton();
  }
}

// Función para actualizar el ícono del carrito
function updateCartButton() {
  const cartButton = document.getElementById("cartBtn");

  // Verificar si el botón existe
  if (!cartButton) {
    console.warn("El botón del carrito no existe en el DOM.");
    return;
  }

  const badge = cartButton.querySelector(".badge");

  // Leer el carrito desde el localStorage
  const cart = JSON.parse(localStorage.getItem("cart")) || [];

  // Contar los artículos en el carrito
  const totalItems = cart.reduce((sum, item) => sum + item.quantity, 0);

  if (totalItems > 0) {
    badge.textContent = totalItems;
    badge.classList.remove("hidden");
  } else {
    badge.classList.add("hidden");
  }
}

// Función para eliminar productos del carrito
function removeFromCart(productId) {
  // Leer el carrito desde el localStorage
  let cart = JSON.parse(localStorage.getItem("cart")) || [];


  showConfirmPopup("¿Estás seguro de que quieres eliminar este producto del carrito?", () => {
    // Eliminar el producto por su ID
    cart = cart.filter(item => item.productId !== productId);

    // Guardar el carrito actualizado en el localStorage
    localStorage.setItem("cart", JSON.stringify(cart));
    renderCart();
    updateCartButton();

    setTimeout(() => {
      if (cart.length === 0) {
        showPopup("El carrito está vacío.");
      }
      else {
        showPopup("El producto se eliminó del carrito .");
      }

    }, 500);

  });
}









// Mostrar ventana emergente genérica
function showPopup(message) {
  const popup = document.getElementById("popup");
  const popupMessage = document.getElementById("popup-message");

  popupMessage.textContent = message;
  popup.style.display = "flex";

  const closePopupButton = document.getElementById("close-popup");
  closePopupButton.onclick = () => {
    popup.style.display = "none";
  };
}

// Mostrar ventana de confirmación
function showConfirmPopup(message, onConfirm) {
  const confirmPopup = document.getElementById("confirm-popup");
  const confirmMessage = document.getElementById("confirm-message");
  const confirmYesButton = document.getElementById("confirm-yes");
  const confirmNoButton = document.getElementById("confirm-no");

  confirmMessage.textContent = message;
  confirmPopup.style.display = "flex";

  // Acción para el botón "Sí"
  confirmYesButton.onclick = () => {
    confirmPopup.style.display = "none";
    onConfirm(); // Ejecutar la acción confirmada
  };

  // Acción para el botón "No"
  confirmNoButton.onclick = () => {
    confirmPopup.style.display = "none";
  };
}

// Función para vaciar el carrito
document.getElementById("empty-cart").addEventListener("click", () => {
  const cart = JSON.parse(localStorage.getItem("cart")) || [];

  if (cart.length === 0) {
    showPopup("El carrito ya está vacío.");
  } else {
    showConfirmPopup("¿Estás seguro de que quieres vaciar el carrito?", () => {
      localStorage.removeItem("cart");
      renderCart();
      updateCartButton();

      setTimeout(() => {
        showPopup("El carrito ha sido vaciado.");
      }, 500);

    });
  }
});

// Función para realizar el pago
document.getElementById("checkout").addEventListener("click", () => {
  const cart = JSON.parse(localStorage.getItem("cart")) || [];

  if (cart.length === 0) {
    showPopup("El carrito está vacío. No puedes proceder al pago.");
  } else {
    showConfirmPopup("¿Confirmas que deseas proceder con el pago?", () => {
      localStorage.removeItem("cart");
      renderCart();
      updateCartButton();

      // Redirigir a la página de pago después de un tiempo
      setTimeout(() => {
        window.location.href = "realizarp.html";
      }, 500);
    });
  }
});

// Botón de "Atrás"
document.getElementById("backButton").addEventListener("click", () => {
  window.location.href = "index.html"; // Redirige a la página principal
});

document.addEventListener("DOMContentLoaded", () => {
  updateCartButton(); // Llamar a la función cuando el DOM esté cargado
});

// Llamar a renderCart cuando se carga la página
document.addEventListener("DOMContentLoaded", renderCart);
