using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Logica_capa;
using System.Data;
using Capa_Entidades;
using System.Collections.Generic;
using System.Linq;

namespace bot
{
    public class Program
    {
        private static string BotToken = "7297737852:AAFKqr7evFu5l1kf5PX7YmXnKDMc9iEABnk";
        private static TelegramBotClient botClient = new TelegramBotClient(BotToken);

        private static Dictionary<long, (string State, string cedula, string Date, string Time, string tipoPago, int id_servicio, string nombre_servicio)> userSessions = new Dictionary<long, (string, string, string, string, string, int,string)>();
        private static Dictionary<long, (string cc, string Nombre, string Apellido, int Edad)> cliente_session = new Dictionary<long, (string, string, string, int)>();

        static async Task Main(string[] args)
        {
            Console.WriteLine("Bot iniciado...");

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            botClient.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                CancellationToken.None
            );

            Console.WriteLine("Presiona Enter para finalizar el bot");
            Console.ReadLine();
        }

        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            if (update.Type == UpdateType.Message && update.Message!.Text == "/start")
            {
                var chatId = update.Message.Chat.Id;
                await MostrarMenuPrincipal(botClient, chatId, cancellationToken);
            }
            else if (update.Type == UpdateType.CallbackQuery)
            {
                var callbackQuery = update.CallbackQuery!;
                var chatId = callbackQuery.Message!.Chat.Id;

                await botClient.AnswerCallbackQueryAsync(callbackQuery.Id, cancellationToken: cancellationToken);

                if (callbackQuery.Data == "agendar_citas")
                {
                    userSessions[chatId] = ("esperando_cedula", "", "", "", "", 0,"");
                    await botClient.SendTextMessageAsync(chatId, "Por favor, indícanos tu cédula", cancellationToken: cancellationToken);
                }
                else if (callbackQuery.Data == "cancelar_cita")
                {
                    userSessions[chatId] = ("esperando_cedula_eliminar", "", "", "", "", 0, "");
                    await botClient.SendTextMessageAsync(chatId, "Para eliminar una cita porfavor digite su cedula", cancellationToken: cancellationToken);
                }
                else if (callbackQuery.Data == "ver_servicios")
                {
                    await seleccionarServicio(botClient, chatId, cancellationToken);
                }
                else if (callbackQuery.Data.StartsWith("servicio_"))
                {
                    if (userSessions.TryGetValue(chatId, out var session))
                    {
                        int servicioId = int.Parse(callbackQuery.Data.Substring("servicio_".Length));

                        Logica_servicio logica_Servicio = new Logica_servicio();

                       string nombre_servicio= logica_Servicio.obtenerNombre(servicioId);
                        userSessions[chatId] = ("esperando_pago", session.cedula, session.Date, session.Time, session.tipoPago, servicioId,nombre_servicio);
                        await MostrarOpcionesDePago(botClient, chatId, cancellationToken);
                    }
                }
                else if (callbackQuery.Data == "pago_efectivo" || callbackQuery.Data == "pago_transferencia")
                {
                    if (userSessions.TryGetValue(chatId, out var session))
                    {
                        string tipoPago = callbackQuery.Data == "pago_efectivo" ? "Efectivo" : "Transferencia";
                        userSessions[chatId] = ("esperando_fecha", session.cedula, session.Date, session.Time, tipoPago, session.id_servicio,session.nombre_servicio);
                        await botClient.SendTextMessageAsync(chatId, "Indica la fecha de la cita (formato dd/MM):", cancellationToken: cancellationToken);
                    }
                }
            }
            else if (update.Type == UpdateType.Message)
            {
                var chatId = update.Message.Chat.Id;
                if (userSessions.TryGetValue(chatId, out var session))
                {
                    if (session.State == "esperando_cedula")
                    {
                        string cedula = update.Message.Text;

                        if (cedula.All(char.IsDigit) && cedula.Length <= 10)
                        {
                            Logica_cliente lcliente = new Logica_cliente();
                            Cliente cliente = new Cliente { cc = cedula };
                            bool existe = lcliente.verificarCliente(cliente);

                            if (!existe)
                            {
                                // Guardar cédula en la sesión de cliente y cambiar el estado a "registrando_cliente"
                                cliente_session[chatId] = (cedula, "", "", 0);
                                userSessions[chatId] = ("registrando_cliente", cedula, "", "", "", 0, "");

                                await botClient.SendTextMessageAsync(chatId, "Cliente no registrado. Comenzaremos el registro.", cancellationToken: cancellationToken);
                                await botClient.SendTextMessageAsync(chatId, "Por favor, ingrese su nombre:", cancellationToken: cancellationToken);
                            }
                            else
                            {
                                // Cliente existe, continuar con selección de servicio
                                userSessions[chatId] = ("esperando_servicio", cedula, "", "", "", 0, "");
                                await seleccionarServicio(botClient, chatId, cancellationToken);
                            }
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId, "Cédula inválida. Debe contener solo números y un máximo de 10 dígitos.", cancellationToken: cancellationToken);
                        }
                    }

                    else if (session.State == "esperando_cedula_eliminar")
                    {
                        string cedula = update.Message.Text;

                        if (cedula.All(char.IsDigit) && cedula.Length <= 10)
                        {
                            Logica_cliente lcliente = new Logica_cliente();
                            Cliente cliente = new Cliente { cc = cedula };
                            bool existe = lcliente.verificarCliente(cliente);

                            if (!existe)
                            {
                                // Guardar cédula en la sesión de cliente y cambiar el estado a "registrando_cliente"
                                cliente_session[chatId] = (cedula, "", "", 0);
                                userSessions[chatId] = ("registrando_cliente", cedula, "", "", "", 0, "");

                                await botClient.SendTextMessageAsync(chatId, "Cliente no registrado.", cancellationToken: cancellationToken);
                             }
                            else
                            {
                                // Cliente existe, continuar con selección de servicio
                                userSessions[chatId] = ("/start", cedula, "", "", "", 0, "");
                                await MostrarMenuPrincipal(botClient, chatId, cancellationToken);
                            }
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId, "Cédula inválida. Debe contener solo números y un máximo de 10 dígitos.", cancellationToken: cancellationToken);
                        }
                    }
                    else if (session.State == "registrando_cliente")
                    {
                        if (cliente_session.TryGetValue(chatId, out var clienteData))
                        {
                            if (string.IsNullOrEmpty(clienteData.Nombre))
                            {
                                // Guardar nombre y solicitar apellido
                                cliente_session[chatId] = (clienteData.cc, update.Message.Text, "", 0);
                                await botClient.SendTextMessageAsync(chatId, "Por favor, ingrese su apellido:", cancellationToken: cancellationToken);
                            }
                            else if (string.IsNullOrEmpty(clienteData.Apellido))
                            {
                                // Guardar apellido y solicitar edad
                                cliente_session[chatId] = (clienteData.cc, clienteData.Nombre, update.Message.Text, 0);
                                await botClient.SendTextMessageAsync(chatId, "Por favor, ingrese su edad:", cancellationToken: cancellationToken);
                            }
                            else if (clienteData.Edad == 0)
                            {
                                if (int.TryParse(update.Message.Text, out int edad) && edad > 0)
                                {
                                    // Guardar edad y completar el registro
                                    cliente_session[chatId] = (clienteData.cc, clienteData.Nombre, clienteData.Apellido, edad);

                                    // Crear el objeto Cliente y guardarlo en la base de datos
                                    Cliente nuevoCliente = new Cliente
                                    {
                                        cc = clienteData.cc,
                                        nombre = clienteData.Nombre,
                                        apellido = clienteData.Apellido,
                                        edad = edad
                                    };

                                    Logica_cliente lcliente = new Logica_cliente();
                                    lcliente.agregarCliente(nuevoCliente);

                                    // Cambiar el estado a "esperando_servicio"
                                    userSessions[chatId] = ("esperando_servicio", clienteData.cc, "", "", "", 0, "");
                                    await botClient.SendTextMessageAsync(chatId, "Registro completado. Ahora, selecciona un servicio.", cancellationToken: cancellationToken);
                                    await seleccionarServicio(botClient, chatId, cancellationToken);
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(chatId, "Edad inválida. Por favor, ingrese una edad válida.", cancellationToken: cancellationToken);
                                }
                            }
                        }
                    }
                

