// Datos de los productos (puedes agregar más productos aquí)
const products = [
  { 
      id: 1, 
      name: "Camiseta Roja Airsoft", 
      category: "Accesorios", 
      price: 11995,  // Múltiplo de 5
      imageUrl: "https://i.pinimg.com/736x/24/16/8c/24168cedacfcb26c189d62d90f79247e.jpg",
      description: "Camiseta de manga larga roja de algodón, perfecta para tus entrenamientos o juegos de airsoft."
  },
  { 
      id: 2, 
      name: "Gorra Deportiva Airsoft", 
      category: "Accesorios", 
      price: 4995,  // Múltiplo de 5
      imageUrl: "https://i.pinimg.com/736x/8b/cc/50/8bcc50be1e7d666fc86a09c27432d100.jpg",
      description: "Gorra deportiva con diseño moderno y ajuste cómodo, ideal para jugar al aire libre."
  },
  { 
      id: 3, 
      name: "Zapatos Deportivos Airsoft", 
      category: "Accesorios", 
      price: 24995,  // Múltiplo de 5
      imageUrl: "https://via.placeholder.com/250",
      description: "Zapatos deportivos cómodos, ideales para correr o entrenar en el gimnasio."
  },
  { 
      id: 4, 
      name: "Camiseta Azul Airsoft", 
      category: "Accesorios", 
      price: 22995,  // Múltiplo de 5
      imageUrl: "https://via.placeholder.com/250",
      description: "Camiseta azul de alta calidad, diseñada para resistir el uso constante."
  },
  { 
      id: 5, 
      name: "Chaqueta Táctica Airsoft", 
      category: "Equipo Táctico", 
      price: 9995,  // Múltiplo de 5
      imageUrl: "https://via.placeholder.com/250",
      description: "Chaqueta táctica robusta y resistente, diseñada para actividades extremas."
  },
  { 
      id: 6, 
      name: "Mochila Militar Airsoft", 
      category: "Equipo Táctico", 
      price: 5995,  // Múltiplo de 5
      imageUrl: "https://via.placeholder.com/250",
      description: "Mochila de alta capacidad y resistencia, perfecta para largas caminatas o misiones."
  },
  { 
      id: 7, 
      name: "Pistola de Aire Comprimido Airsoft", 
      category: "Armas", 
      price: 12995,  // Múltiplo de 5
      imageUrl: "https://via.placeholder.com/250",
      description: "Pistola de aire comprimido de alto rendimiento, ideal para tiro deportivo."
  },
  { 
      id: 8, 
      name: "Munición 9mm Airsoft", 
      category: "Munición", 
      price: 1995,  // Múltiplo de 5
      imageUrl: "https://via.placeholder.com/250",
      description: "Paquete de munición 9mm, compatible con pistolas de diversas marcas."
  },
  { 
      id: 9, 
      name: "Gorra Camuflada Airsoft", 
      category: "Accesorios", 
      price: 15995,  // Múltiplo de 5
      imageUrl: "https://via.placeholder.com/250",
      description: "Gorra con diseño camuflado, ideal para actividades al aire libre y caza."
  },
  { 
      id: 10, 
      name: "Binoculares de Visión Nocturna Airsoft", 
      category: "Equipo Táctico", 
      price: 18995,  // Múltiplo de 5
      imageUrl: "https://via.placeholder.com/250",
      description: "Binoculares de visión nocturna de alta calidad, perfectos para observación en condiciones de poca luz."
  },
  { 
      id: 11, 
      name: "Camiseta de Camuflaje Airsoft", 
      category: "Accesorios", 
      price: 27995,  // Múltiplo de 5
      imageUrl: "https://via.placeholder.com/250",
      description: "Camiseta con patrón de camuflaje, ideal para actividades militares o al aire libre."
  },
  { 
      id: 12, 
      name: "Guantes de Táctica Airsoft", 
      category: "Equipo Táctico", 
      price: 29995,  // Múltiplo de 5
      imageUrl: "https://via.placeholder.com/250",
      description: "Guantes tácticos diseñados para ofrecer protección y comodidad durante actividades extremas."
  },
  { 
      id: 13, 
      name: "Arco de Caza Airsoft", 
      category: "Armas", 
      price: 19995,  // Múltiplo de 5
      imageUrl: "https://via.placeholder.com/250",
      description: "Arco de caza de alto rendimiento, ideal para cazadores experimentados."
  },
  { 
      id: 14, 
      name: "Linterna de Alta Potencia Airsoft", 
      category: "Equipo Táctico", 
      price: 3995,  // Múltiplo de 5
      imageUrl: "https://via.placeholder.com/250",
      description: "Linterna táctica con alta potencia, ideal para iluminar grandes áreas en condiciones de poca luz."
  },
  { 
      id: 15, 
      name: "Carabina de Aire Comprimido Airsoft", 
      category: "Armas", 
      price: 15995,  // Múltiplo de 5
      imageUrl: "https://via.placeholder.com/250",
      description: "Carabina de aire comprimido de alto rendimiento, perfecta para tiro a larga distancia."
  }
  //Añadir más productos si lo deseas
];



let cart = [];

