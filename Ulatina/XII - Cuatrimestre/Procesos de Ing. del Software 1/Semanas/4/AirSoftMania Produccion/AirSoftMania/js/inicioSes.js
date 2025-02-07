// Credenciales válidas
const validCredentials = [
    { email: "user@user.com", password: "user123" },
    { email: "admin@admin.com", password: "admin" }
  ];
  
  // Función para manejar el inicio de sesión
  function handleLogin(event) {
    event.preventDefault(); // Evita el comportamiento por defecto del formulario
  
    // Obtener valores de los campos
    const emailInput = document.getElementById("email").value.trim();
    const passwordInput = document.getElementById("password").value.trim();
  
    // Validar credenciales
    const user = validCredentials.find(
      (cred) => cred.email === emailInput && cred.password === passwordInput
    );
  
    if (user) {
      // Redirigir a index.html después de un inicio de sesión exitoso
      // alert(`Bienvenido ${user.email === "admin@admin.com" ? "Administrador" : "Usuario"} 😊`);
      window.location.href = "index.html"; // Cambia a la página principal
    } else {
      // Mostrar mensaje de error
      showPopup("Credenciales incorrectas. Por favor, inténtelo de nuevo.");
    }
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

  // Asociar evento al botón de inicio de sesión
  document.querySelector(".login-btn").addEventListener("click", handleLogin);
  
  // Función para redirigir a register.html al hacer clic en "Crear cuenta"
  function redirectToRegister(event) {
    event.preventDefault();
    window.location.href = "register.html"; // Cambia a la página de registro
  }
  
  // Asociar evento al enlace de registro
  document.querySelector(".register-link").addEventListener("click", redirectToRegister);
  