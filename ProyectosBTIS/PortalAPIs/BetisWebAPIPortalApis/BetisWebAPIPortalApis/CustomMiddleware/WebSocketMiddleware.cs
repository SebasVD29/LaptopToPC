using BetisWebAPIPortalApis.Manager;
using Newtonsoft.Json;
using System.Net.WebSockets;
using System.Text;

namespace BetisWebAPIPortalApis.CustomMiddleware
{
    public class WebSocketMiddleware
    {
        private readonly WebSocketServerConnectionaManager _manager = new WebSocketServerConnectionaManager();
        private readonly RequestDelegate _next;

        public WebSocketMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.WebSockets.IsWebSocketRequest)
            {
                WebSocket webSocket = await context.WebSockets.AcceptWebSocketAsync();
                Console.WriteLine("WebSocket Connected");
                string ConnID = _manager.AddSocket(webSocket);
                await SendConnIDAsync(webSocket, ConnID); //Call to new method here

                await ReceiveMessage(webSocket, async (result, buffer) =>
                {
                    //if (result.MessageType == WebSocketMessageType.Text)
                    //{
                    //    Console.WriteLine("Message Recieved");
                    //    // await RouteJSONMessageAsync(Encoding.UTF8.GetString(buffer, 0, result.Count));
                    //    await RouteJSONMessageAsync(Encoding.UTF8.GetString(buffer, 0, result.Count), webSocket);

                    //}
                    //else if (result.MessageType == WebSocketMessageType.Close)
                    //{
                    //    Console.WriteLine("Connection Message Closed");
                    //    return;
                    //}
                    if (result.MessageType == WebSocketMessageType.Text)
                    {
                        Console.WriteLine("Message Received");
                        string message = Encoding.UTF8.GetString(buffer, 0, result.Count);

                        // Si el mensaje indica cerrar la conexión, ejecutar lógica de cierre
                        if (message.Trim() == "{\"CloseConnection\":true}")
                        {
                            Console.WriteLine("Connection Message Closed");
                            return;
                        }

                        // Si no es un mensaje de cierre, continuar con la lógica de procesamiento de mensajes
                        await RouteJSONMessageAsync(message, webSocket);
                    }
                    else if (result.MessageType == WebSocketMessageType.Close)
                    {
                        Console.WriteLine("Connection Message Closed");
                        return;
                    }

                });
            }

