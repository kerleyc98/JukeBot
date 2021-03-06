﻿using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Discord;
using Discord.Commands;
using JukeBot.Services;

namespace JukeBot.Modules {
    public class ImageModule : ModuleBase<ICommandContext> {
        private readonly ImageService _Service;

        public ImageModule( ImageService Service ) {
            _Service = Service;
        }

        [Command( "jpg", RunMode = RunMode.Async )]
        [Summary( "Searches Google Images for the first image that matches" )]
        public async Task JPG( [Remainder] String SearchTerm ) {
            await Log( new LogMessage( LogSeverity.Info, "JPG", $"Searching for {SearchTerm}.JPG" ) );
            await ReplyAsync( await _Service.GoogleImageSearch( SearchTerm ) );
        }

        [Command( "gif", RunMode = RunMode.Async )]
        [Alias( "g" )]
        [Summary( "Searches Tenor for the first gif that matches" )]
        public async Task GIF( [Remainder] String SearchTerm ) {
            await Log( new LogMessage( LogSeverity.Info, "GIF", $"Searching for {SearchTerm}.GIF" ) );
            await ReplyAsync( await _Service.TenorSearch( SearchTerm ) );
        }

        public static Task Log( LogMessage msg ) {
            Console.WriteLine( msg.ToString() );
            return Task.CompletedTask;
        }
    }
}
