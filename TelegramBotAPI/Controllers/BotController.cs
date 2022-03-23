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

        [HttpPost]

        public async Task<IActionResult> Post([FromBody] Update update)
        {
            
            TelegramBotClient client = new TelegramBotClient("5293359107:AAGfzC1GBMkLHzqy1enu4dbBHEvHqJ5Iq78");
            string msg = update.Message.Text;

            int level;

            Int64 curruser = update.Message.Chat.Id;
            var usersinstate = stateService.CurrentListOfStates().Result.Select(x => x.OwnerTelegramId).ToList();

            var users = await GetUsers();

            
            level = (await stateService.CurrentListOfStates()).OrderBy(x => x.Level).LastOrDefault().Level;

            if (true)
            {

                if (level == 2)
                {
                    string message = update.Message.Text;
                    if (message.Contains("*"))
                    {

                        var state = (await stateService.CurrentListOfStates()).LastOrDefault();
                        await client.SendTextMessageAsync(update.Message.From.Id, "please enter ending day 1 from to 31", replyMarkup: empty());
                        state.startmonth = message;
                        state.Level = 3;

                        await stateService.UpdateAsync(state);
                        return Ok();
                    }
                    else
                    {

                        //await client.SendTextMessageAsync(update.Message.From.Id, "please choose end date", replyMarkup: getdatebuttons2());
                        await client.SendTextMessageAsync(update.Message.From.Id, "please choose start month", replyMarkup: getdatebuttons());
                        return Ok();

                    }
                }

                else if (level == 3)
                {
                    string message = update.Message.Text;
                    if (message.Length <= 2 && char.IsNumber(message[0]))
                    {

                        Int64 id = update.Message.Chat.Id;

                        var state2 = new State() { OwnerTelegramId = update.Message.Chat.Id, enday = message, Level = 4 };

                        await stateService.AddAsync(state2);
                        await client.SendTextMessageAsync(update.Message.From.Id, "please choose ending Month", replyMarkup: getdatebuttons2());
                        return Ok();
                    }
                    await client.SendTextMessageAsync(update.Message.From.Id, "please enter ending day 1 from to 30", replyMarkup: empty());
                    return Ok();

                }
                else if (level == 4)
                {
                    string message = update.Message.Text;
                    if (message.Contains("-"))
                    {

                        await client.SendTextMessageAsync(update.Message.From.Id, "Please Choose Cities", replyMarkup: getcitiess());
                        var state = (await stateService.CurrentListOfStates()).LastOrDefault();

                        state.endmonth = message;
                        state.Level = 5;

                        await stateService.UpdateAsync(state);
                        return Ok();
                    }
                    else
                    {
                        await client.SendTextMessageAsync(update.Message.From.Id, "please choose end month", replyMarkup: getdatebuttons2());
                        return Ok();

                    }
                }
                else if (level == 5)
                {
                    string message = update.Message.Text.ToLower();
                    if (message.Contains("tbilisi") || message.Contains("tashkent") || message.Contains("kyiev"))
                    {
                        StringBuilder sb = new StringBuilder();

                        var desks = getalldesks();

                        for (int i = 0; i < getalldesks().Count; i++)
                        {
                            sb.AppendLine($"{ desks.ElementAt(i).Id}");
                            sb.Append($",  hascomputer: {desks.ElementAt(i).HasComputer}");
                            sb.Append($",  haswindow  {desks.ElementAt(i).NextToWindow}");
                        }


                        await client.SendTextMessageAsync(update.Message.From.Id, $"{sb.ToString()}", replyMarkup: getworkingdesks());
                        var state = (await stateService.CurrentListOfStates()).LastOrDefault();

                        state.endmonth = message;
                        state.Level = 6;

                        await stateService.UpdateAsync(state);
                        return Ok();
                    }
                    else
                    {
                        await client.SendTextMessageAsync(update.Message.From.Id, "please choose city", replyMarkup: getdatebuttons());
                        return Ok();

                    }
                }

                else if (level == 6)
                {
                    string message = update.Message.Text.ToLower();
                    if (message.Length <= 2 && char.IsNumber(message[0]))
                    {

                        await client.SendTextMessageAsync(update.Message.From.Id, "you succesfully reserved", replyMarkup: succesreservation());
                        var state = (await stateService.CurrentListOfStates()).LastOrDefault();

                        state.endmonth = message;
                        state.Level = 6;

                        await stateService.UpdateAsync(state);
                        return Ok();
                    }
                    else
                    {
                        await client.SendTextMessageAsync(update.Message.From.Id, "please choose city", replyMarkup: getdatebuttons());
                        return Ok();

                    }
                }
                else if (level == 1)
                {
                    string message = update.Message.Text;
                    if (message.Length <= 2 && char.IsNumber(message[0]))
                    {
                        Int64 id = update.Message.Chat.Id;

                        var state2 = new State() { OwnerTelegramId = update.Message.Chat.Id, Startday = message, Level = 2 };

                        await stateService.AddAsync(state2);
                        await client.SendTextMessageAsync(update.Message.From.Id, "please choose staring Month", replyMarkup: getdatebuttons());
                        return Ok();
                    }


                    await client.SendTextMessageAsync(update.Message.From.Id, "please enter starting day 1 from to 30", replyMarkup: empty());
                    return Ok();
                }
                else
                {
                    var state2 = new State() { OwnerTelegramId = update.Message.Chat.Id, Level = 1 };
                    await stateService.AddAsync(state2);
                    await client.SendTextMessageAsync(update.Message.From.Id, "please enter starting day 1 from to 31", replyMarkup: empty());
                    return Ok();
                }
            }
            else
            {
                await client.SendTextMessageAsync(update.Message.From.Id, "sorry u are not exadel employee");
            }

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

        IReplyMarkup getdatebuttons()
        {
            var r = new ReplyKeyboardMarkup(
        new KeyboardButton[]
        {
            new KeyboardButton("jan*"),
            new KeyboardButton("feb*"),
            new KeyboardButton("march*"),
            new KeyboardButton("april*"),
            new KeyboardButton("may*"),
            new KeyboardButton("jun*"),
            new KeyboardButton("jul*"),
            new KeyboardButton("aug*"),
            new KeyboardButton("sep*"),
            new KeyboardButton("oct*"),
            new KeyboardButton("nov*"),
            new KeyboardButton("dec*"),

        }
         );

            return r;
        }

        IReplyMarkup getdatebuttons2()
        {
            var r = new ReplyKeyboardMarkup(new KeyboardButton[][]
         {
        new KeyboardButton[]
        {
            new KeyboardButton("jan-"),
            new KeyboardButton("feb-"),
            new KeyboardButton("march-"),
            new KeyboardButton("april-"),
            new KeyboardButton("may-"),
            new KeyboardButton("jun-"),
            new KeyboardButton("jul-"),
            new KeyboardButton("aug-"),
            new KeyboardButton("sep-"),
            new KeyboardButton("oct-"),
            new KeyboardButton("nov-"),
            new KeyboardButton("dec-"),

        }
         });

            return r;
        }

        IReplyMarkup succesreservation()
        {
            var r = new ReplyKeyboardMarkup(new KeyboardButton[][]
         {
        new KeyboardButton[]
        {
            new KeyboardButton("you succesfully reserved"),

        }
         });

            return r;
        }


        IReplyMarkup getcitiess()
        {
            var cities = getcities();
            var r = new ReplyKeyboardMarkup(new KeyboardButton[][]
         {

                new KeyboardButton[]
                {
                    new KeyboardButton($"{cities.ElementAt(0).Name}"),
                    new KeyboardButton($"{cities.ElementAt(1).Name}"),
                    new KeyboardButton($"{cities.ElementAt(2).Name}"),

                }

         });

            return r;
        }


        IReplyMarkup getworkingdesks()
        {
            StringBuilder sb = new StringBuilder();


            var r = new ReplyKeyboardMarkup(new KeyboardButton[][]
         {
                new KeyboardButton[]
                {
                    new KeyboardButton("please choos one of above working desk, enter its ID"),
                }
         });

            return r;
        }

    }
}

