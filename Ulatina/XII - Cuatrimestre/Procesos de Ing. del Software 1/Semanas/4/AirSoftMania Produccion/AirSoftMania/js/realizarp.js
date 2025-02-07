document.addEventListener("DOMContentLoaded", () => {
  // Botón de "Atrás"
  const goBackButton = document.getElementById("goBack");
  if (goBackButton) {
    goBackButton.addEventListener("click", () => {
      showConfirmPopup("¿Estás seguro de que quieres cancelar tu compra?", () => {

        window.location.href = "index.html"; // Redirige a la página principal
      
      });
    });
  }

  // Botón de "Realizar Pago"
  const paySuccessButton = document.getElementById("paySuccess");
  if (paySuccessButton) {
    paySuccessButton.addEventListener("click", (event) => {
      event.preventDefault(); // Previene el comportamiento predeterminado del formulario
      
      showLoadingModal();

      setTimeout(()=>{
        window.location.href = "pagoRealizado.html";
      }, 4000)

    });
  }
});

// Función para mostrar el modal de carga
function showLoadingModal() {
  const loadingModal = document.getElementById("loadingModal");
  if (loadingModal) {
    loadingModal.style.display = "flex"; // Mostrar el modal
  }
  
}

// Función para ocultar el modal después de un retraso (4 segundos en este caso)
function hideLoadingModal() {
  const loadingModal = document.getElementById("loadingModal");
  if (loadingModal) {
    loadingModal.style.display = "none"; // Ocultar el modal
  }
}

const inputVencimiento = document.getElementById('vencimiento');
const today = new Date();
const year = today.getFullYear();
const month = String(today.getMonth() + 1).padStart(2, '0'); // Asegura formato 01, 02, etc.
inputVencimiento.value = `${year}-${month}`;


// Obtener los botones de pago
const creditCardButton = document.getElementById("creditCardButton");
const paypalButton = document.getElementById("paypalButton");

// Función para alternar el estado activo
function toggleActive(button) {
  // Solo hacer el cambio si el botón no está activo
  if (!button.classList.contains("active")) {
    // Desactivar los otros botones
    creditCardButton.classList.remove("active");
    paypalButton.classList.remove("active");

    // Activar el botón que fue clickeado
    button.classList.add("active");
  }
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

// Añadir los event listeners a los botones
creditCardButton.addEventListener("click", function () {
  toggleActive(creditCardButton);
});

paypalButton.addEventListener("click", function () {
  toggleActive(paypalButton);
});

