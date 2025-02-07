// Simulamos una base de datos de correos electrónicos registrados
const registeredEmails = ["usuario1@example.com", "usuario2@example.com"];

// Función para validar la contraseña
function validatePassword(password) {
  const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*]).{8,}$/;
  return regex.test(password);
}

// Función para mostrar mensajes de error
function showError(elementId, message) {
  const errorElement = document.getElementById(elementId);
  errorElement.textContent = message;
  errorElement.style.display = "block";
}

// Función para manejar el registro
function handleRegistration(event) {
  event.preventDefault();  // Evita que el formulario se envíe de manera predeterminada

  // Obtenemos los valores del formulario
  const fullName = document.getElementById("full-name").value.trim();
  const email = document.getElementById("email").value.trim();
  const password = document.getElementById("password").value;
  const confirmPassword = document.getElementById("confirm-password").value;

  // Limpiamos los mensajes de error previos
  document.getElementById("error-message").style.display = "none"; // Aseguramos que el mensaje de error esté oculto

  // Validación del correo electrónico (simulando que debe ser único)
  if (registeredEmails.includes(email)) {
    showError("error-message", "Este correo electrónico ya está registrado.");
    return; // Detenemos el flujo si el correo ya está registrado
  }

  // Validación de la contraseña
  if (!validatePassword(password)) {
    showError("error-message", "La contraseña debe tener al menos 8 caracteres, una letra mayúscula, una minúscula, un número y un carácter especial.");
    return; // Detenemos el flujo si la contraseña no es válida
  }

  // Validación de la confirmación de contraseña
  if (password !== confirmPassword) {
    showError("error-message", "Las contraseñas no coinciden.");
    return; // Detenemos el flujo si las contraseñas no coinciden
  }

  // Simulamos el registro del usuario
  registeredEmails.push(email);

  // Mostrar el popup de éxito
  showSuccessPopup();

  // Resetear el formulario
  document.getElementById("register-form").reset();
}

// Función para mostrar la ventana emergente de confirmación
function showConfirmationPopup() {
  const confirmationPopup = document.getElementById("confirmation-popup");
  confirmationPopup.style.display = "flex";
}

// Función para redirigir a la página del catálogo (index.html)
function cancelRegistration() {
  window.location.href = "index.html"; // Redirige a la página del catálogo
}

// Función para cerrar la ventana emergente
function closeConfirmationPopup() {
  const confirmationPopup = document.getElementById("confirmation-popup");
  confirmationPopup.style.display = "none";
}

// Función para mostrar la ventana emergente de éxito (registro exitoso)
function showSuccessPopup() {
  const successPopup = document.getElementById("success-popup");
  successPopup.style.display = "flex";
}

// Función para cerrar la ventana emergente de éxito y redirigir al login
function closeSuccessPopup() {
  const successPopup = document.getElementById("success-popup");
  successPopup.style.display = "none";
  // Redirige a la pantalla de login
//   window.location.href = "login.html";
  window.location.href = "index.html";
}

// Agregamos el evento al formulario
document.getElementById("register-form").addEventListener("submit", handleRegistration);

// Agregar el evento al botón de cancelar
document.getElementById("cancel-btn").addEventListener("click", showConfirmationPopup);

// Eventos para el popup de confirmación
document.getElementById("confirm-cancel").addEventListener("click", cancelRegistration);
document.getElementById("cancel-cancel").addEventListener("click", closeConfirmationPopup);

// Evento para cerrar la ventana emergente de éxito y redirigir al login
document.getElementById("close-success-popup").addEventListener("click", closeSuccessPopup);