                else if (session.State == "esperando_fecha")
                    {
                        string fecha = update.Message.Text;
                        if (DateTime.TryParseExact(fecha + "/" + DateTime.Now.Year, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime parsedFecha))
                        {
                            DateTime fechaActual = DateTime.Now;
                            DateTime fechaLimite = new DateTime(2024, 12, 31);

                            // Verifica que la fecha no sea anterior a la actual ni posterior a 2024
                            if (parsedFecha >= fechaActual && parsedFecha <= fechaLimite)
                            {
                                userSessions[chatId] = ("esperando_hora", session.cedula, fecha, session.Time, session.tipoPago, session.id_servicio, session.nombre_servicio);
                                await botClient.SendTextMessageAsync(chatId, "Indica la hora de la cita (formato HH:mm):", cancellationToken: cancellationToken);
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId, "La fecha debe ser posterior a la actual y no puede exceder el año 2024. Usa el formato dd/MM.", cancellationToken: cancellationToken);
                            }
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId, "Fecha inválida. Usa el formato dd/MM.", cancellationToken: cancellationToken);
                        }
                    }

                    else if (session.State == "esperando_hora")
                    {
                        string hora = update.Message.Text;
                        string fechaHoraCompleta = $"{session.Date}/{DateTime.Now.Year} {hora}";

                        if (DateTime.TryParseExact(fechaHoraCompleta, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime fechaCita))
                        {
                            if (fechaCita.Hour >= 6 && fechaCita.Hour < 12 || fechaCita.Hour >= 14 && fechaCita.Hour < 22)
                            {
                                Cita nuevaCita = new Cita
                                {
                                    fecha = fechaCita,
                                    cc_cliente = session.cedula,
                                    cc_empleado = "",
                                    tipo_pago = session.tipoPago,
                                    id_servicio = session.id_servicio,
                                    estado = 0
                                };

                                Logica_cita logicaCita = new Logica_cita();
                                bool citaAgregada = logicaCita.agregarCita(nuevaCita);

                                if (citaAgregada)
                                {
                                    userSessions[chatId] = ("completado", session.cedula, session.Date, hora, session.tipoPago, session.id_servicio, session.nombre_servicio);
                                    await botClient.SendTextMessageAsync(chatId, $"¡Cita agendada con éxito!" +
                                                  $"\nCedula: {session.cedula}" +
                                        $"\nFecha: {fechaCita:dd/MM/yyyy}" +
                                        $"\nHora: {hora}" + $"\nServicio: {session.nombre_servicio}" +

                                        $"\nPago: {session.tipoPago}", cancellationToken: cancellationToken);
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(chatId, "Hubo un problema al agendar tu cita. Por favor, intenta nuevamente.", cancellationToken: cancellationToken);
                                }
                            }
                            else
                            {
                                await botClient.SendTextMessageAsync(chatId, "Hora inválida. Debe estar entre 6:00-12:00 o 14:00-21:59.", cancellationToken: cancellationToken);
                            }
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(chatId, "Formato de hora inválido. Usa el formato HH:mm.", cancellationToken: cancellationToken);
                        }
                    }
                }
            }
        }

        private static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            Console.WriteLine(exception.ToString());
            return Task.CompletedTask;
        }

        private static async Task MostrarMenuPrincipal(ITelegramBotClient botClient, long chatId, CancellationToken cancellationToken)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                new[] { InlineKeyboardButton.WithCallbackData("Agendar citas", "agendar_citas"), InlineKeyboardButton.WithCallbackData("Consultar Cita", "ver_citas") },
                new[] { InlineKeyboardButton.WithCallbackData("Cancelar cita", "cancelar_cita"), InlineKeyboardButton.WithCallbackData("Ver Servicios", "ver_servicios") }

            });

            await botClient.SendTextMessageAsync(chatId, "Selecciona una opción:", replyMarkup: inlineKeyboard, cancellationToken: cancellationToken);
        }

        private static async Task seleccionarServicio(ITelegramBotClient botClient, long chatId, CancellationToken cancellationToken)
        {
            try
            {
                Logica_servicio servicio = new Logica_servicio();
                DataTable servicios = servicio.cargarServicios();

                var botones = new List<InlineKeyboardButton[]>();
                foreach (DataRow row in servicios.Rows)
                {
                    string nombreServicio = row["nombre"].ToString();
                    int id = Convert.ToInt32(row["id"]);
                    botones.Add(new[] { InlineKeyboardButton.WithCallbackData(nombreServicio, $"servicio_{id}") });
                }

                var teclado = new InlineKeyboardMarkup(botones);
                await botClient.SendTextMessageAsync(chatId, "Selecciona un servicio:", replyMarkup: teclado, cancellationToken: cancellationToken);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en seleccionarServicio: {ex.Message}");
                await botClient.SendTextMessageAsync(chatId, "Error al cargar los servicios. Intenta nuevamente.", cancellationToken: cancellationToken);
            }
        }

        private static async Task MostrarOpcionesDePago(ITelegramBotClient botClient, long chatId, CancellationToken cancellationToken)
        {
            var opcionesPago = new InlineKeyboardMarkup(new[]
            {
                InlineKeyboardButton.WithCallbackData("Efectivo", "pago_efectivo"),
                InlineKeyboardButton.WithCallbackData("Transferencia", "pago_transferencia")

            });

            await botClient.SendTextMessageAsync(chatId, "Selecciona el tipo de pago:", replyMarkup: opcionesPago, cancellationToken: cancellationToken);
        }
    }
}