            // Call the next delegate/middleware in the pipeline
            await _next(context);


        }
        //sends connectionid back to the server
        //private async Task SendConnIDAsync(WebSocket socket, string connID)
        //{
        //    var buffer = Encoding.UTF8.GetBytes("ConnID: " + connID);
        //    await socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
        //}
        private async Task SendConnIDAsync(WebSocket socket, string connID)
        {
            var message = new { ConnID = connID };
            var jsonMessage = JsonConvert.SerializeObject(message);
            var buffer = Encoding.UTF8.GetBytes(jsonMessage);
            await socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }


        private async Task ReceiveMessage(WebSocket socket, Action<WebSocketReceiveResult, byte[]> handleMessage)
        {
            var buffer = new byte[1024 * 4];

            while (socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(buffer: new ArraySegment<byte>(buffer),
                                                                   cancellationToken: CancellationToken.None);
                handleMessage(result, buffer);
            }
        }

        //private async Task RouteJSONMessageAsync(string message, WebSocket socket)
        //{
        //    try
        //    {
        //        var routeOb = JsonConvert.DeserializeObject<dynamic>(message);

        //        if (routeOb != null)
        //        {
        //            string toValue = routeOb.To?.ToString();

        //            if (!string.IsNullOrEmpty(toValue) && Guid.TryParse(toValue, out Guid guidOutput))
        //            {
        //                Console.WriteLine("Targeted");

        //                var sock = _manager.GetAllSockets().FirstOrDefault(s => s.Key == toValue);

        //                if (sock.Value != null && sock.Value.State == WebSocketState.Open)
        //                {
        //                    await sock.Value.SendAsync(Encoding.UTF8.GetBytes(routeOb.Message?.ToString()), WebSocketMessageType.Text, true, CancellationToken.None);
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Invalid Recipient");
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("Broadcast");

        //                foreach (var sock in _manager.GetAllSockets())
        //                {
        //                    if (sock.Value.State == WebSocketState.Open)
        //                    {
        //                        await sock.Value.SendAsync(Encoding.UTF8.GetBytes(routeOb.Message?.ToString() ?? ""), WebSocketMessageType.Text, true, CancellationToken.None);
        //                    }
        //                }

        //                // Verificar si el mensaje indica cerrar la conexión
        //                if (routeOb.CloseConnection != null && routeOb.CloseConnection.Value)
        //                {
        //                    await CerrarConexionWebSocket(socket);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error al procesar el mensaje JSON: {ex.Message}");
        //    }
        //}
        // Clase para representar la entrada del mensaje
        // Clase para representar la entrada del mensaje
        public class InputMessage
        {
            public string To { get; set; }
            public string Message { get; set; }
            public bool CloseConnection { get; set; }
            public string Response { get; set; }
        }


        // Clase para representar la salida del mensaje
        public class OutputMessage
        {
            public string MessageType { get; set; }
            public string Content { get; set; }
        }

        //private async Task RouteJSONMessageAsync(string message, WebSocket socket)
        //{
        //    try
        //    {
        //        var routeOb = JsonConvert.DeserializeObject<InputMessage>(message);

        //        if (routeOb != null)
        //        {
        //            string toValue = routeOb.To?.ToString();

        //            if (!string.IsNullOrEmpty(toValue) && Guid.TryParse(toValue, out Guid guidOutput))
        //            {
        //                Console.WriteLine("Targeted");

        //                var sock = _manager.GetAllSockets().FirstOrDefault(s => s.Key == toValue);

        //                if (sock.Value != null && sock.Value.State == WebSocketState.Open)
        //                {
        //                    await sock.Value.SendAsync(Encoding.UTF8.GetBytes(routeOb.Message?.ToString()), WebSocketMessageType.Text, true, CancellationToken.None);
        //                }
        //                else
        //                {
        //                    Console.WriteLine("Invalid Recipient");
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("Broadcast");

        //                foreach (var sock in _manager.GetAllSockets())
        //                {
        //                    if (sock.Value.State == WebSocketState.Open)
        //                    {
        //                        await sock.Value.SendAsync(Encoding.UTF8.GetBytes(routeOb.Message?.ToString() ?? ""), WebSocketMessageType.Text, true, CancellationToken.None);
        //                    }
        //                }

        //                // Verificar si el mensaje indica cerrar la conexión
        //                if (routeOb.CloseConnection)
        //                {
        //                    await CerrarConexionWebSocket(socket);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"Error al procesar el mensaje JSON: {ex.Message}");
        //    }
        //}

        private async Task RouteJSONMessageAsync(string message, WebSocket socket)
        {
            try
            {
                var routeOb = JsonConvert.DeserializeObject<dynamic>(message);

                if (routeOb != null)
                {
                    string toValue = routeOb.To?.ToString();

                    if (!string.IsNullOrEmpty(toValue) && Guid.TryParse(toValue, out Guid guidOutput))
                    {
                        Console.WriteLine("Targeted");

                        var sock = _manager.GetAllSockets().FirstOrDefault(s => s.Key == toValue);

                        if (sock.Value != null && sock.Value.State == WebSocketState.Open)
                        {
                            var responseMessage = new
                            {
                                From = "Server",
                                Message = $"Message sent to {toValue}: {routeOb.Message}"
                            };

                            var jsonResponse = JsonConvert.SerializeObject(responseMessage);

                            await sock.Value.SendAsync(Encoding.UTF8.GetBytes(jsonResponse), WebSocketMessageType.Text, true, CancellationToken.None);
                        }
                        else
                        {
                            Console.WriteLine("Invalid Recipient");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Broadcast");

                        foreach (var sock in _manager.GetAllSockets())
                        {
                            if (sock.Value.State == WebSocketState.Open)
                            {
                                var responseMessage = new
                                {
                                    From = "Server",
                                    Message = $"Broadcast message: {routeOb.Message}"
                                };

                                var jsonResponse = JsonConvert.SerializeObject(responseMessage);

                                await sock.Value.SendAsync(Encoding.UTF8.GetBytes(jsonResponse), WebSocketMessageType.Text, true, CancellationToken.None);
                            }
                        }

                        // Verificar si el mensaje indica cerrar la conexión
                        if (routeOb.CloseConnection != null && routeOb.CloseConnection.Value)
                        {
                            await CerrarConexionWebSocket(socket);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al procesar el mensaje JSON: {ex.Message}");
            }
        }


        private async Task CerrarConexionWebSocket(WebSocket socket)
        {
            if (socket != null && socket.State == WebSocketState.Open)
            {
                await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "Cierre normal", CancellationToken.None);
            }
        }


    }
}