// Función para generar las cards de productos
function renderProducts(filteredProducts) {
  console.log("renderProducts ejecutado");
  const productList = document.getElementById("productList");
console.log('productList:', productList);

  productList.innerHTML = ""; // Limpiar la lista de productos

  filteredProducts.forEach(product => {
    const productCard = document.createElement("div");
    productCard.classList.add("product-card");

    const formattedPrice = product.price.toLocaleString('es-CR');

    // Agregamos el evento al contenedor de la tarjeta
    productCard.addEventListener("click", () => openProductModal(product.id));

    productCard.innerHTML = `
      <img src="${product.imageUrl}" alt="${product.name}">
      <div class="info">
        <h4>${product.name}</h4>
        <div class="category">Categoría: ${product.category}</div>
        <div class="price">Precio: ₡${formattedPrice}</div>
        <button class="add-to-cart-btn">
          <i class="fas fa-shopping-cart"></i> Agregar al carrito
        </button>
      </div>
    `;

    // Prevenir la propagación del clic en el botón de "Agregar al carrito"
    const addToCartBtn = productCard.querySelector(".add-to-cart-btn");
    addToCartBtn.addEventListener("click", (event) => {
      event.stopPropagation();
      addToCart(product.id); // Llamar a la función de agregar al carrito
    });

    productList.appendChild(productCard);
  });
}

function openProductModal(productId) {

  // Obtener la información del producto con el ID
  const product = products.find(p => p.id === productId);
  if (!product) return;

  // Llenar el contenido de la modal con la información del producto
  document.getElementById('modalName').textContent = product.name;
  document.getElementById('modalDescription').textContent = product.description;
  document.getElementById('modalCategory').textContent = product.category;
  document.getElementById('modalPrice').textContent = product.price.toFixed(2);
  document.getElementById('modalImage').src = product.imageUrl;

  // Restablecer la cantidad a 1 al abrir el modal
  document.getElementById("productQuantity").value = 1;

  //Agregar funcionalidad al botón "Agregar al carrito"
  document.getElementById("modalAddToCart").onclick = () => addToCart(product.id);

  // Mostrar la modal
  const modal = document.getElementById("productModal");
  modal.style.display = "flex";  // Cambiar display a flex en lugar de block para que se ajuste a tu diseño

  // Agregar un evento de clic para cerrar la modal
  const closeButton = document.querySelector(".close-modal");
  closeButton.onclick = function() {
    modal.style.display = "none"; // Cerrar la modal
  };

  // También cerrar la modal si se hace clic fuera de ella
  window.onclick = function(event) {
    if (event.target === modal) {
      modal.style.display = "none";
    }
  };
}

function closeProductModal() {
  const modal = document.getElementById("productModal");
  modal.style.display = "none"; // Cerrar la modal
}


function updateQuantity(change) {
  const quantityInput = document.getElementById("productQuantity");
  let currentQuantity = parseInt(quantityInput.value, 10) || 1;
  currentQuantity = Math.max(1, currentQuantity + change);
  quantityInput.value = currentQuantity;
}

// Función para agregar productos al carrito y almacenarlos en el localStorage
function addToCart(productId) {
  const product = products.find(p => p.id === productId);
  const quantity = parseInt(document.getElementById("productQuantity").value, 10);
  
  if (!product) return;

  // Leer el carrito actual desde el localStorage
  let cart = JSON.parse(localStorage.getItem("cart")) || [];

  // Verificar si el producto ya está en el carrito
  const productInCart = cart.find(item => item.productId === productId);

  if (productInCart) {
    productInCart.quantity += quantity;  // Aumentar la cantidad
  } else {
    cart.push({
      productId: productId,
      name: product.name,
      price: product.price,
      category: product.category,
      imageUrl: product.imageUrl,
      quantity: quantity
    });
  }

  // Guardar el carrito actualizado en el localStorage
  localStorage.setItem("cart", JSON.stringify(cart));
  console.log();
  

  updateCartButton(product);  // Actualiza el ícono del carrito
  closeProductModal();
}




// Función para actualizar el ícono del carrito
function updateCartButton() {
  const cartButton = document.getElementById("cartBtn");
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

// Eventos para cerrar el modal
document.querySelector(".close-modal").addEventListener("click", closeProductModal);


// Función para filtrar productos por categoría
function filterProducts() {
  const checkedCategories = Array.from(document.querySelectorAll('.category-filter:checked')).map(input => input.value);
  const filteredProducts = products.filter(product =>
    checkedCategories.length === 0 || checkedCategories.includes(product.category)
  );
  renderProducts(filteredProducts);
}

// Función para buscar productos por nombre
function searchProducts() {
  const searchQuery = document.getElementById("searchInput").value.toLowerCase();
  const filteredProducts = products.filter(product =>
    product.name.toLowerCase().includes(searchQuery)
  );
  renderProducts(filteredProducts);
}

// Agregar eventos para los filtros de categorías
const categoryFilters = document.querySelectorAll('.category-filter');
categoryFilters.forEach(filter => {
  filter.addEventListener('change', filterProducts);
});

// Agregar evento para el buscador
const searchInput = document.getElementById("searchInput");
searchInput.addEventListener('input', searchProducts);

// Redirigir al perfil al hacer clic en el botón de perfil
document.getElementById("profileBtn").addEventListener("click", () => {
  window.location.href = "perfil.html"; 
});

// Redirigir al carrito al hacer clic en el botón de carrito
document.getElementById("cartBtn").addEventListener("click", () => {
  window.location.href = "cart.html"; 
});

// Al final de tu archivo JavaScript en index.js
document.addEventListener('DOMContentLoaded', () => {
  updateCartButton();  // Actualiza el ícono del carrito al cargar la página
});

// Inicializar los productos al cargar la página
renderProducts(products);

