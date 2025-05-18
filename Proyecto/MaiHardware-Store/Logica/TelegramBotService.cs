using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Logica
{
    public class TelegramBotService
    {
        private TelegramBotClient botClient;
        private CancellationTokenSource cts;
        private AsyncLocal<Update> updateContext = new AsyncLocal<Update>();

        public async Task Iniciar()
        {
            string token = "7753003113:AAGNh8yNkCAuYUIwiQcxZbJwTIpgq-noAJ8";
            botClient = new TelegramBotClient(token);

            var me = await botClient.GetMeAsync();
            string botName = $"Bot: {me.FirstName}";

            await StartReceiver();
        }

        public async Task StartReceiver()
        {
            cts = new CancellationTokenSource();
            var cancelToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = Array.Empty<UpdateType>()
            };

            await botClient.ReceiveAsync(
                OnMessage,
                ErrorMessage,
                receiverOptions,
                cancelToken
            );
        }

        public async Task OnMessage(ITelegramBotClient botClient, Update update, CancellationToken cancelToken)
        {
            try
            {
                updateContext.Value = update;

                string chatId = GetCurrentChatId().ToString();
                string message = update.Message?.Text ?? update.CallbackQuery?.Data ?? "Actualización sin mensaje";
                LogToUI($"Mensaje recibido - Chat ID: {chatId}, Mensaje: {message}");

                if (update.Message is Telegram.Bot.Types.Message messages)
                {
                    await ShowMainMenu();
                }
                else if (GetCallbackQueryButtonKey().Equals("products_module"))
                {
                    await ShowProductsMenu();
                }
                else if (GetCallbackQueryButtonKey().Equals("quotes_module"))
                {
                    await ShowQuotesMenu();
                }
                else if (GetCallbackQueryButtonKey().Equals("inventory_module"))
                {
                    await ShowInventoryMenu();
                }
                else if (GetCallbackQueryButtonKey().Equals("clients_module"))
                {
                    await ShowClientsMenu();
                }
                else if (GetCallbackQueryButtonKey().Equals("system_info"))
                {
                    await SendSystemInfo();
                }
            }
            catch (Exception ex)
            {
                LogToUI($"Error procesando mensaje: {ex.Message}");
                await SendTextMessageAsync("⚠ Error en el sistema: " + ex.Message);
            }
        }

        private Task ErrorMessage(ITelegramBotClient botClient, Exception exception, CancellationToken cancelToken)
        {
            if (exception is ApiRequestException apiRequestException)
            {
                LogToUI($"Error de API: {apiRequestException.Message}");
            }
            else
            {
                LogToUI($"Error: {exception.Message}");
                MessageBox.Show($"Error: {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return Task.CompletedTask;
        }

        private void LogToUI(string message)
        {
            if (botClient == null)
            {
                return;
            }
        }

        public long? GetCurrentChatId()
        {
            if (updateContext.Value.Message != null)
            {
                return updateContext.Value.Message.Chat.Id;
            }

            if (updateContext.Value.CallbackQuery != null)
            {
                return updateContext.Value.CallbackQuery.Message.Chat.Id;
            }

            return null;
        }

        public string GetMessageText()
        {
            return updateContext.Value.Message?.Text ?? string.Empty;
        }

        public string GetCallbackQueryButtonKey()
        {
            return updateContext.Value.CallbackQuery?.Data ?? string.Empty;
        }

        public async Task SendTextMessageAsync(string text)
        {
            long? chatId = GetCurrentChatId();
            if (chatId.HasValue)
            {
                await botClient.SendTextMessageAsync(
                    chatId: chatId.Value,
                    text: text,
                    parseMode: ParseMode.Markdown);

                LogToUI($"Mensaje enviado a {chatId}: {text.Substring(0, Math.Min(text.Length, 50))}...");
            }
        }

        public async Task SendTextMessageAsync(string text, Dictionary<string, string> buttons)
        {
            long? chatId = GetCurrentChatId();
            if (chatId.HasValue)
            {
                var keyboardButtons = new List<List<InlineKeyboardButton>>();
                foreach (var buttonName in buttons.Keys)
                {
                    var buttonValue = buttons[buttonName];
                    var button = InlineKeyboardButton.WithCallbackData(buttonName, buttonValue);
                    keyboardButtons.Add(new List<InlineKeyboardButton> { button });
                }

                var keyboard = new InlineKeyboardMarkup(keyboardButtons);

                await botClient.SendTextMessageAsync(
                    chatId: chatId.Value,
                    text: text,
                    parseMode: ParseMode.Markdown,
                    replyMarkup: keyboard);

                LogToUI($"Mensaje con botones enviado a {chatId}: {text.Substring(0, Math.Min(text.Length, 50))}...");
            }
        }

        private async Task ShowMainMenu()
        {
            await SendTextMessageAsync(WELCOME_MSG,
                new Dictionary<string, string>
                {
                    { "📦 Productos", "products_module" },
                    { "📝 Cotizaciones", "quotes_module" },
                    { "📊 Inventario", "inventory_module" },
                    { "👥 Clientes", "clients_module" },
                    { "ℹ Sistema", "system_info" }
                });
        }

        private async Task ShowProductsMenu()
        {
            await SendTextMessageAsync(PRODUCTS_MENU,
                new Dictionary<string, string>
                {
                    { "🔍 Buscar producto", "product_search" },
                    { "🗂 Por categoría", "product_by_category" },
                    { "🏷 Descuentos", "product_discounts" },
                    { "🆕 Nuevos", "new_products" },
                    { BACK_MAIN_MENU, "main_menu" }
                });
        }

        private async Task ShowQuotesMenu()
        {
            await SendTextMessageAsync(QUOTES_MENU,
                new Dictionary<string, string>
                {
                    { "🆕 Nueva", "new_quote" },
                    { "⏳ Pendientes", "pending_quotes" },
                    { "🕰 Histórico", "quote_history" },
                    { "🛒 Convertir", "convert_to_order" },
                    { BACK_MAIN_MENU, "main_menu" }
                });
        }

        private async Task ShowInventoryMenu()
        {
            await SendTextMessageAsync(INVENTORY_MENU,
                new Dictionary<string, string>
                {
                    { "🔎 Consultar", "inventory_check" },
                    { "⚠ Alertas", "inventory_alerts" },
                    { "📋 Movimientos", "inventory_movements" },
                    { "✏ Ajustes", "inventory_adjustments" },
                    { BACK_MAIN_MENU, "main_menu" }
                });
        }

        private async Task ShowClientsMenu()
        {
            await SendTextMessageAsync(CLIENTS_MENU,
                new Dictionary<string, string>
                {
                    { "➕ Registrar", "client_register" },
                    { "🔍 Buscar", "client_search" },
                    { "📋 Historial", "client_history" },
                    { "💳 Crédito", "client_credit" },
                    { BACK_MAIN_MENU, "main_menu" }
                });
        }

        private async Task SendSystemInfo()
        {
            string user = GetCurrentChatId() != null ? "Usuario-" + GetCurrentChatId() : "Invitado";
            string info = string.Format(SYSTEM_INFO, user, DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

            await SendTextMessageAsync(info,
                new Dictionary<string, string>
                {
                    { "🔄 Actualizar", "system_info" },
                    { "📋 Manual", "system_manual" },
                    { CONTACT_SUPPORT, "contact_support" },
                    { BACK_MAIN_MENU, "main_menu" }
                });
        }

        public const string WELCOME_MSG = @"*⚡ FERRETERÍA MAIHARDWARE ⚡*
            
            Sistema Integral de Gestión Comercial
            
            *Versión 2.1* - ©2025
            
            Seleccione un módulo:";

        public const string PRODUCTS_MENU = @"*📦 MÓDULO DE PRODUCTOS*
            
            1. Buscar producto por referencia
            2. Listar por categoría
            3. Productos con descuento
            4. Nuevos ingresos
            
            *Stock total: 1,245 items*";

        public const string QUOTES_MENU = @"*📝 MÓDULO DE COTIZACIONES*
            
            1. Nueva cotización
            2. Cotizaciones pendientes
            3. Histórico de cotizaciones
            4. Convertir a pedido";

        public const string INVENTORY_MENU = @"*📊 MÓDULO DE INVENTARIO*
            
            1. Consultar niveles de stock
            2. Alertas de inventario
            3. Movimientos recientes
            4. Ajustes de inventario";

        public const string CLIENTS_MENU = @"*👥 MÓDULO DE CLIENTES*
            
            1. Registrar nuevo cliente
            2. Buscar cliente
            3. Historial de compras
            4. Crédito disponible";

        public const string BACK_MAIN_MENU = "Volver al menú principal";
        public const string CONTACT_SUPPORT = "📞 Contactar con soporte técnico";
        public const string SYSTEM_INFO = @"*ℹ INFORMACIÓN DEL SISTEMA*
            
            Usuario: {0}
            Sucursal: Principal
            Versión: 2.1.0
            Último acceso: {1}";
    }
}
