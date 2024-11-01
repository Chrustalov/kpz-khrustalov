﻿using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using ok.ViewModels;

namespace ok;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
      .UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

    builder.Services.AddSingleton<BookPageViewModel>()
                    .AddTransient<AddBookPageViewModel>();
	
  	return builder.Build();
	}
}
