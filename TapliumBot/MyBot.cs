using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TapliumBot
{
    class MyBot
    {
        DiscordClient discord;
        CommandService commands;

        Random rand;

        string[] memes;
        string[] words;


        public MyBot()
        {
            
            rand = new Random();
            memes = new string[]
            {
                "memes/wtf.jpg",
                "memes/wtf2.jpg",
                "memes/wtf3.jpg",
                "memes/wtf5.jpg",
                "memes/wtf6.jpg",
                "memes/wtf7.jpg",
                "memes/wtf8.jpg",
                "memes/wtf9.jpg",
                "memes/wtf10.jpg",
                "memes/wtf11.jpg",
                "memes/wtf12.jpg",
                "memes/wtf13.jpg",
                "memes/wtf14.jpg",
                "memes/wtf15.jpg",
                "memes/wtf16.jpg",
                "memes/wtf17.jpg",
                "memes/wtf18.jpg",
                "memes/wtf19.jpg",
                "memes/wtf20.jpg",
                "memes/wtf21.jpg",
                "memes/wtf22.jpg",
                "memes/wtf23.jpg",
                "memes/wtf24.jpg",
                "memes/wtf25.jpg",
                "memes/wtf26.jpg",
                "memes/wtf27.jpg"
            };

            words = new string[]
            {
                "YOU SHALL NOT PASS!!",
                "Words of wisdom",
                "Damn, I don't know what to put",
                "The developer of this bot is retarded",
                "At the end of the day we all make bots, am I right?"
            };
            discord = new DiscordClient(x =>
            {
                x.LogLevel = LogSeverity.Info;
                x.LogHandler = Log;

            });

            discord.UsingCommands(x =>
            {
                x.PrefixChar = '&';
                x.AllowMentionPrefix = true;
            });

            commands = discord.GetService<CommandService>();

            RegisterMemeCommand();
            RegisterWordCommand();
            RegisterPingCommand();
            RegisterCmdsCommand();
            RegisterPurgeCommand();


            commands.CreateCommand("meme");
            commands.CreateCommand("wordsofwisdom");
            commands.CreateCommand("ping");
            commands.CreateCommand("cmds");
            commands.CreateCommand("purge");

            discord.ExecuteAndWait(async () =>
            {

                await discord.Connect("MzA4MjU0MzgxMDM0MTc2NTEy.C-ePWA.WakPnjRCFEMMmItZhHkTp_79JTM", TokenType.Bot);
            });
        }

        private void RegisterMemeCommand()
        {
            commands.CreateCommand("meme")
                .Do(async (e) =>
            {
                int randomMemeIndex = rand.Next(memes.Length);
                string memeToPost = memes[randomMemeIndex];
                await e.Channel.SendFile(memeToPost);
            });
        }

        private void RegisterWordCommand()
        {
            commands.CreateCommand("wordsofwisdom")
                .Do(async (e) =>
                {
                    int randomWordIndex = rand.Next(words.Length);
                    string wordsToPost = words[randomWordIndex];
                    await e.Channel.SendMessage(wordsToPost);
                });
        }

        private void RegisterPingCommand()
        {
            commands.CreateCommand("ping")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("Pong");
                });
        }

        private void RegisterCmdsCommand()
        {
            commands.CreateCommand("cmds")
                .Do(async (e) =>
                {
                    await e.Channel.SendMessage("So far we have the following commands: **Ping**, **meme**, **wordsofwisdom**, **purge**, and **cmds**. The current prefix is **&** or @Taplium#5881.");
                });
        }


        private void RegisterPurgeCommand()
        {
            commands.CreateCommand("purge")
                .Do(async (e) =>
                {
                    Message[] messagesToDelete;
                    messagesToDelete = await e.Channel.DownloadMessages(100);

                    await e.Channel.DeleteMessages(messagesToDelete);
                });
        }


        private void Log(object sender, LogMessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }

}