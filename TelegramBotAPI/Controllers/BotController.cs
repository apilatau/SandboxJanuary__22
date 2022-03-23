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
        private readonly IRoleService roleService;
        private readonly IUserService userService;
        private readonly IStateService stateService;
        private readonly ApplicationDbContext applicationdbcontext;
        private readonly ICityService cityService;

        public BotController(IRoleService roleService, IUserService userService, IStateService stateService, ApplicationDbContext applicationdbcontext)
        {
            this.roleService = roleService;
            this.userService = userService;
            this.stateService = stateService;
            this.applicationdbcontext = applicationdbcontext;
            this.cityService = cityService;
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
            Int64 curruser;
            var usersinstate = stateService.CurrentListOfStates().Result.Select(x => x.OwnerTelegramId).ToList();
            //return Ok();
            var users = await GetUsers();

            TelegramBotClient client = new TelegramBotClient("5293359107:AAGfzC1GBMkLHzqy1enu4dbBHEvHqJ5Iq78");

            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                message = update.Message.Text.ToLower();
                curruser = update.Message.Chat.Id;

                if (!usersinstate.Contains(curruser))
                {
                    var state2 = new State() { OwnerTelegramId = update.Message.Chat.Id, Level = 1 };
                    await stateService.AddAsync(state2);
                    await client.SendTextMessageAsync(curruser, "please enter starting day 1 from to 31", replyMarkup: inreply());
                    return Ok();
                }
            }
            else
            {
                message = update.CallbackQuery.Data.ToLower();
                curruser = update.CallbackQuery.From.Id;

                if (!usersinstate.Contains(curruser))
                {
                    var state2 = new State() { OwnerTelegramId = update.Message.Chat.Id, Level = 1 };
                    await stateService.AddAsync(state2);
                    await client.SendTextMessageAsync(curruser, "please enter starting day 1 from to 31", replyMarkup: inreply());
                    return Ok();
                } 
            }


            int level = 0;

            var lvlobject = (await stateService.CurrentListOfStates()).LastOrDefault();
            level = lvlobject.Level;



            if (true) //usersinstate.Contains(curruser)
            {

                if (level == 2)
                {
                    if (message.Contains("*"))
                    {

                        var state = (await stateService.CurrentListOfStates()).FirstOrDefault(x=>x.OwnerTelegramId==curruser);
                        await client.SendTextMessageAsync(curruser, "please choose ending day 1 from to 31", replyMarkup: inreply());
                        state.startmonth = message;
                        state.Level = 3;

                        await stateService.UpdateAsync(state);
                        return Ok();
                    }
                    else
                    {

                        //await client.SendTextMessageAsync(update.Message.From.Id, "please choose end date", replyMarkup: getdatebuttons2());
                        await client.SendTextMessageAsync(curruser, "please use buttons");
                        return Ok();

                    }
                }

                else if (level == 3)
                {

                    if (message.Length <= 2 && char.IsNumber(message[0]))
                    {

                        Int64 id = update.CallbackQuery.From.Id;

                        var state = (await stateService.CurrentListOfStates()).FirstOrDefault(x => x.OwnerTelegramId == curruser);
                        state.enday = message;
                        state.Level = 4;

                        await stateService.UpdateAsync(state);
                        await client.SendTextMessageAsync(curruser, "please choose ending Month", replyMarkup: MonthL());
                        return Ok();
                    }
                    await client.SendTextMessageAsync(curruser, "please use buttons");
                    return Ok();

                }
                else if (level == 4)
                {
                    if (message.Contains("-"))
                    {

                        await client.SendTextMessageAsync(curruser, "Please Choose Cities", replyMarkup: getcitiess());
                        var state = (await stateService.CurrentListOfStates()).FirstOrDefault(x => x.OwnerTelegramId == curruser);

                        state.endmonth = message;
                        state.Level = 5;

                        await stateService.UpdateAsync(state);
                        return Ok();
                    }
                    else
                    {
                        await client.SendTextMessageAsync(curruser, "please use buttons");
                        return Ok();

                    }
                }

                else if (level == 5)
                {
                    if (char.IsNumber(message[0]))
                    {

                        await client.SendTextMessageAsync(curruser, $"Select Offices:", replyMarkup: getofficies());
                        var state = (await stateService.CurrentListOfStates()).FirstOrDefault(x => x.OwnerTelegramId == curruser);

                        state.CityNumb = int.Parse(message);
                        state.Level = 6;

                        await stateService.UpdateAsync(state);
                        return Ok();
                    }
                    else
                    {
                        await client.SendTextMessageAsync(curruser, "please use buttons");
                        return Ok();

                    }
                }

                else if (level == 6)
                {
                    if (char.IsNumber(message[0]))
                    {
                        StringBuilder sb = new StringBuilder();

                        var offices = getalldesks();
                        sb.AppendLine("please choose Workingdesk");
                        for (int i = 0; i < getalldesks().Count; i++)
                        {
                            sb.Append($" N: { offices.ElementAt(i).Id}");
                            sb.Append($" hasPC: { offices.ElementAt(i).HasComputer}");
                            sb.AppendLine($" hasWindow: { offices.ElementAt(i).NextToWindow}");
                        }

                        await client.SendTextMessageAsync(curruser, $"{sb.ToString()}", replyMarkup: getworkingdesks());
                        var state = (await stateService.CurrentListOfStates()).FirstOrDefault(x => x.OwnerTelegramId == curruser);

                        state.OfficeNumb = int.Parse(message);
                        state.Level = 7;

                        await stateService.UpdateAsync(state);
                        return Ok();
                    }
                    else
                    {
                        await client.SendTextMessageAsync(curruser, "please use buttons");
                        return Ok();

                    }
                }

                else if (level == 7)
                {
                    if (char.IsNumber(message[0]))
                    {

                        await client.SendTextMessageAsync(curruser, "you succesfully reserved");
                        var state = (await stateService.CurrentListOfStates()).FirstOrDefault(x => x.OwnerTelegramId == curruser);

                        state.WorkingDeskNumb = int.Parse(message);
                        state.Level = 8;

                        await stateService.UpdateAsync(state);
                        return Ok();
                    }
                    else
                    {
                        await client.SendTextMessageAsync(curruser, "please use buttons");
                        return Ok();

                    }
                }
                else if (level == 1)
                {
                    if (message.Length <= 2 && char.IsNumber(message[0]))
                    {
                        var state = (await stateService.CurrentListOfStates()).FirstOrDefault(x => x.OwnerTelegramId == curruser);
                        state.Startday = message;
                        state.Level = 2;

                        await stateService.UpdateAsync(state);
                        await client.SendTextMessageAsync(curruser, "please choose staring Month", replyMarkup: MonthF());
                        return Ok();
                    }


                    await client.SendTextMessageAsync(curruser, "please enter starting day 1 from to 30");
                    return Ok();
                }
                else
                {
                    var state2 = new State() { OwnerTelegramId = update.Message.Chat.Id, Level = 1 };
                    await stateService.AddAsync(state2);
                    await client.SendTextMessageAsync(curruser, "please enter starting day 1 from to 31", replyMarkup: inreply());
                    return Ok();
                }
            }
            //else
            //{
            //    await client.SendTextMessageAsync(curruser, "sorry u are not exadel employee");
            //    return Ok();
            //}

            //if (text != button3 && text != button2)
            //{
            //    await client.SendTextMessageAsync(update.Message.From.Id, "please choose starting date", replyMarkup: getdatebuttons());
            //    return Ok();
            //}
            //else
            //{
            //    if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            //    {
            //        Int64 curruser = update.Message.Chat.Id;
            //        var usersinstate = stateService.CurrentListOfStates().Result.Select(x => x.OwnerTelegramId).ToList();

            //        //var users = GetUsers().Result;
            //        //if (true)//(users.Select(x => x.TelegramId).Contains(update.Message.Chat.Id))
            //        //{
            //        if (usersinstate.Contains(curruser))
            //        {
            //            await client.SendTextMessageAsync(update.Message.From.Id, "please choose end date", replyMarkup: getdatebuttons2());
            //            var state = (await stateService.CurrentListOfStates()).LastOrDefault();
            //            state.EndDate = text;

            //            await stateService.UpdateAsync(state);

            //        }
            //        else
            //        {
            //            await client.SendTextMessageAsync(update.Message.From.Id, "please chosse the startingdate", replyMarkup: getdatebuttons());
            //            Int64 id = update.Message.Chat.Id;
            //            var state2 = new State() { OwnerTelegramId = update.Message.Chat.Id, StartDate = text };
            //            await stateService.AddAsync(state2);
            //        }
            //    }
            //}






            return Ok();
        }


        IReplyMarkup empty()
        {
            var r = new ReplyKeyboardMarkup(new KeyboardButton[][]
         {
        new KeyboardButton[]
        {
            new KeyboardButton("please enter above from 1 to 30")
        }
         });

            return r;
        }

        IReplyMarkup getcitiess()
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


        IReplyMarkup getofficies()
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


        IReplyMarkup getworkingdesks()
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
                firstrow[i] = InlineKeyboardButton.WithCallbackData($"N:{ofices.ElementAt(i).Id}",  $"{ofices.ElementAt(i).Id}");
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
                "March*" // Answer you'll recieve
            ),
            InlineKeyboardButton.WithCallbackData( //Second column
                "April", // Button Name
                "April*" // Answer you'll recieve
            ),
        },    new InlineKeyboardButton[] // First row
        {
               InlineKeyboardButton.WithCallbackData( // First Column
                "May", // Button Name
                "May*" // Answer you'll recieve
            ),
               InlineKeyboardButton.WithCallbackData( // First Column
                "June", // Button Name
                "June*" // Answer you'll recieve
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
                "March-" // Answer you'll recieve
            ),
            InlineKeyboardButton.WithCallbackData( //Second column
                "April", // Button Name
                "April-" // Answer you'll recieve
            ),
        },    new InlineKeyboardButton[] // First row
        {
               InlineKeyboardButton.WithCallbackData( // First Column
                "May", // Button Name
                "May-" // Answer you'll recieve
            ),
               InlineKeyboardButton.WithCallbackData( // First Column
                "June", // Button Name
                "June-" // Answer you'll recieve
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

