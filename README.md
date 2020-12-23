# StoneTest - WebCrawler

This is a project created to show one of the possible ways to recover content from the internet in an automated way.

For this example, our target will be the intriguing and random phrases from the website["Lero Lero"](https://lerolero.com/) in an automated way so that in a second step it is submitted to the site ["mothereff.in"](https://mothereff.in/byte-counter#) to count the content in bytes;

In a complementary way, we can also appreciate the architecture used preserving the contexts of individual responsibilities and abstracting functions and elements of common access.

We also have an interesting approach to using Selenium in a current version and also exploring the performance gain by using the ["--Headless"](https://developers.google.com/web/updates/2017/04/headless-chrome) function.

Some calculations and functions for managing volume of data and flow of control of system execution

Enjoy ^.^

## Prerequisites
- Google Chome **v87^** *[Check your Version](https://www.google.com/chrome/update/)*
- Dot Net Core **V3.1^**
- [googledriver.exe **v87**](https://sites.google.com/a/chromium.org/chromedriver/downloads) *(Already available in the project inside the "driver" folder of the webDriver project)*
   - ### Nuget Packages
     - Selenium.WebDriver **v3.141.0**
     - Microsoft.Extensions.Configuration.Json **v5.0.0**
     - MatthiWare.CommandLineParser **v0.5.0**


## Usage / Execution

A. I suggest running via Debug in Visual Studio. Thus, the folder for generating the final file will be **"c:\temp"**

B. You can also run through the prompt and explore passing parameters via the command line. We have an automatic little helper to command line arguments when execute without it.

1. Passing just the only **(mandatory)** folder path **parameter**. This run will generate the output file in the "c: \ Temp2" folder with the default buffer size of 1MB and the default File size of 100MB
```bash
[..\bin\Release]\StoneTest.Crawler.App.exe -dp "c:\temp2"
```

2. Also passing a **numeric and positive(mega bytes)** limit size of the generated buffer. This form will override the default value of 1MB
```bash
[..\bin\Release]\StoneTest.Crawler.App.exe -dp "c:\temp2" -bl 5
```

3. Passing **numeric and positive(mega bytes)** buffer value and also the file size value. Default file size is 100MB
```bash
[..\bin\Release]\StoneTest.Crawler.App.exe -dp "c:\temp2" -bl 5 -fsl 50
```

4. Optionally, it is also possible to eliminate the **"Headless"** configuration so that it is possible enjoy the routine interacting with the web page when the browser being launched on the screen and monitor at each iteration.
```bash
[..\bin\Release]\StoneTest.Crawler.App.exe "c:\temp2 10 50 0"
```
### Usage Help
![Print_1229](https://user-images.githubusercontent.com/33078483/103040889-8b80ac80-4553-11eb-809d-699ec683a718.png).

## Project Status
This project is available for suggestions for evolution and correction. Aims to introduce myself to the "Stone" development team. I still haven't been able to explore all the features I would like, but I really hope you enjoy it.