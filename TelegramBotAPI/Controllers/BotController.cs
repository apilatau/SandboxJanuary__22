using BusinessLayer.Interfaces;
using DataLayer.Data;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBotAPI.Controllers
{
    [ApiController]
    [Route("api/bot")]
    public class BotController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IStateService stateService;
        private readonly ApplicationDbContext applicationdbcontext;
        private readonly IReserveService reserveService;

        public BotController(IUserService userService, IStateService stateService, ApplicationDbContext applicationdbcontext, IReserveService reserveService)
        {
            this.userService = userService;
            this.stateService = stateService;
            this.applicationdbcontext = applicationdbcontext;
            this.reserveService = reserveService;
        }

        [HttpGet("getallusers")]
        public async Task<List<Userr>> GetUsers()
        {
            return await userService.ListAsync();
        }

        [HttpGet("getallcitis")]
        public List<City> getcities()
        {
            return applicationdbcontext.Cities.ToList();
        }


        [HttpGet("getalldesks")]
        public List<WorkingDesk> getalldesks()
        {
            return applicationdbcontext.WorkingDesks.ToList();
        }


        [HttpGet("getallofficies")]
        public List<Office> officies()
        {
            return applicationdbcontext.Offices.ToList();
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Update update)
        {
            string message;
            Int64 CurrentUserId;
            var usersinstate = stateService.CurrentListOfStates().Result.Select(x => x.OwnerTelegramId).ToList();
            //return Ok();

            TelegramBotClient client = new TelegramBotClient("5293359107:AAGfzC1GBMkLHzqy1enu4dbBHEvHqJ5Iq78");

            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                message = update.Message.Text.ToLower();
                CurrentUserId = update.Message.Chat.Id;

                var userId = (await GetUsers()).FirstOrDefault(x => x.TelegramId == CurrentUserId).Id;

                if (userId != null)
                {
                    var reserve = (await reserveService.ListAsync()).FirstOrDefault(x => x.UserrId == userId);

                    if (reserve != null && message != "yes")
                    {
                        await client.SendTextMessageAsync(CurrentUserId, $"Cancel Your Booking, starting at: {reserve.StartDate.ToShortDateString()}", replyMarkup: CancelButtons());
                        return Ok();
                    }
                }

                if (!usersinstate.Contains(CurrentUserId))
                {
                    var state2 = new State() { OwnerTelegramId = update.Message.Chat.Id, Level = 1 };
                    await stateService.AddAsync(state2);

                    await client.SendTextMessageAsync(CurrentUserId, "please enter starting day 1 from to 31", replyMarkup: inreply());
                    return Ok();
                }
                
            }
            else
            {
                message = update.CallbackQuery.Data.ToLower();
                CurrentUserId = update.CallbackQuery.From.Id;
                var userId = (await GetUsers()).FirstOrDefault(x => x.TelegramId == CurrentUserId).Id;

                if (userId != null)
                {
                    var reserve = (await reserveService.ListAsync()).FirstOrDefault(x => x.UserrId == userId);

                    if (reserve != null && message != "yes")
                    {
                        await client.SendTextMessageAsync(CurrentUserId, $"Cancel Your Booking, starting at: {reserve.StartDate.ToShortDateString()}", replyMarkup: CancelButtons());
                        return Ok();
                    }
                    if (message == "yes")
                    {
                        await reserveService.DeleteAsync(reserve);

                        await client.SendTextMessageAsync(CurrentUserId, "u deleted booking, if u want new one, choose from 1 to 31", replyMarkup: inreply());
                        return Ok();
                    }
                }

                if (!usersinstate.Contains(CurrentUserId))
                {
                    var state2 = new State() { OwnerTelegramId = CurrentUserId, Level = 1 };
                    await stateService.AddAsync(state2);

                   

                    await client.SendTextMessageAsync(CurrentUserId, "please enter starting day 1 from to 31", replyMarkup: inreply());
                    return Ok();
                }
            }

            var lvlobject = (await stateService.CurrentListOfStates()).LastOrDefault();
            int level = lvlobject.Level;

            if (level == 2)
            {
                if (char.IsNumber(message[0]))
                {
                    var state = (await stateService.CurrentListOfStates()).FirstOrDefault(x => x.OwnerTelegramId == CurrentUserId);
                    await client.SendTextMessageAsync(CurrentUserId, "please choose ending day 1 from to 31", replyMarkup: inreply());
                    state.startmonth = message;
                    state.Level = 3;

                    await stateService.UpdateAsync(state);
                    return Ok();
                }
                return await WrongUsage(CurrentUserId, client);
            }
            else if (level == 3)
            {
                if (message.Length <= 2 && char.IsNumber(message[0]))
                {
                    var state = (await stateService.CurrentListOfStates()).FirstOrDefault(x => x.OwnerTelegramId == CurrentUserId);
                    await client.SendTextMessageAsync(CurrentUserId, "please choose ending Month", replyMarkup: MonthL());

                    state.enday = message;
                    state.Level = 4;
                    await stateService.UpdateAsync(state);

                    return Ok();
                }
                return await WrongUsage(CurrentUserId, client);
            }
            else if (level == 4)
            {
                if (char.IsNumber(message[0]))
                {
                    await client.SendTextMessageAsync(CurrentUserId, "Please Choose Cities", replyMarkup: GetCities());
                    var state = (await stateService.CurrentListOfStates()).FirstOrDefault(x => x.OwnerTelegramId == CurrentUserId);

                    state.endmonth = message;
                    state.Level = 5;
                    await stateService.UpdateAsync(state);

                    return Ok();
                }
                return await WrongUsage(CurrentUserId, client);
            }
            else if (level == 5)
            {
                if (char.IsNumber(message[0]))
                {
                    await client.SendTextMessageAsync(CurrentUserId, $"Select Offices:", replyMarkup: GetOffices());
                    var state = (await stateService.CurrentListOfStates()).FirstOrDefault(x => x.OwnerTelegramId == CurrentUserId);

                    state.CityNumb = int.Parse(message);
                    state.Level = 6;
                    await stateService.UpdateAsync(state);

                    return Ok();
                }
                return await WrongUsage(CurrentUserId, client);
            }
            else if (level == 6)
            {
                if (char.IsNumber(message[0]))
                {
                    StringBuilder workingDesks = new StringBuilder();

                    var offices = getalldesks();
                    workingDesks.AppendLine("please choose Workingdesk");
                    for (int i = 0; i < getalldesks().Count; i++)
                    {
                        workingDesks.Append($" N: { offices.ElementAt(i).Id}");
                        workingDesks.Append($" hasPC: { offices.ElementAt(i).HasComputer}");
                        workingDesks.AppendLine($" hasWindow: { offices.ElementAt(i).NextToWindow}");
                    }

                    await client.SendTextMessageAsync(CurrentUserId, $"{workingDesks}", replyMarkup: GetWorkingDesks());
                    var state = (await stateService.CurrentListOfStates()).FirstOrDefault(x => x.OwnerTelegramId == CurrentUserId);

                    //DateTime datestart = new DateTime(int.Parse(state.Startday), int.Parse(state.startmonth), DateTime.Now.Year);
                    DateTime datestart = DateTime.Now;

                    state.OfficeNumb = int.Parse(message);
                    state.Level = 7;
                    await stateService.UpdateAsync(state);

                    return Ok();
                }
                return await WrongUsage(CurrentUserId, client);
            }
            else if (level == 7)
            {
                if (char.IsNumber(message[0]))
                {
                    var state = (await stateService.CurrentListOfStates()).FirstOrDefault(x => x.OwnerTelegramId == CurrentUserId);

                    DateTime startDate = new DateTime(DateTime.UtcNow.Year, int.Parse(state.startmonth), int.Parse(state.Startday));
                    DateTime endDate = new DateTime(DateTime.UtcNow.Year, int.Parse(state.endmonth), int.Parse(state.enday));
                    var userId = (await GetUsers()).FirstOrDefault(x => x.TelegramId == CurrentUserId).Id;

                    startDate = DateTime.SpecifyKind(startDate, DateTimeKind.Utc);
                    endDate = DateTime.SpecifyKind(endDate, DateTimeKind.Utc);

                    var reserve = new Reserve
                    {
                        UserrId = userId,
                        StartDate = startDate,
                        EndDate = endDate,
                        WorkingDeskId = int.Parse(message),
                        IsReccuring = false,
                        Frequency = 0,
                        OfficeId = state.OfficeNumb.Value,
                        BookingTypeId = 2
                    };

                    try
                    {
                        await reserveService.AddAsync(reserve);

                        await stateService.DeleteAsync(state);

                        await client.SendTextMessageAsync(CurrentUserId, "you succesfully reserved place");
                    }
                    catch (Exception ex)
                    {
                        await client.SendTextMessageAsync(CurrentUserId, "Error occured during reservation");
                    }

                    return Ok();
                }
                return await WrongUsage(CurrentUserId, client);
            }
            else if (level == 1)
            {
                if (message.Length <= 2 && char.IsNumber(message[0]))
                {
                    var state = (await stateService.CurrentListOfStates()).FirstOrDefault(x => x.OwnerTelegramId == CurrentUserId);
                    state.Startday = message;
                    state.Level = 2;

                    await stateService.UpdateAsync(state);
                    await client.SendTextMessageAsync(CurrentUserId, "please choose staring Month", replyMarkup: MonthF());
                    return Ok();
                }
                return await WrongUsage(CurrentUserId, client);
            }
            else
            {
                var currentState = new State() { OwnerTelegramId = update.Message.Chat.Id, Level = 1 };
                await stateService.AddAsync(currentState);
                await client.SendTextMessageAsync(CurrentUserId, "please enter starting day 1 from to 31", replyMarkup: inreply());
                return Ok();
            }
        }

        private async Task<IActionResult> WrongUsage(long CurrentUserId, TelegramBotClient client)
        {
            await client.SendTextMessageAsync(CurrentUserId, "please enter starting day 1 from to 30");
            return Ok();
        }

        IReplyMarkup GetCities()
        {

            var cities = getcities();
            int introwcount = getcities().Count;


            int firstcount;
            int secondcount;

            firstcount = introwcount / 2;
            secondcount = introwcount - firstcount;

            InlineKeyboardButton[][] keys = new InlineKeyboardButton[2][];
            InlineKeyboardMarkup myInlineKeyboard1 = new InlineKeyboardMarkup(keys);


            InlineKeyboardButton[] firstrow = new InlineKeyboardButton[firstcount];
            InlineKeyboardButton[] secondrow = new InlineKeyboardButton[secondcount];

            for (int i = 0; i < firstcount; i++)
            {
                firstrow[i] = InlineKeyboardButton.WithCallbackData($"{cities.ElementAt(i).Name}", $"{cities.ElementAt(i).Id}");
            }

            for (int i = 0; i < secondcount; i++)
            {
                secondrow[i] = InlineKeyboardButton.WithCallbackData($"{cities.ElementAt(i + firstcount).Name}", $"{cities.ElementAt(i + firstcount).Id}");
            }

            keys[0] = firstrow;
            keys[1] = secondrow;

            return myInlineKeyboard1;

            //InlineKeyboardMarkup myInlineKeyboard = new InlineKeyboardMarkup(

            //new InlineKeyboardButton[][]
            //    {
            //        new InlineKeyboardButton[] // First row
            //        {
            //            InlineKeyboardButton.WithCallbackData( // First Column
            //                "Tbilisi", // Button Name
            //                "tbilisi" // Answer you'll recieve
            //            ),
            //            InlineKeyboardButton.WithCallbackData( //Second column
            //                "Uzbekistan", // Button Name
            //                "uzbekistan" // Answer you'll recieve
            //            ),
            //        },    new InlineKeyboardButton[] // First row
            //        {
            //            InlineKeyboardButton.WithCallbackData( // First Column
            //                "Polland", // Button Name
            //                "polland" // Answer you'll recieve
            //            ),
            //            InlineKeyboardButton.WithCallbackData( //Second column
            //                "Ukraine", // Button Name
            //                "ukraine" // Answer you'll recieve
            //            ),

            //        }
            //});
            //return myInlineKeyboard;
        }

        IReplyMarkup CancelButtons()
        {
            InlineKeyboardMarkup myInlineKeyboard = new InlineKeyboardMarkup(

            new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[] // First row
                    {
                        InlineKeyboardButton.WithCallbackData( // First Column
                            "Yes", // Button Name
                            "Yes" // Answer you'll recieve
                        ),
                        InlineKeyboardButton.WithCallbackData( //Second column
                            "No", // Button Name
                            "No" // Answer you'll recieve
                        ),
                    }
            });
            return myInlineKeyboard;
        }
        IReplyMarkup GetOffices()
        {
            var ofices = officies();
            int introwcount = officies().Count;


            int firstcount;
            int secondcount;

            firstcount = introwcount / 2;
            secondcount = introwcount - firstcount;

            InlineKeyboardButton[][] keys = new InlineKeyboardButton[2][];
            InlineKeyboardMarkup myInlineKeyboard1 = new InlineKeyboardMarkup(keys);


            InlineKeyboardButton[] firstrow = new InlineKeyboardButton[firstcount];
            InlineKeyboardButton[] secondrow = new InlineKeyboardButton[secondcount];

            for (int i = 0; i < firstcount; i++)
            {
                firstrow[i] = InlineKeyboardButton.WithCallbackData($"{ofices.ElementAt(i).Address}", $"{ofices.ElementAt(i).Id}");
            }

            for (int i = 0; i < secondcount; i++)
            {
                secondrow[i] = InlineKeyboardButton.WithCallbackData($"{ofices.ElementAt(i + firstcount).Address}", $"{ofices.ElementAt(i + firstcount).Id}");
            }

            keys[0] = firstrow;
            keys[1] = secondrow;

            return myInlineKeyboard1;













            //           InlineKeyboardMarkup myInlineKeyboard = new InlineKeyboardMarkup(

            //new InlineKeyboardButton[][]
            //            {
            //       new InlineKeyboardButton[] // First row
            //       {

            //           InlineKeyboardButton.WithCallbackData( // First Column
            //               "tbilisioffice", // Button Name
            //               "tbilisi*" // Answer you'll recieve
            //           ),
            //           InlineKeyboardButton.WithCallbackData( //Second column
            //               "qutaisioffice", // Button Name
            //               "qutaisi*" // Answer you'll recieve
            //           ),
            //       },    new InlineKeyboardButton[] // First row
            //       {
            //           InlineKeyboardButton.WithCallbackData( // First Column
            //               "khashurioffice", // Button Name
            //               "kahsuri*" // Answer you'll recieve
            //           ),
            //           InlineKeyboardButton.WithCallbackData( //Second column
            //               "samtredia", // Button Name
            //               "June*" // Answer you'll recieve
            //           ),

            //       }
            //            });
            //           return myInlineKeyboard;
        }
        IReplyMarkup GetWorkingDesks()
        {


            var ofices = getalldesks();
            int introwcount = getalldesks().Count;


            int firstcount;
            int secondcount;

            firstcount = introwcount / 2;
            secondcount = introwcount - firstcount;

            InlineKeyboardButton[][] keys = new InlineKeyboardButton[2][];
            InlineKeyboardMarkup myInlineKeyboard1 = new InlineKeyboardMarkup(keys);


            InlineKeyboardButton[] firstrow = new InlineKeyboardButton[firstcount];
            InlineKeyboardButton[] secondrow = new InlineKeyboardButton[secondcount];

            for (int i = 0; i < firstcount; i++)
            {
                firstrow[i] = InlineKeyboardButton.WithCallbackData($"N:{ofices.ElementAt(i).Id}", $"{ofices.ElementAt(i).Id}");
            }

            for (int i = 0; i < secondcount; i++)
            {
                secondrow[i] = InlineKeyboardButton.WithCallbackData($"N:{ofices.ElementAt(i + firstcount).Id}", $"{ofices.ElementAt(i).Id}");
            }

            keys[0] = firstrow;
            keys[1] = secondrow;

            return myInlineKeyboard1;

        }
        IReplyMarkup MonthF()
        {
            InlineKeyboardMarkup myInlineKeyboard = new InlineKeyboardMarkup(

new InlineKeyboardButton[][]
            {
        new InlineKeyboardButton[] // First row
        {
            InlineKeyboardButton.WithCallbackData( // First Column
                "March", // Button Name
                "3" // Answer you'll recieve
            ),
            InlineKeyboardButton.WithCallbackData( //Second column
                "April", // Button Name
                "4" // Answer you'll recieve
            ),
        },    new InlineKeyboardButton[] // First row
        {
               InlineKeyboardButton.WithCallbackData( // First Column
                "May", // Button Name
                "5" // Answer you'll recieve
            ),
               InlineKeyboardButton.WithCallbackData( // First Column
                "June", // Button Name
                "6" // Answer you'll recieve
            ),

        }
            });
            return myInlineKeyboard;
        }
        IReplyMarkup MonthL()
        {
            InlineKeyboardMarkup myInlineKeyboard = new InlineKeyboardMarkup(

new InlineKeyboardButton[][]
            {
        new InlineKeyboardButton[] // First row
        {
            InlineKeyboardButton.WithCallbackData( // First Column
                "March", // Button Name
                "3" // Answer you'll recieve
            ),
            InlineKeyboardButton.WithCallbackData( //Second column
                "April", // Button Name
                "4" // Answer you'll recieve
            ),
        },    new InlineKeyboardButton[] // First row
        {
               InlineKeyboardButton.WithCallbackData( // First Column
                "May", // Button Name
                "5" // Answer you'll recieve
            ),
               InlineKeyboardButton.WithCallbackData( // First Column
                "June", // Button Name
                "6" // Answer you'll recieve
            ),

        }
            });
            return myInlineKeyboard;
        }
        IReplyMarkup inreply()
        {
            InlineKeyboardMarkup myInlineKeyboard = new InlineKeyboardMarkup(

new InlineKeyboardButton[][]
            {
        new InlineKeyboardButton[] // First row
        {
            InlineKeyboardButton.WithCallbackData( // First Column
                "1", // Button Name
                "1" // Answer you'll recieve
            ),
            InlineKeyboardButton.WithCallbackData( //Second column
                "2", // Button Name
                "2" // Answer you'll recieve
            ),
                        InlineKeyboardButton.WithCallbackData( // First Column
                "3", // Button Name
                "3" // Answer you'll recieve
            ),
            InlineKeyboardButton.WithCallbackData( //Second column
                "4", // Button Name
                "4" // Answer you'll recieve
            ),
                        InlineKeyboardButton.WithCallbackData( // First Column
                "5", // Button Name
                "5" // Answer you'll recieve
            ),
            InlineKeyboardButton.WithCallbackData( //Second column
                "6", // Button Name
                "6" // Answer you'll recieve
            ),
        },    new InlineKeyboardButton[] // First row
        {
            InlineKeyboardButton.WithCallbackData( // First Column
                "7", // Button Name
                "7" // Answer you'll recieve
            ),
            InlineKeyboardButton.WithCallbackData( //Second column
                "8", // Button Name
                "8" // Answer you'll recieve
            ),
                        InlineKeyboardButton.WithCallbackData( // First Column
                "9", // Button Name
                "9" // Answer you'll recieve
            ),
            InlineKeyboardButton.WithCallbackData( //Second column
                "10", // Button Name
                "10" // Answer you'll recieve
            ),
                        InlineKeyboardButton.WithCallbackData( // First Column
                "11", // Button Name
                "11" // Answer you'll recieve
            ),
            InlineKeyboardButton.WithCallbackData( //Second column
                "12", // Button Name
                "12" // Answer you'll recieve
            ),
        },
               new InlineKeyboardButton[] // First row
        {
            InlineKeyboardButton.WithCallbackData( // First Column
                "13", // Button Name
                "13" // Answer you'll recieve
            ),
            InlineKeyboardButton.WithCallbackData( //Second column
                "14", // Button Name
                "14" // Answer you'll recieve
            ),
                        InlineKeyboardButton.WithCallbackData( // First Column
                "15", // Button Name
                "15" // Answer you'll recieve
            ),
            InlineKeyboardButton.WithCallbackData( //Second column
                "16", // Button Name
                "16" // Answer you'll recieve
            ),
                        InlineKeyboardButton.WithCallbackData( // First Column
                "17", // Button Name
                "17" // Answer you'll recieve
            ),
            InlineKeyboardButton.WithCallbackData( //Second column
                "18", // Button Name
                "18" // Answer you'll recieve
            ),
        },    new InlineKeyboardButton[] // First row
        {
            InlineKeyboardButton.WithCallbackData( // First Column
                "19", // Button Name
                "19" // Answer you'll recieve
            ),
            InlineKeyboardButton.WithCallbackData( //Second column
                "20", // Button Name
                "20" // Answer you'll recieve
            ),
                        InlineKeyboardButton.WithCallbackData( // First Column
                "21", // Button Name
                "21" // Answer you'll recieve
            ),
            InlineKeyboardButton.WithCallbackData( //Second column
                "22", // Button Name
                "22" // Answer you'll recieve
            ),
                        InlineKeyboardButton.WithCallbackData( // First Column
                "23", // Button Name
                "23" // Answer you'll recieve
            ),
            InlineKeyboardButton.WithCallbackData( //Second column
                "24", // Button Name
                "24" // Answer you'll recieve
            ),
        },    new InlineKeyboardButton[] // First row
        {
            InlineKeyboardButton.WithCallbackData( // First Column
                "25", // Button Name
                "25" // Answer you'll recieve
            ),
            InlineKeyboardButton.WithCallbackData( //Second column
                "26", // Button Name
                "26" // Answer you'll recieve
            ),
                        InlineKeyboardButton.WithCallbackData( // First Column
                "27", // Button Name
                "27" // Answer you'll recieve
            ),
            InlineKeyboardButton.WithCallbackData( //Second column
                "28", // Button Name
                "28" // Answer you'll recieve
            ),
                        InlineKeyboardButton.WithCallbackData( // First Column
                "29", // Button Name
                "29" // Answer you'll recieve
            ),
            InlineKeyboardButton.WithCallbackData( //Second column
                "30", // Button Name
                "30" // Answer you'll recieve
            ),
                    InlineKeyboardButton.WithCallbackData( //Second column
                "31", // Button Name
                "31" // Answer you'll recieve
            )
        }
            });
            return myInlineKeyboard;
        }
    }
}

